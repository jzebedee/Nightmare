using System;
using System.Runtime.InteropServices;

namespace xBot.Patchables
{
    public enum Pointers : uint
    {
        pDevicePtr1 = 0x970F94, //4.0.1
        pDevicePtr2 = 0x27B4, //4.0.1
        DXEndsceneVFT = 0xA8, //4.0.1

        Target = 0x0042A060, //4.0.1 | CGGameUI__Target | found from TargetNearestEnemy
        CTM = 0x001C7E20, //4.0.1 | CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x0041E630, //4.0.1 | GetCorpsePosition

        GetObjectNameFromGuid = 0x001F9520, //4.0.1 | GetObjectNameFromGuid
        GetLockRecord = 0x001A79D0, //4.0.1 | CGGameObject_C__GetLockRecord

        UnitReaction = 0x001C51A0, //4.0.1 | CGUnit_C__UnitReaction

        InGameByte = 0x00981692, //4.0.1 | CGGameUI__EnterWorld | .text:0042CB97 mov byte_981692, 1

        TraceLine = 0x002BC060, //4.0.1

        ControlBit_This = 0x008266B8, //4.0.1 | referenced in CGInputControl__GetActive
        SetControlBit = 0x00051340, //4.0.1 | CGInputControl__SetControlBit
        UnsetControlBit = 0x00051650, //4.0.1 | CGInputControl__UnsetControlBit
        UpdatePlayer = 0x00052F30, //4.0.1 | CGInputControl__UpdatePlayer

            SendJump = 0x0072EB80,

        GetSpellCooldownProxy = 0x00408950, //4.0.1 | Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x008B7BF8, //4.0.1 can be found in MoveForwardStart/etc commands
        PerformanceCounter = 0x003CF020, //4.0.1 

        ItemCache_GetInfoBlockByID = 0x00062B00, //4.0.1 | DBItemCache_GetInfoBlockByID
        ItemCache_This = 0x00881688, //4.0.1 | found in the call to DBItemCache_GetInfoBlockByID from CGItem_C__GetItemEntry

        DoString = 0x003958F0, //4.0.1 | FrameScript__Execute
        RegisterFunction = 0x00394740, //4.0.1 | FrameScript_RegisterFunction
        UnregisterFunction = 0x00394780, //4.0.1 | FrameScript_UnregisterFunction
        GetTop = 0x000346E0, //4.0.1 | FrameScript_GetTop
        ToLString = 0x00034BF0, //4.0.1 | FrameScript_ToLString

        TextHookA = 0x00BAA94, //4.0.1 linear discovery, above .text:000BAAC0 sub_BAAC0 <-- called by AssertAndCrash
        TextHookB = 0x00BAAB5, //4.0.1 next to A

        EnumVisibleObjects = 0x00093BB0, //4.0.1 | EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x00093E30, //4.0.1 | ClntObjMgrObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x000034A0, //4.0.1 | ClntObjMgrGetActivePlayerObj
    }
}