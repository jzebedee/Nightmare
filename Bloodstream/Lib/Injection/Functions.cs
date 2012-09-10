using System;
using System.Runtime.InteropServices;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;

namespace Bloodstream.Lib.Injection
{
    internal static class Functions
    {
        static Functions()
        {
            System.Diagnostics.Debug.Assert(!AppDomain.CurrentDomain.IsDefaultAppDomain(), "Lib.Injection.Functions reached its ctor in a non-MeatHook appdomain!");
        }

        static T WrapFunction<T>(Pointers p) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer(((IntPtr)p).Rebase(), typeof(T)) as T;
        }

        internal static dRegisterFunction f_RegisterFunction = WrapFunction<dRegisterFunction>(Pointers.RegisterFunction);
        internal static dUnregisterFunction f_UnregisterFunction = WrapFunction<dUnregisterFunction>(Pointers.UnregisterFunction);

        internal static dDoString f_DoString = WrapFunction<dDoString>(Pointers.DoString);
        internal static dGetTop f_GetTop = WrapFunction<dGetTop>(Pointers.GetTop);
        internal static dToLString f_ToLString = WrapFunction<dToLString>(Pointers.ToLString);

        internal static dCastSpell f_CastSpell = WrapFunction<dCastSpell>(Pointers.CastSpell);

        internal static dGetSpellPowerCost f_GetSpellPowerCost = WrapFunction<dGetSpellPowerCost>(Pointers.GetSpellPowerCost);

        internal static dGetSpellCooldown_Proxy f_GetSpellCooldown_Proxy = WrapFunction<dGetSpellCooldown_Proxy>(Pointers.GetSpellCooldownProxy);

        internal static dGetObjectNameFromGuid f_GetObjectNameFromGuid = WrapFunction<dGetObjectNameFromGuid>(Pointers.GetObjectNameFromGuid);

        internal static dGetLockRecord f_GetLockRecord = WrapFunction<dGetLockRecord>(Pointers.GetLockRecord);

        internal static dGetInfoBlockByID f_GetInfoBlockByID = WrapFunction<dGetInfoBlockByID>(Pointers.GetItemCacheEntry);
        internal static dPopulate f_Populate = WrapFunction<dPopulate>(Pointers.ItemCacheEntry_Populate);

        internal static dGetItemIDByName f_GetItemIDByName = WrapFunction<dGetItemIDByName>(Pointers.GetItemIDByName);

        internal static dIntersect f_Intersect = WrapFunction<dIntersect>(Pointers.Intersect);

        internal static dGetCorpsePosition f_GetCorpsePosition = WrapFunction<dGetCorpsePosition>(Pointers.GetCorpsePosition);

        internal static dGetUnitReaction f_GetUnitReaction = WrapFunction<dGetUnitReaction>(Pointers.UnitReaction);

        internal static dTarget f_Target = WrapFunction<dTarget>(Pointers.Target);

        internal static dGetComboPointsForGuid f_GetComboPointsForGuid = WrapFunction<dGetComboPointsForGuid>(Pointers.GetComboPointsForGuid);

        internal static dCTM f_CTM = WrapFunction<dCTM>(Pointers.CTM);

        internal static dSetControlBit f_SetControlBit = WrapFunction<dSetControlBit>(Pointers.SetControlBit);
        internal static dUnsetControlBit f_UnsetControlBit = WrapFunction<dUnsetControlBit>(Pointers.UnsetControlBit);
        internal static dUpdatePlayer f_UpdatePlayer = WrapFunction<dUpdatePlayer>(Pointers.UpdatePlayer);
        internal static dSendJump f_SendJump = WrapFunction<dSendJump>(Pointers.SendJump);

        internal static dPerformanceCounter f_PerformanceCounter = WrapFunction<dPerformanceCounter>(Pointers.PerformanceCounter);

        internal static dEnumVisibleObjects f_EnumVisibleObjects = WrapFunction<dEnumVisibleObjects>(Pointers.EnumVisibleObjects);
        internal static dClntObjMgrGetObjectPtr f_ClntObjMgrGetObjectPtr = WrapFunction<dClntObjMgrGetObjectPtr>(Pointers.ClntObjMgrGetObjectPtr);
        internal static dClntObjMgrGetActivePlayerObj f_ClntObjMgrGetActivePlayerObj = WrapFunction<dClntObjMgrGetActivePlayerObj>(Pointers.ClntObjMgrGetActivePlayerObj);

        internal static dClntObjMgrGetMapID f_ClntObjMgrGetMapID = WrapFunction<dClntObjMgrGetMapID>(Pointers.ClntObjMgrGetMapID);

        internal static dGetSpellEffectID f_GetSpellEffectID = WrapFunction<dGetSpellEffectID>(Pointers.GetSpellEffectID);

        internal static dOnTerrainClick f_OnTerrainClick = WrapFunction<dOnTerrainClick>(Pointers.OnTerrainClick);
    }
}