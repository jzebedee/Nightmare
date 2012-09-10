namespace xWow.Lib.Pointers
{
    public static class Misc
    {
        //3.3.3a 00C51EB0 pet spellbook | comes after localplayer spellbook block
        public const uint
            DescriptorOffset = 0x8,             //3.3.2
            EntryOffset = 0xC,                  //3.3.3a
            GuidOffset = 0x30,                  //3.3.2
            TypeOffset = 0x14,                  //3.3.2
            InGame = 0xC4EB2A;                  //3.3.3a
    }
    public static class LocalPlayer
    {
        public const uint
            SpellBookCount = 0xC52EB0,  //3.3.3a | sub_731A90 | .text:00731AB4 cmp     eax, dword_C52EB0
            SpellBook = 0xC50EA0,       //3.3.3a | CGSpellBook__UpdateSpells | .text:00733212 mov     ecx, dword_C50E9C[ecx*4]
            RuneTypes = 0xC5421C,       //3.3.3a
            ComboPoints = 0xC4EBE5;     //3.3.3a
    }
    public static class Zone
    {
        public const uint
            ZoneText = 0xC4EB18, //3.3.3
            SubZoneText = 0x00C4EB1C, //3.3.3
            WorldMap = 0x00B22298; //3.3.3
    }
    public static class Player
    {
        public const uint
            PlayerNameCachePointer = 0x00CF8C50; //3.3.2
    }
    public static class UnitAuras
    { //3.3
        public const uint
            AURA_COUNT_1 = 0xDD0,
            AURA_COUNT_2 = 0xC54,
            AURA_TABLE_1 = 0xC50,
            AURA_TABLE_2 = 0xC58,
            AURA_SIZE = 0x18,
            AURA_SPELL_ID = 0x8;
    }
    public static class Position
    {
        public const int
            RotationOffset = 0x7A8, //Updated for 3.2
            OBJECT_LOCATION_X = 0xE8, //Updated for 3.2
            OBJECT_LOCATION_Y = 0xEC, //Updated for 3.2
            OBJECT_LOCATION_Z = 0xF0; //Updated for 3.2
    }

    public static class WDB
    {
        public const uint
            DBItemCache = 0xBB91C0; //3.3.3a
    }
    public static class DBC
    {
        public const uint
            ClientDBRegisterBase = 0x0066A970,
            ClientDBSpellUnpack = 0x4CB1A0;
    }

    public enum ClientDb
    {
        Achievement = 0x000000EB, // 0x00A8BA04
        Achievement_Criteria = 0x000000EC, // 0x00A8BA28
        Achievement_Category = 0x000000ED, // 0x00A8BA4C
        AnimationData = 0x000000EE, // 0x00A8BA70
        AreaGroup = 0x000000EF, // 0x00A8BA94
        AreaPOI = 0x000000F0, // 0x00A8BAB8
        AreaTable = 0x000000F1, // 0x00A8BADC
        AreaTrigger = 0x000000F2, // 0x00A8BB00
        AttackAnimKits = 0x000000F3, // 0x00A8BB24
        AttackAnimTypes = 0x000000F4, // 0x00A8BB48
        AuctionHouse = 0x000000F5, // 0x00A8BB6C
        BankBagSlotPrices = 0x000000F6, // 0x00A8BB90
        BannedAddOns = 0x000000F7, // 0x00A8BBB4
        BarberShopStyle = 0x000000F8, // 0x00A8BBD8
        BattlemasterList = 0x000000F9, // 0x00A8BBFC
        CameraShakes = 0x000000FA, // 0x00A8BC20
        Cfg_Categories = 0x000000FB, // 0x00A8BC44
        Cfg_Configs = 0x000000FC, // 0x00A8BC68
        CharBaseInfo = 0x000000FD, // 0x00A8BC8C
        CharHairGeosets = 0x000000FE, // 0x00A8BCB0
        CharSections = 0x000000FF, // 0x00A8BCD4
        CharStartOutfit = 0x00000100, // 0x00A8BCF8
        CharTitles = 0x00000101, // 0x00A8BD1C
        CharacterFacialHairStyles = 0x00000102, // 0x00A8BD40
        ChatChannels = 0x00000103, // 0x00A8BD64
        ChatProfanity = 0x00000104, // 0x00A8BD88
        ChrClasses = 0x00000105, // 0x00A8BDAC
        ChrRaces = 0x00000106, // 0x00A8BDD0
        CinematicCamera = 0x00000107, // 0x00A8BDF4
        CinematicSequences = 0x00000108, // 0x00A8BE18
        CreatureDisplayInfo = 0x00000109, // 0x00A8BE60
        CreatureDisplayInfoExtra = 0x0000010A, // 0x00A8BE3C
        CreatureFamily = 0x0000010B, // 0x00A8BE84
        CreatureModelData = 0x0000010C, // 0x00A8BEA8
        CreatureMovementInfo = 0x0000010D, // 0x00A8BECC
        CreatureSoundData = 0x0000010E, // 0x00A8BEF0
        CreatureSpellData = 0x0000010F, // 0x00A8BF14
        CreatureType = 0x00000110, // 0x00A8BF38
        CurrencyTypes = 0x00000111, // 0x00A8BF5C
        CurrencyCategory = 0x00000112, // 0x00A8BF80
        DanceMoves = 0x00000113, // 0x00A8BFA4
        DeathThudLookups = 0x00000114, // 0x00A8BFC8
        DestructibleModelData = 0x00000115, // 0x00A8C034
        DungeonEncounter = 0x00000116, // 0x00A8C058
        DungeonMap = 0x00000117, // 0x00A8C07C
        DungeonMapChunk = 0x00000118, // 0x00A8C0A0
        DurabilityCosts = 0x00000119, // 0x00A8C0C4
        DurabilityQuality = 0x0000011A, // 0x00A8C0E8
        Emotes = 0x0000011B, // 0x00A8C10C
        EmotesText = 0x0000011C, // 0x00A8C178
        EmotesTextData = 0x0000011D, // 0x00A8C130
        EmotesTextSound = 0x0000011E, // 0x00A8C154
        EnvironmentalDamage = 0x0000011F, // 0x00A8C19C
        Exhaustion = 0x00000120, // 0x00A8C1C0
        Faction = 0x00000121, // 0x00A8C208
        FactionGroup = 0x00000122, // 0x00A8C1E4
        FactionTemplate = 0x00000123, // 0x00A8C22C
        FileData = 0x00000124, // 0x00A8C250
        FootprintTextures = 0x00000125, // 0x00A8C274
        FootstepTerrainLookup = 0x00000126, // 0x00A8C298
        GameObjectArtKit = 0x00000127, // 0x00A8C2BC
        GameObjectDisplayInfo = 0x00000128, // 0x00A8C2E0
        GameTables = 0x00000129, // 0x00A8C304
        GameTips = 0x0000012A, // 0x00A8C328
        GemProperties = 0x0000012B, // 0x00A8C34C
        GlyphProperties = 0x0000012C, // 0x00A8C370
        GlyphSlot = 0x0000012D, // 0x00A8C394
        GMSurveyAnswers = 0x0000012E, // 0x00A8C3B8
        GMSurveyCurrentSurvey = 0x0000012F, // 0x00A8C3DC
        GMSurveyQuestions = 0x00000130, // 0x00A8C400
        GMSurveySurveys = 0x00000131, // 0x00A8C424
        GMTicketCategory = 0x00000132, // 0x00A8C448
        GroundEffectDoodad = 0x00000133, // 0x00A8C46C
        GroundEffectTexture = 0x00000134, // 0x00A8C490
        gtBarberShopCostBase = 0x00000135, // 0x00A8C4B4
        gtCombatRatings = 0x00000136, // 0x00A8C4D8
        gtChanceToMeleeCrit = 0x00000137, // 0x00A8C4FC
        gtChanceToMeleeCritBase = 0x00000138, // 0x00A8C520
        gtChanceToSpellCrit = 0x00000139, // 0x00A8C544
        gtChanceToSpellCritBase = 0x0000013A, // 0x00A8C568
        gtNPCManaCostScaler = 0x0000013B, // 0x00A8C58C
        gtOCTClassCombatRatingScalar = 0x0000013C, // 0x00A8C5B0
        gtOCTRegenHP = 0x0000013D, // 0x00A8C5D4
        gtOCTRegenMP = 0x0000013E, // 0x00A8C5F8
        gtRegenHPPerSpt = 0x0000013F, // 0x00A8C61C
        gtRegenMPPerSpt = 0x00000140, // 0x00A8C640
        HelmetGeosetVisData = 0x00000141, // 0x00A8C664
        HolidayDescriptions = 0x00000142, // 0x00A8C688
        HolidayNames = 0x00000143, // 0x00A8C6AC
        Holidays = 0x00000144, // 0x00A8C6D0
        Item = 0x00000145, // 0x00A8C6F4
        ItemBagFamily = 0x00000146, // 0x00A8C718
        ItemClass = 0x00000147, // 0x00A8C73C
        ItemCondExtCosts = 0x00000148, // 0x00A8C760
        ItemDisplayInfo = 0x00000149, // 0x00A8C784
        ItemExtendedCost = 0x0000014A, // 0x00A8C7A8
        ItemGroupSounds = 0x0000014B, // 0x00A8C7CC
        ItemLimitCategory = 0x0000014C, // 0x00A8C7F0
        ItemPetFood = 0x0000014D, // 0x00A8C814
        ItemPurchaseGroup = 0x0000014E, // 0x00A8C838
        ItemRandomProperties = 0x0000014F, // 0x00A8C85C
        ItemRandomSuffix = 0x00000150, // 0x00A8C880
        ItemSet = 0x00000151, // 0x00A8C8A4
        ItemSubClass = 0x00000152, // 0x00A8C8EC
        ItemSubClassMask = 0x00000153, // 0x00A8C8C8
        ItemVisualEffects = 0x00000154, // 0x00A8C910
        ItemVisuals = 0x00000155, // 0x00A8C934
        LanguageWords = 0x00000156, // 0x00A8C958
        Languages = 0x00000157, // 0x00A8C97C
        LfgDungeonExpansion = 0x00000158, // 0x00A8C9A0
        LfgDungeonGroup = 0x00000159, // 0x00A8C9C4
        LfgDungeons = 0x0000015A, // 0x00A8C9E8
        Light = 0x0000015B, // 0x00A71F30
        LightFloatBand = 0x0000015C, // 0x00A71EE8
        LightIntBand = 0x0000015D, // 0x00A71EC4
        LightParams = 0x0000015E, // 0x00A71F0C
        LightSkybox = 0x0000015F, // 0x00A71EA0
        LiquidType = 0x00000160, // 0x00A8CA0C
        LiquidMaterial = 0x00000161, // 0x00A8CA30
        LoadingScreens = 0x00000162, // 0x00A8CA54
        LoadingScreenTaxiSplines = 0x00000163, // 0x00A8CA78
        Lock = 0x00000164, // 0x00A8CA9C
        LockType = 0x00000165, // 0x00A8CAC0
        MailTemplate = 0x00000166, // 0x00A8CAE4
        Map = 0x00000167, // 0x00A8CB08
        MapDifficulty = 0x00000168, // 0x00A8CB2C
        Material = 0x00000169, // 0x00A8CB50
        Movie = 0x0000016A, // 0x00A8CB74
        MovieFileData = 0x0000016B, // 0x00A8CB98
        MovieVariation = 0x0000016C, // 0x00A8CBBC
        NameGen = 0x0000016D, // 0x00A8CBE0
        NPCSounds = 0x0000016E, // 0x00A8CC04
        NamesProfanity = 0x0000016F, // 0x00A8CC28
        NamesReserved = 0x00000170, // 0x00A8CC4C
        OverrideSpellData = 0x00000171, // 0x00A8CC70
        Package = 0x00000172, // 0x00A8CC94
        PageTextMaterial = 0x00000173, // 0x00A8CCB8
        PaperDollItemFrame = 0x00000174, // 0x00A8CCDC
        ParticleColor = 0x00000175, // 0x00A8CD00
        PetPersonality = 0x00000176, // 0x00A8CD24
        PowerDisplay = 0x00000177, // 0x00A8CD48
        PvpDifficulty = 0x00000178, // 0x00A8CD6C
        QuestFactionReward = 0x00000179, // 0x00A8CD90
        QuestInfo = 0x0000017A, // 0x00A8CDB4
        QuestSort = 0x0000017B, // 0x00A8CDD8
        QuestXP = 0x0000017C, // 0x00A8CDFC
        Resistances = 0x0000017D, // 0x00A8CE20
        RandPropPoints = 0x0000017E, // 0x00A8CE44
        ScalingStatDistribution = 0x0000017F, // 0x00A8CE68
        ScalingStatValues = 0x00000180, // 0x00A8CE8C
        ScreenEffect = 0x00000181, // 0x00A8CEB0
        ServerMessages = 0x00000182, // 0x00A8CED4
        SheatheSoundLookups = 0x00000183, // 0x00A8CEF8
        SkillCostsData = 0x00000184, // 0x00A8CF1C
        SkillLineAbility = 0x00000185, // 0x00A8CF40
        SkillLineCategory = 0x00000186, // 0x00A8CF64
        SkillLine = 0x00000187, // 0x00A8CF88
        SkillRaceClassInfo = 0x00000188, // 0x00A8CFAC
        SkillTiers = 0x00000189, // 0x00A8CFD0
        SoundAmbience = 0x0000018A, // 0x00A8CFF4
        SoundEmitters = 0x0000018B, // 0x00A8D03C
        SoundEntries = 0x0000018C, // 0x00A8D018
        SoundProviderPreferences = 0x0000018D, // 0x00A8D060
        SoundSamplePreferences = 0x0000018E, // 0x00A8D084
        SoundWaterType = 0x0000018F, // 0x00A8D0A8
        SpamMessages = 0x00000190, // 0x00A8D0CC
        SpellCastTimes = 0x00000191, // 0x00A8D0F0
        SpellCategory = 0x00000192, // 0x00A8D114
        SpellChainEffects = 0x00000193, // 0x00A8D138
        Spell = 0x00000194, // 0x00A8D378
        SpellDescriptionVariables = 0x00000195, // 0x00A8D15C
        SpellDifficulty = 0x00000196, // 0x00A8D180
        SpellDispelType = 0x00000197, // 0x00A8D1A4
        SpellDuration = 0x00000198, // 0x00A8D1C8
        SpellEffectCameraShakes = 0x00000199, // 0x00A8D1EC
        SpellFocusObject = 0x0000019A, // 0x00A8D210
        SpellIcon = 0x0000019B, // 0x00A8D234
        SpellItemEnchantment = 0x0000019C, // 0x00A8D258
        SpellItemEnchantmentCondition = 0x0000019D, // 0x00A8D27C
        SpellMechanic = 0x0000019E, // 0x00A8D2A0
        SpellMissile = 0x0000019F, // 0x00A8D2C4
        SpellMissileMotion = 0x000001A0, // 0x00A8D2E8
        SpellRadius = 0x000001A1, // 0x00A8D30C
        SpellRange = 0x000001A2, // 0x00A8D330
        SpellRuneCost = 0x000001A3, // 0x00A8D354
        SpellShapeshiftForm = 0x000001A4, // 0x00A8D39C
        SpellVisual = 0x000001A5, // 0x00A8D450
        SpellVisualEffectName = 0x000001A6, // 0x00A8D3C0
        SpellVisualKit = 0x000001A7, // 0x00A8D3E4
        SpellVisualKitAreaModel = 0x000001A8, // 0x00A8D408
        SpellVisualKitModelAttach = 0x000001A9, // 0x00A8D42C
        StableSlotPrices = 0x000001AA, // 0x00A8D474
        Stationery = 0x000001AB, // 0x00A8D498
        StringLookups = 0x000001AC, // 0x00A8D4BC
        SummonProperties = 0x000001AD, // 0x00A8D4E0
        Talent = 0x000001AE, // 0x00A8D504
        TalentTab = 0x000001AF, // 0x00A8D528
        TaxiNodes = 0x000001B0, // 0x00A8D54C
        TaxiPath = 0x000001B1, // 0x00A8D594
        TaxiPathNode = 0x000001B2, // 0x00A8D570
        TeamContributionPoints = 0x000001B3, // 0x00A8D5B8
        TerrainType = 0x000001B4, // 0x00A8D5DC
        TerrainTypeSounds = 0x000001B5, // 0x00A8D600
        TotemCategory = 0x000001B6, // 0x00A8D624
        TransportAnimation = 0x000001B7, // 0x00A8D648
        TransportPhysics = 0x000001B8, // 0x00A8D66C
        TransportRotation = 0x000001B9, // 0x00A8D690
        UISoundLookups = 0x000001BA, // 0x00A8D6B4
        UnitBlood = 0x000001BB, // 0x00A8D6FC
        UnitBloodLevels = 0x000001BC, // 0x00A8D6D8
        Vehicle = 0x000001BD, // 0x00A8D720
        VehicleSeat = 0x000001BE, // 0x00A8D744
        VehicleUIIndicator = 0x000001BF, // 0x00A8D768
        VehicleUIIndSeat = 0x000001C0, // 0x00A8D78C
        VocalUISounds = 0x000001C1, // 0x00A8D7B0
        WMOAreaTable = 0x000001C2, // 0x00A8D7D4
        WeaponImpactSounds = 0x000001C3, // 0x00A8D7F8
        WeaponSwingSounds2 = 0x000001C4, // 0x00A8D81C
        Weather = 0x000001C5, // 0x00A8D840
        WorldMapArea = 0x000001C6, // 0x00A8D864
        WorldMapTransforms = 0x000001C7, // 0x00A8D8D0
        WorldMapContinent = 0x000001C8, // 0x00A8D888
        WorldMapOverlay = 0x000001C9, // 0x00A8D8AC
        WorldSafeLocs = 0x000001CA, // 0x00A8D8F4
        WorldStateUI = 0x000001CB, // 0x00A8D918
        ZoneIntroMusicTable = 0x000001CC, // 0x00A8D93C
        ZoneMusic = 0x000001CD, // 0x00A8D960
        WorldStateZoneSounds = 0x000001CE, // 0x00A8D984
        WorldChunkSounds = 0x000001CF, // 0x00A8D9A8
        SoundEntriesAdvanced = 0x000001D0, // 0x00A8D9CC
        ObjectEffect = 0x000001D1, // 0x00A8D9F0
        ObjectEffectGroup = 0x000001D2, // 0x00A8DA14
        ObjectEffectModifier = 0x000001D3, // 0x00A8DA38
        ObjectEffectPackage = 0x000001D4, // 0x00A8DA5C
        ObjectEffectPackageElem = 0x000001D5, // 0x00A8DA80
        SoundFilter = 0x000001D6, // 0x00A8DAA4
        SoundFilterElem = 0x000001D7, // 0x00A8DAC8
    }

    public static class UnitName
    {
        public const uint
            ObjectName1 = 0x1A4,
            ObjectName2 = 0x90,
            UnitName1 = 0x964,
            UnitName2 = 0x5C;
    }


    #region Patchable enums
    // Descriptors: 0x00AD9F58
    enum ObjectFields
    {
        GUID = 0x0,
        TYPE = 0x2,
        ENTRY = 0x3,
        SCALE_X = 0x4,
        PADDING = 0x5,
        //TOTAL_OBJECT_FIELDS = 0x5
    };
    // Descriptors: 0x00AD9FF8
    enum ItemFields
    {
        OWNER = 0x18,
        CONTAINED = 0x20,
        CREATOR = 0x28,
        GIFTCREATOR = 0x30,
        STACK_COUNT = 0x38,
        DURATION = 0x3C,
        SPELL_CHARGES = 0x40,
        FLAGS = 0x54,
        ENCHANTMENT_1_1 = 0x58,
        ENCHANTMENT_1_3 = 0x60,
        ENCHANTMENT_2_1 = 0x64,
        ENCHANTMENT_2_3 = 0x6C,
        ENCHANTMENT_3_1 = 0x70,
        ENCHANTMENT_3_3 = 0x78,
        ENCHANTMENT_4_1 = 0x7C,
        ENCHANTMENT_4_3 = 0x84,
        ENCHANTMENT_5_1 = 0x88,
        ENCHANTMENT_5_3 = 0x90,
        ENCHANTMENT_6_1 = 0x94,
        ENCHANTMENT_6_3 = 0x9C,
        ENCHANTMENT_7_1 = 0xA0,
        ENCHANTMENT_7_3 = 0xA8,
        ENCHANTMENT_8_1 = 0xAC,
        ENCHANTMENT_8_3 = 0xB4,
        ENCHANTMENT_9_1 = 0xB8,
        ENCHANTMENT_9_3 = 0xC0,
        ENCHANTMENT_10_1 = 0xC4,
        ENCHANTMENT_10_3 = 0xCC,
        ENCHANTMENT_11_1 = 0xD0,
        ENCHANTMENT_11_3 = 0xD8,
        ENCHANTMENT_12_1 = 0xDC,
        ENCHANTMENT_12_3 = 0xE4,
        PROPERTY_SEED = 0xE8,
        RANDOM_PROPERTIES_ID = 0xEC,
        DURABILITY = 0xF0,
        MAXDURABILITY = 0xF4,
        CREATE_PLAYED_TIME = 0xF8,
        PAD = 0xFC,
        //TOTAL_ITEM_FIELDS = 0x26
    };
    // Descriptors: 0x00AD9FBC
    enum ContainerFields
    {
        NUM_SLOTS = 0x18,
        ALIGN_PAD = 0x1C,
        SLOT_1 = 0x20,
        //TOTAL_CONTAINER_FIELDS = 0x3
    };
    // Descriptors: 0x00ADBB58
    enum DynamicObjectFields
    {
        CASTER = 0x6,
        BYTES = 0x8,
        SPELLID = 0x9,
        RADIUS = 0xA,
        CASTTIME = 0xB,
        //TOTAL_DYNAMICOBJECT_FIELDS = 0x5
    };
    // Descriptors: 0x00ADBBC0
    enum CorpseFields
    {
        OWNER = 0x6,
        PARTY = 0x8,
        DISPLAY_ID = 0xA,
        ITEM = 0xB,
        BYTES_1 = 0x1E,
        BYTES_2 = 0x1F,
        GUILD = 0x20,
        FLAGS = 0x21,
        DYNAMIC_FLAGS = 0x22,
        PAD = 0x23,
        //TOTAL_CORPSE_FIELDS = 0xA
    };
    // Descriptors: 0x00ADA2F0
    enum UnitFields
    {
        CHARM = 0x18,
        SUMMON = 0x20,
        CRITTER = 0x28,
        CHARMEDBY = 0x30,
        SUMMONEDBY = 0x38,
        CREATEDBY = 0x40,
        TARGET = 0x48,
        CHANNEL_OBJECT = 0x50,
        CHANNEL_SPELL = 0x58,
        BYTES_0 = 0x5C,
        HEALTH = 0x60,
        POWER1 = 0x64,
        POWER2 = 0x68,
        POWER3 = 0x6C,
        POWER4 = 0x70,
        POWER5 = 0x74,
        POWER6 = 0x78,
        POWER7 = 0x7C,
        MAXHEALTH = 0x80,
        MAXPOWER1 = 0x84,
        MAXPOWER2 = 0x88,
        MAXPOWER3 = 0x8C,
        MAXPOWER4 = 0x90,
        MAXPOWER5 = 0x94,
        MAXPOWER6 = 0x98,
        MAXPOWER7 = 0x9C,
        POWER_REGEN_FLAT_MODIFIER = 0xA0,
        POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = 0xBC,
        LEVEL = 0xD8,
        FACTIONTEMPLATE = 0xDC,
        VIRTUAL_ITEM_SLOT_ID = 0xE0,
        FLAGS = 0xEC,
        FLAGS_2 = 0xF0,
        AURASTATE = 0xF4,
        BASEATTACKTIME = 0xF8,
        RANGEDATTACKTIME = 0x100,
        BOUNDINGRADIUS = 0x104,
        COMBATREACH = 0x108,
        DISPLAYID = 0x10C,
        NATIVEDISPLAYID = 0x110,
        MOUNTDISPLAYID = 0x114,
        MINDAMAGE = 0x118,
        MAXDAMAGE = 0x11C,
        MINOFFHANDDAMAGE = 0x120,
        MAXOFFHANDDAMAGE = 0x124,
        BYTES_1 = 0x128,
        PETNUMBER = 0x12C,
        PET_NAME_TIMESTAMP = 0x130,
        PETEXPERIENCE = 0x134,
        PETNEXTLEVELEXP = 0x138,
        DYNAMIC_FLAGS = 0x13C,
        MOD_CAST_SPEED = 0x140,
        CREATED_BY_SPELL = 0x144,
        NPC_FLAGS = 0x148,
        NPC_EMOTESTATE = 0x14C,
        STAT0 = 0x150,
        STAT1 = 0x154,
        STAT2 = 0x158,
        STAT3 = 0x15C,
        STAT4 = 0x160,
        POSSTAT0 = 0x164,
        POSSTAT1 = 0x168,
        POSSTAT2 = 0x16C,
        POSSTAT3 = 0x170,
        POSSTAT4 = 0x174,
        NEGSTAT0 = 0x178,
        NEGSTAT1 = 0x17C,
        NEGSTAT2 = 0x180,
        NEGSTAT3 = 0x184,
        NEGSTAT4 = 0x188,
        RESISTANCES = 0x18C,
        RESISTANCEBUFFMODSPOSITIVE = 0x1A8,
        RESISTANCEBUFFMODSNEGATIVE = 0x1C4,
        BASE_MANA = 0x1E0,
        BASE_HEALTH = 0x1E4,
        BYTES_2 = 0x1E8,
        ATTACK_POWER = 0x1EC,
        ATTACK_POWER_MODS = 0x1F0,
        ATTACK_POWER_MULTIPLIER = 0x1F4,
        RANGED_ATTACK_POWER = 0x1F8,
        RANGED_ATTACK_POWER_MODS = 0x1FC,
        RANGED_ATTACK_POWER_MULTIPLIER = 0x200,
        MINRANGEDDAMAGE = 0x204,
        MAXRANGEDDAMAGE = 0x208,
        POWER_COST_MODIFIER = 0x20C,
        POWER_COST_MULTIPLIER = 0x228,
        MAXHEALTHMODIFIER = 0x244,
        HOVERHEIGHT = 0x248,
        //PADDING = 0x24C,
        //TOTAL_UNIT_FIELDS = 0x59
    };
    enum PlayerFields
    {
        DUEL_ARBITER = 0x250,
        FLAGS = 0x258,
        GUILDID = 0x25C,
        GUILDRANK = 0x260,
        BYTES = 0x264,
        BYTES_2 = 0x268,
        BYTES_3 = 0x26C,
        DUEL_TEAM = 0x270,
        GUILD_TIMESTAMP = 0x274,
        QUEST_LOG_1_1 = 0x278,
        QUEST_LOG_1_2 = 0x27C,
        QUEST_LOG_1_3 = 0x280,
        QUEST_LOG_1_4 = 0x288,
        QUEST_LOG_2_1 = 0x28C,
        QUEST_LOG_2_2 = 0x290,
        QUEST_LOG_2_3 = 0x294,
        QUEST_LOG_2_5 = 0x29C,
        QUEST_LOG_3_1 = 0x2A0,
        QUEST_LOG_3_2 = 0x2A4,
        QUEST_LOG_3_3 = 0x2A8,
        QUEST_LOG_3_5 = 0x2B0,
        QUEST_LOG_4_1 = 0x2B4,
        QUEST_LOG_4_2 = 0x2B8,
        QUEST_LOG_4_3 = 0x2BC,
        QUEST_LOG_4_5 = 0x2C4,
        QUEST_LOG_5_1 = 0x2C8,
        QUEST_LOG_5_2 = 0x2CC,
        QUEST_LOG_5_3 = 0x2D0,
        QUEST_LOG_5_5 = 0x2D8,
        QUEST_LOG_6_1 = 0x2DC,
        QUEST_LOG_6_2 = 0x2E0,
        QUEST_LOG_6_3 = 0x2E4,
        QUEST_LOG_6_5 = 0x2EC,
        QUEST_LOG_7_1 = 0x2F0,
        QUEST_LOG_7_2 = 0x2F4,
        QUEST_LOG_7_3 = 0x2F8,
        QUEST_LOG_7_5 = 0x300,
        QUEST_LOG_8_1 = 0x304,
        QUEST_LOG_8_2 = 0x308,
        QUEST_LOG_8_3 = 0x30C,
        QUEST_LOG_8_5 = 0x314,
        QUEST_LOG_9_1 = 0x318,
        QUEST_LOG_9_2 = 0x31C,
        QUEST_LOG_9_3 = 0x320,
        QUEST_LOG_9_5 = 0x328,
        QUEST_LOG_10_1 = 0x32C,
        QUEST_LOG_10_2 = 0x330,
        QUEST_LOG_10_3 = 0x334,
        QUEST_LOG_10_5 = 0x33C,
        QUEST_LOG_11_1 = 0x340,
        QUEST_LOG_11_2 = 0x344,
        QUEST_LOG_11_3 = 0x348,
        QUEST_LOG_11_5 = 0x350,
        QUEST_LOG_12_1 = 0x354,
        QUEST_LOG_12_2 = 0x358,
        QUEST_LOG_12_3 = 0x35C,
        QUEST_LOG_12_5 = 0x364,
        QUEST_LOG_13_1 = 0x368,
        QUEST_LOG_13_2 = 0x36C,
        QUEST_LOG_13_3 = 0x370,
        QUEST_LOG_13_5 = 0x378,
        QUEST_LOG_14_1 = 0x37C,
        QUEST_LOG_14_2 = 0x380,
        QUEST_LOG_14_3 = 0x384,
        QUEST_LOG_14_5 = 0x38C,
        QUEST_LOG_15_1 = 0x390,
        QUEST_LOG_15_2 = 0x394,
        QUEST_LOG_15_3 = 0x398,
        QUEST_LOG_15_5 = 0x3A0,
        QUEST_LOG_16_1 = 0x3A4,
        QUEST_LOG_16_2 = 0x3A8,
        QUEST_LOG_16_3 = 0x3AC,
        QUEST_LOG_16_5 = 0x3B4,
        QUEST_LOG_17_1 = 0x3B8,
        QUEST_LOG_17_2 = 0x3BC,
        QUEST_LOG_17_3 = 0x3C0,
        QUEST_LOG_17_5 = 0x3C8,
        QUEST_LOG_18_1 = 0x3CC,
        QUEST_LOG_18_2 = 0x3D0,
        QUEST_LOG_18_3 = 0x3D4,
        QUEST_LOG_18_5 = 0x3DC,
        QUEST_LOG_19_1 = 0x3E0,
        QUEST_LOG_19_2 = 0x3E4,
        QUEST_LOG_19_3 = 0x3E8,
        QUEST_LOG_19_5 = 0x3F0,
        QUEST_LOG_20_1 = 0x3F4,
        QUEST_LOG_20_2 = 0x3F8,
        QUEST_LOG_20_3 = 0x3FC,
        QUEST_LOG_20_5 = 0x404,
        QUEST_LOG_21_1 = 0x408,
        QUEST_LOG_21_2 = 0x40C,
        QUEST_LOG_21_3 = 0x410,
        QUEST_LOG_21_5 = 0x418,
        QUEST_LOG_22_1 = 0x41C,
        QUEST_LOG_22_2 = 0x420,
        QUEST_LOG_22_3 = 0x424,
        QUEST_LOG_22_5 = 0x42C,
        QUEST_LOG_23_1 = 0x430,
        QUEST_LOG_23_2 = 0x434,
        QUEST_LOG_23_3 = 0x438,
        QUEST_LOG_23_5 = 0x440,
        QUEST_LOG_24_1 = 0x444,
        QUEST_LOG_24_2 = 0x448,
        QUEST_LOG_24_3 = 0x44C,
        QUEST_LOG_24_5 = 0x454,
        QUEST_LOG_25_1 = 0x458,
        QUEST_LOG_25_2 = 0x45C,
        QUEST_LOG_25_3 = 0x460,
        QUEST_LOG_25_5 = 0x468,
        VISIBLE_ITEM_1_ENTRYID = 0x46C,
        VISIBLE_ITEM_1_ENCHANTMENT = 0x470,
        VISIBLE_ITEM_2_ENTRYID = 0x474,
        VISIBLE_ITEM_2_ENCHANTMENT = 0x478,
        VISIBLE_ITEM_3_ENTRYID = 0x47C,
        VISIBLE_ITEM_3_ENCHANTMENT = 0x480,
        VISIBLE_ITEM_4_ENTRYID = 0x484,
        VISIBLE_ITEM_4_ENCHANTMENT = 0x488,
        VISIBLE_ITEM_5_ENTRYID = 0x48C,
        VISIBLE_ITEM_5_ENCHANTMENT = 0x490,
        VISIBLE_ITEM_6_ENTRYID = 0x494,
        VISIBLE_ITEM_6_ENCHANTMENT = 0x498,
        VISIBLE_ITEM_7_ENTRYID = 0x49C,
        VISIBLE_ITEM_7_ENCHANTMENT = 0x4A0,
        VISIBLE_ITEM_8_ENTRYID = 0x4A4,
        VISIBLE_ITEM_8_ENCHANTMENT = 0x4A8,
        VISIBLE_ITEM_9_ENTRYID = 0x4AC,
        VISIBLE_ITEM_9_ENCHANTMENT = 0x4B0,
        VISIBLE_ITEM_10_ENTRYID = 0x4B4,
        VISIBLE_ITEM_10_ENCHANTMENT = 0x4B8,
        VISIBLE_ITEM_11_ENTRYID = 0x4BC,
        VISIBLE_ITEM_11_ENCHANTMENT = 0x4C0,
        VISIBLE_ITEM_12_ENTRYID = 0x4C4,
        VISIBLE_ITEM_12_ENCHANTMENT = 0x4C8,
        VISIBLE_ITEM_13_ENTRYID = 0x4CC,
        VISIBLE_ITEM_13_ENCHANTMENT = 0x4D0,
        VISIBLE_ITEM_14_ENTRYID = 0x4D4,
        VISIBLE_ITEM_14_ENCHANTMENT = 0x4D8,
        VISIBLE_ITEM_15_ENTRYID = 0x4DC,
        VISIBLE_ITEM_15_ENCHANTMENT = 0x4E0,
        VISIBLE_ITEM_16_ENTRYID = 0x4E4,
        VISIBLE_ITEM_16_ENCHANTMENT = 0x4E8,
        VISIBLE_ITEM_17_ENTRYID = 0x4EC,
        VISIBLE_ITEM_17_ENCHANTMENT = 0x4F0,
        VISIBLE_ITEM_18_ENTRYID = 0x4F4,
        VISIBLE_ITEM_18_ENCHANTMENT = 0x4F8,
        VISIBLE_ITEM_19_ENTRYID = 0x4FC,
        VISIBLE_ITEM_19_ENCHANTMENT = 0x500,
        CHOSEN_TITLE = 0x504,
        FAKE_INEBRIATION = 0x508,
        FIELD_PAD_0 = 0x50C,
        FIELD_INV_SLOT_HEAD = 0x510,
        FIELD_PACK_SLOT_1 = 0x5C8,
        FIELD_BANK_SLOT_1 = 0x648,
        FIELD_BANKBAG_SLOT_1 = 0x728,
        FIELD_VENDORBUYBACK_SLOT_1 = 0x760,
        FIELD_KEYRING_SLOT_1 = 0x7C0,
        FIELD_CURRENCYTOKEN_SLOT_1 = 0x8C0,
        FARSIGHT = 0x9C0,
        FIELD_KNOWN_TITLES = 0x9C8,
        FIELD_KNOWN_TITLES1 = 0x9D0,
        FIELD_KNOWN_TITLES2 = 0x9D8,
        FIELD_KNOWN_CURRENCIES = 0x9E0,
        XP = 0x9E8,
        NEXT_LEVEL_XP = 0x9EC,
        SKILL_INFO_1_1 = 0x9F0,
        CHARACTER_POINTS1 = 0xFF0,
        CHARACTER_POINTS2 = 0xFF4,
        TRACK_CREATURES = 0xFF8,
        TRACK_RESOURCES = 0xFFC,
        BLOCK_PERCENTAGE = 0x1000,
        DODGE_PERCENTAGE = 0x1004,
        PARRY_PERCENTAGE = 0x1008,
        EXPERTISE = 0x100C,
        OFFHAND_EXPERTISE = 0x1010,
        CRIT_PERCENTAGE = 0x1014,
        RANGED_CRIT_PERCENTAGE = 0x1018,
        OFFHAND_CRIT_PERCENTAGE = 0x101C,
        SPELL_CRIT_PERCENTAGE1 = 0x1020,
        SHIELD_BLOCK = 0x103C,
        SHIELD_BLOCK_CRIT_PERCENTAGE = 0x1040,
        EXPLORED_ZONES_1 = 0x1044,
        REST_STATE_EXPERIENCE = 0x1244,
        FIELD_COINAGE = 0x1248,
        FIELD_MOD_DAMAGE_DONE_POS = 0x124C,
        FIELD_MOD_DAMAGE_DONE_NEG = 0x1268,
        FIELD_MOD_DAMAGE_DONE_PCT = 0x1284,
        FIELD_MOD_HEALING_DONE_POS = 0x12A0,
        FIELD_MOD_HEALING_PCT = 0x12A4,
        FIELD_MOD_HEALING_DONE_PCT = 0x12A8,
        FIELD_MOD_TARGET_RESISTANCE = 0x12AC,
        FIELD_MOD_TARGET_PHYSICAL_RESISTANCE = 0x12B0,
        FIELD_BYTES = 0x12B4,
        AMMO_ID = 0x12B8,
        SELF_RES_SPELL = 0x12BC,
        FIELD_PVP_MEDALS = 0x12C0,
        FIELD_BUYBACK_PRICE_1 = 0x12C4,
        FIELD_BUYBACK_TIMESTAMP_1 = 0x12F4,
        FIELD_KILLS = 0x1324,
        FIELD_TODAY_CONTRIBUTION = 0x1328,
        FIELD_YESTERDAY_CONTRIBUTION = 0x132C,
        FIELD_LIFETIME_HONORBALE_KILLS = 0x1330,
        FIELD_BYTES2 = 0x1334,
        FIELD_WATCHED_FACTION_INDEX = 0x1338,
        FIELD_COMBAT_RATING_1 = 0x133C,
        FIELD_ARENA_TEAM_INFO_1_1 = 0x13A0,
        FIELD_HONOR_CURRENCY = 0x13F4,
        FIELD_ARENA_CURRENCY = 0x13F8,
        FIELD_MAX_LEVEL = 0x13FC,
        FIELD_DAILY_QUESTS_1 = 0x1400,
        RUNE_REGEN_1 = 0x1464,
        NO_REAGENT_COST_1 = 0x1474,
        FIELD_GLYPH_SLOTS_1 = 0x1480,
        FIELD_GLYPHS_1 = 0x1498,
        GLYPHS_ENABLED = 0x14B0,
        PET_SPELL_POWER = 0x14B4,
        //TOTAL_PLAYER_FIELDS = 0xD7
    };
    enum GameObjectFields
    {
        //OBJECT_FIELD_CREATED_BY = 0x18,
        DISPLAYID = 0x20,
        FLAGS = 0x24,
        PARENTROTATION = 0x28,
        DYNAMIC = 0x38,
        FACTION = 0x3C,
        LEVEL = 0x40,
        BYTES_1 = 0x44,
    }
    #endregion
}
