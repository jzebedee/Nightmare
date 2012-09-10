
namespace xBot.Patchables
{
    public enum Pointers : uint //4.0.1b
    {
        pDevicePtr1 = 0x971094, //4.0.1b unchanged
        pDevicePtr2 = 0x27B4, //4.0.1b unchanged
        DXEndsceneVFT = 0xA8, //4.0.1b unchanged

        Target = 0x0042A3E0, //4.0.1b | CGGameUI__Target | found from TargetNearestEnemy
        CTM = 0x001C7840, //4.0.1b | CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x0041EA00, //4.0.1b | GetCorpsePosition

        GetObjectNameFromGuid = 0x001F8FC0, //4.0.1b | GetObjectNameFromGuid
        GetLockRecord = 0x001A7550, //4.0.1b | CGGameObject_C__GetLockRecord

        UnitReaction = 0x001C4BC0, //4.0.1b | CGUnit_C__UnitReaction

        InGameByte = 0x00981692, //4.0.1b | CGGameUI__EnterWorld | .text:0042CFB7 mov byte_981692, 1

        CastSpell = 0x0040EEB0, //4.0.1b | Spell_C_CastSpell

        GetSpellPowerCost = 0x00408C60, //4.0.1b | GetSpellPowerCostByID

        Intersect = 0x00281C80, //4.0.1b | CGWorldFrame__Intersect

        ControlBit_This = 0x008266B8, //4.0.1b unchanged | referenced in CGInputControl__GetActive
        SetControlBit = 0x00051360, //4.0.1b | CGInputControl__SetControlBit
        UnsetControlBit = 0x00051670, //4.0.1b | CGInputControl__UnsetControlBit
        UpdatePlayer = 0x00052F50, //4.0.1b | CGInputControl__UpdatePlayer

        SendJump = 0x001BE660, //4.0.1b

        GetSpellCooldownProxy = 0x00408A90, //4.0.1b | Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x008B7BF8, //4.0.1b unchanged | can be found in MoveForwardStart/etc commands
        PerformanceCounter = 0x003CF120, //4.0.1b

        ItemCache_GetInfoBlockByID = 0x00062BA0, //4.0.1b | DBItemCache_GetInfoBlockByID
        ItemCache_This = 0x00881688, //4.0.1b unchanged | found in the call to DBItemCache_GetInfoBlockByID from CGItem_C__GetItemEntry

        DoString = 0x00395960, //4.0.1b | FrameScript__Execute
        RegisterFunction = 0x003947B0, //4.0.1b | FrameScript_RegisterFunction
        UnregisterFunction = 0x003947F0, //4.0.1b | FrameScript_UnregisterFunction
        GetTop = 0x000346F0, //4.0.1b | FrameScript_GetTop
        ToLString = 0x00034C00, //4.0.1b | FrameScript_ToLString

        TextHookA = 0x000BA864, //4.0.1b linear discovery, above .text:000BAAC0 sub_BAAC0 <-- called by AssertAndCrash
        TextHookB = 0x000BA885, //4.0.1b next to A

        EnumVisibleObjects = 0x00093A10, //4.0.1b | EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x00093C90, //4.0.1b | ClntObjMgrObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x00003480, //4.0.1b | ClntObjMgrGetActivePlayerObj

        ClntObjMgrGetMapID = 0x00092880, //4.0.1b | ClntObjMgrGetMapID
    }
}