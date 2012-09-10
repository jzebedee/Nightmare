using System;
using System.Runtime.InteropServices;
using Bloodstream.Patchables;
using Utils;

namespace Bloodstream.Lib.Injection
{
    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    delegate int EndSceneDelegate(IntPtr instance);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dLuaWrapper(uint pLuaState);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dRegisterFunction(string name, uint pFunction);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dUnregisterFunction(uint pFunction);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dDoString(
        [MarshalAs(UnmanagedType.LPStr)] string Lua,
        [MarshalAs(UnmanagedType.LPStr)] string LuaFilename,
        int LuaState);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dGetTop(uint pLuaState); //int __cdecl FrameScript_GetTop(int a1)

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate string dToLString(uint pLuaState, int index, int length); //int __cdecl FrameScript_ToLString(int a1, int a2, int a3)

    //bool __cdecl Spell_C__GetSpellCooldown_Proxy(int a1, int a2, int a3, int a4, int a5, int a6)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate bool dGetSpellCooldown_Proxy(uint spellID, int unk_zero_one, ref uint Duration, ref uint Start, ref uint Enable, int unk_zero);

    //int __cdecl Spell_C_CastSpell(int a1, int a2, int a3, int a4, int a5, int a6, int a7, int a8)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dCastSpell(int spellID, int unk_zero1, ulong targetGUID, int unk, int unk_zero2, int unk_zero3, int unk_zero4, int unk_zero5);

    //int __usercall GetSpellPowerCostByID<eax>(int a1<ebp>, int a2, int a3)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dGetSpellPowerCost(IntPtr pSpellRow, IntPtr pLocalPlayer);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dInteract(uint instance);

    //bool __thiscall CGGameObject_C__ContainsLoot(int this, int a2)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    unsafe delegate bool dContainsLoot(uint pThis, int* pRet);

    //__int64 __cdecl CGObject_C__GetTransportGuid()
    //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    //internal delegate ulong dGetTransportGuid(uint pThis);

    //char *__cdecl GetObjectNameFromGuid(int a1)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate sbyte* dGetObjectNameFromGuid(ulong* pGUID);

    //int __thiscall CGGameObject_C__GetLockRecord(int this)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dGetLockRecord(uint pThis);

    //int __thiscall DBItemCache_GetInfoBlockByID(void *this, int a2, int a3, int a4, int a5, int a6)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    unsafe delegate uint dGetInfoBlockByID(IntPtr pThis, uint itemID, uint* unkRef, void* Callback, int unk_zero2, int guess_SignalCallback);

    //int __cdecl GetItemIDByName(const char *Str)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dGetItemIDByName(
            [MarshalAs(UnmanagedType.LPStr)]string str
        );

    //int __thiscall DBItemCacheEntry_Populate(void *this)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dPopulate(uint pCacheEntry);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    delegate bool dIntersect(ref Vector3D End, ref Vector3D Start, ref Vector3D Intersect, ref float Completion, uint Flags, IntPtr pOpt);

    //int __cdecl GetCorpsePosition(int a1)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    unsafe delegate Vector3D* dGetCorpsePosition(ulong* pGUID);

    //0x5CD930 signed int __thiscall CGUnit_C__UnitReaction(int this, int a2)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate int dGetUnitReaction(uint pThis, uint pUnit);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dTarget(UInt64 GUID);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate bool dCTM(uint pMe, uint CTM_Type, ref ulong InteractGUID, ref Vector3D Location, float Precision);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dSetControlBit(uint pThis, uint flag, uint LastHardwareAction);

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dUnsetControlBit(uint pThis, uint flag, uint LastHardwareAction, int unk_zero);

    //int __thiscall CGInputControl__UpdatePlayer(void *this, int a2, int a3)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate uint dUpdatePlayer(uint pThis, uint timeStamp, int forceUpdate);

    //char __cdecl GetComboPointsForGuid(__int64 a1, char a2)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate byte dGetComboPointsForGuid(ulong GUID, byte unk_param);

    //int __thiscall SendJump(int this, int a2)
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    delegate int dSendJump(uint pThis, uint LastHardwareAction);

    //unsigned __int64 __cdecl PerformanceCounter()
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate ulong dPerformanceCounter();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate Int32 dEnumVisibleObjects(IntPtr callback, WoWObjectType filter);

    //void *__cdecl ClntObjMgrGetObjectPtr(WGUID guid, TypeMask mask, char *file, int line)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dClntObjMgrGetObjectPtr(ulong guid, int filter);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dClntObjMgrGetActivePlayerObj(); //this basically does a ClntObjMgrGetObjectPtr(ClntObjMgrGetActivePlayer());

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int EnumVisibleObjectsCallback(ulong guid, int filter);

    //int __cdecl ClntObjMgrGetMapID()
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate int dClntObjMgrGetMapID();

    //int __cdecl Spell_GetSpellEffectID(unsigned int spellID, unsigned int effectIndex)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    delegate uint dGetSpellEffectID(uint spellID, uint effectIndex);

    //bool __cdecl CGGameUI__OnTerrainClick(TerrainClick *)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.I1)]
    delegate bool dOnTerrainClick(IntPtr pTerrainClickStruct);
}