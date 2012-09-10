﻿namespace xBot.Patchables
{
    public enum Misc : uint
    {
        DescriptorOffset = 0x8, //4.0.1b
        EntryOffset = 0xC,      //3.3.3a
        GuidOffset = 0x30,      //4.0.1b
        TypeOffset = 0x14,      //4.0.1b
    }
    public enum LocalPlayerExtras : uint
    {
        //pet spellbook comes after localplayer spellbook block
        SpellBookCount = 0x009DDD7C,    //4.0.1b | CGSpellBook__UpdateSpells | from Lecht
        SpellBook = 0x009DDD80,         //4.0.1b | CGSpellBook__UpdateSpells
        RuneTypes = 0x009DFF68,         //4.0.1b | lua_GetRuneType
        //RuneCooldowns = 0x009DFFB0,   //4.0.1b | lua_GetRuneCooldown
        ComboPoints = 0x00981751,       //4.0.1b | lua_GetComboPoints
    }
    public enum Zone : uint
    {
        //ZoneText = 0x00AF4E48, //3.3.5a | unk
        //SubZoneText = 0x00C4EB1C, //3.3.3
        //WorldMap = 0x00CE06D0 //3.3.5a | CMap__Load | .text:007BFD1D push    offset unk_CE06D0
    }
    public enum UnitExtras : uint
    {
        Casting = 0xB24, //4.0.1b | CGGameUI__Target
        ChanneledCasting = 0xB38, //4.0.1b | CGGameUI__Target
        AttackedGUID = 0xAD8, //4.0.1b | lua_StopAttack | .text:0051D0DD call    CGUnit_C__AttackedGUID_Is_NonZero(0071AF90) | .text:0071AF90 mov     eax, [ecx+0A20h]
        ClassificationBase = 0x964, //3.3.5a | CGUnit_C__GetCreatureRank ~ v1 = *(_DWORD *)(this + 2404)
        ClassficationOffset = 0x18, //3.3.5a | CGUnit_C__GetCreatureRank ~ result = *(_DWORD *)(v1 + 24)
    }
    public enum UnitAuras : uint //4.0.1
    {
        AURA_COUNT_1 = 0xF80,
        AURA_COUNT_2 = 0xD04,
        AURA_TABLE_1 = 0xD00,
        AURA_TABLE_2 = 0xD08,
        AURA_SIZE = 0x28,
    }
    public enum ObjectPosition : uint
    {
        ObjectX = 0x880, //4.0.1b
        ObjectY = 0x884, //4.0.1b
        ObjectZ = 0x888, //4.0.1b
        ObjectFacing = 0x890, //4.0.1b
    }
    public enum GameObjectExtras : uint
    {
        LockTypeOffset = 0x24,
        RequiredSkillOffset = 0x44,
        TransportMatrix = 0x1D0, //4.0.1b | CGGameObject_C_virt10
    }

    public enum ClientDb //4.0.1
    {
        AnimationData = 0x00796C54,
        LiquidMaterial = 0x00796C70,
        LiquidObject = 0x00796C8C,
        LiquidType = 0x00796CA8,
        SoundEntriesAdvanced = 0x00796CC4,
        SoundEntries = 0x00796CE0,
        SoundEntriesFallbacks = 0x00796CFC,
        TerrainMaterial = 0x00796D18,
        Achievement = 0x00797934,
        Achievement_Criteria = 0x00797950,
        Achievement_Category = 0x0079796C,
        AnimKit = 0x00797988,
        AnimKitBoneSet = 0x007979A4,
        AnimKitBoneSetAlias = 0x007979C0,
        AnimKitConfig = 0x007979DC,
        AnimKitConfigBoneSet = 0x007979F8,
        AnimKitPriority = 0x00797A14,
        AnimKitSegment = 0x00797A30,
        AnimReplacement = 0x00797A4C,
        AnimReplacementSet = 0x00797A68,
        AreaGroup = 0x00797A84,
        AreaPOI = 0x00797AA0,
        AreaPOISortedWorldState = 0x00797ABC,
        AreaTable = 0x00797AD8,
        AreaAssignment = 0x00797AF4,
        AreaTrigger = 0x00797B10,
        ArmorLocation = 0x00797B2C,
        AuctionHouse = 0x00797B48,
        BankBagSlotPrices = 0x00797B64,
        BannedAddOns = 0x00797B80,
        BarberShopStyle = 0x00797B9C,
        BattlemasterList = 0x00797BB8,
        CameraMode = 0x00797BD4,
        CameraShakes = 0x00797BF0,
        CastableRaidBuffs = 0x00797C0C,
        Cfg_Categories = 0x00797C28,
        Cfg_Configs = 0x00797C44,
        CharBaseInfo = 0x00797C60,
        CharHairGeosets = 0x00797C7C,
        CharSections = 0x00797C98,
        CharStartOutfit = 0x00797CB4,
        CharTitles = 0x00797CD0,
        CharacterFacialHairStyles = 0x00797CEC,
        ChatChannels = 0x00797D08,
        ChatProfanity = 0x00797D24,
        ChrClasses = 0x00797D40,
        ChrRaces = 0x00797D5C,
        CinematicCamera = 0x00797D78,
        CinematicSequences = 0x00797D94,
        CreatureDisplayInfoExtra = 0x00797DB0,
        CreatureDisplayInfo = 0x00797DCC,
        CreatureFamily = 0x00797DE8,
        CreatureModelData = 0x00797E04,
        CreatureMovementInfo = 0x00797E20,
        CreatureSoundData = 0x00797E3C,
        CreatureSpellData = 0x00797E58,
        CreatureType = 0x00797E74,
        CurrencyTypes = 0x00797E90,
        CurrencyCategory = 0x00797EAC,
        DanceMoves = 0x00797EC8,
        DeathThudLookups = 0x00797EE4,
        DestructibleModelData = 0x00797F38,
        DungeonEncounter = 0x00797F54,
        DungeonMap = 0x00797F70,
        DungeonMapChunk = 0x00797F8C,
        DurabilityCosts = 0x00797FA8,
        DurabilityQuality = 0x00797FC4,
        Emotes = 0x00797FE0,
        EmotesTextData = 0x00797FFC,
        EmotesTextSound = 0x00798018,
        EmotesText = 0x00798034,
        EnvironmentalDamage = 0x00798050,
        Exhaustion = 0x0079806C,
        FactionGroup = 0x00798088,
        Faction = 0x007980A4,
        FactionTemplate = 0x007980C0,
        FileData = 0x007980DC,
        FootprintTextures = 0x007980F8,
        FootstepTerrainLookup = 0x00798114,
        GameObjectArtKit = 0x00798130,
        GameObjectDisplayInfo = 0x0079814C,
        GameTables = 0x00798168,
        GameTips = 0x00798184,
        GemProperties = 0x007981A0,
        GlueScreenEmote = 0x007981BC,
        GlyphProperties = 0x007981D8,
        GlyphSlot = 0x007981F4,
        GMSurveyAnswers = 0x00798210,
        GMSurveyCurrentSurvey = 0x0079822C,
        GMSurveyQuestions = 0x00798248,
        GMSurveySurveys = 0x00798264,
        GMTicketCategory = 0x00798280,
        GroundEffectDoodad = 0x0079829C,
        GroundEffectTexture = 0x007982B8,
        gtBarberShopCostBase = 0x007982D4,
        gtCombatRatings = 0x007982F0,
        gtChanceToMeleeCrit = 0x0079830C,
        gtChanceToMeleeCritBase = 0x00798328,
        gtChanceToSpellCrit = 0x00798344,
        gtChanceToSpellCritBase = 0x00798360,
        gtNPCManaCostScaler = 0x0079837C,
        gtOCTClassCombatRatingScalar = 0x00798398,
        gtOCTRegenMP = 0x007983B4,
        gtRegenMPPerSpt = 0x007983D0,
        gtSpellScaling = 0x00798408,
        gtShieldBlockRegular = 0x007983EC,
        GuildColorBackground = 0x00798424,
        GuildColorBorder = 0x00798440,
        GuildColorEmblem = 0x0079845C,
        GuildPerkSpells = 0x00798478,
        HelmetGeosetVisData = 0x00798494,
        HolidayDescriptions = 0x007984B0,
        HolidayNames = 0x007984CC,
        Holidays = 0x007984E8,
        ItemArmorQuality = 0x00798520,
        ItemArmorTotal = 0x00798504,
        ItemArmorShield = 0x0079853C,
        ItemBagFamily = 0x00798558,
        ItemClass = 0x00798574,
        ItemCurrencyCost = 0x00798590,
        ItemDamageAmmo = 0x007985AC,
        ItemDamageOneHand = 0x007985C8,
        ItemDamageOneHandCaster = 0x007985E4,
        ItemDamageRanged = 0x00798600,
        ItemDamageThrown = 0x0079861C,
        ItemDamageTwoHand = 0x00798638,
        ItemDamageTwoHandCaster = 0x00798654,
        ItemDamageWand = 0x00798670,
        ItemDisenchantLoot = 0x0079868C,
        ItemDisplayInfo = 0x007986A8,
        ItemExtendedCost = 0x007986C8,
        ItemGroupSounds = 0x007986E4,
        ItemLimitCategory = 0x00798700,
        ItemPetFood = 0x0079871C,
        ItemPurchaseGroup = 0x00798738,
        ItemRandomProperties = 0x00798754,
        ItemRandomSuffix = 0x00798770,
        ItemReforge = 0x0079878C,
        ItemSet = 0x007987A8,
        ItemSubClassMask = 0x007987C4,
        ItemSubClass = 0x007987E0,
        ItemVisualEffects = 0x007987FC,
        ItemVisuals = 0x00798818,
        LanguageWords = 0x00798834,
        Languages = 0x00798850,
        LfgDungeonExpansion = 0x0079886C,
        LfgDungeonGroup = 0x00798888,
        LfgDungeons = 0x007988A4,
        Light = 0x007A15FC,
        LightFloatBand = 0x007A15C0,
        LightIntBand = 0x007A15A0,
        LightParams = 0x007A15E0,
        LightSkybox = 0x007A1584,
        LoadingScreens = 0x007988C0,
        LoadingScreenTaxiSplines = 0x007988DC,
        Lock = 0x007988F8,
        LockType = 0x00798914,
        MailTemplate = 0x00798930,
        Map = 0x0079894C,
        MapDifficulty = 0x00798968,
        Material = 0x00798984,
        MountCapability = 0x007989A0,
        MountType = 0x007989BC,
        Movie = 0x007989D8,
        MovieFileData = 0x007989F4,
        MovieVariation = 0x00798A10,
        NameGen = 0x00798A2C,
        NPCSounds = 0x00798A48,
        NamesProfanity = 0x00798A80,
        NamesReserved = 0x00798A9C,
        NumTalentsAtLevel = 0x00798A64,
        OverrideSpellData = 0x00798AB8,
        Package = 0x00798AD4,
        PageTextMaterial = 0x00798AF0,
        PaperDollItemFrame = 0x00798B0C,
        ParticleColor = 0x00798B28,
        PetPersonality = 0x00798B44,
        Phase = 0x00798B60,
        PhaseXPhaseGroup = 0x00798B98,
        PowerDisplay = 0x00798BB4,
        PvpDifficulty = 0x00798BD0,
        QuestFactionReward = 0x00798BEC,
        QuestInfo = 0x00798C08,
        QuestPOIBlob = 0x00798C24,
        QuestPOIPoint = 0x00798C40,
        QuestSort = 0x00798C5C,
        QuestXP = 0x00798C78,
        Resistances = 0x00798C94,
        ResearchBranch = 0x00798CE8,
        ResearchField = 0x00798CCC,
        ResearchProject = 0x00798D04,
        ResearchSite = 0x00798D20,
        RandPropPoints = 0x00798CB0,
        ScalingStatDistribution = 0x00798D3C,
        ScalingStatValues = 0x00798D58,
        ScreenEffect = 0x00798D74,
        ScreenLocation = 0x00798D90,
        ServerMessages = 0x00798DAC,
        SkillLineAbility = 0x00798DC8,
        SkillLineAbilitySortedSpell = 0x00798DE4,
        SkillLineCategory = 0x00798E00,
        SkillLine = 0x00798E1C,
        SkillRaceClassInfo = 0x00798E38,
        SkillTiers = 0x00798E54,
        SoundAmbience = 0x00798E70,
        SoundEmitters = 0x00798E8C,
        SoundProviderPreferences = 0x00798EA8,
        SpamMessages = 0x00798EC4,
        SpellActivationOverlay = 0x00798EE0,
        SpellAuraOptions = 0x00798EFC,
        SpellAuraRestrictions = 0x00798F18,
        SpellCastingRequirements = 0x00798F34,
        SpellCastTimes = 0x00798F50,
        SpellCategories = 0x00798F6C,
        SpellCategory = 0x00798F88,
        SpellChainEffects = 0x00798FA4,
        SpellClassOptions = 0x00798FC0,
        SpellCooldowns = 0x00798FDC,
        Spell = 0x0079927C,
        SpellDescriptionVariables = 0x00798FF8,
        SpellDifficulty = 0x00799014,
        SpellDispelType = 0x00799030,
        SpellDuration = 0x0079904C,
        SpellEffect = 0x00799068,
        SpellEffectCameraShakes = 0x00799084,
        SpellEquippedItems = 0x007990A0,
        SpellFlyout = 0x007990BC,
        SpellFlyoutItem = 0x007990D8,
        SpellFocusObject = 0x007990F4,
        SpellIcon = 0x00799110,
        SpellInterrupts = 0x0079912C,
        SpellItemEnchantment = 0x00799148,
        SpellItemEnchantmentCondition = 0x00799164,
        SpellLevels = 0x00799180,
        SpellMechanic = 0x0079919C,
        SpellMissile = 0x007991B8,
        SpellMissileMotion = 0x007991D4,
        SpellRadius = 0x0079920C,
        SpellRange = 0x00799228,
        SpellPower = 0x007991F0,
        SpellReagents = 0x00799260,
        SpellRuneCost = 0x00799244,
        SpellScaling = 0x00799298,
        SpellShapeshift = 0x007992B4,
        SpellShapeshiftForm = 0x007992D0,
        SpellTargetRestrictions = 0x007992EC,
        SpellTotems = 0x00799308,
        SpellVisual = 0x00799394,
        SpellVisualEffectName = 0x00799324,
        SpellVisualKit = 0x00799340,
        SpellVisualKitAreaModel = 0x0079935C,
        SpellVisualKitModelAttach = 0x00799378,
        Stationery = 0x007993B0,
        StringLookups = 0x007993CC,
        SummonProperties = 0x007993E8,
        Talent = 0x00799404,
        TalentTab = 0x00799420,
        TalentTreePrimarySpells = 0x0079943C,
        TaxiNodes = 0x00799458,
        TaxiPathNode = 0x00799474,
        TaxiPath = 0x00799490,
        TerrainType = 0x007994AC,
        TerrainTypeSounds = 0x007994C8,
        TotemCategory = 0x007994E4,
        TransportAnimation = 0x00799500,
        TransportPhysics = 0x0079951C,
        TransportRotation = 0x00799538,
        UnitBloodLevels = 0x00799554,
        UnitBlood = 0x00799570,
        UnitPowerBar = 0x0079958C,
        Vehicle = 0x007995A8,
        VehicleSeat = 0x007995C4,
        VehicleUIIndicator = 0x007995E0,
        VehicleUIIndSeat = 0x007995FC,
        VocalUISounds = 0x00799618,
        WMOAreaTable = 0x00799634,
        World_PVP_Area = 0x00799650,
        WeaponImpactSounds = 0x0079966C,
        WeaponSwingSounds2 = 0x00799688,
        Weather = 0x007996A4,
        WorldMapArea = 0x007996C0,
        WorldMapContinent = 0x007996DC,
        WorldMapOverlay = 0x007996F8,
        WorldMapTransforms = 0x00799714,
        WorldSafeLocs = 0x00799730,
        WorldStateUI = 0x0079974C,
        ZoneIntroMusicTable = 0x00799768,
        ZoneLight = 0x00799784,
        ZoneLightPoint = 0x007997A0,
        ZoneMusic = 0x007997BC,
        WorldStateZoneSounds = 0x007997D8,
        WorldChunkSounds = 0x007997F4,
        ObjectEffect = 0x00799810,
        ObjectEffectGroup = 0x0079982C,
        ObjectEffectModifier = 0x00799848,
        ObjectEffectPackage = 0x00799864,
        ObjectEffectPackageElem = 0x00799880,
        SoundFilter = 0x0079989C,
        SoundFilterElem = 0x007998B8,
        PhaseShiftZoneSounds = 0x00798B7C,
    }

    #region Patchable enums
    // Version: 4.0.1  Build number: 13164  Build date: Oct  6 2010
    // Descriptors: 0x00C07368
    enum ObjectFields
    {
        GUID = 0x0,
        TYPE = 0x8,
        ENTRY = 0xC,
        SCALE_X = 0x10,
        DATA = 0x14,
        PADDING = 0x1C,
        END = 0x20
    };

    // Descriptors: 0x00C07768
    enum UnitFields
    {
        CHARM = ObjectFields.END + 0x0,
        SUMMON = ObjectFields.END + 0x8,
        CRITTER = ObjectFields.END + 0x10,
        CHARMEDBY = ObjectFields.END + 0x18,
        SUMMONEDBY = ObjectFields.END + 0x20,
        CREATEDBY = ObjectFields.END + 0x28,
        TARGET = ObjectFields.END + 0x30,
        CHANNEL_OBJECT = ObjectFields.END + 0x38,
        CHANNEL_SPELL = ObjectFields.END + 0x40,
        BYTES_0 = ObjectFields.END + 0x44,
        HEALTH = ObjectFields.END + 0x48,
        POWER1 = ObjectFields.END + 0x4C,
        POWER2 = ObjectFields.END + 0x50,
        POWER3 = ObjectFields.END + 0x54,
        POWER4 = ObjectFields.END + 0x58,
        POWER5 = ObjectFields.END + 0x5C,
        POWER6 = ObjectFields.END + 0x60,
        POWER7 = ObjectFields.END + 0x64,
        POWER8 = ObjectFields.END + 0x68,
        POWER9 = ObjectFields.END + 0x6C,
        POWER10 = ObjectFields.END + 0x70,
        POWER11 = ObjectFields.END + 0x74,
        MAXHEALTH = ObjectFields.END + 0x78,
        MAXPOWER1 = ObjectFields.END + 0x7C,
        MAXPOWER2 = ObjectFields.END + 0x80,
        MAXPOWER3 = ObjectFields.END + 0x84,
        MAXPOWER4 = ObjectFields.END + 0x88,
        MAXPOWER5 = ObjectFields.END + 0x8C,
        MAXPOWER6 = ObjectFields.END + 0x90,
        MAXPOWER7 = ObjectFields.END + 0x94,
        MAXPOWER8 = ObjectFields.END + 0x98,
        MAXPOWER9 = ObjectFields.END + 0x9C,
        MAXPOWER10 = ObjectFields.END + 0xA0,
        MAXPOWER11 = ObjectFields.END + 0xA4,
        POWER_REGEN_FLAT_MODIFIER = ObjectFields.END + 0xA8,
        POWER_REGEN_INTERRUPTED_FLAT_MODIFIER = ObjectFields.END + 0xD4,
        LEVEL = ObjectFields.END + 0x100,
        FACTIONTEMPLATE = ObjectFields.END + 0x104,
        VIRTUAL_ITEM_SLOT_ID = ObjectFields.END + 0x108,
        FLAGS = ObjectFields.END + 0x114,
        FLAGS_2 = ObjectFields.END + 0x118,
        AURASTATE = ObjectFields.END + 0x11C,
        BASEATTACKTIME = ObjectFields.END + 0x120,
        RANGEDATTACKTIME = ObjectFields.END + 0x128,
        BOUNDINGRADIUS = ObjectFields.END + 0x12C,
        COMBATREACH = ObjectFields.END + 0x130,
        DISPLAYID = ObjectFields.END + 0x134,
        NATIVEDISPLAYID = ObjectFields.END + 0x138,
        MOUNTDISPLAYID = ObjectFields.END + 0x13C,
        MINDAMAGE = ObjectFields.END + 0x140,
        MAXDAMAGE = ObjectFields.END + 0x144,
        MINOFFHANDDAMAGE = ObjectFields.END + 0x148,
        MAXOFFHANDDAMAGE = ObjectFields.END + 0x14C,
        BYTES_1 = ObjectFields.END + 0x150,
        PETNUMBER = ObjectFields.END + 0x154,
        PET_NAME_TIMESTAMP = ObjectFields.END + 0x158,
        PETEXPERIENCE = ObjectFields.END + 0x15C,
        PETNEXTLEVELEXP = ObjectFields.END + 0x160,
        DYNAMIC_FLAGS = ObjectFields.END + 0x164,
        MOD_CAST_SPEED = ObjectFields.END + 0x168,
        CREATED_BY_SPELL = ObjectFields.END + 0x16C,
        NPC_FLAGS = ObjectFields.END + 0x170,
        NPC_EMOTESTATE = ObjectFields.END + 0x174,
        STAT0 = ObjectFields.END + 0x178,
        STAT1 = ObjectFields.END + 0x17C,
        STAT2 = ObjectFields.END + 0x180,
        STAT3 = ObjectFields.END + 0x184,
        STAT4 = ObjectFields.END + 0x188,
        POSSTAT0 = ObjectFields.END + 0x18C,
        POSSTAT1 = ObjectFields.END + 0x190,
        POSSTAT2 = ObjectFields.END + 0x194,
        POSSTAT3 = ObjectFields.END + 0x198,
        POSSTAT4 = ObjectFields.END + 0x19C,
        NEGSTAT0 = ObjectFields.END + 0x1A0,
        NEGSTAT1 = ObjectFields.END + 0x1A4,
        NEGSTAT2 = ObjectFields.END + 0x1A8,
        NEGSTAT3 = ObjectFields.END + 0x1AC,
        NEGSTAT4 = ObjectFields.END + 0x1B0,
        RESISTANCES = ObjectFields.END + 0x1B4,
        RESISTANCEBUFFMODSPOSITIVE = ObjectFields.END + 0x1D0,
        RESISTANCEBUFFMODSNEGATIVE = ObjectFields.END + 0x1EC,
        BASE_MANA = ObjectFields.END + 0x208,
        BASE_HEALTH = ObjectFields.END + 0x20C,
        BYTES_2 = ObjectFields.END + 0x210,
        ATTACK_POWER = ObjectFields.END + 0x214,
        ATTACK_POWER_MODS = ObjectFields.END + 0x218,
        ATTACK_POWER_MULTIPLIER = ObjectFields.END + 0x21C,
        RANGED_ATTACK_POWER = ObjectFields.END + 0x220,
        RANGED_ATTACK_POWER_MODS = ObjectFields.END + 0x224,
        RANGED_ATTACK_POWER_MULTIPLIER = ObjectFields.END + 0x228,
        MINRANGEDDAMAGE = ObjectFields.END + 0x22C,
        MAXRANGEDDAMAGE = ObjectFields.END + 0x230,
        POWER_COST_MODIFIER = ObjectFields.END + 0x234,
        POWER_COST_MULTIPLIER = ObjectFields.END + 0x250,
        MAXHEALTHMODIFIER = ObjectFields.END + 0x26C,
        HOVERHEIGHT = ObjectFields.END + 0x270,
        MAXITEMLEVEL = ObjectFields.END + 0x274,
        END = ObjectFields.END + 0x278
    };

    // Descriptors: 0x00C073E0
    enum ItemFields
    {
        OWNER = ObjectFields.END + 0x0,
        CONTAINED = ObjectFields.END + 0x8,
        CREATOR = ObjectFields.END + 0x10,
        GIFTCREATOR = ObjectFields.END + 0x18,
        STACK_COUNT = ObjectFields.END + 0x20,
        DURATION = ObjectFields.END + 0x24,
        SPELL_CHARGES = ObjectFields.END + 0x28,
        FLAGS = ObjectFields.END + 0x3C,
        ENCHANTMENT_1_1 = ObjectFields.END + 0x40,
        ENCHANTMENT_1_3 = ObjectFields.END + 0x48,
        ENCHANTMENT_2_1 = ObjectFields.END + 0x4C,
        ENCHANTMENT_2_3 = ObjectFields.END + 0x54,
        ENCHANTMENT_3_1 = ObjectFields.END + 0x58,
        ENCHANTMENT_3_3 = ObjectFields.END + 0x60,
        ENCHANTMENT_4_1 = ObjectFields.END + 0x64,
        ENCHANTMENT_4_3 = ObjectFields.END + 0x6C,
        ENCHANTMENT_5_1 = ObjectFields.END + 0x70,
        ENCHANTMENT_5_3 = ObjectFields.END + 0x78,
        ENCHANTMENT_6_1 = ObjectFields.END + 0x7C,
        ENCHANTMENT_6_3 = ObjectFields.END + 0x84,
        ENCHANTMENT_7_1 = ObjectFields.END + 0x88,
        ENCHANTMENT_7_3 = ObjectFields.END + 0x90,
        ENCHANTMENT_8_1 = ObjectFields.END + 0x94,
        ENCHANTMENT_8_3 = ObjectFields.END + 0x9C,
        ENCHANTMENT_9_1 = ObjectFields.END + 0xA0,
        ENCHANTMENT_9_3 = ObjectFields.END + 0xA8,
        ENCHANTMENT_10_1 = ObjectFields.END + 0xAC,
        ENCHANTMENT_10_3 = ObjectFields.END + 0xB4,
        ENCHANTMENT_11_1 = ObjectFields.END + 0xB8,
        ENCHANTMENT_11_3 = ObjectFields.END + 0xC0,
        ENCHANTMENT_12_1 = ObjectFields.END + 0xC4,
        ENCHANTMENT_12_3 = ObjectFields.END + 0xCC,
        ENCHANTMENT_13_1 = ObjectFields.END + 0xD0,
        ENCHANTMENT_13_3 = ObjectFields.END + 0xD8,
        ENCHANTMENT_14_1 = ObjectFields.END + 0xDC,
        ENCHANTMENT_14_3 = ObjectFields.END + 0xE4,
        PROPERTY_SEED = ObjectFields.END + 0xE8,
        RANDOM_PROPERTIES_ID = ObjectFields.END + 0xEC,
        DURABILITY = ObjectFields.END + 0xF0,
        MAXDURABILITY = ObjectFields.END + 0xF4,
        CREATE_PLAYED_TIME = ObjectFields.END + 0xF8,
        PAD = ObjectFields.END + 0xFC,
        END = ObjectFields.END + 0x100
    };

    // Descriptors: 0x00C07F00
    enum PlayerFields
    {
        DUEL_ARBITER = UnitFields.END + 0x0,
        FLAGS = UnitFields.END + 0x8,
        GUILDRANK = UnitFields.END + 0xC,
        GUILDDELETE_DATE = UnitFields.END + 0x10,
        GUILDLEVEL = UnitFields.END + 0x14,
        BYTES = UnitFields.END + 0x18,
        BYTES_2 = UnitFields.END + 0x1C,
        BYTES_3 = UnitFields.END + 0x20,
        DUEL_TEAM = UnitFields.END + 0x24,
        GUILD_TIMESTAMP = UnitFields.END + 0x28,
        QUEST_LOG_1_1 = UnitFields.END + 0x2C,
        QUEST_LOG_1_2 = UnitFields.END + 0x30,
        QUEST_LOG_1_3 = UnitFields.END + 0x34,
        QUEST_LOG_1_4 = UnitFields.END + 0x3C,
        QUEST_LOG_2_1 = UnitFields.END + 0x40,
        QUEST_LOG_2_2 = UnitFields.END + 0x44,
        QUEST_LOG_2_3 = UnitFields.END + 0x48,
        QUEST_LOG_2_5 = UnitFields.END + 0x50,
        QUEST_LOG_3_1 = UnitFields.END + 0x54,
        QUEST_LOG_3_2 = UnitFields.END + 0x58,
        QUEST_LOG_3_3 = UnitFields.END + 0x5C,
        QUEST_LOG_3_5 = UnitFields.END + 0x64,
        QUEST_LOG_4_1 = UnitFields.END + 0x68,
        QUEST_LOG_4_2 = UnitFields.END + 0x6C,
        QUEST_LOG_4_3 = UnitFields.END + 0x70,
        QUEST_LOG_4_5 = UnitFields.END + 0x78,
        QUEST_LOG_5_1 = UnitFields.END + 0x7C,
        QUEST_LOG_5_2 = UnitFields.END + 0x80,
        QUEST_LOG_5_3 = UnitFields.END + 0x84,
        QUEST_LOG_5_5 = UnitFields.END + 0x8C,
        QUEST_LOG_6_1 = UnitFields.END + 0x90,
        QUEST_LOG_6_2 = UnitFields.END + 0x94,
        QUEST_LOG_6_3 = UnitFields.END + 0x98,
        QUEST_LOG_6_5 = UnitFields.END + 0xA0,
        QUEST_LOG_7_1 = UnitFields.END + 0xA4,
        QUEST_LOG_7_2 = UnitFields.END + 0xA8,
        QUEST_LOG_7_3 = UnitFields.END + 0xAC,
        QUEST_LOG_7_5 = UnitFields.END + 0xB4,
        QUEST_LOG_8_1 = UnitFields.END + 0xB8,
        QUEST_LOG_8_2 = UnitFields.END + 0xBC,
        QUEST_LOG_8_3 = UnitFields.END + 0xC0,
        QUEST_LOG_8_5 = UnitFields.END + 0xC8,
        QUEST_LOG_9_1 = UnitFields.END + 0xCC,
        QUEST_LOG_9_2 = UnitFields.END + 0xD0,
        QUEST_LOG_9_3 = UnitFields.END + 0xD4,
        QUEST_LOG_9_5 = UnitFields.END + 0xDC,
        QUEST_LOG_10_1 = UnitFields.END + 0xE0,
        QUEST_LOG_10_2 = UnitFields.END + 0xE4,
        QUEST_LOG_10_3 = UnitFields.END + 0xE8,
        QUEST_LOG_10_5 = UnitFields.END + 0xF0,
        QUEST_LOG_11_1 = UnitFields.END + 0xF4,
        QUEST_LOG_11_2 = UnitFields.END + 0xF8,
        QUEST_LOG_11_3 = UnitFields.END + 0xFC,
        QUEST_LOG_11_5 = UnitFields.END + 0x104,
        QUEST_LOG_12_1 = UnitFields.END + 0x108,
        QUEST_LOG_12_2 = UnitFields.END + 0x10C,
        QUEST_LOG_12_3 = UnitFields.END + 0x110,
        QUEST_LOG_12_5 = UnitFields.END + 0x118,
        QUEST_LOG_13_1 = UnitFields.END + 0x11C,
        QUEST_LOG_13_2 = UnitFields.END + 0x120,
        QUEST_LOG_13_3 = UnitFields.END + 0x124,
        QUEST_LOG_13_5 = UnitFields.END + 0x12C,
        QUEST_LOG_14_1 = UnitFields.END + 0x130,
        QUEST_LOG_14_2 = UnitFields.END + 0x134,
        QUEST_LOG_14_3 = UnitFields.END + 0x138,
        QUEST_LOG_14_5 = UnitFields.END + 0x140,
        QUEST_LOG_15_1 = UnitFields.END + 0x144,
        QUEST_LOG_15_2 = UnitFields.END + 0x148,
        QUEST_LOG_15_3 = UnitFields.END + 0x14C,
        QUEST_LOG_15_5 = UnitFields.END + 0x154,
        QUEST_LOG_16_1 = UnitFields.END + 0x158,
        QUEST_LOG_16_2 = UnitFields.END + 0x15C,
        QUEST_LOG_16_3 = UnitFields.END + 0x160,
        QUEST_LOG_16_5 = UnitFields.END + 0x168,
        QUEST_LOG_17_1 = UnitFields.END + 0x16C,
        QUEST_LOG_17_2 = UnitFields.END + 0x170,
        QUEST_LOG_17_3 = UnitFields.END + 0x174,
        QUEST_LOG_17_5 = UnitFields.END + 0x17C,
        QUEST_LOG_18_1 = UnitFields.END + 0x180,
        QUEST_LOG_18_2 = UnitFields.END + 0x184,
        QUEST_LOG_18_3 = UnitFields.END + 0x188,
        QUEST_LOG_18_5 = UnitFields.END + 0x190,
        QUEST_LOG_19_1 = UnitFields.END + 0x194,
        QUEST_LOG_19_2 = UnitFields.END + 0x198,
        QUEST_LOG_19_3 = UnitFields.END + 0x19C,
        QUEST_LOG_19_5 = UnitFields.END + 0x1A4,
        QUEST_LOG_20_1 = UnitFields.END + 0x1A8,
        QUEST_LOG_20_2 = UnitFields.END + 0x1AC,
        QUEST_LOG_20_3 = UnitFields.END + 0x1B0,
        QUEST_LOG_20_5 = UnitFields.END + 0x1B8,
        QUEST_LOG_21_1 = UnitFields.END + 0x1BC,
        QUEST_LOG_21_2 = UnitFields.END + 0x1C0,
        QUEST_LOG_21_3 = UnitFields.END + 0x1C4,
        QUEST_LOG_21_5 = UnitFields.END + 0x1CC,
        QUEST_LOG_22_1 = UnitFields.END + 0x1D0,
        QUEST_LOG_22_2 = UnitFields.END + 0x1D4,
        QUEST_LOG_22_3 = UnitFields.END + 0x1D8,
        QUEST_LOG_22_5 = UnitFields.END + 0x1E0,
        QUEST_LOG_23_1 = UnitFields.END + 0x1E4,
        QUEST_LOG_23_2 = UnitFields.END + 0x1E8,
        QUEST_LOG_23_3 = UnitFields.END + 0x1EC,
        QUEST_LOG_23_5 = UnitFields.END + 0x1F4,
        QUEST_LOG_24_1 = UnitFields.END + 0x1F8,
        QUEST_LOG_24_2 = UnitFields.END + 0x1FC,
        QUEST_LOG_24_3 = UnitFields.END + 0x200,
        QUEST_LOG_24_5 = UnitFields.END + 0x208,
        QUEST_LOG_25_1 = UnitFields.END + 0x20C,
        QUEST_LOG_25_2 = UnitFields.END + 0x210,
        QUEST_LOG_25_3 = UnitFields.END + 0x214,
        QUEST_LOG_25_5 = UnitFields.END + 0x21C,
        QUEST_LOG_26_1 = UnitFields.END + 0x220,
        QUEST_LOG_26_2 = UnitFields.END + 0x224,
        QUEST_LOG_26_3 = UnitFields.END + 0x228,
        QUEST_LOG_26_5 = UnitFields.END + 0x230,
        QUEST_LOG_27_1 = UnitFields.END + 0x234,
        QUEST_LOG_27_2 = UnitFields.END + 0x238,
        QUEST_LOG_27_3 = UnitFields.END + 0x23C,
        QUEST_LOG_27_5 = UnitFields.END + 0x244,
        QUEST_LOG_28_1 = UnitFields.END + 0x248,
        QUEST_LOG_28_2 = UnitFields.END + 0x24C,
        QUEST_LOG_28_3 = UnitFields.END + 0x250,
        QUEST_LOG_28_5 = UnitFields.END + 0x258,
        QUEST_LOG_29_1 = UnitFields.END + 0x25C,
        QUEST_LOG_29_2 = UnitFields.END + 0x260,
        QUEST_LOG_29_3 = UnitFields.END + 0x264,
        QUEST_LOG_29_5 = UnitFields.END + 0x26C,
        QUEST_LOG_30_1 = UnitFields.END + 0x270,
        QUEST_LOG_30_2 = UnitFields.END + 0x274,
        QUEST_LOG_30_3 = UnitFields.END + 0x278,
        QUEST_LOG_30_5 = UnitFields.END + 0x280,
        QUEST_LOG_31_1 = UnitFields.END + 0x284,
        QUEST_LOG_31_2 = UnitFields.END + 0x288,
        QUEST_LOG_31_3 = UnitFields.END + 0x28C,
        QUEST_LOG_31_5 = UnitFields.END + 0x294,
        QUEST_LOG_32_1 = UnitFields.END + 0x298,
        QUEST_LOG_32_2 = UnitFields.END + 0x29C,
        QUEST_LOG_32_3 = UnitFields.END + 0x2A0,
        QUEST_LOG_32_5 = UnitFields.END + 0x2A8,
        QUEST_LOG_33_1 = UnitFields.END + 0x2AC,
        QUEST_LOG_33_2 = UnitFields.END + 0x2B0,
        QUEST_LOG_33_3 = UnitFields.END + 0x2B4,
        QUEST_LOG_33_5 = UnitFields.END + 0x2BC,
        QUEST_LOG_34_1 = UnitFields.END + 0x2C0,
        QUEST_LOG_34_2 = UnitFields.END + 0x2C4,
        QUEST_LOG_34_3 = UnitFields.END + 0x2C8,
        QUEST_LOG_34_5 = UnitFields.END + 0x2D0,
        QUEST_LOG_35_1 = UnitFields.END + 0x2D4,
        QUEST_LOG_35_2 = UnitFields.END + 0x2D8,
        QUEST_LOG_35_3 = UnitFields.END + 0x2DC,
        QUEST_LOG_35_5 = UnitFields.END + 0x2E4,
        QUEST_LOG_36_1 = UnitFields.END + 0x2E8,
        QUEST_LOG_36_2 = UnitFields.END + 0x2EC,
        QUEST_LOG_36_3 = UnitFields.END + 0x2F0,
        QUEST_LOG_36_5 = UnitFields.END + 0x2F8,
        QUEST_LOG_37_1 = UnitFields.END + 0x2FC,
        QUEST_LOG_37_2 = UnitFields.END + 0x300,
        QUEST_LOG_37_3 = UnitFields.END + 0x304,
        QUEST_LOG_37_5 = UnitFields.END + 0x30C,
        QUEST_LOG_38_1 = UnitFields.END + 0x310,
        QUEST_LOG_38_2 = UnitFields.END + 0x314,
        QUEST_LOG_38_3 = UnitFields.END + 0x318,
        QUEST_LOG_38_5 = UnitFields.END + 0x320,
        QUEST_LOG_39_1 = UnitFields.END + 0x324,
        QUEST_LOG_39_2 = UnitFields.END + 0x328,
        QUEST_LOG_39_3 = UnitFields.END + 0x32C,
        QUEST_LOG_39_5 = UnitFields.END + 0x334,
        QUEST_LOG_40_1 = UnitFields.END + 0x338,
        QUEST_LOG_40_2 = UnitFields.END + 0x33C,
        QUEST_LOG_40_3 = UnitFields.END + 0x340,
        QUEST_LOG_40_5 = UnitFields.END + 0x348,
        QUEST_LOG_41_1 = UnitFields.END + 0x34C,
        QUEST_LOG_41_2 = UnitFields.END + 0x350,
        QUEST_LOG_41_3 = UnitFields.END + 0x354,
        QUEST_LOG_41_5 = UnitFields.END + 0x35C,
        QUEST_LOG_42_1 = UnitFields.END + 0x360,
        QUEST_LOG_42_2 = UnitFields.END + 0x364,
        QUEST_LOG_42_3 = UnitFields.END + 0x368,
        QUEST_LOG_42_5 = UnitFields.END + 0x370,
        QUEST_LOG_43_1 = UnitFields.END + 0x374,
        QUEST_LOG_43_2 = UnitFields.END + 0x378,
        QUEST_LOG_43_3 = UnitFields.END + 0x37C,
        QUEST_LOG_43_5 = UnitFields.END + 0x384,
        QUEST_LOG_44_1 = UnitFields.END + 0x388,
        QUEST_LOG_44_2 = UnitFields.END + 0x38C,
        QUEST_LOG_44_3 = UnitFields.END + 0x390,
        QUEST_LOG_44_5 = UnitFields.END + 0x398,
        QUEST_LOG_45_1 = UnitFields.END + 0x39C,
        QUEST_LOG_45_2 = UnitFields.END + 0x3A0,
        QUEST_LOG_45_3 = UnitFields.END + 0x3A4,
        QUEST_LOG_45_5 = UnitFields.END + 0x3AC,
        QUEST_LOG_46_1 = UnitFields.END + 0x3B0,
        QUEST_LOG_46_2 = UnitFields.END + 0x3B4,
        QUEST_LOG_46_3 = UnitFields.END + 0x3B8,
        QUEST_LOG_46_5 = UnitFields.END + 0x3C0,
        QUEST_LOG_47_1 = UnitFields.END + 0x3C4,
        QUEST_LOG_47_2 = UnitFields.END + 0x3C8,
        QUEST_LOG_47_3 = UnitFields.END + 0x3CC,
        QUEST_LOG_47_5 = UnitFields.END + 0x3D4,
        QUEST_LOG_48_1 = UnitFields.END + 0x3D8,
        QUEST_LOG_48_2 = UnitFields.END + 0x3DC,
        QUEST_LOG_48_3 = UnitFields.END + 0x3E0,
        QUEST_LOG_48_5 = UnitFields.END + 0x3E8,
        QUEST_LOG_49_1 = UnitFields.END + 0x3EC,
        QUEST_LOG_49_2 = UnitFields.END + 0x3F0,
        QUEST_LOG_49_3 = UnitFields.END + 0x3F4,
        QUEST_LOG_49_5 = UnitFields.END + 0x3FC,
        QUEST_LOG_50_1 = UnitFields.END + 0x400,
        QUEST_LOG_50_2 = UnitFields.END + 0x404,
        QUEST_LOG_50_3 = UnitFields.END + 0x408,
        QUEST_LOG_50_5 = UnitFields.END + 0x410,
        VISIBLE_ITEM_1_ENTRYID = UnitFields.END + 0x414,
        VISIBLE_ITEM_1_ENCHANTMENT = UnitFields.END + 0x418,
        VISIBLE_ITEM_2_ENTRYID = UnitFields.END + 0x41C,
        VISIBLE_ITEM_2_ENCHANTMENT = UnitFields.END + 0x420,
        VISIBLE_ITEM_3_ENTRYID = UnitFields.END + 0x424,
        VISIBLE_ITEM_3_ENCHANTMENT = UnitFields.END + 0x428,
        VISIBLE_ITEM_4_ENTRYID = UnitFields.END + 0x42C,
        VISIBLE_ITEM_4_ENCHANTMENT = UnitFields.END + 0x430,
        VISIBLE_ITEM_5_ENTRYID = UnitFields.END + 0x434,
        VISIBLE_ITEM_5_ENCHANTMENT = UnitFields.END + 0x438,
        VISIBLE_ITEM_6_ENTRYID = UnitFields.END + 0x43C,
        VISIBLE_ITEM_6_ENCHANTMENT = UnitFields.END + 0x440,
        VISIBLE_ITEM_7_ENTRYID = UnitFields.END + 0x444,
        VISIBLE_ITEM_7_ENCHANTMENT = UnitFields.END + 0x448,
        VISIBLE_ITEM_8_ENTRYID = UnitFields.END + 0x44C,
        VISIBLE_ITEM_8_ENCHANTMENT = UnitFields.END + 0x450,
        VISIBLE_ITEM_9_ENTRYID = UnitFields.END + 0x454,
        VISIBLE_ITEM_9_ENCHANTMENT = UnitFields.END + 0x458,
        VISIBLE_ITEM_10_ENTRYID = UnitFields.END + 0x45C,
        VISIBLE_ITEM_10_ENCHANTMENT = UnitFields.END + 0x460,
        VISIBLE_ITEM_11_ENTRYID = UnitFields.END + 0x464,
        VISIBLE_ITEM_11_ENCHANTMENT = UnitFields.END + 0x468,
        VISIBLE_ITEM_12_ENTRYID = UnitFields.END + 0x46C,
        VISIBLE_ITEM_12_ENCHANTMENT = UnitFields.END + 0x470,
        VISIBLE_ITEM_13_ENTRYID = UnitFields.END + 0x474,
        VISIBLE_ITEM_13_ENCHANTMENT = UnitFields.END + 0x478,
        VISIBLE_ITEM_14_ENTRYID = UnitFields.END + 0x47C,
        VISIBLE_ITEM_14_ENCHANTMENT = UnitFields.END + 0x480,
        VISIBLE_ITEM_15_ENTRYID = UnitFields.END + 0x484,
        VISIBLE_ITEM_15_ENCHANTMENT = UnitFields.END + 0x488,
        VISIBLE_ITEM_16_ENTRYID = UnitFields.END + 0x48C,
        VISIBLE_ITEM_16_ENCHANTMENT = UnitFields.END + 0x490,
        VISIBLE_ITEM_17_ENTRYID = UnitFields.END + 0x494,
        VISIBLE_ITEM_17_ENCHANTMENT = UnitFields.END + 0x498,
        VISIBLE_ITEM_18_ENTRYID = UnitFields.END + 0x49C,
        VISIBLE_ITEM_18_ENCHANTMENT = UnitFields.END + 0x4A0,
        VISIBLE_ITEM_19_ENTRYID = UnitFields.END + 0x4A4,
        VISIBLE_ITEM_19_ENCHANTMENT = UnitFields.END + 0x4A8,
        CHOSEN_TITLE = UnitFields.END + 0x4AC,
        FAKE_INEBRIATION = UnitFields.END + 0x4B0,
        PAD_0 = UnitFields.END + 0x4B4,
        INV_SLOT_HEAD = UnitFields.END + 0x4B8,
        PACK_SLOT_1 = UnitFields.END + 0x570,
        BANK_SLOT_1 = UnitFields.END + 0x5F0,
        BANKBAG_SLOT_1 = UnitFields.END + 0x6D0,
        VENDORBUYBACK_SLOT_1 = UnitFields.END + 0x708,
        KEYRING_SLOT_1 = UnitFields.END + 0x768,
        FARSIGHT = UnitFields.END + 0x868,
        KNOWN_TITLES = UnitFields.END + 0x870,
        KNOWN_TITLES1 = UnitFields.END + 0x878,
        KNOWN_TITLES2 = UnitFields.END + 0x880,
        XP = UnitFields.END + 0x888,
        NEXT_LEVEL_XP = UnitFields.END + 0x88C,
        SKILL_INFO_1_1 = UnitFields.END + 0x890,
        CHARACTER_POINTS = UnitFields.END + 0xE90,
        TRACK_CREATURES = UnitFields.END + 0xE94,
        TRACK_RESOURCES = UnitFields.END + 0xE98,
        BLOCK_PERCENTAGE = UnitFields.END + 0xE9C,
        DODGE_PERCENTAGE = UnitFields.END + 0xEA0,
        PARRY_PERCENTAGE = UnitFields.END + 0xEA4,
        EXPERTISE = UnitFields.END + 0xEA8,
        OFFHAND_EXPERTISE = UnitFields.END + 0xEAC,
        CRIT_PERCENTAGE = UnitFields.END + 0xEB0,
        RANGED_CRIT_PERCENTAGE = UnitFields.END + 0xEB4,
        OFFHAND_CRIT_PERCENTAGE = UnitFields.END + 0xEB8,
        SPELL_CRIT_PERCENTAGE1 = UnitFields.END + 0xEBC,
        SHIELD_BLOCK = UnitFields.END + 0xED8,
        SHIELD_BLOCK_CRIT_PERCENTAGE = UnitFields.END + 0xEDC,
        MASTERY = UnitFields.END + 0xEE0,
        EXPLORED_ZONES_1 = UnitFields.END + 0xEE4,
        REST_STATE_EXPERIENCE = UnitFields.END + 0x1124,
        COINAGE = UnitFields.END + 0x1128,
        MOD_DAMAGE_DONE_POS = UnitFields.END + 0x1130,
        MOD_DAMAGE_DONE_NEG = UnitFields.END + 0x114C,
        MOD_DAMAGE_DONE_PCT = UnitFields.END + 0x1168,
        MOD_HEALING_DONE_POS = UnitFields.END + 0x1184,
        MOD_HEALING_PCT = UnitFields.END + 0x1188,
        MOD_HEALING_DONE_PCT = UnitFields.END + 0x118C,
        MOD_SPELL_POWER_PCT = UnitFields.END + 0x1190,
        MOD_TARGET_RESISTANCE = UnitFields.END + 0x1194,
        MOD_TARGET_PHYSICAL_RESISTANCE = UnitFields.END + 0x1198,
        FIELD_BYTES = UnitFields.END + 0x119C,
        SELF_RES_SPELL = UnitFields.END + 0x11A0,
        PVP_MEDALS = UnitFields.END + 0x11A4,
        BUYBACK_PRICE_1 = UnitFields.END + 0x11A8,
        BUYBACK_TIMESTAMP_1 = UnitFields.END + 0x11D8,
        KILLS = UnitFields.END + 0x1208,
        LIFETIME_HONORBALE_KILLS = UnitFields.END + 0x120C,
        BYTES2 = UnitFields.END + 0x1210,
        WATCHED_FACTION_INDEX = UnitFields.END + 0x1214,
        COMBAT_RATING_1 = UnitFields.END + 0x1218,
        ARENA_TEAM_INFO_1_1 = UnitFields.END + 0x1280,
        BATTLEGROUND_RATING = UnitFields.END + 0x12D4,
        MAX_LEVEL = UnitFields.END + 0x12D8,
        DAILY_QUESTS_1 = UnitFields.END + 0x12DC,
        RUNE_REGEN_1 = UnitFields.END + 0x1340,
        NO_REAGENT_COST_1 = UnitFields.END + 0x1350,
        GLYPH_SLOTS_1 = UnitFields.END + 0x135C,
        GLYPHS_1 = UnitFields.END + 0x1380,
        GLYPHS_ENABLED = UnitFields.END + 0x13A4,
        PET_SPELL_POWER = UnitFields.END + 0x13A8,
        RESEARCHING_1 = UnitFields.END + 0x13AC,
        RESERACH_SITE_1 = UnitFields.END + 0x13CC,
        PROFESSION_SKILL_LINE_1 = UnitFields.END + 0x13EC,
        UI_HIT_MODIFIER = UnitFields.END + 0x13F4,
        UI_SPELL_HIT_MODIFIER = UnitFields.END + 0x13F8,
        HOME_REALM_TIME_OFFSET = UnitFields.END + 0x13FC,
        END = UnitFields.END + 0x1400
    };

    // Descriptors: 0x00C07728
    enum ContainerFields
    {
        NUM_SLOTS = ItemFields.END + 0x0,
        ALIGN_PAD = ItemFields.END + 0x4,
        SLOT_1 = ItemFields.END + 0x8,
        END = ItemFields.END + 0x128
    };

    // Descriptors: 0x00C097C8
    enum GameObjectFields
    {
        DISPLAYID = ObjectFields.END + 0x8,
        FLAGS = ObjectFields.END + 0xC,
        PARENTROTATION = ObjectFields.END + 0x10,
        DYNAMIC = ObjectFields.END + 0x20,
        FACTION = ObjectFields.END + 0x24,
        LEVEL = ObjectFields.END + 0x28,
        BYTES_1 = ObjectFields.END + 0x2C,
        END = ObjectFields.END + 0x30
    };

    // Descriptors: 0x00C09868
    enum DynamicObjectFields
    {
        CASTER = ObjectFields.END + 0x0,
        BYTES = ObjectFields.END + 0x8,
        SPELLID = ObjectFields.END + 0xC,
        RADIUS = ObjectFields.END + 0x10,
        CASTTIME = ObjectFields.END + 0x14,
        END = ObjectFields.END + 0x18
    };

    // Descriptors: 0x00C098D0
    enum CorpseFields
    {
        OWNER = ObjectFields.END + 0x0,
        PARTY = ObjectFields.END + 0x8,
        DISPLAY_ID = ObjectFields.END + 0x10,
        ITEM = ObjectFields.END + 0x14,
        BYTES_1 = ObjectFields.END + 0x60,
        BYTES_2 = ObjectFields.END + 0x64,
        FLAGS = ObjectFields.END + 0x68,
        DYNAMIC_FLAGS = ObjectFields.END + 0x6C,
        END = ObjectFields.END + 0x70
    };
    #endregion
}