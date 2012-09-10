namespace xBot.Patchables //4.0.3
{
    public enum Pointers : uint
    {
        Target = 0x00432130, //4.0.3 | CGGameUI__Target | found from TargetNearestEnemy
        CTM = 0x001C9D90, //4.0.3 | CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x004266B0, //4.0.3 | GetCorpsePosition

        GetObjectNameFromGuid = 0x001FB800, //4.0.3 | GetObjectNameFromGuid
        GetLockRecord = 0x001A9930, //4.0.3 | CGGameObject_C__GetLockRecord

        UnitReaction = 0x001C7390, //4.0.3 | CGUnit_C__UnitReaction

        InGameByte = 0x0098F69A, //4.0.3 | CGGameUI__EnterWorld | .text:0042CFB7 mov byte_981692, 1

        CastSpell = 0x00416AD0, //4.0.3 | Spell_C_CastSpell

        GetSpellPowerCost = 0x00410920, //4.0.3 | GetSpellPowerCostByID

        Intersect = 0x00285110, //4.0.3 | CGWorldFrame__Intersect

        ControlBit_This = 0x008336D8, //4.0.3 unchanged | referenced in CGInputControl__GetActive
        SetControlBit = 0x00052030, //4.0.3 | CGInputControl__SetControlBit
        UnsetControlBit = 0x00052340, //4.0.3 | CGInputControl__UnsetControlBit
        UpdatePlayer = 0x00053C20, //4.0.3 | CGInputControl__UpdatePlayer

        SendJump = 0x001BE660, //NOT UPDATED SINCE 3.3.5a

        GetSpellCooldownProxy = 0x00410750, //4.0.3 | Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x008C4F78, //4.0.3 | can be found in MoveForwardStart/etc commands
        PerformanceCounter = 0x003D6C00, //4.0.3

        ItemCache_GetInfoBlockByID = 0x000635D0, //4.0.3 | DBItemCache_GetInfoBlockByID
        ItemCache_This = 0x0088E790, //4.0.3 | found in the call to DBItemCache_GetInfoBlockByID from CGItem_C__GetItemEntry

        DoString = 0x0039D7F0, //4.0.3 | FrameScript__Execute
        RegisterFunction = 0x0039C640, //4.0.3 | FrameScript_RegisterFunction
        UnregisterFunction = 0x0039C680, //4.0.3 | FrameScript_UnregisterFunction
        GetTop = 0x000352C0, //4.0.3 | FrameScript_GetTop
        ToLString = 0x000357D0, //4.0.3 | FrameScript_ToLString

        TextHookA = 0x000BB896, //4.0.3 linear discovery, above .text:000BAAC0 sub_BAAC0 <-- called by AssertAndCrash
        TextHookB = 0x000BB8B4, //4.0.3 next to A

        EnumVisibleObjects = 0x00094A50, //4.0.3 | EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x00094CD0, //4.0.3 | ClntObjMgrObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x00003550, //4.0.3 | ClntObjMgrGetActivePlayerObj

        ClntObjMgrGetMapID = 0x00093B20, //4.0.3 | ClntObjMgrGetMapID
    }
    public enum VFTIndices
    {
        DXEndScene = 0xA8, //4.0.3
        Interact = 46, //4.0.3 Lecht
        GetTransportGUID = 16, //4.0.3 | Object
        ContainsLoot = 24, //4.0.3 | GameObject
    }
}