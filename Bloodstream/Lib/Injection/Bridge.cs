//#define DEBUG_EVENTS
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Bloodstream.Interfaces;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;
using Utils;
using Utils.Extensions.Strings;

namespace Bloodstream.Lib.Injection
{
    internal partial class Bridge : IDisposable
    {
        internal Bridge()
        {
            f_LuaWrapper = MeatWrap;
            f_EventWrapper = EventWrap;
            f_HandleTerrainClick = HandleTerrainClick;
        }
        ~Bridge()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (InGame)
            {
                DoString(string.Format("{0}:UnregisterAllEvents()", LuaEventFrameName), "dispose.lua");

                Functions.f_UnregisterFunction(WowMemory.ModuleBase + (int)Pointers.TextHookA);
                Functions.f_UnregisterFunction(WowMemory.ModuleBase + (int)Pointers.TextHookB);
            }

            if (WrapperHook != null)
                WrapperHook.Dispose();

            if (EventHook != null)
                EventHook.Dispose();

            if (TerrainClickHook != null)
                TerrainClickHook.Dispose();
        }

        internal void Initialize()
        {
            if (TerrainClickHook == null)
            {
                TerrainClickHook = new Hooker(WowMemory.ModuleBase + (int)Pointers.OnTerrainClick, f_HandleTerrainClick.TargetAddress());
                TerrainClickHook.Hook();
            }

            if (WrapperHook == null)
            {
                WrapperHook = new Hooker(WowMemory.ModuleBase + (int)Pointers.TextHookA, f_LuaWrapper.TargetAddress());
                WrapperHook.Hook();
            }

            Functions.f_RegisterFunction(LuaWrapperName, WowMemory.ModuleBase + (int)Pointers.TextHookA);

            if (EventHook == null)
            {
                EventHook = new Hooker(WowMemory.ModuleBase + (int)Pointers.TextHookB, f_EventWrapper.TargetAddress());
                EventHook.Hook();
            }

            Functions.f_RegisterFunction(LuaEventHandlerName, WowMemory.ModuleBase + (int)Pointers.TextHookB);

            DoString(string.Format(
                //"if {0}~=nil then " +
                        " CreateFrame(\"Frame\", \"{0}\", nil); " +
                        "{0}:SetScript(\"OnEvent\", " +
                        " function(self, event, ...) " +
                        "  {1}(event, ...); " +
                        " end " +
                        "); "// +
                //"end "
                //"{0}:RegisterAllEvents();"
                        , LuaEventFrameName, LuaEventHandlerName
                    ), "BridgeInitialize.lua", DoStringOptions.Sync);

            foreach (var oldEvent in RegisteredEvents)
                RegisterEvent(oldEvent);
        }

        #region Handle Terrain Click
        Hooker TerrainClickHook;

        static dOnTerrainClick f_HandleTerrainClick;
        bool HandleTerrainClick(IntPtr pstruct)
        {
            Show("Click at: {0}", Location.FromVector(SMemory.Read<Vector3D>((uint)(pstruct + 8))));

            try
            {
                while (!TerrainClickHook.Unhook())
                    continue;
                return Functions.f_OnTerrainClick(pstruct);
            }
            finally
            {
                TerrainClickHook.Hook();
            }
        }
        #endregion

        /*internal bool GetSpellCooldown(uint spellID, out uint Start, out uint Duration, out uint Enable)
        {
            return false;
            //   return (bool)Core.RunPulse(() => Functions.f_GetSpellCooldown_Proxy(spellID, 0, pDuration, pStart, pEnable));
        }*/

        internal void Interact(uint pWowObj)
        {
            var pInteract = SMemory.GetVFT(pWowObj, (int)VFTIndices.Interact);
            var dInteract = Marshal.GetDelegateForFunctionPointer((IntPtr)pInteract, typeof(dInteract)) as dInteract;
            if (dInteract == null) return;

            Core.RunPulse(() => dInteract(pWowObj));
        }

        /*internal ulong GetTransportGUID(uint pWowObj)
        {
            var pGetTransportGuid = SMemory.GetVFT(pWowObj, (int)VFTIndices.GetTransportGUID);
            var f_GetTransportGuid = Marshal.GetDelegateForFunctionPointer((IntPtr)pGetTransportGuid, typeof(dGetTransportGuid)) as dGetTransportGuid;
            if (f_GetTransportGuid == null) return 0;

            return (ulong)Core.RunPulse(() => f_GetTransportGuid(pWowObj));
        }*/

        internal unsafe bool ContainsLoot(uint pWowObj)
        {
            var pContainsLoot = SMemory.GetVFT(pWowObj, (int)VFTIndices.ContainsLoot);
            var dContainsLoot = Marshal.GetDelegateForFunctionPointer((IntPtr)pContainsLoot, typeof(dContainsLoot)) as dContainsLoot;
            if (dContainsLoot == null) return false;

            int zero = 0;
            return dContainsLoot(pWowObj, &zero);
        }

        internal byte GetComboPointsForGuid(ulong GUID, byte param = 0)
        {
            return Core.RunPulse<byte>(() => Functions.f_GetComboPointsForGuid(GUID, param));
        }

        internal unsafe string GetObjectNameFromGuid(UInt64 GUID)
        {
            ulong* pGUID = &GUID;
            return Core.RunPulse<string>(() => new string(Functions.f_GetObjectNameFromGuid(pGUID)));
        }

        internal int GetItemIDByName(string name)
        {
            return Core.RunPulse<int>(() => Functions.f_GetItemIDByName(name));
        }

        internal uint GetLockRecord(uint pThis)
        {
            return Core.RunPulse<uint>(() => Functions.f_GetLockRecord(pThis));
        }

        internal unsafe uint GetInfoBlockByID_Internal(uint itemID)
        {
            uint pSomeRef = 0;
            return Functions.f_GetInfoBlockByID(((IntPtr)Pointers.ItemCache_This).Rebase(), itemID, &pSomeRef, Pointers.Callback_ItemInfoReceivedSignaller.ToRebasedPointer(), 0, 1);
        }

        internal unsafe ItemCacheEntry GetInfoBlockByID(uint itemID)
        {
            using (var handle = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                EventHandler<LuaEventArgs>
                    handler_GetItemInfoReceived = (event_name, args) => handle.Set();

                using (var events = new Events())
                {
                    events.GetItemInfoReceived += handler_GetItemInfoReceived;

                    bool tried = false;

                GetBlock:
                    var pICE = Core.RunPulse<uint>(() => GetInfoBlockByID_Internal(itemID));
                    if (pICE > 0)
                    {
                        Functions.f_Populate(pICE);
                        return SMemory.Read<ItemCacheEntry>(pICE);
                    }
                    else if (!tried)
                    {
                        handle.WaitOne();

                        tried = true;
                        goto GetBlock;
                    }

                    return null;
                }
            }
        }

        internal bool Traceline(ILocation Start, ILocation End, out ILocation intersect_result, out float intersect_distance, WorldHitFlags Flags)
        {
            Vector3D sectResult;

            var ret = Traceline(Start.ToVector<Vector3D>(), End.ToVector<Vector3D>(), out sectResult, out intersect_distance, (uint)Flags);

            intersect_result = Location.FromVector(sectResult);

            return ret;
        }
        internal bool Traceline(Vector3D Start, Vector3D End, out Vector3D Intersect, out float Completion, uint Flags)
        {
            var in_Intersect = default(Vector3D);
            var in_Completion = 1.0f;

            var ret = Core.RunPulse<bool>(() => Functions.f_Intersect(ref End, ref Start, ref in_Intersect, ref in_Completion, Flags, IntPtr.Zero));

            Intersect = in_Intersect;
            Completion = in_Completion;

            return ret;
        }

        internal unsafe ILocation GetCorpsePosition(ulong GUID)
        {
            return Location.FromVector(Core.RunPulse<Vector3D>(() => *Functions.f_GetCorpsePosition((ulong*)GUID)));
        }
        internal int GetUnitReaction(uint pThis, uint pUnit)
        {
            return Core.RunPulse<int>(() => Functions.f_GetUnitReaction(pThis, pUnit));
        }

        //Action<>
        internal void CastSpell(int ID, ulong TargetGUID)
        {
            Core.RunPulse(() => Functions.f_CastSpell(ID, 0, TargetGUID, 0, 0, 0, 0, 0));
        }

        internal int GetSpellPowerCost(IntPtr pSpellRow)
        {
            return Core.RunPulse<int>(() => Functions.f_GetSpellPowerCost(pSpellRow, (IntPtr)WowBase.Instance.Me.Pointer));
        }

        internal void Target(UInt64 GUID)
        {
            Core.RunPulse(() => Functions.f_Target(GUID));
        }

        internal void ClickToMove(ILocation movePos = null, ClickToMoveAction clickType = ClickToMoveAction.Move, UInt64 interactGuid = 0, float precision = 2.5F)
        {
            ClickToMove((uint)clickType, movePos != null ? movePos.ToVector<Vector3D>() : default(Vector3D), interactGuid, precision);
        }
        void ClickToMove(uint ClickType, Vector3D clickPos, UInt64 interactGuid, float precision)
        {
            Core.RunPulse(() => Functions.f_CTM(WowBase.Instance.Me.Pointer, ClickType, ref interactGuid, ref clickPos, precision));
        }

        internal void StopMove()
        {
            ClickToMove(clickType: ClickToMoveAction.ConstantFace);
            UnsetControlBits(MovementDirection.Forward, MovementDirection.Backward, MovementDirection.JumpAscend, MovementDirection.StrafeLeft, MovementDirection.StrafeRight);
        }
        internal void StopTurn()
        {
            UnsetControlBits(MovementDirection.TurnLeft, MovementDirection.TurnRight);
        }

        internal void SetControlBits(params MovementDirection[] Flags)
        {
            SetControlBits(Flags.Cast<uint>().ToArray());
        }
        internal void SetControlBits(params uint[] flags)
        {
            Core.RunPulse(() =>
            {
                foreach (var flag in flags)
                    Functions.f_SetControlBit(ControlBit_This, flag, LastHardwareAction);
                UpdatePlayer();
            });
        }
        internal void UnsetControlBits(params MovementDirection[] Flags)
        {
            UnsetControlBits(Flags.Cast<uint>().ToArray());
        }
        internal void UnsetControlBits(params uint[] flags)
        {
            Core.RunPulse(() =>
            {
                foreach (var flag in flags)
                    Functions.f_UnsetControlBit(ControlBit_This, flag, LastHardwareAction, 0);
                UpdatePlayer();
            });
        }
        void UpdatePlayer()
        {
            Functions.f_UpdatePlayer(ControlBit_This, LastHardwareAction, 1);
        }

        internal void SendJump()
        {
            Core.RunPulse(() => Functions.f_SendJump(WowBase.Instance.Me.Pointer, LastHardwareAction));
        }

        internal int GetMapID()
        {
            return Core.RunPulse<int>(() => Functions.f_ClntObjMgrGetMapID());
        }

        internal Patchables.DBC.SpellEffectEntry GetSpellEffectID(uint spellID, uint effectIndex)
        {
            var addr = Core.RunPulse<uint>(() => Functions.f_GetSpellEffectID(spellID, effectIndex));
            if (addr > 0)
                return SMemory.Read<Patchables.DBC.SpellEffectEntry>(addr);

            return default(Patchables.DBC.SpellEffectEntry);
        }

        internal ulong PerformanceCounter()
        {
            return Functions.f_PerformanceCounter();
        }

        #region Property Reads
        private static uint ControlBit_This
        {
            get
            {
                return WowMemory.Read<uint>((uint)Pointers.ControlBit_This);
            }
        }

        private static uint LastHardwareAction
        {
            get
            {
                return WowMemory.Read<uint>((uint)Pointers.LastHardwareAction);
            }
        }

        internal static bool InGame
        {
            get
            {
                return WowMemory.Read<byte>((uint)Pointers.InGameByte) == 1;
            }
        }
        #endregion

        internal void Show(string msg, params object[] args)
        {
            if (msg == null)
                return;
            DoString("if print~=nil then print(\"" + string.Format(msg, args).AddSlashes() + "\") end");
        }
    }
}