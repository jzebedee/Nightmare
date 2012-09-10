namespace Bloodstream.Patchables //4.0.3a
{
    public enum Pointers : uint
    {
        Target = 0x004321C0, //4.0.3a | CGGameUI__Target | found from TargetNearestEnemy
        CTM = 0x001C9E80, //4.0.3a | CGPlayer_C__ClickToMove
        GetCorpsePosition = 0x00426760, //4.0.3a | GetCorpsePosition

        GetObjectNameFromGuid = 0x001FB8E0, //4.0.3a | GetObjectNameFromGuid
        GetLockRecord = 0x001A99C0, //4.0.3a | CGGameObject_C__GetLockRecord

        UnitReaction = 0x001C7480, //4.0.3a | CGUnit_C__UnitReaction

        InGameByte = 0x0099069A, //4.0.3a | CGGameUI__EnterWorld | mov InGameByte, 1

        CastSpell = 0x00416CA0, //4.0.3a | Spell_C_CastSpell

        GetSpellPowerCost = 0x00410AF0, //4.0.3a | GetSpellPowerCostByID

        Intersect = 0x002851E0, //4.0.3a | CGWorldFrame__Intersect

        ControlBit_This = 0x008346D8, //4.0.3a | referenced in CGInputControl__GetActive
        SetControlBit = 0x00052080, //4.0.3a | CGInputControl__SetControlBit
        UnsetControlBit = 0x00052390, //4.0.3a | CGInputControl__UnsetControlBit
        UpdatePlayer = 0x00053C70, //4.0.3a | CGInputControl__UpdatePlayer

        SendJump = 0x001D2F20, //4.0.3a | callsite in lua_JumpOrAscendStart

        GetComboPointsForGuid = 0x004220A0, //4.0.3a | GetComboPointsForGuid

        GetSpellCooldownProxy = 0x00410920, //4.0.3a | Spell_C__GetSpellCooldown_Proxy, args derived from call in lua_GetSpellCooldown

        LastHardwareAction = 0x008C5F78, //4.0.3a | can be found in Lua_MoveForwardStart/etc commands | mov esi, LastHardwareAction
        PerformanceCounter = 0x003D6D80, //4.0.3a | PerformanceCounter

        GetItemIDByName = 0x001B11C0, //4.0.3a

        Callback_ItemInfoReceivedSignaller = 0x0041F140, //4.0.3a | callsite of DBItemCache_GetInfoBlockByID in lua_GetItemInfo
        ItemCacheEntry_Populate = 0x0008DA60, //4.0.3a | DBItemCacheEntry_Populate
        ItemCache_GetInfoBlockByID = 0x000636A0, //4.0.3a | DBItemCache_GetInfoBlockByID
        ItemCache_This = 0x0088F790, //4.0.3a | found in the call to DBItemCache_GetInfoBlockByID from CGItem_C__GetItemEntry

        OnTerrainClick = 0x00438DF0, //4.0.3a | CGGameUI__OnTerrainClick

        LuaState = 0x0097F280, //4.0.3a
        DoString = 0x0039D8C0, //4.0.3a | FrameScript__Execute
        RegisterFunction = 0x0039C710, //4.0.3a | FrameScript__RegisterFunction
        UnregisterFunction = 0x0039C750, //4.0.3a | FrameScript__UnregisterFunction
        GetTop = 0x00035300, //4.0.3a | FrameScript__GetTop
        ToLString = 0x00035810, //4.0.3a | FrameScript__ToLString

        TextHookA = 0x000BB7C4, //4.0.3a | nothing specific to these, just find something to hijack in .text
        TextHookB = 0x000BB7CA, //4.0.3a | (I'm using garbage around alignment directives)

        EnumVisibleObjects = 0x00094960, //4.0.3a | EnumVisibleObjects
        ClntObjMgrGetObjectPtr = 0x00094BE0, //4.0.3a | ClntObjMgrGetObjectPtr
        ClntObjMgrGetActivePlayerObj = 0x00003580, //4.0.3a | ClntObjMgrGetActivePlayerObj

        ClntObjMgrGetMapID = 0x00093A30, //4.0.3a | ClntObjMgrGetMapID

        GetSpellEffectID = 0x0009B8D0, //4.0.3a | Spell_GetSpellEffectID
    }
    public enum VFTIndices
    {
        DXEndScene = 0xA8, //4.0.3a
        Interact = 46, //4.0.3a
        //GetTransportGUID = 16, //4.0.3a | Unit
        ContainsLoot = 24, //4.0.3 | GameObject
    }
}