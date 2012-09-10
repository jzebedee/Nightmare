namespace Bloodstream.Patchables //13623
{
    public enum Pointers : uint
    {
        Target = 0x00437B50, //13623 | CGGameUI__Target | found from TargetNearestEnemy
        CTM = 0x001C8590, //13623 | CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x0042BDF0, //13623 | GetCorpsePosition

        GetObjectNameFromGuid = 0x00200040, //13623 | GetObjectNameFromGuid
        GetLockRecord = 0x001A7440, //13623 | CGGameObject_C__GetLockRecord

        UnitReaction = 0x001C56C0, //13623 | CGUnit_C__UnitReaction

        InGameByte = 0x0099C69A, //13623 | CGGameUI__EnterWorld | mov InGameByte, 1

        CastSpell = 0x0041B110, //13623 | Spell_C_CastSpell

        GetSpellPowerCost = 0x00415BA0, //13623 | GetSpellPowerCostByID

        Intersect = 0x00289790, //13623 | CGWorldFrame__Intersect

        ControlBit_This = 0x00C3D700, //13623 | referenced in CGInputControl__GetActive
        SetControlBit = 0x00052C50, //13623 | CGInputControl__SetControlBit
        UnsetControlBit = 0x00052F60, //13623 | CGInputControl__UnsetControlBit
        UpdatePlayer = 0x000547F0, //13623 | CGInputControl__UpdatePlayer

        SendJump = 0x001D1380, //13623 | callsite in lua_JumpOrAscendStart

        GetComboPointsForGuid = 0x0042CE60, //13623 | GetComboPointsForGuid

        GetSpellCooldownProxy = 0x004159D0, //13623 | Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x008D1280, //13623 | can be found in Lua_MoveForwardStart/etc commands | mov esi, LastHardwareAction
        PerformanceCounter = 0x003DBC30, //13623 | PerformanceCounter

        GetItemIDByName = 0x001AEBF0, //13623 | GetItemIDByName

        Callback_ItemInfoReceivedSignaller = 0x004244C0, //13623 | callsite of DBItemCache_GetInfoBlockByID in lua_GetItemInfo
        ItemCacheEntry_Populate = 0x0008F070, //13623 | DBItemCacheEntry_Populate
        GetItemCacheEntry = 0x00064890, //13623 | WowClientDB2__ItemRecSparse_C__GetRow
        ItemCache_This = 0x00898A40, //13623 | found in the call to DBItemCache_GetInfoBlockByID from CGItem_C__GetItemEntry

        OnTerrainClick = 0x0043E6E0, //13623 | CGGameUI__OnTerrainClick

        LuaState = 0x0098B768, //13623
        DoString = 0x003A2620, //13623 | FrameScript__Execute
        RegisterFunction = 0x003A1470, //13623 | FrameScript__RegisterFunction
        UnregisterFunction = 0x003A14B0, //13623 | FrameScript__UnregisterFunction
        GetTop = 0x00035E10, //13623 | FrameScript__GetTop
        ToLString = 0x00036320, //13623 | FrameScript__ToLString

        TextHookA = 0x00238728, //13623 | nothing specific to these, just find something to hijack in .text
        TextHookB = 0x00238754, //13623 | (I'm using garbage around alignment directives)

        EnumVisibleObjects = 0x000961B0, //13623 | EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x00096430, //13623 | ClntObjMgrGetObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x00003520, //13623 | ClntObjMgrGetActivePlayerObj

        ClntObjMgrGetMapID = 0x00095270, //13623 | ClntObjMgrGetMapID

        GetSpellEffectID = 0x0009D210, //13623 | Spell_GetSpellEffectID
    }
    public enum VFTIndices
    {
        DXEndScene = 0xA8, //4.0.3a
        Interact = 45, //13623
        //GetTransportGUID = 16, //4.0.3a | Unit
        ContainsLoot = 24, //13623 | GameObject
    }
}