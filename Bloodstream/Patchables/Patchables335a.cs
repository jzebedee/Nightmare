using System;
using System.Runtime.InteropServices;

namespace MeatHook.Patchables
{
    public enum Pointers : uint //3.3.5a
    {
        pDevicePtr1 = 0xC5DF88, //
        pDevicePtr2 = 0x397C, //unchanged

        Target = 0x00524BF0, //CGGameUI__Target
        CTM = 0x00727400, //CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x0051F430, //GetCorpsePosition

        GetObjectNameFromGuid = 0x0074D750, //GetObjectNameFromGuid
        GetLockRecord = 0x0070EF30, //CGGameObject_C__GetLockRecord

        UnitReaction = 0x007251C0, //CGUnit_C__UnitReaction

        InGameByte = 0x00BD0792,    //3.3.5a | CGGameUI__EnterWorld | .text:00528027 mov     byte_BD0792, 1

        TraceLine = 0x007A3B70,

        ControlBit_This = 0x00C24954, //referenced in CGInputControl__GetActive
        SetControlBit = 0x005FA170, //CGInputControl__SetControlBit
        UnsetControlBit = 0x005FA450, //CGInputControl__UnsetControlBit
        UpdatePlayer = 0x005FBBC0, //CGInputControl__UpdatePlayer

        SendJump = 0x0072EB80,

        GetSpellCooldownProxy = 0x00809000, //Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x00B499A4, //
        Timestamp = 0x00B1D618, //unchanged
        /*
.text:009D0F87                 align 10h
.text:009D0F90                 push    offset aBlizzardMopaq ; "Blizzard::Mopaq"
.text:009D0F95                 call    sub_433830
.text:009D0F9A                 add     esp, 4
.text:009D0F9D                 mov     ecx, offset unk_B1D5E8
.text:009D0FA2                 call    sub_8777F0
.text:009D0FA7                 xor     eax, eax
.text:009D0FA9                 push    offset loc_9DD560
.text:009D0FAE                 mov     dword_B1D610, eax
.text:009D0FB3                 mov     dword_B1D61C, eax
.text:009D0FB8                 mov     dword_B1D618, eax
.text:009D0FBD                 mov     dword_B1D614, 400000h
.text:009D0FC7                 call    _atexit
.text:009D0FCC                 pop     ecx
.text:009D0FCD                 retn
        */

        ItemCache_GetInfoBlockByID = 0x0067CA30, //DBItemCache_GetInfoBlockByID
        ItemCache_This = 0x00C5D828, //

        DoString = 0x00819210, //FrameScript__Execute
        RegisterFunction = 0x00817F90, //FrameScript_RegisterFunction
        GetTop = 0x0084DBD0, //FrameScript_GetTop
        ToLString = 0x0084E0E0, //FrameScript_ToLString

        TextHookA = 0x00772A74,
        TextHookB = 0x00772AB5,
        LuaStatePtr = 0x00D3F78C, //referenced by GetLuaState

        EnumVisibleObjects = 0x004D4B30, //EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x004D4DB0, //ClntObjMgrObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x004038F0, //ClntObjMgrGetActivePlayerObj
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3D
    {
        public Single X, Y, Z;
        public Vector3D(Single X, Single Y, Single Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }

    public enum ClickToMoveAction : uint
    {
        FaceTarget = 0x1,
        Face = 0x2,
        Stop = 0x3,
        Move = 0x4,
        NpcInteract = 0x5,
        Loot = 0x6,
        ObjInteract = 0x7,
        FaceOther = 0x8,
        Skin = 0x9,
        AttackPosition = 0xA,
        AttackGuid = 0xB,
        ConstantFace = 0xC,
        None = 0xD,
        Attack = 0x10,
        Idle = 0x13,
    }

    public enum WoWObjectType : uint
    {
        Object = 0,
        Item = 1,
        Container = 2,
        Unit = 3,
        Player = 4,
        GameObject = 5,
        DynamicObject = 6,
        Corpse = 7,
        AiGroup = 8,
        AreaTrigger = 9
    }
}
