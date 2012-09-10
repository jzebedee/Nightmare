#region Legal
/*
Copyright 2009 NaaBot Development Team
Copyright 2009 scorpion

This file is part of N2.

N2 is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

N2 is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with N2.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion Legal
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Bloodstream.Patchables
{
    #region Bot
    [Obfuscation]
    public enum BuyType
    {
        Unknown,
        Food,
        Drink,
        Ammo,
        Poison
    }

    internal enum DoStringOptions
    {
        AsScript,
        WrapReturns,
        Sync,
        Async,
    }

    [Obfuscation]
    public enum SkillCategory //TrainerServiceEntryType
    {
        Available,
        Header,
        Unavailable,
        Used
    }

    [Obfuscation]
    public enum GossipType
    {
        Banker,
        BattleMaster,
        Binder,
        Gossip,
        Tabard,
        Taxi,
        Trainer,
        Vendor
    }

    public class GossipOption
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public GossipType GossipType { get; set; }
    }


    public class TaxiOption
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public uint Cost { get; set; }
    }

    public class AvailableQuestOption
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public bool IsLowLevel { get; set; }
        public bool IsDaily { get; set; }
        public bool IsRepeatable { get; set; }
    }

    public class ActiveQuestOption
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public bool IsLowLevel { get; set; }
        public bool IsComplete { get; set; }
    }

    public class TradeSkillInfo
    {
        public int Index { get; set; }
        public string SkillName { get; set; }
        public string SkillType { get; set; }
        public int NumAvailable { get; set; }
        public bool IsExpanded { get; set; }
        public string Verb { get; set; }
    }

    public class QuestRewardInfo
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Count { get; set; }
        public string Quality { get; set; }
        public bool IsUsable { get; set; }
    }

    public class TrainerSkill
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string SubText { get; set; }
        public SkillCategory Category { get; set; }
        bool Expanded { get; set; }
        public int Cost { get; set; }
        public int RequiredLevel { get; set; }
    }

    public class TrainerSkillRequirement
    {
        public string Ability { get; set; }
        //public bool 
    }
    #endregion

    #region Enums.cs stuff (old)
    //public enum PlayerClass { Druid, Rogue, Shaman, Mage, Warrior, Warlock, DeathKnight, Paladin, Priest }
    // public enum PlayerRace { Human, NightElf, BloodElf, Orc, Tauren, Troll, Gnome, Dwarf, Dranei }
    [Obfuscation]
    public enum PlayerFaction { Alliance, Horde }
    [Obfuscation]
    public enum CommunicationChannel { Say, Whisper, Guild, Yell, Raid, Party, Trade, Custom }

    public enum MountType
    {
        EpicGroundOnly = 225,
        Flight = 229,
        Ground = 230,
        Aquatic = 231,
        AquaticVashjir = 232,
        TransformFlight = 238,
        AQMount = 241,
        ProfessionMount = 247,
        Scaling = 248,
    }

    //     Loot method
    [Obfuscation]
    public enum LootMethod
    {
        FreeForAll = 0,
        RoundRobin = 1,
        MasterLoot = 2,
        GroupLoot = 3,
        NeedBeforeGreed = 4,
        End = 5,
    }

    //     Loot threshold
    [Obfuscation]
    public enum LootItemQuality
    {
        Poor = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Artifact = 6,
        End = 7,
    }
    [Obfuscation]
    public enum GroupRole
    {
        Tank,
        OffTank,
        HealSupport,
        Dps,
        MiscSupport,
    }

    /// <summary>
    /// The mask is the corrosponding WoWClasss-value ^2 - 1
    /// </summary>
    [Flags]
    [Obfuscation]
    public enum ClassMask : uint
    {
        Warrior = 0x0001,
        Paladin = 0x0002,
        Hunter = 0x0004,
        Rogue = 0x0008,
        Priest = 0x0010,

        Shaman = 0x0040,
        Mage = 0x0080,
        Warlock = 0x0100,

        Druid = 0x0400
    }

    [Flags]
    [Obfuscation]
    public enum WoWRaceMask
    {
        Human = 0x00001,
        Orc = 0x00002,
        Dwarf = 0x00004,
        Nightelf = 0x00008,
        Undead = 0x00010,
        Tauren = 0x00020,
        Gnomoe = 0x00040,
        Troll = 0x00080,
        Goblin = 0x00100,
        Bloodelf = 0x00200,
        Draenei = 0x00400,
        FelOrc = 0x00800,
        Naga = 0x01000,
        Broken = 0x02000,
        Skeleton = 0x04000
    }

    [Obfuscation]
    public enum SpellPowerType : int
    {
        Health = -2,
        Mana = 0,
        Rage = 1,
        Focus = 2,
        Energy = 3,
        Happiness = 4,
        Runes = 5,
        RunicPower = 6,
        SoulShards = 7,
        Eclipse = 8,
        HolyPower = 9
    }

    [Flags]
    [Obfuscation]
    public enum NpcUdbFlags
    {
        None = 0,
        Gossip = 1,
        Quest = 2,
        Trainer = 16,
        ClassTrainer = 32,
        ProfessionTrainer = 64,
        Vendor = 128,
        Ammo = 256,
        Food = 512,
        Poison = 1024,
        Reagent = 2048,
        Repair = 4096,
        FlightMaster = 8192,
        SpiritHealer = 16384,
        SpiritGuide = 32768,
        Innkeeper = 65536,
        Banker = 131072,
        Petitioner = 262144,
        Tabard = 524288,
        BattleMaster = 1048576,
        Auctioneer = 2097152,
        StableMaster = 4194304,
        Guard = 268435456
    }

    [Obfuscation]
    public enum NpcEntryType
    {
        SpiritGuide = 6,	// pre 2.3.0

        Gossip = 1,
        QuestGiver = 2,
        Trainer = 4,
        Vendor = 7,
        Armorer = 12,
        TaxiVendor = 13,
        ProfessionTrainer = 14,
        SpiritHealer = 15,
        InnKeeper = 16,
        Banker = 17,
        ArenaPetitioner = 18,
        TabardVendor = 19,
        BattleMaster = 20,
        Auctioneer = 21,
        Stable = 22,
        GuildBanker = 23
    }

    [Flags]
    [Obfuscation]
    public enum NpcEntryTypeMask
    {
        SpiritGuide = 0x00000040,	// pre 2.3.0
        GuildPetitioner = 0x00000600,	// pre 2.3.0
        None = 0x00000000,
        Gossip = 0x00000001,
        QuestGiver = 0x00000002,
        Trainer = 0x00000010,
        Vendor = 0x00000080,
        Armorer = 0x00001000,
        TaxiVendor = 0x00002000,
        ProfessionTrainer = 0x00004000,
        SpiritHealer = 0x00008000,
        InnKeeper = 0x00010000,
        Banker = 0x00020000,
        ArenaPetitioner = 0x00040000,
        TabardVendor = 0x00080000,
        BattleMaster = 0x00100000,
        Auctioneer = 0x00200000,
        Stable = 0x00400000,
        GuildBanker = 0x00800000
    }


    /// <summary>
    /// Update Types used in SMSG_UPDATE_OBJECT inside realm server
    /// </summary>
    public enum UpdateType : byte
    {
        Values = 0,
        Movement = 1,
        Create = 2,
        CreateSelf = 3,
        OutOfRange = 4,
        Near = 5
    }

    /// <summary>
    /// Object Type Ids are used in SMSG_UPDATE_OBJECT inside realm server
    /// </summary>
    [Obfuscation]
    public enum ObjectTypeId
    {
        Object = 0,
        Item = 1,
        Container = 2,
        Unit = 3,
        Player = 4,
        GameObject = 5,
        DynamicObject = 6,
        Corpse = 7,
        AIGroup = 8,
        AreaTrigger = 9,
        Count,
        None = 0xFF
    }

    [Flags]
    [Obfuscation]
    public enum ObjectTypes : uint
    {
        None = 0,
        Object = 0x1,
        Item = 0x2,
        Container = 0x4,
        /// <summary>
        /// Any unit
        /// </summary>
        Unit = 0x8,
        Player = 0x10,
        GameObject = 0x20,
        /// <summary>
        /// Any Unit or GameObject
        /// </summary>
        Attackable = 0x28,
        DynamicObject = 0x40,
        Corpse = 0x80,
        AIGroup = 0x100,
        AreaTrigger = 0x200,
        All = 0xFFFF,
    }

    /// <summary>
    /// Custom enum to enable further distinction between Units
    /// </summary>
    [Flags]
    [Obfuscation]
    public enum ObjectTypeCustom
    {
        None = 0,
        Object = 0x1,
        Item = 0x2,
        Container = 0x6,
        /// <summary>
        /// Any unit
        /// </summary>
        Unit = 0x8,
        Player = 0x10,
        GameObject = 0x20,
        /// <summary>
        /// Any Unit or GameObject
        /// </summary>
        Attackable = 0x28,
        DynamicObject = 0x40,
        Corpse = 0x80,
        AIGroup = 0x100,
        AreaTrigger = 0x200,
        NPC = 0x1000,
        Pet = 0x2000,
        All = 0xFFFF
    }


    public enum MonsterMoveType
    {
        Normal = 0,
        Stop = 1,
        FinalFacingPoint = 2,
        FinalFacingGuid = 3,
        FinalFacingAngle = 4,
    }
    [Flags]
    public enum MonsterMoveFlags : uint
    {
        None = 0,
        Flag_0x1 = 1,
        Flag_0x2 = 2,
        Flag_0x4 = 4,
        Flag_0x8 = 8,
        Flag_0x10 = 16,
        Flag_0x20 = 32,
        Flag_0x40 = 64,
        Flag_0x80 = 128,
        Flag_0x100 = 256,
        Flag_0x200 = 512,
        Flag_0x400 = 1024,
        //
        // Summary:
        //     Adds a float and uint to the packet
        Flag_0x800 = 2048,
        //
        // Summary:
        //     The monster will run unless this is set
        Walk = 4096,
        //
        // Summary:
        //     The default mask sets the Run flag and the flag that makes the client expect
        //     full vector3's for the intermediate points
        DefaultMask = 8192,
        //
        // Summary:
        //     Client expects points in full vector3 format
        Flag_0x2000_FullPoints_1 = 8192,
        Fly = 8192,
        Flag_0x4000 = 16384,
        Flag_0x8000 = 32768,
        Flag_0x10000 = 65536,
        Flag_0x20000 = 131072,
        //
        // Summary:
        //     Client expects points in full vector3 format
        Flag_0x40000_FullPoints_2 = 262144,
        Flag_0x80000 = 524288,
        Flag_0x100000 = 1048576,
        //
        // Summary:
        //     Adds a byte and uint to the packet
        Flag_0x200000 = 2097152,
        Flag_0x400000 = 4194304,
        Flag_0x800000 = 8388608,
        Flag_0x1000000 = 16777216,
        Flag_0x2000000 = 33554432,
        Flag_0x4000000 = 67108864,
        Flag_0x8000000 = 134217728,
        Flag_0x10000000 = 268435456,
        Flag_0x20000000 = 536870912,
        Flag_0x40000000 = 1073741824,
        Flag_0x80000000 = 2147483648,
    }

    [Flags]
    public enum MovementFlags : uint
    {
        // Byte 1 (Resets on Movement Key Press)
        MOVEFLAG_MOVE_STOP = 0x00,			//verified
        MOVEFLAG_MOVE_FORWARD = 0x01,			//verified
        MOVEFLAG_MOVE_BACKWARD = 0x02,			//verified
        MOVEFLAG_STRAFE_LEFT = 0x04,			//verified
        MOVEFLAG_STRAFE_RIGHT = 0x08,			//verified
        MOVEFLAG_TURN_LEFT = 0x10,			//verified
        MOVEFLAG_TURN_RIGHT = 0x20,			//verified
        MOVEFLAG_PITCH_DOWN = 0x40,			//Unconfirmed
        MOVEFLAG_PITCH_UP = 0x80,			//Unconfirmed

        // Byte 2 (Resets on Situation Change)
        MOVEFLAG_WALK = 0x100,		//verified
        MOVEFLAG_TAXI = 0x200,
        MOVEFLAG_NO_COLLISION = 0x400,
        MOVEFLAG_FLYING = 0x800,		//verified
        MOVEFLAG_REDIRECTED = 0x1000,		//Unconfirmed
        MOVEFLAG_FALLING = 0x2000,       //verified
        MOVEFLAG_FALLING_FAR = 0x4000,		//verified
        MOVEFLAG_FREE_FALLING = 0x8000,		//half verified

        // Byte 3 (Set by server. TB = Third Byte. Completely unconfirmed.)
        MOVEFLAG_TB_PENDING_STOP = 0x10000,		// (MOVEFLAG_PENDING_STOP)
        MOVEFLAG_TB_PENDING_UNSTRAFE = 0x20000,		// (MOVEFLAG_PENDING_UNSTRAFE)
        MOVEFLAG_TB_PENDING_FALL = 0x40000,		// (MOVEFLAG_PENDING_FALL)
        MOVEFLAG_TB_PENDING_FORWARD = 0x80000,		// (MOVEFLAG_PENDING_FORWARD)
        MOVEFLAG_TB_PENDING_BACKWARD = 0x100000,		// (MOVEFLAG_PENDING_BACKWARD)
        MOVEFLAG_SWIMMING = 0x200000,		//  verified
        MOVEFLAG_FLYING_PITCH_UP = 0x400000,		// (half confirmed)(MOVEFLAG_PENDING_STR_RGHT)
        MOVEFLAG_TB_MOVED = 0x800000,		// (half confirmed) gets called when landing (MOVEFLAG_MOVED)

        // Byte 4 (Script Based Flags. Never reset, only turned on or off.)
        MOVEFLAG_AIR_SUSPENSION = 0x1000000,	// confirmed allow body air suspension(good name? lol).
        MOVEFLAG_AIR_SWIMMING = 0x2000000,	// confirmed while flying.
        MOVEFLAG_SPLINE_MOVER = 0x4000000,	// Unconfirmed
        MOVEFLAG_IMMOBILIZED = 0x8000000,
        MOVEFLAG_WATER_WALK = 0x10000000,
        MOVEFLAG_FEATHER_FALL = 0x20000000,	// Does not negate fall damage.
        MOVEFLAG_LEVITATE = 0x40000000,
        MOVEFLAG_LOCAL = 0x80000000,	// This flag defaults to on. (Assumption)

        // Masks
        MOVEFLAG_MOVING_MASK = 0x03,
        MOVEFLAG_STRAFING_MASK = 0x0C,
        MOVEFLAG_TURNING_MASK = 0x30,
        MOVEFLAG_FALLING_MASK = 0x6000,
        MOVEFLAG_MOTION_MASK = 0xE00F,		// Forwards, Backwards, Strafing, Falling
        MOVEFLAG_PENDING_MASK = 0x7F0000,
        MOVEFLAG_PENDING_STRAFE_MASK = 0x600000,
        MOVEFLAG_PENDING_MOVE_MASK = 0x180000,
        MOVEFLAG_FULL_FALLING_MASK = 0xE000,
    };

    [Flags]
    public enum MovementFlags2
    {
        None = 0,
        /// <summary>        
        /// 0x20        
        /// </summary>        
        AlwaysAllowPitching = 0x20,
        InterpMask = 0x400 | 0x800 | 0x1000,
    }

    [Flags]
    public enum SpellTargetFlags : uint
    {
        Self = 0x0000,
        TargetFlag0x0001 = 0x0001,
        Unit = 0x0002,
        TargetFlag0x0004 = 0x0004,
        TargetFlag0x0008 = 0x0008,
        Item = 0x0010,
        SourceLocation = 0x0020,
        DestinationLocation = 0x0040,
        TargetFlag0x0080 = 0x0080,
        TargetFlag0x0100 = 0x0100,
        PvPCorpse = 0x0200,
        TargetFlag0x400 = 0x0400,
        Object = 0x0800,
        TradeItem = 0x1000,
        String = 0x2000,
        /// <summary>
        /// Target also sends orientation
        /// </summary>
        OrientedLocation = 0x4000,
        Corpse = 0x8000,
        Flag_0x10000 = 0x10000,
        Glyph = 0x20000,
    }
    [Obfuscation]
    public enum SpellFailedReason : byte
    {
        AffectingCombat = 0,
        AlreadyAtFullHealth = 1,
        AlreadyAtFullMana = 2,
        AlreadyAtFullPower = 3,
        AlreadyBeingTamed = 4,
        AlreadyHaveCharm = 5,
        AlreadyHaveSummon = 6,
        AlreadyOpen = 7,
        AuraBounced = 8,
        AutotrackInterrupted = 9,
        BadImplicitTargets = 10,
        BadTargets = 11,
        CantBeCharmed = 12,
        CantBeDisenchanted = 13,
        CantBeDisenchantedSkill = 14,
        CantBeMilled = 15,
        CantBeProspected = 16,
        CantCastOnTapped = 17,
        CantDuelWhileInvisible = 18,
        CantDuelWhileStealthed = 19,
        CantStealth = 20,
        CasterAurastate = 21,
        CasterDead = 22,
        Charmed = 23,
        ChestInUse = 24,
        Confused = 25,
        DontReport = 26,
        EquippedItem = 27,
        EquippedItemClass = 28,
        EquippedItemClassMainhand = 29,
        EquippedItemClassOffhand = 30,
        Error = 31,
        Fizzle = 32,
        Fleeing = 33,
        FoodLowlevel = 34,
        Highlevel = 35,
        HungerSatiated = 36,
        Immune = 37,
        IncorrectArea = 38,
        Interrupted = 39,
        InterruptedCombat = 40,
        ItemAlreadyEnchanted = 41,
        ItemGone = 42,
        ItemNotFound = 43,
        ItemNotReady = 44,
        LevelRequirement = 45,
        LineOfSight = 46,
        Lowlevel = 47,
        LowCastlevel = 48,
        MainhandEmpty = 49,
        Moving = 50,
        NeedAmmo = 51,
        NeedAmmoPouch = 52,
        NeedExoticAmmo = 53,
        NeedMoreItems = 54,
        Nopath = 55,
        NotBehind = 56,
        NotFishable = 57,
        NotFlying = 58,
        NotHere = 59,
        NotInfront = 60,
        NotInControl = 61,
        NotKnown = 62,
        NotMounted = 63,
        NotOnTaxi = 64,
        NotOnTransport = 65,
        NotReady = 66,
        NotShapeshift = 67,
        NotStanding = 68,
        NotTradeable = 69,
        NotTrading = 70,
        NotUnsheathed = 71,
        NotWhileGhost = 72,
        NotWhileLooting = 73,
        NoAmmo = 74,
        NoChargesRemain = 75,
        NoChampion = 76,
        NoComboPoints = 77,
        NoDueling = 78,
        NoEndurance = 79,
        NoFish = 80,
        NoItemsWhileShapeshifted = 81,
        NoMountsAllowed = 82,
        NoPet = 83,
        NoPower = 84,
        NothingToDispel = 85,
        NothingToSteal = 86,
        OnlyAbovewater = 87,
        OnlyDaytime = 88,
        OnlyIndoors = 89,
        OnlyMounted = 90,
        OnlyNighttime = 91,
        OnlyOutdoors = 92,
        OnlyShapeshift = 93,
        OnlyStealthed = 94,
        OnlyUnderwater = 95,
        OutOfRange = 96,
        Pacified = 97,
        Possessed = 98,
        Reagents = 99,
        RequiresArea = 100,
        RequiresSpellFocus = 101,
        Rooted = 102,
        Silenced = 103,
        SpellInProgress = 104,
        SpellLearned = 105,
        SpellUnavailable = 106,
        Stunned = 107,
        TargetsDead = 108,
        TargetAffectingCombat = 109,
        TargetAurastate = 110,
        TargetDueling = 111,
        TargetEnemy = 112,
        TargetEnraged = 113,
        TargetFriendly = 114,
        TargetInCombat = 115,
        TargetIsPlayer = 116,
        TargetIsPlayerControlled = 117,
        TargetNotDead = 118,
        TargetNotInParty = 119,
        TargetNotLooted = 120,
        TargetNotPlayer = 121,
        TargetNoPockets = 122,
        TargetNoWeapons = 123,
        TargetNoRangedWeapons = 124,
        TargetUnskinnable = 125,
        ThirstSatiated = 126,
        TooClose = 127,
        TooManyOfItem = 128,
        TotemCategory = 129,
        Totems = 130,
        TryAgain = 131,
        UnitNotBehind = 132,
        UnitNotInfront = 133,
        WrongPetFood = 134,
        NotWhileFatigued = 135,
        TargetNotInInstance = 136,
        NotWhileTrading = 137,
        TargetNotInRaid = 138,
        TargetFreeforall = 139,
        NoEdibleCorpses = 140,
        OnlyBattlegrounds = 141,
        TargetNotGhost = 142,
        TransformUnusable = 143,
        WrongWeather = 144,
        DamageImmune = 145,
        PreventedByMechanic = 146,
        PlayTime = 147,
        Reputation = 148,
        MinSkill = 149,
        NotInArena = 150,
        NotOnShapeshift = 151,
        NotOnStealthed = 152,
        NotOnDamageImmune = 153,
        NotOnMounted = 154,
        TooShallow = 155,
        TargetNotInSanctuary = 156,
        TargetIsTrivial = 157,
        BmOrInvisgod = 158,
        ExpertRidingRequirement = 159,
        ArtisanRidingRequirement = 160,
        NotIdle = 161,
        NotInactive = 162,
        PartialPlaytime = 163,
        NoPlaytime = 164,
        NotInBattleground = 165,
        NotInRaidInstance = 166,
        OnlyInArena = 167,
        TargetLockedToRaidInstance = 168,
        OnUseEnchant = 169,
        NotOnGround = 170,
        CustomError = 171,
        CantDoThatRightNow = 172,
        TooManySockets = 173,
        InvalidGlyph = 174,
        UniqueGlyph = 175,
        GlyphSocketLocked = 176,
        NoValidTargets = 177,
        ItemAtMaxCharges = 178,
        NotInBarbershop = 179,
        FishingTooLow = 180,
        ItemEnchantTradeWindow = 181,
        Unknown = 182,
        Ok = 0xFF
    }
    [Obfuscation]
    public enum SpellFocus : uint
    {
        None = 0,
        Anvil = 1,
        Loom = 2,
        Forge = 3,
        CookingFire = 4,
        ShardsOfMyzrael = 5,
        WinterhoofWaterWell = 6,
        ThunderhornWaterWell = 7,
        WildmaneWaterWell = 8,
        TribalFire = 9,
        MachineShop = 10,
        ShadowglenMoonwell = 11,
        StarbreezeVillageMoonwell = 12,
        PoolsOfArlithrienMoonwell = 13,
        OracleGladeMoonwell = 14,
        VentureCoAirport = 15,
        VentureCoWagonBlue = 16,
        VentureCoWagonRed = 17,
        NG5ExplosivesRed = 18,
        NG5ExplosivesBlue = 19,
        FlameOfUzel = 20,
        AshenvaleMoonwell = 21,
        SeawornAltar = 22,
        NearbyTubers = 23,
        UndercitySummoningCircle = 43,
        ShamanShrine = 63,
        StormwindSummoningCircle = 83,
        BarrensSummoningCircle = 103,
        MirrorLakeWaterfall = 123,
        TalonDen = 143,
        XavianWaterfall = 163,
        StoneOfOuterBinding = 164,
        ManaRiftDisturbance = 183,
        OrgrimmarSummoningCircle = 203,
        RuinsOfStardustFountain = 223,
        QuilboarWateringHole = 224,
        WaterPuritySilverpine = 225,
        SpringWell = 226,
        TempleOfTheMoonFountain = 243,
        JinthaAlorAltar = 263,
        PirateShipBilge = 264,
        EquinexMonolith = 283,
        WitherbarkVillage = 303,
        ShadraAlorAltar = 304,
        SandsorrowWatchWaterHole = 323,
        HatetalonStones = 343,
        EcheyakeesLair = 363,
        TheDeadTree = 383,
        MakeshiftHelipad = 403,
        CircleOfAquementas = 423,
        SanctumOfTheFallenGod = 424,
        TheFirstTidePool = 443,
        TheSecondTidePool = 444,
        TheThirdTidePool = 445,
        TheFourthTidePool = 446,
        GorishiHiveHatchery = 463,
        MiblonSnarltooth = 483,
        GadgetzanGraveyard = 503,
        TheRuinsOfIrontreeWoods = 523,
        BlackForge = 543,
        GolakkaCrater = 563,
        TombOfTheSeven = 583,
        FlatUnGoroRock = 603,
        PreservedThreshadonCarcass = 604,
        BlackAnvil = 623,
        GorishiSilithidCrystal = 643,
        CorruptedMoonwell = 644,
        AlchemyLab = 663,
        UnforgedSealOfAscension = 683,
        AuberdineMoonwell = 703,
        BlackwoodFurbolgNorthBonfire = 704,
        CliffspringRiverWaterfall = 705,
        FirePlumeRidgeHotSpot = 723,
        UroksTributePile = 743,
        AndorhalSiloTemporalRift = 763,
        StoneOfShyRotam = 783,
        SacredFireOfLife = 803,
        ScarletCrusadeForwardCamp = 804,
        AndorhalTower = 805,
        ScholomanceViewingRoom = 823,
        TheJaedenarCorruptMoonWell = 843,
        UmisFriend = 863,
        Moonwell = 883,
        FirePlumeRidgeLavaLake = 903,
        TheCrateInTheCenterOfTheNorthridgeLumberMill = 923,
        MoonkinStone = 943,
        DarrowshireTownSquare = 944,
        BrightLightBeam = 963,
        MarkOfDetonation = 983,
        CliffspringFallsCaveMouth = 1003,
        DreadmistPeakPool = 1004,
        TheDeadGoliaths = 1023,
        ShrineOfRemulos = 1043,
        FoulwealdTotemMound = 1063,
        DirePool = 1083,
        MaraudonPortal = 1103,
        HordeGlobeOfScrying = 1123,
        EasternCrater = 1143,
        WesternCrater = 1144,
        SnowfallGraveyard = 1145,
        AllianceGlobeOfScrying = 1163,
        DunBaldarCourtyard = 1164,
        FrostwolfKeepCourtyard = 1165,
        SnowfallGraveyard_2 = 1183,
        EastCrater = 1184,
        WestCrater = 1185,
        OrangeCrystalPool = 1203,
        OnyxiasFlameBreath = 1223,
        KroshiusRemains = 1243,
        PedestalOfImmolThar = 1263,
        CircleOfDarkSummoning = 1264,
        TheGreatOssuary = 1283,
        TerrordaleHauntingSpirit = 1284,
        AeriePeakTownCenter = 1303,
        UthersTombStatue = 1323,
        GromsMonument = 1324,
        PaglesPointe = 1343,
        AltarOfZanza = 1344,
        Southshore = 1345,
        BonesOfGrakkarond = 1346,
        ForsakenStinkBomb = 1347,
        DropOffPoint = 1348,
        SwirlingMaelstrom = 1349,
        HighChiefWinterfallsCave = 1350,
        FireworkLauncher = 1351,
        ClusterLauncher = 1352,
        GreaterMoonlight = 1353,
        VoonesChamber = 1354,
        AlzzinsChamber = 1355,
        TheCrimsonThrone = 1356,
        RasFrostwhispersChamber = 1357,
        TheBeastsChamber = 1358,
        HauntedLocus = 1359,
        BlackrockDepthsArena = 1360,
        PHCrystalCorpse = 1361,
        IcebellowAnvil = 1362,
        EversongRunestone = 1363,
        ConsecratedEarth = 1364,
        MidsummerBonfire = 1365,
        Maypole = 1366,
        AltarOfAggonar = 1367,
        BonesOfAggonar = 1368,
        SchoolOfRedSnapper = 1369,
        KrunSpinebreakersCorpse = 1370,
        ThalanaarMoonwell = 1371,
        ConcealedControlPanel = 1372,
        AltarOfNaias = 1373,
        DiscreetLocation = 1374,
        RuneOfSummoning = 1375,
        FelBrazier = 1376,
        YouToBeInTraitorsCoveWhileTheNagaFlagIsUp = 1377,
        SedaisCorpse = 1378,
        NazzivusMonument = 1379,
        ImpactSiteCrystal = 1380,
        AlteredBloodmystCrystal = 1381,
        AxxarienCrystal = 1382,
        TheSouthernEndOfTheMastersTerrace = 1383,
        MedivhsTelescope = 1384,
        AlonsusChapelEternalFlame = 1385,
        BloodmystWaterfall = 1386,
        SteamPumpControls = 1387,
        WindyreedHut = 1388,
        EarthenBrand = 1389,
        UndergroundWaterSource = 1390,
        BohaMuRuinsStairs = 1391,
        DaggerfenRock = 1392,
        BurningBladePyreInTheBurningBladeRuins = 1393,
        YsielsBalcony = 1394,
        BlazingWarmaulPyre = 1395,
        VeilShalasTotem = 1396,
        TrampledSkeleton = 1397,
        AllianceCannon = 1398,
        HordeBladeThrower = 1399,
        LegionAntenna = 1400,
        ScorchedGroveRunestone = 1401,
        Bookcase = 1402,
        WeaponRack = 1403,
        Dresser = 1404,
        Footlocker = 1405,
        RuinedAllianceSiegeTower = 1406,
        UncontrolledScrapReaverX6000 = 1407,
        KirinVarRune = 1408,
        ArchmageVargothsOrb = 1409,
        ElrendarFalls = 1410,
        DragonSkeleton = 1411,
        EtherealTeleportPad = 1412,
        ArklonBrazier = 1413,
        VoidStone = 1414,
        ManaforgeBNaarPipe = 1415,
        DraeneiBanner = 1416,
        EarthbindersCircle = 1417,
        SalhadaarsPowerConduit = 1418,
        SocretharsTeleporter = 1419,
        EcoDomeSuthronGenerator = 1420,
        YouToBeCloserToManaforgeUltris = 1421,
        NorthmaulTower = 1422,
        AltarOfShadows = 1423,
        ShadowmoonTuberMound = 1424,
        RokgahBloodgrip = 1425,
        ManaLoom = 1426,
        AncientDraeneiAltar = 1427,
        OgreBuildingEntrance = 1428,
        BladesEdgeArakkoaCircle = 1429,
        LashhAnSpellCircle = 1430,
        VekhNirCircleOfPower = 1431,
        YouToBeAtTheEndOfTheBridge = 1432,
        TorgossBane = 1433,
        VekhNirSpellCircle = 1434,
        YouToBeStandingNextToGulDanAtTheAltarOfDamnation = 1435,
        LegionHoldTeleporter = 1436,
        RuuanOkOracleCircle = 1437,
        LegionCommunicationDevice = 1438,
        ForemanRazelcraz = 1439,
        PortalAtMarshlightLake = 1440,
        BladesEdgeQuestBirdSpying = 1441,
        MalukazsCandles = 1442,
        BleedingHollowForge = 1443,
        MarmotDen = 1444,
        GehennaTeleporter = 1445,
        ForceCommanderGoraxsCorpse = 1446,
        ZethGorTower = 1447,
        UnguardedSummoningSite = 1448,
        LockedWyvernCage = 1449,
        GorgromsCorpse = 1450,
        DeathsDoorFelCannon = 1451,
        WrithingMoundSummoningCircle = 1452,
        AltarOfGocAndThatGocHasNotBeenSummoned = 1453,
        TheRavensClaw = 1454,
        ArakkoaShrine = 1455,
        SoulgrindersAltar = 1456,
        ShartuulsTransporterPlatform = 1457,
        ShipwreckDebris = 1458,
        BlackhoofVillageWindmill = 1459,
        GrimtotemTent = 1460,
        HyalFamilyMonument = 1461,
        BurningTrollHut = 1462,
        EntranceToOnyxiasLair = 1463,
        SwamplightManorDock = 1464,
        TheWyrmlordsPlatform = 1465,
        ShatteredStrandCannon = 1466,
        CannonOnNorthernAllianceWall = 1467,
        TheThanesPyre = 1468,
        FrozenWaterfall = 1469,
        ProximityToPlaguehoundCagesAtVengeanceLanding = 1470,
        StandingAtTheBoothCounter = 1471,
        CauldronOfVrykulBlood = 1472,
        HarrissPlagueSamples = 1473,
        YouToBeCloserToPlaguehoundCages = 1474,
        BrokenTablet = 1475,
        SunkenBoat = 1476,
        CenterOfBaleheim = 1477,
        BrewfestMugRequest = 1478,
        WaltsTransportRune = 1479,
        IronDwarfTransportRune = 1480,
        LeyLinesOfQuelDanas = 1481,
        RazorthornDirtMound = 1482,
        CrystalWard = 1483,
        LegionTeleporter = 1484,
        HauthaasAnvil = 1485,
        VrykulBurialMound = 1486,
        WestriftSeismicAnomaly = 1487,
        JSBReusePost240 = 1488,
        NerubArSinkhole = 1489,
        SnarlfangsTotem = 1490,
        EnKilahCauldron = 1491,
        YouToBeAtOrNearTheFrontOfAKvaldirShip = 1492,
        YouToBeStandingAtTheEndOfWarsongJetty = 1493,
        ImprisonedBerylSorcerer = 1494,
        BerylForceShield = 1495,
        DenOfDyingPlagueCauldron = 1496,
        SouthSinkhole = 1497,
        YouToBeAtTheCrossroadsEastOfWarsongHoldWithAnAllianceDeserterInTow = 1498,
        YouToBeStandingNextToBloodmageLaurithAtTheBloodsporePlains = 1499,
        ShatteredSunPortal = 1500,
        ShatteredSunPortal_2 = 1501,
        CrashedFlyingMachine = 1502,
        GeyserFieldsSteamVent = 1503,
        NexusDimensionalRift = 1504,
        FarshireGrain = 1505,
        SaragosasLanding = 1506,
        ProximityToAScourgeSinkhole = 1507,
        NorthwestNexusEntrance = 1508,
        DrakurusBrazier = 1509,
        EastEndOfThorModanTunnel = 1510,
        TuaKeasFishingHook = 1511,
        ToaluUsBrazier = 1512,
        FizzcrankPracticeParachuteZone = 1513,
        FizzcrankParatrooperTeleporter = 1514,
        LeyLineFocusOnTheBeach = 1515,
        LeyLineFocusInTheLothalorWoodlands = 1516,
        LeyLineFocusUnderTheLake = 1517,
        DrakilJinGongs = 1518,
        MarkedColdwindTree = 1519,
        CenterOfThePitUnderTheSurgeNeedle = 1520,
        DepthsBelowVordrassilsRemains = 1521,
        DepthsBelowVordrassilsLimb = 1522,
        DepthsBelowVordrassilsTears = 1523,
        HanselBauer = 1524,
        GromTharsChallengingArea = 1525,
        WintergardeGryphonStation = 1526,
        NewHearthglenLumbermill = 1527,
        VordrassilsSapling = 1528,
        Basecamp = 1529,
        ObsidianDragonshrineExitPath = 1530,
        YouToBeStandingNextToSiegeEngineerQuarterflash = 1531,
        NecromanticRune = 1532,
        YouToBeStandingAtOneOfTheEntrancePointsToWintergardeMine = 1533,
        SchoolOfNorthernSalmon = 1534,
        YouToBeStandingInTheCenterOfTheRuinsAtTheForgottenShore = 1535,
        YouToBeAtTheFrontOfTheWintergardeMausoleum = 1536,
        RuunasCrystalBall = 1537,
        SquirePercy = 1538,
        ThatYouBeCloserToAlystrosTheVerdantKeeper = 1539,
        FrostmourneAltar = 1540,
        ThatYouBeOnTheSandsOfTheBronzeDragonshrine = 1541,
        VrykulHawkRoost = 1542,
        ScourgedMummyFire = 1543,
        DrakkariRitualStatue = 1544,
        FinklesteinsCauldron = 1545,
        MistwhisperWeatherShrine = 1546,
        OfferingBowl = 1547,
        DrakkariPedestal = 1548,
        FallenLog = 1549,
        AncientDirtMound = 1550,
        NerubianCrater = 1551,
        Runeforge = 1552,
        LandingPad = 1553,
        Scourgewagon = 1554,
        QuetzLunsCorpseAndThatTheProphetOfQuetzLunBePresentAndUnengaged = 1555,
        AltarOfKartak = 1556,
        GreatLightningStone = 1557,
        WarlordZolMazPresentAndUnengagedInCombat = 1558,
        TopOfTheSuntouchedPillar = 1559,
        ConvocationSummoningCircle = 1560,
        SoakedFertileDirt = 1561,
        TopOfSholazarPillar = 1562,
        TopOfTheGlimmeringPillar = 1563,
        ExposedLifebloodPillarCrystal = 1564,
        UzoDeathcaller = 1565,
        ArchbishopLandgrensCorpseAndLordCommanderAreteNotBePresent = 1566,
        SchoolOfTastyReefFish = 1567,
        MagmawyrmResurrectionChamber = 1568,
        FrostgutsAltar = 1569,
        GarmTeleporter = 1570,
        ThaneUfrangTheMightyPresentAndSeated = 1571,
        NorthernIceSpike = 1572,
        IcyCrater = 1573,
        VanguardInfirmary = 1574,
        Snowdrift = 1575,
        TheBroodmothersNest = 1576,
        K3Landing = 1577,
        ThaneIllskarBePresentAndThatHeAndHisChampionsNotBeEngagedInBattle = 1578,
        PileOfCrusaderSkulls = 1579,
        MalykrissFurnace = 1580,
        AhnKahetBrazier = 1581,
        SanctumOfReanimationSlab = 1582,
        DalaranFountain = 1583,
        YmirheimPeakSkulls = 1584,
        MordRetharPlagueCauldron = 1585,
        GrimkorsOrb = 1586,
        CultistsCauldron = 1587,
        AlumethsSoulstone = 1588,
        YouToBeNearALexiconOfPower = 1589,
        SmolderingScrap = 1590,
        AltarOfTheEbonDepths = 1591,
        CorpseOfTheFallenWorg = 1592,
        UnlitSignalFire = 1596,
        End
    }

    public enum FactionRepListId
    {
        None = 0,
        BootyBay = 1,
        GelkisClanCentaur = 2,
        MagramClanCentaur = 3,
        ThoriumBrotherhood = 4,
        Ravenholdt = 5,
        Syndicate = 6,
        Gadgetzan = 7,
        Ratchet = 9,
        SteamwheedleCartel = 10,
        Alliance = 11,
        Horde = 12,
        ArgentDawn = 13,
        Orgrimmar = 14,
        DarkspearTrolls = 15,
        ThunderBluff = 16,
        Undercity = 17,
        GnomereganExiles = 18,
        Stormwind = 19,
        Ironforge = 20,
        Darnassus = 21,
        WintersaberTrainers = 27,
        Everlook = 28,
        TimbermawHold = 35,
        CenarionCircle = 36,
        Thrallmar = 37,
        HonorHold = 38,
        TheShaTar = 39,
        StormpikeGuard = 40,
        FrostwolfClan = 41,
        HydraxianWaterlords = 42,
        ShenDralar = 44,
        SilverwingSentinels = 45,
        WarsongOutriders = 46,
        Exodar = 49,
        DarkmoonFaire = 50,
        ZandalarTribe = 51,
        TheDefilers = 52,
        TheLeagueOfArathor = 53,
        BroodOfNozdormu = 54,
        SilvermoonCity = 55,
        Tranquillien = 56,
        TheScaleOfTheSands = 57,
        TheAldor = 58,
        TheConsortium = 60,
        TheMagHar = 61,
        TheScryers = 62,
        TheVioletEye = 63,
        CenarionExpedition = 64,
        Sporeggar = 65,
        Kurenai = 66,
        KeepersOfTime = 67,
        LowerCity = 69,
        AshtongueDeathsworn = 70,
        Netherwing = 71,
        ShaTariSkyguard = 72,
        OgriLa = 73,
        ValianceExpedition = 74,
        HordeExpedition = 75,
        TheTaunka = 76,
        TheHandOfVengeance = 77,
        ExplorersLeague = 78,
        TheKaluAk = 79,
        ShatteredSunOffensive = 80,
        WarsongOffensive = 81,
        REUSE = 82,
        TheWyrmrestAccord = 83,
        KirinTor = 84,
        TestFaction1 = 85,
        TestFaction3 = 87,
        TheSilverCovenant = 90,
        KnightsOfTheEbonBlade = 91,
        FrenzyheartTribe = 92,
        TheOracles = 93,
        ArgentCrusade = 94,
        TheSonsOfHodir = 97,
        TheSunreavers = 98,
        End
    }

    public enum FactionId : uint
    {
        None = 0,
        PLAYERHuman = 1,
        PLAYEROrc = 2,
        PLAYERDwarf = 3,
        PLAYERNightElf = 4,
        PLAYERUndead = 5,
        PLAYERTauren = 6,
        Creature = 7,
        PLAYERGnome = 8,
        PLAYERTroll = 9,
        Monster = 14,
        DefiasBrotherhood = 15,
        GnollRiverpaw = 16,
        GnollRedridge = 17,
        GnollShadowhide = 18,
        Murloc = 19,
        UndeadScourge = 20,
        BootyBay = 21,
        BeastSpider = 22,
        BeastBoar = 23,
        Worgen = 24,
        Kobold = 25,
        TrollBloodscalp = 26,
        TrollSkullsplitter = 27,
        Prey = 28,
        BeastWolf = 29,
        Friendly = 31,
        Trogg = 32,
        TrollFrostmane = 33,
        OrcBlackrock = 34,
        Villian = 35,
        Victim = 36,
        BeastBear = 37,
        Ogre = 38,
        KurzensMercenaries = 39,
        Escortee = 40,
        VentureCompany = 41,
        BeastRaptor = 42,
        Basilisk = 43,
        DragonflightGreen = 44,
        LostOnes = 45,
        Ironforge = 47,
        DarkIronDwarves = 48,
        HumanNightWatch = 49,
        DragonflightRed = 50,
        GnollMosshide = 51,
        OrcDragonmaw = 52,
        GnomeLeper = 53,
        GnomereganExiles = 54,
        Leopard = 55,
        ScarletCrusade = 56,
        GnollRothide = 57,
        BeastGorilla = 58,
        ThoriumBrotherhood = 59,
        Naga = 60,
        Dalaran = 61,
        ForlornSpirit = 62,
        Darkhowl = 63,
        Grell = 64,
        Furbolg = 65,
        HordeGeneric = 66,
        Horde = 67,
        Undercity = 68,
        Darnassus = 69,
        Syndicate = 70,
        HillsbradMilitia = 71,
        Stormwind = 72,
        Demon = 73,
        Elemental = 74,
        Spirit = 75,
        Orgrimmar = 76,
        Treasure = 77,
        GnollMudsnout = 78,
        HIllsbradSouthshoreMayor = 79,
        DragonflightBlack = 80,
        ThunderBluff = 81,
        TrollWitherbark = 82,
        QuilboarBristleback = 85,
        BloodsailBuccaneers = 87,
        Blackfathom = 88,
        Makrura = 89,
        CentaurKolkar = 90,
        CentaurGalak = 91,
        GelkisClanCentaur = 92,
        MagramClanCentaur = 93,
        Maraudine = 94,
        Theramore = 108,
        QuilboarRazorfen = 109,
        QuilboarRazormane2 = 110,
        QuilboarDeathshead = 111,
        Enemy = 128,
        Ambient = 148,
        NethergardeCaravan = 168,
        SteamwheedleCartel = 169,
        AllianceGeneric = 189,
        WailingCaverns = 229,
        Silithid = 249,
        SilvermoonRemnant = 269,
        ZandalarTribe = 270,
        Scorpid = 309,
        BeastBat = 310,
        Titan = 311,
        TaskmasterFizzule = 329,
        Ravenholdt = 349,
        Gadgetzan = 369,
        GnomereganBug = 389,
        Harpy = 409,
        BurningBlade = 429,
        ShadowsilkPoacher = 449,
        SearingSpider = 450,
        Alliance = 469,
        Ratchet = 470,
        GoblinDarkIronBarPatron = 489,
        TheLeagueOfArathor = 509,
        TheDefilers = 510,
        Giant = 511,
        Bloodfeather = 514,
        ArgentDawn = 529,
        DarkspearTrolls = 530,
        DragonflightBronze = 531,
        TrollVilebranch = 572,
        SouthseaFreebooters = 573,
        FurbolgUncorrupted = 575,
        TimbermawHold = 576,
        Everlook = 577,
        WintersaberTrainers = 589,
        CenarionCircle = 609,
        ShatterspearTrolls = 629,
        BeastCarrionBird = 669,
        TrainingDummy = 679,
        DragonflightBlackBait = 689,
        BattlegroundNeutral = 709,
        FrostwolfClan = 729,
        StormpikeGuard = 730,
        HydraxianWaterlords = 749,
        SulfuronFirelords = 750,
        GizlocksDummy = 769,
        GizlocksCharm = 770,
        Gizlock = 771,
        SpiritGuideAlliance = 790,
        ShenDralar = 809,
        OgreCaptainKromcrush = 829,
        SpiritGuideHorde = 849,
        Jaedenar = 869,
        WarsongOutriders = 889,
        SilverwingSentinels = 890,
        DarkmoonFaire = 909,
        BroodOfNozdormu = 910,
        SilvermoonCity = 911,
        MightOfKalimdor = 912,
        PLAYERBloodElf = 914,
        ArmiesOfCThun = 915,
        SilithidAttackers = 916,
        RCEnemies = 918,
        RCObjects = 919,
        Red = 920,
        Blue = 921,
        Tranquillien = 922,
        Farstriders = 923,
        PLAYERDraenei = 927,
        ScourgeInvaders = 928,
        BloodmaulClan = 929,
        Exodar = 930,
        TheAldor = 932,
        TheConsortium = 933,
        TheScryers = 934,
        TheShaTar = 935,
        TrollForest = 937,
        TheSonsOfLothar = 940,
        TheMagHar = 941,
        CenarionExpedition = 942,
        FelOrc = 943,
        FelOrcGhost = 944,
        SonsOfLotharGhosts = 945,
        HonorHold = 946,
        Thrallmar = 947,
        TestFaction1 = 949,
        ToWoWFlag = 950,
        ToWoWFlagTriggerAllianceDND = 951,
        TestFaction3 = 952,
        TestFaction4 = 953,
        ToWoWFlagTriggerHordeDND = 954,
        Broken = 955,
        Ethereum = 956,
        EarthElemental = 957,
        FightingRobots = 958,
        ActorGood = 959,
        ActorEvil = 960,
        StillpineFurbolg = 961,
        CrazedOwlkin = 962,
        ChessAlliance = 963,
        ChessHorde = 964,
        MonsterSpar = 965,
        MonsterSparBuddy = 966,
        TheVioletEye = 967,
        Sunhawks = 968,
        Sporeggar = 970,
        FungalGiant = 971,
        MonsterPredator = 973,
        MonsterPrey = 974,
        VoidAnomaly = 975,
        HyjalDefenders = 976,
        HyjalInvaders = 977,
        Kurenai = 978,
        EarthenRing = 979,
        Arakkoa = 981,
        ZangarmarshBannerAlliance = 982,
        ZangarmarshBannerHorde = 983,
        ZangarmarshBannerNeutral = 984,
        CavernsOfTimeThrall = 985,
        CavernsOfTimeDurnholde = 986,
        CavernsOfTimeSouthshoreGuards = 987,
        ShadowCouncilCovert = 988,
        KeepersOfTime = 989,
        TheScaleOfTheSands = 990,
        DarkPortalDefenderAlliance = 991,
        DarkPortalDefenderHorde = 992,
        DarkPortalAttackerLegion = 993,
        InciterTrigger = 994,
        InciterTrigger2 = 995,
        InciterTrigger3 = 996,
        InciterTrigger4 = 997,
        InciterTrigger5 = 998,
        ManaCreature = 999,
        KhadgarsServant = 1000,
        BladespireClan = 1001,
        EthereumSparbuddy = 1002,
        Protectorate = 1003,
        ArcaneAnnihilatorDNR = 1004,
        KirinVarDathric = 1006,
        KirinVarBelmara = 1007,
        KirinVarLuminrath = 1008,
        KirinVarCohlien = 1009,
        ServantOfIllidan = 1010,
        LowerCity = 1011,
        AshtongueDeathsworn = 1012,
        SpiritsOfShadowmoon1 = 1013,
        SpiritsOfShadowmoon2 = 1014,
        Netherwing = 1015,
        Wyrmcult = 1016,
        Treant = 1017,
        LeotherasDemonI = 1018,
        LeotherasDemonII = 1019,
        LeotherasDemonIII = 1020,
        LeotherasDemonIV = 1021,
        LeotherasDemonV = 1022,
        Azaloth = 1023,
        RockFlayer = 1024,
        FlayerHunter = 1025,
        ShadowmoonShade = 1026,
        LegionCommunicator = 1027,
        RavenswoodAncients = 1028,
        ChessFriendlyToAllChess = 1029,
        ShaTariSkyguard = 1031,
        Maiev = 1033,
        SkettisShadowyArakkoa = 1034,
        SkettisArakkoa = 1035,
        DragonmawEnemy = 1036,
        OgriLa = 1038,
        Frenzy = 1041,
        SkyguardEnemy = 1042,
        TheramoreDeserter = 1044,
        Vrykul = 1045,
        NorthseaPirates = 1046,
        Tuskarr = 1047,
        UNUSED = 1048,
        TrollAmani = 1049,
        ValianceExpedition = 1050,
        HordeExpedition = 1052,
        SpottedGryphon = 1054,
        TamedPlaguehound = 1055,
        VrykulAncientSpirit1 = 1056,
        VrykulAncientSiprit2 = 1057,
        VrykulAncientSiprit3 = 1058,
        CTFFlagAlliance = 1059,
        Test = 1060,
        VrykulGladiator = 1062,
        ValgardeCombatant = 1063,
        TheTaunka = 1064,
        MonsterZoneForceReaction1 = 1065,
        MonsterZoneForceReaction2 = 1066,
        TheHandOfVengeance = 1067,
        ExplorersLeague = 1068,
        RamRacingPowerupDND = 1069,
        RamRacingTrapDND = 1070,
        CraigsSquirrels = 1071,
        TheKaluAk = 1073,
        HolidayWaterBarrel = 1074,
        IronDwarves = 1076,
        ShatteredSunOffensive = 1077,
        FightingVanityPet = 1078,
        MurlocWinterfin = 1079,
        FriendlyForceReaction = 1080,
        ObjectForceReaction = 1081,
        REUSE = 1082,
        WarsongOffensive = 1085,
        Poacher = 1086,
        HolidayMonster = 1087,
        FurbolgRedfang = 1088,
        FurbolgFrostpaw = 1089,
        KirinTor = 1090,
        TheWyrmrestAccord = 1091,
        AzjolNerub = 1092,
        TheSilverCovenant = 1094,
        GrizzlyHillsTrapper = 1095,
        KnightsOfTheEbonBlade = 1098,
        WrathgateScourge = 1099,
        WrathgateAlliance = 1100,
        WrathgateHorde = 1101,
        CTFFlagHorde = 1102,
        CTFFlagNeutral = 1103,
        FrenzyheartTribe = 1104,
        TheOracles = 1105,
        ArgentCrusade = 1106,
        TrollDrakkari = 1107,
        CoTArthas = 1108,
        CoTStratholmeCitizen = 1109,
        CoTScourge = 1110,
        Freya = 1111,
        MountTaxiAlliance = 1112,
        MountTaxiHorde = 1113,
        MountTaxiNeutral = 1114,
        ElementalWater = 1115,
        ElementalAir = 1116,
        TheSonsOfHodir = 1119,
        IronGiants = 1120,
        FrostVrykul = 1121,
        Earthen = 1122,
        MonsterReferee = 1123,
        TheSunreavers = 1124,
        Hyldsmeet = 1125,
        End
    }

    public enum WoWMap : int
    {
        None = -1,
        Azeroth = 0,
        Kalimdor = 1,
        test = 13,
        ScottTest = 25,
        PVPZone01 = 30,
        Shadowfang = 33,
        StormwindJail = 34,
        StormwindPrison = 35,
        DeadminesInstance = 36,
        PVPZone02 = 37,
        Collin = 42,
        WailingCaverns = 43,
        Monastery = 44,
        RazorfenKraulInstance = 47,
        Blackfathom = 48,
        Uldaman = 70,
        GnomeragonInstance = 90,
        SunkenTemple = 109,
        RazorfenDowns = 129,
        EmeraldDream = 169,
        MonasteryInstances = 189,
        TanarisInstance = 209,
        BlackRockSpire = 229,
        BlackrockDepths = 230,
        OnyxiaLairInstance = 249,
        CavernsOfTime = 269,
        SchoolofNecromancy = 289,
        Zulgurub = 309,
        Stratholme = 329,
        Mauradon = 349,
        DeeprunTram = 369,
        OrgrimmarInstance = 389,
        MoltenCore = 409,
        DireMaul = 429,
        AlliancePVPBarracks = 449,
        HordePVPBarracks = 450,
        development = 451,
        BlackwingLair = 469,
        PVPZone03 = 489,
        AhnQiraj = 509,
        PVPZone04 = 529,
        Expansion01 = 530,
        AhnQirajTemple = 531,
        Karazahn = 532,
        StratholmeRaid = 533,
        HyjalPast = 534,
        HellfireMilitary = 540,
        HellfireDemon = 542,
        HellfireRampart = 543,
        HellfireRaid = 544,
        CoilfangPumping = 545,
        CoilfangMarsh = 546,
        CoilfangDraenei = 547,
        CoilfangRaid = 548,
        TempestKeepRaid = 550,
        TempestKeepArcane = 552,
        TempestKeepAtrium = 553,
        TempestKeepFactory = 554,
        AuchindounShadow = 555,
        AuchindounDemon = 556,
        AuchindounEthereal = 557,
        AuchindounDraenei = 558,
        PVPZone05 = 559,
        HillsbradPast = 560,
        bladesedgearena = 562,
        BlackTemple = 564,
        GruulsLair = 565,
        NetherstormBG = 566,
        ZulAman = 568,
        Northrend = 571,
        PVPLordaeron = 572,
        ExteriorTest = 573,
        Valgarde70 = 574,
        UtgardePinnacle = 575,
        Nexus70 = 576,
        Nexus80 = 578,
        SunwellPlateau = 580,
        Transport176244 = 582,
        Transport176231 = 584,
        Sunwell5ManFix = 585,
        Transport181645 = 586,
        Transport177233 = 587,
        Transport176310 = 588,
        Transport175080 = 589,
        Transport176495 = 590,
        Transport164871 = 591,
        Transport186238 = 592,
        Transport20808 = 593,
        Transport187038 = 594,
        StratholmeCOT = 595,
        Transport187263 = 596,
        CraigTest = 597,
        Sunwell5Man = 598,
        Ulduar70 = 599,
        DrakTheronKeep = 600,
        Azjol_Uppercity = 601,
        Ulduar80 = 602,
        UlduarRaid = 603,
        GunDrak = 604,
        development_nonweighted = 605,
        QA_DVD = 606,
        NorthrendBG = 607,
        DalaranPrison = 608,
        DeathKnightStart = 609,
        Transport_Tirisfal_Vengeance_Landing = 610,
        Transport_Menethil_Valgarde = 612,
        Transport_Orgrimmar_Warsong_Hold = 613,
        Transport_Stormwind_Valiance_Keep = 614,
        ChamberOfAspectsBlack = 615,
        NexusRaid = 616,
        DalaranArena = 617,
        OrgrimmarArena = 618,
        Azjol_LowerCity = 619,
        Transport_Moaki_Unupe = 620,
        Transport_Moaki_Kamagua = 621,
        Transport192241 = 622,
        Transport192242 = 623,
        WintergraspRaid = 624,
        unused = 627,
        IsleofConquest = 628,
        IcecrownCitadel = 631,
        IcecrownCitadel5Man = 632,
        AbyssalMaw = 637,
        Gilneas = 638,
        Transport_AllianceAirshipBG = 641,
        Transport_HordeAirshipBG = 642,
        AbyssalMaw_Interior = 643,
        Uldum = 644,
        BlackRockSpire_4_0 = 645,
        Deephome = 646,
        Transport_Orgrimmar_to_Thunderbluff = 647,
        LostIsles = 648,
        ArgentTournamentRaid = 649,
        ArgentTournamentDungeon = 650,
        ElevatorSpawnTest = 651,
        Gilneas2 = 654,
        GilneasPhase1 = 655,
        GilneasPhase2 = 656,
        SkywallDungeon = 657,
        QuarryofTears = 658,
        LostIslesPhase1 = 659,
        Deephomeceiling = 660,
        LostIslesPhase2 = 661,
        Transport197195 = 662,
        HallsOfReflection = 668,
        BlackwingDescent = 669,
        GrimBatolDungeon = 670,
        GrimBatolRaid = 671,
        Transport197347 = 672,
        Transport197348 = 673,
        Transport197349_2 = 674,
        Transport197349 = 712,
        Transport197350 = 713,
        Transport201834 = 718,
        MountHyjalPhase1 = 719,
        Firelands1 = 720,
        Firelands2 = 721,
        Stormwind = 723,
        ChamberofAspectsRed = 724,
        DeepholmeDungeon = 725,
        CataclysmCTF = 726,
        STV_Mine_BG = 727,
        TheBattleforGilneas = 728,
        MaelstromZone = 730,
        DesolaceBomb = 731,
        TolBarad = 732,
        AhnQirajTerrace = 734,
        TwilightHighlandsDragonmawPhase = 736,
        Transport200100 = 738,
        Transport200101 = 739,
        Transport200102 = 740,
        Transport200103 = 741,
        Transport203729 = 742,
        Transport203730 = 743,
        UldumPhaseOasis = 746,
        Transport203732 = 747,
        Transport203858 = 748,
        Transport203859 = 749,
        Transport203860 = 750,
        RedgridgeOrcBomb = 751,
        RedridgeBridgePhaseOne = 752,
        RedridgeBridgePhaseTwo = 753,
        SkywallRaid = 754,
        UldumDungeon = 755,
        BaradinHold = 757,
        UldumPhasedEntrance = 759,
        TwilightHighlandsPhasedEntrance = 760,
        Gilneas_BG_2 = 761,
        Transport203861 = 762,
        Transport203862 = 763,
        UldumPhaseWreckedCamp = 764,
        Transport203863 = 765,
        Transport2033864 = 766,
    }

    public enum ImplicitTargetType
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,
        Self = 1,
        /// <summary>
        /// 30235
        /// This is cast by the Astral Flares summoned by The Curator in Karazhan.
        /// It chains to nearby characters, hitting up to three of them.
        /// </summary>
        Type_2 = 2,
        InvisibleOrHiddenEnemiesAtLocationRadius = 3,
        /// <summary>
        /// Single target, can spread to nearby. Ie 3439, 7103
        /// </summary>
        SpreadableDesease = 4,
        /// <summary>
        /// Own pet or summon
        /// </summary>
        Pet = 5,
        /// <summary>
        /// Single enemy, might be chained
        /// </summary>
        SingleEnemy = 6,
        ScriptedTarget = 7,
        AllAroundLocation = 8,
        /// <summary>
        /// Teleport back home
        /// </summary>
        HeartstoneLocation = 9,
        //Unused_Type_10 = 10,
        /// <summary>
        /// Spell 4, Word of Recall Other
        /// </summary>
        Type_11 = 11,
        //Unused_Type_12 = 12,
        //Unused_Type_13 = 13,
        //Unused_Type_14 = 14,
        AllEnemiesInArea = 15,
        AllEnemiesInAreaInstant = 16,
        TeleportLocation = 17,
        LocationToSummon = 18,
        //Unused_Type_19 = 19,
        AllPartyAroundCaster = 20,
        SingleFriend = 21,
        AllEnemiesAroundCaster = 22,
        /// <summary>
        /// All kinds of GameObject interactions (mostly for quests)
        /// </summary>
        GameObject = 23,
        InFrontOfCaster = 24,
        /// <summary>
        /// Enemy target apparently
        /// </summary>
        Duel = 25,
        /// <summary>
        /// Needed for all open lock spells
        /// </summary>
        GameObjectOrItem = 26,
        PetMaster = 27,
        AllEnemiesInAreaChanneled = 28,
        /// <summary>
        /// Tranquility and some Dummies (visual only)
        /// </summary>
        AllPartyInAreaChanneled = 29,
        AllFriendlyInAura = 30,
        AllTargetableAroundLocationInRadiusOverTime = 31,
        Minion = 32,
        AllPartyInArea = 33,
        /// <summary>
        /// Only used for Tranquilities' Trigger spell
        /// </summary>
        Tranquility = 34,
        SingleParty = 35,
        PetSummonLocation = 36,
        AllParty = 37,
        ScriptedOrSingleTarget = 38,
        SelfFishing = 39,
        ScriptedGameObject = 40,
        TotemEarth = 41,
        TotemWater = 42,
        TotemAir = 43,
        TotemFire = 44,
        /// <summary>
        /// Any kind of chain effect:
        /// Chain Lightning etc, as well as Multishot 
        /// </summary>
        Chain = 45,
        ScriptedObjectLocation = 46,
        /// <summary>
        /// Spell-targettype always = self
        /// Examples: Mortar, all kinds of Picnics etc
        /// </summary>
        DynamicObject = 47,
        MultipleSummonLocation = 48,
        MultipleSummonPetLocation = 49,
        SummonLocation = 50,
        /// <summary>
        /// Odd stuff
        /// </summary>
        CaliriEggs = 51,
        LocationNearCaster = 52,
        CurrentSelection = 53,
        TargetAtOrientationOfCaster = 54,
        /// <summary>
        /// Teleport location
        /// </summary>
        LocationInFrontCaster = 55,
        PartyAroundCaster = 56,
        PartyMember = 57,
        Type_58 = 58,
        TargetForVisualEffect = 59,
        ScriptedTarget2 = 60,
        AreaEffectPartyAndClass = 61,
        //Unused_PriestChampion = 62,
        NatureSummonLocation = 63,
        Type_64 = 64,
        /// <summary>
        /// Eg Shadowstep, Warp etc
        /// </summary>
        BehindTargetLocation = 65,
        Type_66 = 66,
        Type_67 = 67,
        Type_68 = 68,
        Type_69 = 69,
        Type_70 = 70,
        //Unused_Type_71 = 71,
        MultipleGuardianSummonLocation = 72,
        NetherDrakeSummonLocation = 73,
        ScriptedLocation = 74,
        /// <summary>
        /// Teleport location
        /// </summary>
        LocationInFrontCasterAtRange = 75,
        //Unused_EnemiesInAreaChanneledWithExceptions = 76,
        SelectedEnemyChanneled = 77,
        Type_78 = 78,
        Type_79 = 79,
        Type_80 = 80,
        Type_81 = 81,
        //Unused_Type_82 = 82,
        //Unused_Type_83 = 83,
        //Unused_Type_84 = 84,
        Type_85 = 85,
        SelectedEnemyDeadlyPoison = 86,
        Type_87 = 87,
        Type_88 = 88,
        Type_89 = 89,
        Type_90 = 90,
        Type_91 = 91,
        //Unused_Type_92 = 92,
        Type_93 = 93, // Highest as of 2.4.3.8606
    }

    /*[Obsolete("Old. Replaced by SpellEffects")]
    public enum SpellEffectType : uint  //Value corresponds with Effect_Type_A,Effect_Type_B,Effect_Type_C in Spell.DBC
    {
        None = 0,
        InstantKill = 1,
        SchoolDamage = 2,
        Dummy = 3,
        Unused_PortalTeleport = 4,
        TeleportUnits = 5,
        /// <summary>
        /// MiscValue: AuraId
        /// MiscValueB: StatType
        /// </summary>
        ApplyAura = 6,
        EnvironmentalDamage = 7,
        PowerDrain = 8,
        HealthLeech = 9,
        Heal = 10,
        Bind = 11,
        Portal = 12,
        Unused_RitualBase = 13,
        Unused_RitualSpecialize = 14,
        Unused_RitualActivatePortal = 15,
        QuestComplete = 16,
        WeaponDamageNoSchool = 17,
        Resurrect = 18,
        AddExtraAttacks = 19,
        Dodge = 20,
        Evade = 21,
        Parry = 22,
        Block = 23,
        CreateItem = 24,
        Weapon = 25,
        Defense = 26,
        PersistantAreaAura = 27,
        /// <summary>
        /// MiscValue: Pet entry
        /// MiscValueB: Index in SummonProperties.dbc
        /// </summary>
        Summon = 28,
        Leap = 29,
        Energize = 30,
        WeaponPercentDamage = 31,
        TriggerMissile = 32,
        OpenLock = 33,
        TransformItem = 34,
        /// <summary>
        /// Mobile AreaAura.
        /// Totems and Paladins mostly
        /// </summary>
        ApplyAreaAura = 35,
        LearnSpell = 36,
        SpellDefense = 37,
        Dispel = 38,
        Language = 39,
        DualWeild = 40,
        Unused_SummonWild,
        Unused_SummonGuardian,
        TeleportUnitsFaceCaster,
        SkillStep,
        AddHonor,
        Spawn,
        TradeSkill,
        Stealth,
        Detect,
        SummonObject = 50,
        Unused_ForceCriticalHit,
        Unused_GuaranteeHit,
        EnchantItem,
        EnchantItemTemporary,
        TameCreature,
        SummonPet,
        LearnPetSpell,
        WeaponDamage,
        OpenLockItem,
        Proficiency = 60,
        SendEvent,
        PowerBurn,
        Threat,
        TriggerSpell,
        ApplyAreaAura2,
        CreateManaGem,
        HealMaxHealth,
        InterruptCast,
        Distract,
        Pull = 70,
        Pickpocket,
        AddFarsight,
        Unused_SummonPossessed,
        /// <summary>
        /// MiscValue = GlyphProperties.dbc
        /// </summary>
        ApplyGlyph = 74,
        HealMechanical,
        SummonObjectWild,
        ScriptEffect,
        Attack,
        Sanctuary,
        AddComboPoints = 80,
        CreateHouse,
        BindSight,
        Duel,
        Stuck,
        SummonPlayer,
        ActivateObject,
        Unused_SummonTotemSlot1,
        Unused_SummonTotemSlot2,
        Unused_SummonTotemSlot3,
        Unused_SummonTotemSlot4 = 90,
        Unused_ThreatAll = 91,
        EnchantHeldItem = 92,
        Unused_SummonPhantasm = 93,
        SelfResurrect = 94,
        Skinning = 95,
        Charge = 96,
        Unused_SummonCritter = 97,
        KnockBack = 98,
        Disenchant = 99,
        Inebriate = 100,
        FeedPet = 101,
        DismissPet = 102,
        Reputation = 103,
        SummonObjectSlot1 = 104,
        SummonObjectSlot2 = 105,
        Unused_SummonObjectSlot3 = 106,
        Unused_SummonObjectSlot4 = 107,
        DispelMechanic = 108,
        SummonDeadPet = 109,
        DestroyAllTotems = 110,
        DurabilityDamage = 111,
        Unused_SummonDemon = 112,
        ResurrectFlat = 113,
        AttackMe = 114,
        DurabilityDamagePercent = 115,
        SkinPlayerCorpse = 116,
        SpiritHeal = 117,
        Skill = 118,
        ApplyPetAura = 119,
        TeleportGraveyard = 120,
        NormalizedWeaponDamagePlus = 121,
        /// <summary>
        /// Unused
        /// </summary>
        Unused_Effect_122 = 122,
        /// <summary>
        /// Scripted Event?
        /// </summary>
        Video = 123,
        /// <summary>
        /// Pulls the target towards the caster
        /// </summary>
        PlayerPull = 124,
        ReduceThreatPercent = 125,
        /// <summary>
        /// Spellsteal
        /// </summary>
        StealBeneficialBuff = 126,
        Prospecting = 127,
        ApplyStatAura = 128,
        ApplyStatAuraPercent = 129,
        /// <summary>
        /// Effect 3 of spell 34477, Misdirection
        /// </summary>
        Effect_130 = 130, // RedirectThreat
        Effect_131 = 131, // 44393, 44393
        /// <summary>
        /// Unused
        /// </summary>
        Effect_132 = 132, //Play Music
        ForgetSpecialization = 133,
        Effect_134 = 134, // Kill Credit
        Effect_135 = 135, //Call-summon pet
        /// <summary>
        /// Heal %?
        /// </summary>
        RestoreHealthPercent = 136,
        RestoreManaPercent = 137,
        /// <summary>
        /// Something about leaping
        /// </summary>
        Effect_138 = 138, //Leap
        /// <summary>
        /// Unused
        /// </summary>
        Unused_Effect_139 = 139, // Clear Quest
        Effect_140 = 140, // Spawn GameObject? 
        Effect_141 = 141, // Damage and Reduced Speed (Blood Bolt)
        /// <summary>
        /// Deals with branching targets
        /// </summary>
        Effect_142 = 142, //Prayer of Mending, Spell Aura Jump and Heal - heal after hit?
        /// <summary>
        /// Soul link and Demonic Knowledge
        /// </summary>
        ApplyAuraToMaster = 143,
        Effect_144 = 144, // PushBack
        Effect_145 = 145, // Black Hole Effect, Gravity Well Effect
        ActivateRune = 146, //EmpowerRune
        QuestFail = 147, // Quest Fail
        Unused_Effect_148 = 148,
        Effect_149 = 149, //Sliding, Side leap
        Unused_Effect_150 = 150,
        TriggerRitualOfSummoning = 151,
        /// <summary>
        /// Spell 45927, Alows you to summon your Refer-A-Friend.
        /// </summary>
        SummonReferAFriend = 152,
        /// <summary>
        /// Tame Creature
        /// </summary>
        Effect_153 = 153, // Highest as of 2.4.3.8606
        Unused_154 = 154,
        EnableTitanGrip = 155, // Dual wield 2H
        AddPrismaticGem = 156, // Add Socket
        CreateItem2 = 157, // Create Item
        Milling = 158,
        RenamePet = 159, // Highest in 3.0.2.9056
        Effect_160 = 160,
        Effect_161 = 161,
        Effect_162 = 162, // Highest as of 0.1.0.9626
        End
    }*/

    // Summary:
    //     The mask is the corrosponding WoWRaces-value ^2 - 1
    [Flags]
    [Obfuscation]
    public enum RaceMask
    {
        Human = 1,
        Orc = 2,
        Dwarf = 4,
        NightElf = 8,
        Undead = 16,
        Tauren = 32,
        Gnome = 64,
        Troll = 128,
        Goblin = 256,
        BloodElf = 512,
        Draenei = 1024,
        FelOrc = 2048,
        Naga = 4096,
        Broken = 8192,
        Skeleton = 16384,
        AllRaces2 = 32768,
        AllRaces1 = 65536,
    }

    // Summary:
    //     A mask of the values from FactionGroup.dbc
    [Flags]
    public enum FactionGroupMask
    {
        // Summary:
        //     Not aggressive
        None = 0,
        Player = 1,
        //
        // Summary:
        //     A member of the Alliance faction
        Alliance = 2,
        //
        // Summary:
        //     A member of the Horde faction
        Horde = 4,
        Monster = 8,
    }

    // Summary:
    //     FactionGroup
    public enum FactionGroup
    {
        Alliance = 1,
        Horde = 2,
        Invalid = 3,
    }

    public enum FactionTemplateId
    {
        None = 0,
        PLAYERHuman = 1,
        PLAYEROrc = 2,
        PLAYERDwarf = 3,
        PLAYERNightElf = 4,
        PLAYERUndead = 5,
        PLAYERTauren = 6,
        Creature = 7,
        Escortee = 10,
        Stormwind = 11,
        Stormwind_2 = 12,
        Monster = 14,
        Creature_2 = 15,
        Monster_2 = 16,
        DefiasBrotherhood = 17,
        Murloc = 18,
        GnollRedridge = 19,
        GnollRiverpaw = 20,
        UndeadScourge = 21,
        BeastSpider = 22,
        GnomereganExiles = 23,
        Worgen = 24,
        Kobold = 25,
        Kobold_2 = 26,
        DefiasBrotherhood_2 = 27,
        TrollBloodscalp = 28,
        Orgrimmar = 29,
        TrollSkullsplitter = 30,
        Prey = 31,
        BeastWolf = 32,
        Escortee_2 = 33,
        DefiasBrotherhood_3 = 34,
        Friendly = 35,
        Trogg = 36,
        TrollFrostmane = 37,
        BeastWolf_2 = 38,
        GnollShadowhide = 39,
        OrcBlackrock = 40,
        Villian = 41,
        Victim = 42,
        Villian_2 = 43,
        BeastBear = 44,
        Ogre = 45,
        KurzensMercenaries = 46,
        VentureCompany = 47,
        BeastRaptor = 48,
        Basilisk = 49,
        DragonflightGreen = 50,
        LostOnes = 51,
        GizlocksDummy = 52,
        HumanNightWatch = 53,
        DarkIronDwarves = 54,
        Ironforge = 55,
        HumanNightWatch_2 = 56,
        Ironforge_2 = 57,
        Creature_3 = 58,
        Trogg_2 = 59,
        DragonflightRed = 60,
        GnollMosshide = 61,
        OrcDragonmaw = 62,
        GnomeLeper = 63,
        GnomereganExiles_2 = 64,
        Orgrimmar_2 = 65,
        Leopard = 66,
        ScarletCrusade = 67,
        Undercity = 68,
        Ratchet = 69,
        GnollRothide = 70,
        Undercity_2 = 71,
        BeastGorilla = 72,
        BeastCarrionBird = 73,
        Naga = 74,
        Dalaran = 76,
        ForlornSpirit = 77,
        Darkhowl = 78,
        Darnassus = 79,
        Darnassus_2 = 80,
        Grell = 81,
        Furbolg = 82,
        HordeGeneric = 83,
        AllianceGeneric = 84,
        Orgrimmar_3 = 85,
        GizlocksCharm = 86,
        Syndicate = 87,
        HillsbradMilitia = 88,
        ScarletCrusade_2 = 89,
        Demon = 90,
        Elemental = 91,
        Spirit = 92,
        Monster_3 = 93,
        Treasure = 94,
        GnollMudsnout = 95,
        HIllsbradSouthshoreMayor = 96,
        Syndicate_2 = 97,
        Undercity_3 = 98,
        Victim_2 = 99,
        Treasure_2 = 100,
        Treasure_3 = 101,
        Treasure_4 = 102,
        DragonflightBlack = 103,
        ThunderBluff = 104,
        ThunderBluff_2 = 105,
        HordeGeneric_2 = 106,
        TrollFrostmane_2 = 107,
        Syndicate_3 = 108,
        QuilboarRazormane2 = 109,
        QuilboarRazormane2_2 = 110,
        QuilboarBristleback = 111,
        QuilboarBristleback_2 = 112,
        Escortee_3 = 113,
        Treasure_5 = 114,
        PLAYERGnome = 115,
        PLAYERTroll = 116,
        Undercity_4 = 118,
        BloodsailBuccaneers = 119,
        BootyBay = 120,
        BootyBay_2 = 121,
        Ironforge_3 = 122,
        Stormwind_3 = 123,
        Darnassus_3 = 124,
        Orgrimmar_4 = 125,
        DarkspearTrolls = 126,
        Villian_3 = 127,
        Blackfathom = 128,
        Makrura = 129,
        CentaurKolkar = 130,
        CentaurGalak = 131,
        GelkisClanCentaur = 132,
        MagramClanCentaur = 133,
        Maraudine = 134,
        Monster_4 = 148,
        Theramore = 149,
        Theramore_2 = 150,
        Theramore_3 = 151,
        QuilboarRazorfen = 152,
        QuilboarRazorfen_2 = 153,
        QuilboarDeathshead = 154,
        Enemy = 168,
        Ambient = 188,
        Creature_4 = 189,
        Ambient_2 = 190,
        NethergardeCaravan = 208,
        NethergardeCaravan_2 = 209,
        AllianceGeneric_2 = 210,
        SouthseaFreebooters = 230,
        Escortee_4 = 231,
        Escortee_5 = 232,
        UndeadScourge_2 = 233,
        Escortee_6 = 250,
        WailingCaverns = 270,
        Escortee_7 = 290,
        Silithid = 310,
        Silithid_2 = 311,
        BeastSpider_2 = 312,
        WailingCaverns_2 = 330,
        Blackfathom_2 = 350,
        ArmiesOfCThun = 370,
        SilvermoonRemnant = 371,
        BootyBay_3 = 390,
        Basilisk_2 = 410,
        BeastBat = 411,
        TheDefilers = 412,
        Scorpid = 413,
        TimbermawHold = 414,
        Titan = 415,
        Titan_2 = 416,
        TaskmasterFizzule = 430,
        WailingCaverns_3 = 450,
        Titan_3 = 470,
        Ravenholdt = 471,
        Syndicate_4 = 472,
        Ravenholdt_2 = 473,
        Gadgetzan = 474,
        Gadgetzan_2 = 475,
        GnomereganBug = 494,
        Escortee_8 = 495,
        Harpy = 514,
        AllianceGeneric_3 = 534,
        BurningBlade = 554,
        ShadowsilkPoacher = 574,
        SearingSpider = 575,
        Trogg_3 = 594,
        Victim_3 = 614,
        Monster_5 = 634,
        CenarionCircle = 635,
        TimbermawHold_2 = 636,
        Ratchet_2 = 637,
        TrollWitherbark = 654,
        CentaurKolkar_2 = 655,
        DarkIronDwarves_2 = 674,
        AllianceGeneric_4 = 694,
        HydraxianWaterlords = 695,
        HordeGeneric_3 = 714,
        DarkIronDwarves_3 = 734,
        GoblinDarkIronBarPatron = 735,
        GoblinDarkIronBarPatron_2 = 736,
        DarkIronDwarves_4 = 754,
        Escortee_9 = 774,
        Escortee_10 = 775,
        BroodOfNozdormu = 776,
        MightOfKalimdor = 777,
        Giant = 778,
        ArgentDawn = 794,
        TrollVilebranch = 795,
        ArgentDawn_2 = 814,
        Elemental_2 = 834,
        Everlook = 854,
        Everlook_2 = 855,
        WintersaberTrainers = 874,
        GnomereganExiles_3 = 875,
        DarkspearTrolls_2 = 876,
        DarkspearTrolls_3 = 877,
        Theramore_4 = 894,
        TrainingDummy = 914,
        FurbolgUncorrupted = 934,
        Demon_2 = 954,
        UndeadScourge_3 = 974,
        CenarionCircle_2 = 994,
        ThunderBluff_3 = 995,
        CenarionCircle_3 = 996,
        ShatterspearTrolls = 1014,
        ShatterspearTrolls_2 = 1015,
        HordeGeneric_4 = 1034,
        AllianceGeneric_5 = 1054,
        AllianceGeneric_6 = 1055,
        Orgrimmar_5 = 1074,
        Theramore_5 = 1075,
        Darnassus_4 = 1076,
        Theramore_6 = 1077,
        Stormwind_4 = 1078,
        Friendly_2 = 1080,
        Elemental_3 = 1081,
        BeastBoar = 1094,
        TrainingDummy_2 = 1095,
        Theramore_7 = 1096,
        Darnassus_5 = 1097,
        DragonflightBlackBait = 1114,
        Undercity_5 = 1134,
        Undercity_6 = 1154,
        Orgrimmar_6 = 1174,
        BattlegroundNeutral = 1194,
        FrostwolfClan = 1214,
        FrostwolfClan_2 = 1215,
        StormpikeGuard = 1216,
        StormpikeGuard_2 = 1217,
        SulfuronFirelords = 1234,
        SulfuronFirelords_2 = 1235,
        SulfuronFirelords_3 = 1236,
        CenarionCircle_4 = 1254,
        Creature_5 = 1274,
        Creature_6 = 1275,
        Gizlock = 1294,
        HordeGeneric_5 = 1314,
        AllianceGeneric_7 = 1315,
        StormpikeGuard_3 = 1334,
        FrostwolfClan_3 = 1335,
        ShenDralar = 1354,
        ShenDralar_2 = 1355,
        OgreCaptainKromcrush = 1374,
        Treasure_6 = 1375,
        DragonflightBlack_2 = 1394,
        SilithidAttackers = 1395,
        SpiritGuideAlliance = 1414,
        SpiritGuideHorde = 1415,
        Jaedenar = 1434,
        Victim_4 = 1454,
        ThoriumBrotherhood = 1474,
        ThoriumBrotherhood_2 = 1475,
        HordeGeneric_6 = 1494,
        HordeGeneric_7 = 1495,
        HordeGeneric_8 = 1496,
        SilverwingSentinels = 1514,
        WarsongOutriders = 1515,
        StormpikeGuard_4 = 1534,
        FrostwolfClan_4 = 1554,
        DarkmoonFaire = 1555,
        ZandalarTribe = 1574,
        Stormwind_5 = 1575,
        SilvermoonRemnant_2 = 1576,
        TheLeagueOfArathor = 1577,
        Darnassus_6 = 1594,
        Orgrimmar_7 = 1595,
        StormpikeGuard_5 = 1596,
        FrostwolfClan_5 = 1597,
        TheDefilers_2 = 1598,
        TheLeagueOfArathor_2 = 1599,
        Darnassus_7 = 1600,
        BroodOfNozdormu_2 = 1601,
        SilvermoonCity = 1602,
        SilvermoonCity_2 = 1603,
        SilvermoonCity_3 = 1604,
        DragonflightBronze = 1605,
        Creature_7 = 1606,
        Creature_8 = 1607,
        CenarionCircle_5 = 1608,
        PLAYERBloodElf = 1610,
        Ironforge_4 = 1611,
        Orgrimmar_8 = 1612,
        MightOfKalimdor_2 = 1613,
        Monster_6 = 1614,
        SteamwheedleCartel = 1615,
        RCObjects = 1616,
        RCEnemies = 1617,
        Ironforge_5 = 1618,
        Orgrimmar_9 = 1619,
        Enemy_2 = 1620,
        Blue = 1621,
        Red = 1622,
        Tranquillien = 1623,
        ArgentDawn_3 = 1624,
        ArgentDawn_4 = 1625,
        UndeadScourge_4 = 1626,
        Farstriders = 1627,
        Tranquillien_2 = 1628,
        PLAYERDraenei = 1629,
        ScourgeInvaders = 1630,
        ScourgeInvaders_2 = 1634,
        SteamwheedleCartel_2 = 1635,
        Farstriders_2 = 1636,
        Farstriders_3 = 1637,
        Exodar = 1638,
        Exodar_2 = 1639,
        Exodar_3 = 1640,
        WarsongOutriders_2 = 1641,
        SilverwingSentinels_2 = 1642,
        TrollForest = 1643,
        TheSonsOfLothar = 1644,
        TheSonsOfLothar_2 = 1645,
        Exodar_4 = 1646,
        Exodar_5 = 1647,
        TheSonsOfLothar_3 = 1648,
        TheSonsOfLothar_4 = 1649,
        TheMagHar = 1650,
        TheMagHar_2 = 1651,
        TheMagHar_3 = 1652,
        TheMagHar_4 = 1653,
        Exodar_6 = 1654,
        Exodar_7 = 1655,
        SilvermoonCity_4 = 1656,
        SilvermoonCity_5 = 1657,
        SilvermoonCity_6 = 1658,
        CenarionExpedition = 1659,
        CenarionExpedition_2 = 1660,
        CenarionExpedition_3 = 1661,
        FelOrc = 1662,
        FelOrcGhost = 1663,
        SonsOfLotharGhosts = 1664,
        HonorHold = 1666,
        HonorHold_2 = 1667,
        Thrallmar = 1668,
        Thrallmar_2 = 1669,
        Thrallmar_3 = 1670,
        HonorHold_3 = 1671,
        TestFaction1 = 1672,
        ToWoWFlag = 1673,
        TestFaction4 = 1674,
        TestFaction3 = 1675,
        ToWoWFlagTriggerHordeDND = 1676,
        ToWoWFlagTriggerAllianceDND = 1677,
        Ethereum = 1678,
        Broken = 1679,
        Elemental_4 = 1680,
        EarthElemental = 1681,
        FightingRobots = 1682,
        ActorGood = 1683,
        ActorEvil = 1684,
        StillpineFurbolg = 1685,
        StillpineFurbolg_2 = 1686,
        CrazedOwlkin = 1687,
        ChessAlliance = 1688,
        ChessHorde = 1689,
        ChessAlliance_2 = 1690,
        ChessHorde_2 = 1691,
        MonsterSpar = 1692,
        MonsterSparBuddy = 1693,
        Exodar_8 = 1694,
        SilvermoonCity_7 = 1695,
        TheVioletEye = 1696,
        FelOrc_2 = 1697,
        Exodar_9 = 1698,
        Exodar_10 = 1699,
        Exodar_11 = 1700,
        Sunhawks = 1701,
        Sunhawks_2 = 1702,
        TrainingDummy_3 = 1703,
        FelOrc_3 = 1704,
        FelOrc_4 = 1705,
        FungalGiant = 1706,
        Sporeggar = 1707,
        Sporeggar_2 = 1708,
        Sporeggar_3 = 1709,
        CenarionExpedition_4 = 1710,
        MonsterPredator = 1711,
        MonsterPrey = 1712,
        MonsterPrey_2 = 1713,
        Sunhawks_3 = 1714,
        VoidAnomaly = 1715,
        HyjalDefenders = 1716,
        HyjalDefenders_2 = 1717,
        HyjalDefenders_3 = 1718,
        HyjalDefenders_4 = 1719,
        HyjalInvaders = 1720,
        Kurenai = 1721,
        Kurenai_2 = 1722,
        Kurenai_3 = 1723,
        Kurenai_4 = 1724,
        EarthenRing = 1725,
        EarthenRing_2 = 1726,
        EarthenRing_3 = 1727,
        CenarionExpedition_5 = 1728,
        Thrallmar_4 = 1729,
        TheConsortium = 1730,
        TheConsortium_2 = 1731,
        AllianceGeneric_8 = 1732,
        AllianceGeneric_9 = 1733,
        HordeGeneric_9 = 1734,
        HordeGeneric_10 = 1735,
        MonsterSparBuddy_2 = 1736,
        HonorHold_4 = 1737,
        Arakkoa = 1738,
        ZangarmarshBannerAlliance = 1739,
        ZangarmarshBannerHorde = 1740,
        TheShaTar = 1741,
        ZangarmarshBannerNeutral = 1742,
        TheAldor = 1743,
        TheScryers = 1744,
        SilvermoonCity_8 = 1745,
        TheScryers_2 = 1746,
        CavernsOfTimeThrall = 1747,
        CavernsOfTimeDurnholde = 1748,
        CavernsOfTimeSouthshoreGuards = 1749,
        ShadowCouncilCovert = 1750,
        Monster_7 = 1751,
        DarkPortalAttackerLegion = 1752,
        DarkPortalAttackerLegion_2 = 1753,
        DarkPortalAttackerLegion_3 = 1754,
        DarkPortalDefenderAlliance = 1755,
        DarkPortalDefenderAlliance_2 = 1756,
        DarkPortalDefenderAlliance_3 = 1757,
        DarkPortalDefenderHorde = 1758,
        DarkPortalDefenderHorde_2 = 1759,
        DarkPortalDefenderHorde_3 = 1760,
        InciterTrigger = 1761,
        InciterTrigger2 = 1762,
        InciterTrigger3 = 1763,
        InciterTrigger4 = 1764,
        InciterTrigger5 = 1765,
        ArgentDawn_5 = 1766,
        ArgentDawn_6 = 1767,
        Demon_3 = 1768,
        Demon_4 = 1769,
        ActorGood_2 = 1770,
        ActorEvil_2 = 1771,
        ManaCreature = 1772,
        KhadgarsServant = 1773,
        Friendly_3 = 1774,
        TheShaTar_2 = 1775,
        TheAldor_2 = 1776,
        TheAldor_3 = 1777,
        TheScaleOfTheSands = 1778,
        KeepersOfTime = 1779,
        BladespireClan = 1780,
        BloodmaulClan = 1781,
        BladespireClan_2 = 1782,
        BloodmaulClan_2 = 1783,
        BladespireClan_3 = 1784,
        BloodmaulClan_3 = 1785,
        Demon_5 = 1786,
        Monster_8 = 1787,
        TheConsortium_3 = 1788,
        Sunhawks_4 = 1789,
        BladespireClan_4 = 1790,
        BloodmaulClan_4 = 1791,
        FelOrc_5 = 1792,
        Sunhawks_5 = 1793,
        Protectorate = 1794,
        Protectorate_2 = 1795,
        Ethereum_2 = 1796,
        Protectorate_3 = 1797,
        ArcaneAnnihilatorDNR = 1798,
        EthereumSparbuddy = 1799,
        Ethereum_3 = 1800,
        Horde = 1801,
        Alliance = 1802,
        Ambient_3 = 1803,
        Ambient_4 = 1804,
        TheAldor_4 = 1805,
        Friendly_4 = 1806,
        Protectorate_4 = 1807,
        KirinVarBelmara = 1808,
        KirinVarCohlien = 1809,
        KirinVarDathric = 1810,
        KirinVarLuminrath = 1811,
        Friendly_5 = 1812,
        ServantOfIllidan = 1813,
        MonsterSparBuddy_3 = 1814,
        BeastWolf_3 = 1815,
        Friendly_6 = 1816,
        LowerCity = 1818,
        AllianceGeneric_10 = 1819,
        AshtongueDeathsworn = 1820,
        SpiritsOfShadowmoon1 = 1821,
        SpiritsOfShadowmoon2 = 1822,
        Ethereum_4 = 1823,
        Netherwing = 1824,
        Demon_6 = 1825,
        ServantOfIllidan_2 = 1826,
        Wyrmcult = 1827,
        Treant = 1828,
        LeotherasDemonI = 1829,
        LeotherasDemonII = 1830,
        LeotherasDemonIII = 1831,
        LeotherasDemonIV = 1832,
        LeotherasDemonV = 1833,
        Azaloth = 1834,
        HordeGeneric_11 = 1835,
        TheConsortium_4 = 1836,
        Sporeggar_4 = 1837,
        TheScryers_3 = 1838,
        RockFlayer = 1839,
        FlayerHunter = 1840,
        ShadowmoonShade = 1841,
        LegionCommunicator = 1842,
        ServantOfIllidan_3 = 1843,
        TheAldor_5 = 1844,
        TheScryers_4 = 1845,
        RavenswoodAncients = 1846,
        MonsterSpar_2 = 1847,
        MonsterSparBuddy_4 = 1848,
        ServantOfIllidan_4 = 1849,
        Netherwing_2 = 1850,
        LowerCity_2 = 1851,
        ChessFriendlyToAllChess = 1852,
        ServantOfIllidan_5 = 1853,
        TheAldor_6 = 1854,
        TheScryers_5 = 1855,
        ShaTariSkyguard = 1856,
        Friendly_7 = 1857,
        AshtongueDeathsworn_2 = 1858,
        Maiev = 1859,
        SkettisShadowyArakkoa = 1860,
        SkettisArakkoa = 1862,
        OrcDragonmaw_2 = 1863,
        DragonmawEnemy = 1864,
        OrcDragonmaw_3 = 1865,
        AshtongueDeathsworn_3 = 1866,
        Maiev_2 = 1867,
        MonsterSparBuddy_5 = 1868,
        Arakkoa_2 = 1869,
        ShaTariSkyguard_2 = 1870,
        SkettisArakkoa_2 = 1871,
        OgriLa = 1872,
        RockFlayer_2 = 1873,
        OgriLa_2 = 1874,
        TheAldor_7 = 1875,
        TheScryers_6 = 1876,
        OrcDragonmaw_4 = 1877,
        Frenzy = 1878,
        SkyguardEnemy = 1879,
        OrcDragonmaw_5 = 1880,
        SkettisArakkoa_3 = 1881,
        ServantOfIllidan_6 = 1882,
        TheramoreDeserter = 1883,
        Tuskarr = 1884,
        Vrykul = 1885,
        Creature_9 = 1886,
        Creature_10 = 1887,
        NorthseaPirates = 1888,
        UNUSED = 1889,
        TrollAmani = 1890,
        ValianceExpedition = 1891,
        ValianceExpedition_2 = 1892,
        ValianceExpedition_3 = 1893,
        Vrykul_2 = 1894,
        Vrykul_3 = 1895,
        DarkmoonFaire_2 = 1896,
        TheHandOfVengeance = 1897,
        ValianceExpedition_4 = 1898,
        ValianceExpedition_5 = 1899,
        TheHandOfVengeance_2 = 1900,
        HordeExpedition = 1901,
        ActorEvil_3 = 1902,
        ActorEvil_4 = 1904,
        TamedPlaguehound = 1905,
        SpottedGryphon = 1906,
        TestFaction1_2 = 1907,
        TestFaction1_3 = 1908,
        BeastRaptor_2 = 1909,
        VrykulAncientSpirit1 = 1910,
        VrykulAncientSiprit2 = 1911,
        VrykulAncientSiprit3 = 1912,
        CTFFlagAlliance = 1913,
        Vrykul_4 = 1914,
        Test = 1915,
        Maiev_3 = 1916,
        Creature_11 = 1917,
        HordeExpedition_2 = 1918,
        VrykulGladiator = 1919,
        ValgardeCombatant = 1920,
        TheTaunka = 1921,
        TheTaunka_2 = 1922,
        TheTaunka_3 = 1923,
        MonsterZoneForceReaction1 = 1924,
        Monster_9 = 1925,
        ExplorersLeague = 1926,
        ExplorersLeague_2 = 1927,
        TheHandOfVengeance_3 = 1928,
        TheHandOfVengeance_4 = 1929,
        RamRacingPowerupDND = 1930,
        RamRacingTrapDND = 1931,
        Elemental_5 = 1932,
        Friendly_8 = 1933,
        ActorGood_3 = 1934,
        ActorGood_4 = 1935,
        CraigsSquirrels = 1936,
        CraigsSquirrels_2 = 1937,
        CraigsSquirrels_3 = 1938,
        CraigsSquirrels_4 = 1939,
        CraigsSquirrels_5 = 1940,
        CraigsSquirrels_6 = 1941,
        CraigsSquirrels_7 = 1942,
        CraigsSquirrels_8 = 1943,
        CraigsSquirrels_9 = 1944,
        CraigsSquirrels_10 = 1945,
        CraigsSquirrels_11 = 1947,
        Blue_2 = 1948,
        TheKaluAk = 1949,
        TheKaluAk_2 = 1950,
        Darnassus_8 = 1951,
        HolidayWaterBarrel = 1952,
        MonsterPredator_2 = 1953,
        IronDwarves = 1954,
        IronDwarves_2 = 1955,
        ShatteredSunOffensive = 1956,
        ShatteredSunOffensive_2 = 1957,
        ActorEvil_5 = 1958,
        ActorEvil_6 = 1959,
        ShatteredSunOffensive_3 = 1960,
        FightingVanityPet = 1961,
        UndeadScourge_5 = 1962,
        Demon_7 = 1963,
        UndeadScourge_6 = 1964,
        MonsterSpar_3 = 1965,
        Murloc_2 = 1966,
        ShatteredSunOffensive_4 = 1967,
        MurlocWinterfin = 1968,
        Murloc_3 = 1969,
        Monster_10 = 1970,
        FriendlyForceReaction = 1971,
        ObjectForceReaction = 1972,
        ValianceExpedition_6 = 1973,
        ValianceExpedition_7 = 1974,
        UndeadScourge_7 = 1975,
        ValianceExpedition_8 = 1976,
        ValianceExpedition_9 = 1977,
        WarsongOffensive = 1978,
        WarsongOffensive_2 = 1979,
        WarsongOffensive_3 = 1980,
        WarsongOffensive_4 = 1981,
        UndeadScourge_8 = 1982,
        MonsterSpar_4 = 1983,
        MonsterSparBuddy_6 = 1984,
        Monster_11 = 1985,
        Escortee_11 = 1986,
        CenarionExpedition_6 = 1987,
        UndeadScourge_9 = 1988,
        Poacher = 1989,
        Ambient_5 = 1990,
        UndeadScourge_10 = 1991,
        Monster_12 = 1992,
        MonsterSpar_5 = 1993,
        MonsterSparBuddy_7 = 1994,
        CTFFlagAlliance_2 = 1995,
        CTFFlagAlliance_3 = 1997,
        HolidayMonster = 1998,
        MonsterPrey_3 = 1999,
        MonsterPrey_4 = 2000,
        FurbolgRedfang = 2001,
        FurbolgFrostpaw = 2003,
        ValianceExpedition_10 = 2004,
        UndeadScourge_11 = 2005,
        KirinTor = 2006,
        KirinTor_2 = 2007,
        KirinTor_3 = 2008,
        KirinTor_4 = 2009,
        TheWyrmrestAccord = 2010,
        TheWyrmrestAccord_2 = 2011,
        TheWyrmrestAccord_3 = 2012,
        TheWyrmrestAccord_4 = 2013,
        AzjolNerub = 2014,
        AzjolNerub_2 = 2016,
        AzjolNerub_3 = 2017,
        UndeadScourge_12 = 2018,
        TheTaunka_4 = 2019,
        WarsongOffensive_5 = 2020,
        REUSE = 2021,
        Monster_13 = 2022,
        ScourgeInvaders_3 = 2023,
        TheHandOfVengeance_5 = 2024,
        TheSilverCovenant = 2025,
        TheSilverCovenant_2 = 2026,
        TheSilverCovenant_3 = 2027,
        Ambient_6 = 2028,
        MonsterPredator_3 = 2029,
        MonsterPredator_4 = 2030,
        HordeGeneric_12 = 2031,
        GrizzlyHillsTrapper = 2032,
        Monster_14 = 2033,
        WarsongOffensive_6 = 2034,
        UndeadScourge_13 = 2035,
        Friendly_9 = 2036,
        ValianceExpedition_11 = 2037,
        Ambient_7 = 2038,
        Monster_15 = 2039,
        ValianceExpedition_12 = 2040,
        TheWyrmrestAccord_5 = 2041,
        UndeadScourge_14 = 2042,
        UndeadScourge_15 = 2043,
        ValianceExpedition_13 = 2044,
        WarsongOffensive_7 = 2045,
        Escortee_12 = 2046,
        TheKaluAk_3 = 2047,
        ScourgeInvaders_4 = 2048,
        ScourgeInvaders_5 = 2049,
        KnightsOfTheEbonBlade = 2050,
        KnightsOfTheEbonBlade_2 = 2051,
        WrathgateScourge = 2052,
        WrathgateAlliance = 2053,
        WrathgateHorde = 2054,
        MonsterSpar_6 = 2055,
        MonsterSparBuddy_8 = 2056,
        MonsterZoneForceReaction2 = 2057,
        CTFFlagHorde = 2058,
        CTFFlagNeutral = 2059,
        FrenzyheartTribe = 2060,
        FrenzyheartTribe_2 = 2061,
        FrenzyheartTribe_3 = 2062,
        TheOracles = 2063,
        TheOracles_2 = 2064,
        TheOracles_3 = 2065,
        TheOracles_4 = 2066,
        TheWyrmrestAccord_6 = 2067,
        UndeadScourge_16 = 2068,
        TrollDrakkari = 2069,
        ArgentCrusade = 2070,
        ArgentCrusade_2 = 2071,
        ArgentCrusade_3 = 2072,
        ArgentCrusade_4 = 2073,
        CavernsOfTimeDurnholde_2 = 2074,
        CoTScourge = 2075,
        CoTArthas = 2076,
        CoTArthas_2 = 2077,
        CoTStratholmeCitizen = 2078,
        CoTArthas_3 = 2079,
        UndeadScourge_17 = 2080,
        Freya = 2081,
        UndeadScourge_18 = 2082,
        UndeadScourge_19 = 2083,
        UndeadScourge_20 = 2084,
        UndeadScourge_21 = 2085,
        ArgentDawn_7 = 2086,
        ArgentDawn_8 = 2087,
        ActorEvil_7 = 2088,
        ScarletCrusade_3 = 2089,
        MountTaxiAlliance = 2090,
        MountTaxiHorde = 2091,
        MountTaxiNeutral = 2092,
        UndeadScourge_22 = 2093,
        UndeadScourge_23 = 2094,
        ScarletCrusade_4 = 2095,
        ScarletCrusade_5 = 2096,
        UndeadScourge_24 = 2097,
        ElementalAir = 2098,
        ElementalWater = 2099,
        UndeadScourge_25 = 2100,
        ActorEvil_8 = 2101,
        ActorEvil_9 = 2102,
        ScarletCrusade_6 = 2103,
        MonsterSpar_7 = 2104,
        MonsterSparBuddy_9 = 2105,
        Ambient_8 = 2106,
        TheSonsOfHodir = 2107,
        IronGiants = 2108,
        FrostVrykul = 2109,
        Friendly_10 = 2110,
        Monster_16 = 2111,
        TheSonsOfHodir_2 = 2112,
        FrostVrykul_2 = 2113,
        Vrykul_5 = 2114,
        ActorGood_5 = 2115,
        Vrykul_6 = 2116,
        ActorGood_6 = 2117,
        Earthen = 2118,
        MonsterReferee = 2119,
        MonsterReferee_2 = 2120,
        TheSunreavers = 2121,
        TheSunreavers_2 = 2122,
        TheSunreavers_3 = 2123,
        Monster_17 = 2124,
        FrostVrykul_3 = 2125,
        FrostVrykul_4 = 2126,
        Ambient_9 = 2127,
        Hyldsmeet = 2128,
        TheSunreavers_4 = 2129,
        TheSilverCovenant_4 = 2130,
        ArgentCrusade_5 = 2131,
        WarsongOffensive_8 = 2132,
        FrostVrykul_5 = 2133,
        ArgentCrusade_6 = 2134,
        Friendly_11 = 2135,
        Ambient_10 = 2136,
        Friendly_12 = 2137,
        ArgentCrusade_7 = 2138,
        ScourgeInvaders_6 = 2139,
        Friendly_13 = 2140,
        Friendly_14 = 2141,
        Alliance_2 = 2142,
        ValianceExpedition_14 = 2143,
        KnightsOfTheEbonBlade_3 = 2144,
        ScourgeInvaders_7 = 2145,
        TheKaluAk_4 = 2148,
        MonsterSparBuddy_10 = 2150,
        Ironforge_6 = 2155,
        MonsterPredator_5 = 2156,
        End = 2157,
    }

    // Summary:
    //     The Ids for the different races
    //
    // Remarks:
    //     Values come from column 1 of ChrRaces.dbc
    public enum RaceId
    {
        None = 0,
        Human = 1,
        Orc = 2,
        Dwarf = 3,
        NightElf = 4,
        Undead = 5,
        Tauren = 6,
        Gnome = 7,
        Troll = 8,
        Goblin = 9,
        BloodElf = 10,
        Draenei = 11,
        FelOrc = 12,
        Naga = 13,
        Broken = 14,
        Skeleton = 15,
        End = 16,
    }

    public enum FactionReputationIndex
    {
        Invalid = -1,
        None = 0,
        BootyBay = 1,
        GelkisClanCentaur = 2,
        MagramClanCentaur = 3,
        ThoriumBrotherhood = 4,
        Ravenholdt = 5,
        Syndicate = 6,
        Gadgetzan = 7,
        Ratchet = 9,
        SteamwheedleCartel = 10,
        Alliance = 11,
        Horde = 12,
        ArgentDawn = 13,
        Orgrimmar = 14,
        DarkspearTrolls = 15,
        ThunderBluff = 16,
        Undercity = 17,
        GnomereganExiles = 18,
        Stormwind = 19,
        Ironforge = 20,
        Darnassus = 21,
        WintersaberTrainers = 27,
        Everlook = 28,
        TimbermawHold = 35,
        CenarionCircle = 36,
        Thrallmar = 37,
        HonorHold = 38,
        TheShaTar = 39,
        StormpikeGuard = 40,
        FrostwolfClan = 41,
        HydraxianWaterlords = 42,
        ShenDralar = 44,
        SilverwingSentinels = 45,
        WarsongOutriders = 46,
        Exodar = 49,
        DarkmoonFaire = 50,
        ZandalarTribe = 51,
        TheDefilers = 52,
        TheLeagueOfArathor = 53,
        BroodOfNozdormu = 54,
        SilvermoonCity = 55,
        Tranquillien = 56,
        TheScaleOfTheSands = 57,
        TheAldor = 58,
        TheConsortium = 60,
        TheMagHar = 61,
        TheScryers = 62,
        TheVioletEye = 63,
        CenarionExpedition = 64,
        Sporeggar = 65,
        Kurenai = 66,
        KeepersOfTime = 67,
        LowerCity = 69,
        AshtongueDeathsworn = 70,
        Netherwing = 71,
        ShaTariSkyguard = 72,
        OgriLa = 73,
        ValianceExpedition = 74,
        HordeExpedition = 75,
        TheTaunka = 76,
        TheHandOfVengeance = 77,
        ExplorersLeague = 78,
        TheKaluAk = 79,
        ShatteredSunOffensive = 80,
        WarsongOffensive = 81,
        REUSE = 82,
        TheWyrmrestAccord = 83,
        KirinTor = 84,
        TestFaction1 = 85,
        TestFaction3 = 87,
        TheSilverCovenant = 90,
        KnightsOfTheEbonBlade = 91,
        FrenzyheartTribe = 92,
        TheOracles = 93,
        ArgentCrusade = 94,
        TheSonsOfHodir = 97,
        TheSunreavers = 98,
        End = 99,
    }

    public enum ClientLocale
    {
        // Summary:
        //     Any english locale
        English = 0,
        //
        // Summary:
        //     Korean
        Korean = 1,
        //
        // Summary:
        //     French
        French = 2,
        //
        // Summary:
        //     German
        German = 3,
        //
        // Summary:
        //     Simplified Chinese
        ChineseSimplified = 4,
        //
        // Summary:
        //     Traditional Chinese
        ChineseTraditional = 5,
        //
        // Summary:
        //     Spanish.  Also esMX.
        Spanish = 6,
        //
        // Summary:
        //     Russian
        Russian = 7,
        End = 8,
    }

    public enum SellItemError : byte
    {
        Success = 0x00,
        CantFindItem = 0x01,
        CantSellItem = 0x02,
        CantFindVendor = 0x03,
        PlayerDoesntOwnItem = 0x04,
        Unknown = 0x05,
        OnlyEmptyBag = 0x06
    }

    public enum BuyItemError : byte
    {
        CantFindItem = 0x00,
        ItemAlreadySold = 0x01,
        NotEnoughMoney = 0x02,
        Unknown1 = 0x03,
        SellerDoesntLikeYou = 0x04,
        DistanceTooFar = 0x05,
        Unknown2 = 0x06,
        ItemSoldOut = 0x07,
        CantCarryAnymore = 0x08,
        Unknown3 = 0x09,
        Unknown4 = 0x10,
        RankRequirementNotMet = 0x11,
        ReputationRequirementNotMet = 0x12
    }

    #region Item stuff (?)
    [Obfuscation]
    public enum ItemQuality
    {
        Poor = 0,
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Artifact = 6,
        Heirloom = 7,
        Unknown = 8
    }

    [Obfuscation]
    public enum ItemModType
    {
        MANA = 0,
        HEALTH = 1,
        AGILITY = 3,
        STRENGTH = 4,
        INTELLECT = 5,
        SPIRIT = 6,
        STAMINA = 7,
        DEFENSE_SKILL_RATING = 12,
        DODGE_RATING = 13,
        PARRY_RATING = 14,
        BLOCK_RATING = 15,
        HIT_MELEE_RATING = 16,
        HIT_RANGED_RATING = 17,
        HIT_SPELL_RATING = 18,
        CRIT_MELEE_RATING = 19,
        CRIT_RANGED_RATING = 20,
        CRIT_SPELL_RATING = 21,
        HIT_TAKEN_MELEE_RATING = 22,
        HIT_TAKEN_RANGED_RATING = 23,
        HIT_TAKEN_SPELL_RATING = 24,
        CRIT_TAKEN_MELEE_RATING = 25,
        CRIT_TAKEN_RANGED_RATING = 26,
        CRIT_TAKEN_SPELL_RATING = 27,
        HASTE_MELEE_RATING = 28,
        HASTE_RANGED_RATING = 29,
        HASTE_SPELL_RATING = 30,
        HIT_RATING = 31,
        CRIT_RATING = 32,
        HIT_TAKEN_RATING = 33,
        CRIT_TAKEN_RATING = 34,
        RESILIENCE_RATING = 35,
        HASTE_RATING = 36,
        EXPERTISE_RATING = 37
    }

    //internal class Item : WowObject
    //{

    //    //public Item(IWowInterop interop, WoWGuid guid, ObjectTypeId type, UInt32[] fields, IMovementBlock mb)
    //    //    : base(interop, guid, type, fields, mb)
    //    //{
    //    //}






    //    public new string Name { get { return Template.Name; } }
    //    public ItemClass Class { get { return Template.Class; } }
    //    public ItemQuality Quality { get { return Template.Quality; } }
    //    public ItemFlags Flags { get; set; }
    //    public WoWGuid OwnerGuid { get; set; }
    //    public WoWGuid ContainerGuid { get; set; }

    //    public byte StackCount { get; set; }

    //    public bool Equipped
    //    { 
    //        get 
    //        {
    //            var equippedItem = (from i in Interop.Player.Equipment.Values
    //                                where i.GUID == GUID
    //                                select i).FirstOrDefault();

    //            if (equippedItem != null)
    //                return true;
    //            return false;
    //        } 
    //    }

    //    public override string ToString()
    //    {
    //        return Template.ToString();
    //    }

    //    public uint TemplateId { get; set; }
    //    public ItemTemplate Template
    //    {
    //        get
    //        {
    //            if (ItemTemplate.Templates.ContainsKey(TemplateId))
    //                return ItemTemplate.Templates[TemplateId];
    //            else
    //                return ItemTemplate.Empty;
    //        }
    //    }


    //}

    [Flags]
    public enum ItemFlags : uint
    {
        Soulbound = 0x00000001, // set in game at binding, not set in template
        Conjured = 0x00000002,
        Openable = 0x00000004,
        Wrapped = 0x00000008, // conflicts with heroic flag
        //Heroic = 0x00000008, // weird...
        Broken = 0x00000010, // appears red icon (like when item durability==0)
        UNK2 = 0x00000020, // saw this on item 43012, 43013, 46377, 52021...
        Usable = 0x00000040, // ?
        NoEquipCooldown = 0x00000080, // ?
        UNK3 = 0x00000100, // saw this on item 47115, 49295...
        Wrapper = 0x00000200, // used or not used wrapper
        IgnoreBagSpace = 0x00000400, // ignore bag space at new item creation?
        PartyLoot = 0x00000800, // determines if item is party loot or not
        Refundable = 0x00001000, // item cost can be refunded within 2 hours after purchase
        Charter = 0x00002000, // arena/guild charter
        UNK4 = 0x00008000, // a lot of items have this
        UNK1 = 0x00010000, // a lot of items have this
        Prospectable = 0x00040000,
        UniqueEquipped = 0x00080000,
        ArenaUseable = 0x00200000,
        Throwable = 0x00400000, // not used in game for check trow possibility, only for item in game tooltip
        SpecialUse = 0x00800000, // last used flag in 2.3.0
        AccountBound = 0x08000000, // bind on account (set in template for items that can binded in like way)
        EnchantScroll = 0x10000000, // for enchant scrolls
        Millable = 0x20000000,
        BOP_TRADEABLE = 0x80000000
    }

    [Obfuscation]
    enum ItemClass
    {
        Consumable = 0,
        Container = 1,
        Weapon = 2,
        Gem = 3,
        Armor = 4,
        Reagent = 5,
        Projectile = 6,
        Trade = 7,
        Generic = 8,
        Recipie = 9,
        Money = 10,
        Quiver = 11,
        Quest = 12,
        Key = 13,
        Permanent = 14,
        Misc = 15,
        Glyph = 16
    };
    [Obfuscation]
    enum ItemBondingType
    {
        NoBind = 0,
        BoP = 1,
        BoE = 2,
        BoUse = 3,
        Quest = 4,
        Quest2 = 5         // not used in game
    };
    [Obfuscation]
    enum ItemType
    {
        None = 0,
        Head = 1,
        Neck = 2,
        Shoulders = 3,
        Body = 4,
        Chest = 5,
        Waist = 6,
        Legs = 7,
        Feet = 8,
        Wrists = 9,
        Hands = 10,
        Finger = 11,
        Trinket = 12,
        Weapon = 13,
        Shield = 14,
        Ranged = 15,
        Cloak = 16,
        TwoHandedWeapon = 17,
        Bag = 18,
        Tabard = 19,
        Robe = 20,
        MainHand = 21,
        OffHand = 22,
        Holdable = 23,
        Ammo = 24,
        Thrown = 25,
        RangedRight = 26,//??
        Quiver = 27,
        Relic = 28
    };

    /// <summary>
    /// Holds information about an item in inventory, loot, or vendor
    /// </summary>
    internal class LootItem
    {
        public uint Index { get; set; }
        public uint ItemId { get; set; }
        public uint StackCount { get; set; }
        public uint DisplayId { get; set; }
        public uint Suffix { get; set; }
        public uint Properties { get; set; }
        public LootDecision Decision { get; set; }
        public string Name { get; set; }
    }

    //public struct BuyItems
    //{
    //    public UInt64 Vendor;
    //    public UInt64 ItemID;
    //    public Int32 BagID;
    //    public Byte BagSlot;
    //    public UInt32 Amount;
    //    public Int32 Slot;
    //}



    public struct ItemSpellInfo
    {
        uint Id;
        uint Trigger;
        int Charges;
        int Cooldown;
        uint Category;
        int CategoryCooldown;
    }



    public struct StatModifier
    {
        //public ItemModType Type;
        public int Value;

    }

    public enum LootResponseType : byte
    {
        Fail = 0,
        Default = 1,
        Profession
    }

    public enum LootDecision : byte
    {
        /// <summary>
        /// Free to be taken
        /// </summary>
        Free = 0,
        /// <summary>
        /// Must be rolled for
        /// </summary>
        Rolling = 1,
        /// <summary>
        /// MasterLooter decides
        /// </summary>
        Master = 2
    }

    #endregion
    #endregion

    #region WoW
    #region SpellBook
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpellBookEntry
    {
        /// <summary>
        /// `1` if the LocalPlayer knows this spell
        /// </summary>
        public SpellBookType Type;
        /// <summary>
        /// ID of the spell in this spellbook entry
        /// </summary>
        public uint SpellID;
    }

    public enum SpellBookType : int
    {
        Known = 1,
        Trainable = 2,
        Pet = 3,
        Flyout = 4,
    }
    #endregion

    [System.Diagnostics.DebuggerDisplay("ID {Id} | SkillStep {SkillStep} | CurValue {CurValue} / MaxValue {MaxValue} | Modifier {Modifier} | Bonus {Bonus}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct PlayerSkillEntry //4.0.3a -- all credit to Lecht
    {
        public ushort Id;
        public ushort SkillStep;
        public ushort CurValue;
        public ushort MaxValue;
        public short Modifier;
        public ushort Bonus;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MerchantItem //4.0.3a
    {
        /* MerchantItem struc ; (sizeof=0x28) */
        public int Index;
        int unk_4;
        public int ItemID;
        public int Icon;
        public int NumAvailable;
        public int BuyPrice;
        int unk_18;
        public int Quantity;
        public int ExtendedCostDBIndex;
        int unk_24;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AuraEntry
    {
        public ulong creatorGUID; //0-8
        public uint auraID; //8-12
        public byte flags; //12-13
        public byte level; //13-14
        public byte count; //14-15
        byte unk1; //15-16
        public uint duration; //16-20
        public uint endTime; //20-24

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        int[] unk_end; //24-28, 28-32, 32-36, 36-40

        //INCOMPLETE
    }

    public enum ClickToMoveAction : uint
    {
        FaceTarget = 0x1,
        Face = 0x2,
        Follow = 0x3,
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

    [Flags]
    public enum AuraFlags : byte
    {
        None = 0,
        Effect1AppliesAura = 0x1, // 001
        Effect2AppliesAura = 0x2, // 010
        Effect3AppliesAura = 0x4, // 100
        TargetIsCaster = 0x8,
        Positive = 0x10,
        HasDuration = 0x20,
        Flag_0x40 = 0x40,
        Negative = 0x80,
    }

    public enum WowEvents
    {
        SET_GLUE_SCREEN = 0x0,
        START_GLUE_MUSIC = 0x1,
        DISCONNECTED_FROM_SERVER = 0x2,
        OPEN_STATUS_DIALOG = 0x3,
        UPDATE_STATUS_DIALOG = 0x4,
        CLOSE_STATUS_DIALOG = 0x5,
        ADDON_LIST_UPDATE = 0x6,
        CHARACTER_LIST_UPDATE = 0x7,
        UPDATE_SELECTED_CHARACTER = 0x8,
        OPEN_REALM_LIST = 0x9,
        GET_PREFERRED_REALM_INFO = 0xA,
        UPDATE_SELECTED_RACE = 0xB,
        SELECT_LAST_CHARACTER = 0xC,
        SELECT_FIRST_CHARACTER = 0xD,
        GLUE_SCREENSHOT_SUCCEEDED = 0xE,
        GLUE_SCREENSHOT_FAILED = 0xF,
        PATCH_UPDATE_PROGRESS = 0x10,
        PATCH_DOWNLOADED = 0x11,
        SUGGEST_REALM = 0x12,
        SUGGEST_REALM_WRONG_PVP = 0x13,
        SUGGEST_REALM_WRONG_CATEGORY = 0x14,
        SHOW_SERVER_ALERT = 0x15,
        FRAMES_LOADED = 0x16,
        FORCE_RENAME_CHARACTER = 0x17,
        FORCE_DECLINE_CHARACTER = 0x18,
        SHOW_SURVEY_NOTIFICATION = 0x19,
        PLAYER_ENTER_PIN = 0x1A,
        CLIENT_ACCOUNT_MISMATCH = 0x1B,
        PLAYER_ENTER_MATRIX = 0x1C,
        SCANDLL_ERROR = 0x1D,
        SCANDLL_DOWNLOADING = 0x1E,
        SCANDLL_FINISHED = 0x1F,
        SERVER_SPLIT_NOTICE = 0x20,
        TIMER_ALERT = 0x21,
        ACCOUNT_MESSAGES_AVAILABLE = 0x22,
        ACCOUNT_MESSAGES_HEADERS_LOADED = 0x23,
        ACCOUNT_MESSAGES_BODY_LOADED = 0x24,
        CLIENT_TRIAL = 0x25,
        PLAYER_ENTER_TOKEN = 0x26,
        GAME_ACCOUNTS_UPDATED = 0x27,
        CLIENT_CONVERTED = 0x28,
        UNIT_PET = 0x0,
        UNIT_PET_2 = 0x2,
        UNIT_TARGET = 0xC,
        UNIT_DISPLAYPOWER = 0x11,
        UNIT_HEALTH = 0x12,
        UNIT_MAXHEALTH = 0x1E,
        UNIT_LEVEL = 0x40,
        UNIT_FACTION = 0x41,
        UNIT_FLAGS = 0x45,
        UNIT_FLAGS_2 = 0x46,
        UNIT_ATTACK_SPEED = 0x48,
        UNIT_ATTACK_SPEED_2 = 0x49,
        UNIT_RANGEDDAMAGE = 0x4A,
        UNIT_DAMAGE = 0x50,
        UNIT_DAMAGE_2 = 0x51,
        UNIT_DAMAGE_3 = 0x52,
        UNIT_DAMAGE_4 = 0x53,
        UNIT_PET_EXPERIENCE = 0x57,
        UNIT_PET_EXPERIENCE_2 = 0x58,
        UNIT_DYNAMIC_FLAGS = 0x59,
        UNIT_STATS = 0x5E,
        UNIT_STATS_2 = 0x5F,
        UNIT_STATS_3 = 0x60,
        UNIT_STATS_4 = 0x61,
        UNIT_STATS_5 = 0x62,
        UNIT_RESISTANCES = 0x6D,
        UNIT_RESISTANCES_2 = 0x6E,
        UNIT_RESISTANCES_3 = 0x6F,
        UNIT_RESISTANCES_4 = 0x70,
        UNIT_RESISTANCES_5 = 0x71,
        UNIT_RESISTANCES_6 = 0x72,
        UNIT_RESISTANCES_7 = 0x73,
        UNIT_RESISTANCES_8 = 0x74,
        UNIT_RESISTANCES_9 = 0x75,
        UNIT_RESISTANCES_10 = 0x76,
        UNIT_RESISTANCES_11 = 0x77,
        UNIT_RESISTANCES_12 = 0x78,
        UNIT_RESISTANCES_13 = 0x79,
        UNIT_RESISTANCES_14 = 0x7A,
        UNIT_RESISTANCES_15 = 0x7B,
        UNIT_RESISTANCES_16 = 0x7C,
        UNIT_RESISTANCES_17 = 0x7D,
        UNIT_RESISTANCES_18 = 0x7E,
        UNIT_RESISTANCES_19 = 0x7F,
        UNIT_RESISTANCES_20 = 0x80,
        UNIT_RESISTANCES_21 = 0x81,
        UNIT_ATTACK_POWER = 0x85,
        UNIT_ATTACK_POWER_2 = 0x86,
        UNIT_ATTACK_POWER_3 = 0x87,
        UNIT_ATTACK_POWER_4 = 0x88,
        UNIT_RANGED_ATTACK_POWER = 0x89,
        UNIT_RANGED_ATTACK_POWER_2 = 0x8A,
        UNIT_RANGED_ATTACK_POWER_3 = 0x8B,
        UNIT_RANGED_ATTACK_POWER_4 = 0x8C,
        UNIT_RANGEDDAMAGE_2 = 0x8D,
        UNIT_RANGEDDAMAGE_3 = 0x8E,
        UNIT_MANA = 0x8F,
        UNIT_MANA_2 = 0x96,
        UNIT_STATS_6 = 0x9D,
        UNIT_AURA = 0xA0,
        UNIT_COMBAT = 0xA1,
        UNIT_NAME_UPDATE = 0xA2,
        UNIT_PORTRAIT_UPDATE = 0xA3,
        UNIT_MODEL_CHANGED = 0xA4,
        UNIT_INVENTORY_CHANGED = 0xA5,
        UNIT_CLASSIFICATION_CHANGED = 0xA6,
        UNIT_COMBO_POINTS = 0xA7,
        UNIT_TARGETABLE_CHANGED = 0xA8,
        ITEM_LOCK_CHANGED = 0xA9,
        PLAYER_XP_UPDATE = 0xAA,
        PLAYER_REGEN_DISABLED = 0xAB,
        PLAYER_REGEN_ENABLED = 0xAC,
        PLAYER_AURAS_CHANGED = 0xAD,
        PLAYER_ENTER_COMBAT = 0xAE,
        PLAYER_LEAVE_COMBAT = 0xAF,
        PLAYER_TARGET_CHANGED = 0xB0,
        PLAYER_FOCUS_CHANGED = 0xB1,
        PLAYER_CONTROL_LOST = 0xB2,
        PLAYER_CONTROL_GAINED = 0xB3,
        PLAYER_FARSIGHT_FOCUS_CHANGED = 0xB4,
        PLAYER_LEVEL_UP = 0xB5,
        PLAYER_MONEY = 0xB6,
        PLAYER_DAMAGE_DONE_MODS = 0xB7,
        PLAYER_TOTEM_UPDATE = 0xB8,
        ZONE_CHANGED = 0xB9,
        ZONE_CHANGED_INDOORS = 0xBA,
        ZONE_CHANGED_NEW_AREA = 0xBB,
        MINIMAP_UPDATE_ZOOM = 0xBC,
        MINIMAP_UPDATE_TRACKING = 0xBD,
        SCREENSHOT_SUCCEEDED_2 = 0xBE,
        SCREENSHOT_FAILED_2 = 0xBF,
        ACTIONBAR_SHOWGRID = 0xC0,
        ACTIONBAR_HIDEGRID = 0xC1,
        ACTIONBAR_PAGE_CHANGED = 0xC2,
        ACTIONBAR_SLOT_CHANGED = 0xC3,
        ACTIONBAR_UPDATE_STATE = 0xC4,
        ACTIONBAR_UPDATE_USABLE = 0xC5,
        ACTIONBAR_UPDATE_COOLDOWN = 0xC6,
        UPDATE_BONUS_ACTIONBAR = 0xC7,
        PARTY_MEMBERS_CHANGED = 0xC8,
        PARTY_LEADER_CHANGED = 0xC9,
        PARTY_MEMBER_ENABLE = 0xCA,
        PARTY_MEMBER_DISABLE = 0xCB,
        PARTY_LOOT_METHOD_CHANGED = 0xCC,
        SYSMSG = 0xCD,
        UI_ERROR_MESSAGE = 0xCE,
        UI_INFO_MESSAGE = 0xCF,
        UPDATE_CHAT_COLOR = 0xD0,
        CHAT_MSG_ADDON = 0xD1,
        CHAT_MSG_SYSTEM = 0xD2,
        CHAT_MSG_SAY = 0xD3,
        CHAT_MSG_PARTY = 0xD4,
        CHAT_MSG_RAID = 0xD5,
        CHAT_MSG_GUILD = 0xD6,
        CHAT_MSG_OFFICER = 0xD7,
        CHAT_MSG_YELL = 0xD8,
        CHAT_MSG_WHISPER = 0xD9,
        CHAT_MSG_WHISPER_INFORM = 0xDA,
        CHAT_MSG_EMOTE = 0xDB,
        CHAT_MSG_TEXT_EMOTE = 0xDC,
        CHAT_MSG_MONSTER_SAY = 0xDD,
        CHAT_MSG_MONSTER_PARTY = 0xDE,
        CHAT_MSG_MONSTER_YELL = 0xDF,
        CHAT_MSG_MONSTER_WHISPER = 0xE0,
        CHAT_MSG_MONSTER_EMOTE = 0xE1,
        CHAT_MSG_CHANNEL = 0xE2,
        CHAT_MSG_CHANNEL_JOIN = 0xE3,
        CHAT_MSG_CHANNEL_LEAVE = 0xE4,
        CHAT_MSG_CHANNEL_LIST = 0xE5,
        CHAT_MSG_CHANNEL_NOTICE = 0xE6,
        CHAT_MSG_CHANNEL_NOTICE_USER = 0xE7,
        CHAT_MSG_AFK = 0xE8,
        CHAT_MSG_DND = 0xE9,
        CHAT_MSG_IGNORED = 0xEA,
        CHAT_MSG_SKILL = 0xEB,
        CHAT_MSG_LOOT = 0xEC,
        CHAT_MSG_MONEY = 0xED,
        CHAT_MSG_OPENING = 0xEE,
        CHAT_MSG_TRADESKILLS = 0xEF,
        CHAT_MSG_PET_INFO = 0xF0,
        CHAT_MSG_COMBAT_MISC_INFO = 0xF1,
        CHAT_MSG_COMBAT_XP_GAIN = 0xF2,
        CHAT_MSG_COMBAT_HONOR_GAIN = 0xF3,
        CHAT_MSG_COMBAT_FACTION_CHANGE = 0xF4,
        CHAT_MSG_BG_SYSTEM_NEUTRAL = 0xF5,
        CHAT_MSG_BG_SYSTEM_ALLIANCE = 0xF6,
        CHAT_MSG_BG_SYSTEM_HORDE = 0xF7,
        CHAT_MSG_RAID_LEADER = 0xF8,
        CHAT_MSG_RAID_WARNING = 0xF9,
        CHAT_MSG_RAID_BOSS_WHISPER = 0xFA,
        CHAT_MSG_RAID_BOSS_EMOTE = 0xFB,
        CHAT_MSG_FILTERED = 0xFC,
        CHAT_MSG_BATTLEGROUND = 0xFD,
        CHAT_MSG_BATTLEGROUND_LEADER = 0xFE,
        CHAT_MSG_RESTRICTED = 0xFF,
        CHAT_MSG_ACHIEVEMENT = 0x101,
        CHAT_MSG_GUILD_ACHIEVEMENT = 0x102,
        LANGUAGE_LIST_CHANGED = 0x103,
        TIME_PLAYED_MSG = 0x104,
        SPELLS_CHANGED = 0x105,
        CURRENT_SPELL_CAST_CHANGED = 0x106,
        SPELL_UPDATE_COOLDOWN = 0x107,
        SPELL_UPDATE_USABLE = 0x108,
        CHARACTER_POINTS_CHANGED = 0x109,
        SKILL_LINES_CHANGED = 0x10A,
        ITEM_PUSH = 0x10B,
        LOOT_OPENED = 0x10C,
        LOOT_SLOT_CLEARED = 0x10D,
        LOOT_SLOT_CHANGED = 0x10E,
        LOOT_CLOSED = 0x10F,
        PLAYER_LOGIN = 0x110,
        PLAYER_LOGOUT = 0x111,
        PLAYER_ENTERING_WORLD = 0x112,
        PLAYER_LEAVING_WORLD = 0x113,
        PLAYER_ALIVE = 0x114,
        PLAYER_DEAD = 0x115,
        PLAYER_CAMPING = 0x116,
        PLAYER_QUITING = 0x117,
        LOGOUT_CANCEL = 0x118,
        RESURRECT_REQUEST = 0x119,
        PARTY_INVITE_REQUEST = 0x11A,
        PARTY_INVITE_CANCEL = 0x11B,
        GUILD_INVITE_REQUEST = 0x11C,
        GUILD_INVITE_CANCEL = 0x11D,
        GUILD_MOTD = 0x11E,
        TRADE_REQUEST = 0x11F,
        TRADE_REQUEST_CANCEL = 0x120,
        LOOT_BIND_CONFIRM = 0x121,
        EQUIP_BIND_CONFIRM = 0x122,
        AUTOEQUIP_BIND_CONFIRM = 0x123,
        USE_BIND_CONFIRM = 0x124,
        DELETE_ITEM_CONFIRM = 0x125,
        CURSOR_UPDATE = 0x126,
        ITEM_TEXT_BEGIN = 0x127,
        ITEM_TEXT_TRANSLATION = 0x128,
        ITEM_TEXT_READY = 0x129,
        ITEM_TEXT_CLOSED = 0x12A,
        GOSSIP_SHOW = 0x12B,
        GOSSIP_CONFIRM = 0x12C,
        GOSSIP_CONFIRM_CANCEL = 0x12D,
        GOSSIP_ENTER_CODE = 0x12E,
        GOSSIP_CLOSED = 0x12F,
        QUEST_GREETING = 0x130,
        QUEST_DETAIL = 0x131,
        QUEST_PROGRESS = 0x132,
        QUEST_COMPLETE = 0x133,
        QUEST_FINISHED = 0x134,
        QUEST_ITEM_UPDATE = 0x135,
        QUEST_AUTOCOMPLETE = 0x136,
        TAXIMAP_OPENED = 0x137,
        TAXIMAP_CLOSED = 0x138,
        QUEST_LOG_UPDATE = 0x139,
        TRAINER_SHOW = 0x13A,
        TRAINER_UPDATE = 0x13B,
        TRAINER_DESCRIPTION_UPDATE = 0x13C,
        TRAINER_CLOSED = 0x13D,
        CVAR_UPDATE = 0x13E,
        TRADE_SKILL_SHOW = 0x13F,
        TRADE_SKILL_UPDATE = 0x140,
        TRADE_SKILL_NAME_UPDATE = 0x141,
        TRADE_SKILL_CLOSE = 0x142,
        MERCHANT_SHOW = 0x143,
        MERCHANT_UPDATE = 0x144,
        MERCHANT_CLOSED = 0x145,
        TRADE_SHOW = 0x146,
        TRADE_CLOSED = 0x147,
        TRADE_UPDATE = 0x148,
        TRADE_ACCEPT_UPDATE = 0x149,
        TRADE_TARGET_ITEM_CHANGED = 0x14A,
        TRADE_PLAYER_ITEM_CHANGED = 0x14B,
        TRADE_MONEY_CHANGED = 0x14C,
        PLAYER_TRADE_MONEY = 0x14D,
        BAG_OPEN = 0x14E,
        BAG_UPDATE = 0x14F,
        BAG_CLOSED = 0x150,
        BAG_UPDATE_COOLDOWN = 0x151,
        LOCALPLAYER_PET_RENAMED = 0x152,
        UNIT_ATTACK_3 = 0x153,
        UNIT_DEFENSE = 0x154,
        PET_ATTACK_START = 0x155,
        PET_ATTACK_STOP = 0x156,
        UPDATE_MOUSEOVER_UNIT = 0x157,
        UNIT_SPELLCAST_SENT = 0x158,
        UNIT_SPELLCAST_START = 0x159,
        UNIT_SPELLCAST_STOP = 0x15A,
        UNIT_SPELLCAST_FAILED = 0x15B,
        UNIT_SPELLCAST_FAILED_QUIET = 0x15C,
        UNIT_SPELLCAST_INTERRUPTED = 0x15D,
        UNIT_SPELLCAST_DELAYED = 0x15E,
        UNIT_SPELLCAST_SUCCEEDED = 0x15F,
        UNIT_SPELLCAST_CHANNEL_START = 0x160,
        UNIT_SPELLCAST_CHANNEL_UPDATE = 0x161,
        UNIT_SPELLCAST_CHANNEL_STOP = 0x162,
        UNIT_SPELLCAST_INTERRUPTIBLE = 0x163,
        UNIT_SPELLCAST_NOT_INTERRUPTIBLE = 0x164,
        PLAYER_GUILD_UPDATE = 0x165,
        QUEST_ACCEPT_CONFIRM = 0x166,
        PLAYERBANKSLOTS_CHANGED = 0x167,
        BANKFRAME_OPENED = 0x168,
        BANKFRAME_CLOSED = 0x169,
        PLAYERBANKBAGSLOTS_CHANGED = 0x16A,
        FRIENDLIST_UPDATE = 0x16B,
        IGNORELIST_UPDATE = 0x16C,
        MUTELIST_UPDATE = 0x16D,
        PET_BAR_UPDATE = 0x16E,
        PET_BAR_UPDATE_COOLDOWN = 0x16F,
        PET_BAR_SHOWGRID = 0x170,
        PET_BAR_HIDEGRID = 0x171,
        PET_BAR_HIDE_2 = 0x172,
        PET_BAR_UPDATE_USABLE = 0x173,
        MINIMAP_PING = 0x174,
        MIRROR_TIMER_START = 0x175,
        MIRROR_TIMER_PAUSE = 0x176,
        MIRROR_TIMER_STOP = 0x177,
        WORLD_MAP_UPDATE = 0x178,
        WORLD_MAP_NAME_UPDATE = 0x179,
        AUTOFOLLOW_BEGIN = 0x17A,
        AUTOFOLLOW_END = 0x17B,
        CINEMATIC_START = 0x17D,
        CINEMATIC_STOP = 0x17E,
        UPDATE_FACTION = 0x17F,
        CLOSE_WORLD_MAP = 0x180,
        OPEN_TABARD_FRAME = 0x181,
        CLOSE_TABARD_FRAME = 0x182,
        TABARD_CANSAVE_CHANGED = 0x183,
        GUILD_REGISTRAR_SHOW = 0x184,
        GUILD_REGISTRAR_CLOSED = 0x185,
        DUEL_REQUESTED = 0x186,
        DUEL_OUTOFBOUNDS = 0x187,
        DUEL_INBOUNDS = 0x188,
        DUEL_FINISHED = 0x189,
        TUTORIAL_TRIGGER = 0x18A,
        PET_DISMISS_START = 0x18B,
        UPDATE_BINDINGS = 0x18C,
        UPDATE_SHAPESHIFT_FORMS = 0x18D,
        UPDATE_SHAPESHIFT_FORM_2 = 0x18E,
        UPDATE_SHAPESHIFT_USABLE = 0x18F,
        UPDATE_SHAPESHIFT_COOLDOWN = 0x190,
        WHO_LIST_UPDATE = 0x191,
        PETITION_SHOW = 0x192,
        PETITION_CLOSED = 0x193,
        EXECUTE_CHAT_LINE = 0x194,
        UPDATE_MACROS = 0x195,
        UPDATE_TICKET = 0x196,
        UPDATE_CHAT_WINDOWS = 0x197,
        CONFIRM_XP_LOSS = 0x198,
        CORPSE_IN_RANGE = 0x199,
        CORPSE_IN_INSTANCE = 0x19A,
        CORPSE_OUT_OF_RANGE = 0x19B,
        UPDATE_GM_STATUS = 0x19C,
        PLAYER_UNGHOST = 0x19D,
        BIND_ENCHANT = 0x19E,
        REPLACE_ENCHANT = 0x19F,
        TRADE_REPLACE_ENCHANT = 0x1A0,
        TRADE_POTENTIAL_BIND_ENCHANT = 0x1A1,
        PLAYER_UPDATE_RESTING = 0x1A2,
        UPDATE_EXHAUSTION = 0x1A3,
        PLAYER_FLAGS_CHANGED = 0x1A4,
        GUILD_ROSTER_UPDATE = 0x1A5,
        GM_PLAYER_INFO = 0x1A6,
        MAIL_SHOW = 0x1A7,
        MAIL_CLOSED = 0x1A8,
        SEND_MAIL_MONEY_CHANGED = 0x1A9,
        SEND_MAIL_COD_CHANGED = 0x1AA,
        MAIL_SEND_INFO_UPDATE = 0x1AB,
        MAIL_SEND_SUCCESS = 0x1AC,
        MAIL_INBOX_UPDATE = 0x1AD,
        MAIL_LOCK_SEND_ITEMS = 0x1AE,
        MAIL_UNLOCK_SEND_ITEMS = 0x1AF,
        BATTLEFIELDS_SHOW = 0x1B0,
        BATTLEFIELDS_CLOSED = 0x1B1,
        UPDATE_BATTLEFIELD_STATUS = 0x1B2,
        UPDATE_BATTLEFIELD_SCORE = 0x1B3,
        BATTLEFIELD_QUEUE_TIMEOUT = 0x1B4,
        AUCTION_HOUSE_SHOW = 0x1B5,
        AUCTION_HOUSE_CLOSED = 0x1B6,
        NEW_AUCTION_UPDATE = 0x1B7,
        AUCTION_ITEM_LIST_UPDATE = 0x1B8,
        AUCTION_OWNED_LIST_UPDATE = 0x1B9,
        AUCTION_BIDDER_LIST_UPDATE = 0x1BA,
        PET_UI_UPDATE = 0x1BB,
        PET_UI_CLOSE = 0x1BC,
        ADDON_LOADED = 0x1BD,
        VARIABLES_LOADED = 0x1BE,
        MACRO_ACTION_FORBIDDEN = 0x1BF,
        ADDON_ACTION_FORBIDDEN = 0x1C0,
        MACRO_ACTION_BLOCKED = 0x1C1,
        ADDON_ACTION_BLOCKED = 0x1C2,
        START_AUTOREPEAT_SPELL = 0x1C3,
        STOP_AUTOREPEAT_SPELL = 0x1C4,
        PET_STABLE_SHOW = 0x1C5,
        PET_STABLE_UPDATE = 0x1C6,
        PET_STABLE_UPDATE_PAPERDOLL = 0x1C7,
        PET_STABLE_CLOSED = 0x1C8,
        RAID_ROSTER_UPDATE = 0x1C9,
        UPDATE_PENDING_MAIL = 0x1CA,
        UPDATE_INVENTORY_ALERTS = 0x1CB,
        UPDATE_INVENTORY_DURABILITY = 0x1CC,
        UPDATE_TRADESKILL_RECAST = 0x1CD,
        OPEN_MASTER_LOOT_LIST = 0x1CE,
        UPDATE_MASTER_LOOT_LIST = 0x1CF,
        START_LOOT_ROLL = 0x1D0,
        CANCEL_LOOT_ROLL = 0x1D1,
        CONFIRM_LOOT_ROLL = 0x1D2,
        CONFIRM_DISENCHANT_ROLL = 0x1D3,
        INSTANCE_BOOT_START = 0x1D4,
        INSTANCE_BOOT_STOP = 0x1D5,
        LEARNED_SPELL_IN_TAB = 0x1D6,
        DISPLAY_SIZE_CHANGED = 0x1D7,
        CONFIRM_TALENT_WIPE = 0x1D8,
        CONFIRM_BINDER = 0x1D9,
        MAIL_FAILED = 0x1DA,
        CLOSE_INBOX_ITEM = 0x1DB,
        CONFIRM_SUMMON = 0x1DC,
        CANCEL_SUMMON = 0x1DD,
        BILLING_NAG_DIALOG = 0x1DE,
        IGR_BILLING_NAG_DIALOG = 0x1DF,
        PLAYER_SKINNED = 0x1E0,
        TABARD_SAVE_PENDING = 0x1E1,
        UNIT_QUEST_LOG_CHANGED = 0x1E2,
        PLAYER_PVP_KILLS_CHANGED = 0x1E3,
        PLAYER_PVP_RANK_CHANGED = 0x1E4,
        INSPECT_HONOR_UPDATE = 0x1E5,
        UPDATE_WORLD_STATES = 0x1E6,
        AREA_SPIRIT_HEALER_IN_RANGE = 0x1E7,
        AREA_SPIRIT_HEALER_OUT_OF_RANGE = 0x1E8,
        PLAYTIME_CHANGED = 0x1E9,
        UPDATE_LFG_TYPES = 0x1EA,
        UPDATE_LFG_LIST = 0x1EB,
        UPDATE_LFG_LIST_INCREMENTAL = 0x1EC,
        START_MINIGAME = 0x1ED,
        MINIGAME_UPDATE = 0x1EE,
        READY_CHECK = 0x1EF,
        READY_CHECK_CONFIRM = 0x1F0,
        READY_CHECK_FINISHED = 0x1F1,
        RAID_TARGET_UPDATE = 0x1F2,
        GMSURVEY_DISPLAY = 0x1F3,
        UPDATE_INSTANCE_INFO = 0x1F4,
        SOCKET_INFO_UPDATE = 0x1F5,
        SOCKET_INFO_CLOSE = 0x1F6,
        PETITION_VENDOR_SHOW = 0x1F7,
        PETITION_VENDOR_CLOSED = 0x1F8,
        PETITION_VENDOR_UPDATE = 0x1F9,
        COMBAT_TEXT_UPDATE = 0x1FA,
        QUEST_WATCH_UPDATE = 0x1FB,
        KNOWLEDGE_BASE_SETUP_LOAD_SUCCESS = 0x1FC,
        KNOWLEDGE_BASE_SETUP_LOAD_FAILURE = 0x1FD,
        KNOWLEDGE_BASE_QUERY_LOAD_SUCCESS = 0x1FE,
        KNOWLEDGE_BASE_QUERY_LOAD_FAILURE = 0x1FF,
        KNOWLEDGE_BASE_ARTICLE_LOAD_SUCCESS = 0x200,
        KNOWLEDGE_BASE_ARTICLE_LOAD_FAILURE = 0x201,
        KNOWLEDGE_BASE_SYSTEM_MOTD_UPDATED = 0x202,
        KNOWLEDGE_BASE_SERVER_MESSAGE = 0x203,
        ARENA_TEAM_UPDATE = 0x204,
        ARENA_TEAM_ROSTER_UPDATE = 0x205,
        ARENA_TEAM_INVITE_REQUEST = 0x206,
        KNOWN_TITLES_UPDATE = 0x207,
        NEW_TITLE_EARNED = 0x208,
        OLD_TITLE_LOST = 0x209,
        LFG_UPDATE = 0x20A,
        LFG_PROPOSAL_UPDATE = 0x20B,
        LFG_PROPOSAL_SHOW = 0x20C,
        LFG_PROPOSAL_FAILED = 0x20D,
        LFG_PROPOSAL_SUCCEEDED = 0x20E,
        LFG_ROLE_UPDATE = 0x20F,
        LFG_ROLE_CHECK_UPDATE = 0x210,
        LFG_ROLE_CHECK_SHOW = 0x211,
        LFG_ROLE_CHECK_HIDE = 0x212,
        LFG_ROLE_CHECK_ROLE_CHOSEN = 0x213,
        LFG_QUEUE_STATUS_UPDATE = 0x214,
        LFG_BOOT_PROPOSAL_UPDATE = 0x215,
        LFG_LOCK_INFO_RECEIVED = 0x216,
        LFG_UPDATE_RANDOM_INFO = 0x217,
        LFG_OFFER_CONTINUE = 0x218,
        LFG_OPEN_FROM_GOSSIP = 0x219,
        LFG_COMPLETION_REWARD = 0x21A,
        PARTY_LFG_RESTRICTED = 0x21B,
        PLAYER_ROLES_ASSIGNED = 0x21C,
        COMBAT_RATING_UPDATE = 0x21D,
        MODIFIER_STATE_CHANGED = 0x21E,
        UPDATE_STEALTH = 0x21F,
        ENABLE_TAXI_BENCHMARK = 0x220,
        DISABLE_TAXI_BENCHMARK = 0x221,
        VOICE_START = 0x222,
        VOICE_STOP = 0x223,
        VOICE_STATUS_UPDATE = 0x224,
        VOICE_CHANNEL_STATUS_UPDATE = 0x225,
        UPDATE_FLOATING_CHAT_WINDOWS = 0x226,
        RAID_INSTANCE_WELCOME = 0x227,
        MOVIE_RECORDING_PROGRESS = 0x228,
        MOVIE_COMPRESSING_PROGRESS = 0x229,
        MOVIE_UNCOMPRESSED_MOVIE = 0x22A,
        VOICE_PUSH_TO_TALK_START = 0x22B,
        VOICE_PUSH_TO_TALK_STOP = 0x22C,
        GUILDBANKFRAME_OPENED = 0x22D,
        GUILDBANKFRAME_CLOSED = 0x22E,
        GUILDBANKBAGSLOTS_CHANGED = 0x22F,
        GUILDBANK_ITEM_LOCK_CHANGED = 0x230,
        GUILDBANK_UPDATE_TABS = 0x231,
        GUILDBANK_UPDATE_MONEY = 0x232,
        GUILDBANKLOG_UPDATE = 0x233,
        GUILDBANK_UPDATE_WITHDRAWMONEY = 0x234,
        GUILDBANK_UPDATE_TEXT = 0x235,
        GUILDBANK_TEXT_CHANGED = 0x236,
        CHANNEL_UI_UPDATE = 0x237,
        CHANNEL_COUNT_UPDATE = 0x238,
        CHANNEL_ROSTER_UPDATE = 0x239,
        CHANNEL_VOICE_UPDATE = 0x23A,
        CHANNEL_INVITE_REQUEST = 0x23B,
        CHANNEL_PASSWORD_REQUEST = 0x23C,
        CHANNEL_FLAGS_UPDATED = 0x23D,
        VOICE_SESSIONS_UPDATE = 0x23E,
        VOICE_CHAT_ENABLED_UPDATE = 0x23F,
        VOICE_LEFT_SESSION = 0x240,
        INSPECT_READY = 0x241,
        VOICE_SELF_MUTE = 0x242,
        VOICE_PLATE_START = 0x243,
        VOICE_PLATE_STOP = 0x244,
        ARENA_SEASON_WORLD_STATE = 0x245,
        GUILD_EVENT_LOG_UPDATE = 0x246,
        GUILDTABARD_UPDATE = 0x247,
        SOUND_DEVICE_UPDATE = 0x248,
        COMMENTATOR_MAP_UPDATE = 0x249,
        COMMENTATOR_ENTER_WORLD = 0x24A,
        COMBAT_LOG_EVENT = 0x24B,
        COMBAT_LOG_EVENT_UNFILTERED = 0x24C,
        COMMENTATOR_PLAYER_UPDATE = 0x24D,
        PLAYER_ENTERING_BATTLEGROUND = 0x24E,
        BARBER_SHOP_OPEN = 0x24F,
        BARBER_SHOP_CLOSE = 0x250,
        BARBER_SHOP_SUCCESS = 0x251,
        BARBER_SHOP_APPEARANCE_APPLIED = 0x252,
        CALENDAR_UPDATE_INVITE_LIST = 0x253,
        CALENDAR_UPDATE_EVENT_LIST = 0x254,
        CALENDAR_NEW_EVENT = 0x255,
        CALENDAR_OPEN_EVENT = 0x256,
        CALENDAR_CLOSE_EVENT = 0x257,
        CALENDAR_UPDATE_EVENT_2 = 0x258,
        CALENDAR_UPDATE_PENDING_INVITES = 0x259,
        CALENDAR_EVENT_ALARM = 0x25A,
        CALENDAR_UPDATE_ERROR = 0x25B,
        CALENDAR_ACTION_PENDING = 0x25C,
        CALENDAR_UPDATE_GUILD_EVENTS = 0x25D,
        VEHICLE_ANGLE_SHOW = 0x25E,
        VEHICLE_ANGLE_UPDATE = 0x25F,
        VEHICLE_POWER_SHOW = 0x260,
        UNIT_ENTERING_VEHICLE = 0x261,
        UNIT_ENTERED_VEHICLE = 0x262,
        UNIT_EXITING_VEHICLE = 0x263,
        UNIT_EXITED_VEHICLE = 0x264,
        VEHICLE_PASSENGERS_CHANGED = 0x265,
        PLAYER_GAINS_VEHICLE_DATA = 0x266,
        PLAYER_LOSES_VEHICLE_DATA = 0x267,
        PET_FORCE_NAME_DECLENSION = 0x268,
        LEVEL_GRANT_PROPOSED = 0x269,
        SYNCHRONIZE_SETTINGS = 0x26A,
        PLAY_MOVIE = 0x26B,
        RUNE_POWER_UPDATE = 0x26C,
        RUNE_TYPE_UPDATE = 0x26D,
        ACHIEVEMENT_EARNED = 0x26E,
        CRITERIA_UPDATE = 0x26F,
        RECEIVED_ACHIEVEMENT_LIST = 0x270,
        PET_RENAMEABLE = 0x271,
        CURRENCY_DISPLAY_UPDATE = 0x272,
        COMPANION_LEARNED = 0x273,
        COMPANION_UNLEARNED = 0x274,
        COMPANION_UPDATE = 0x275,
        UNIT_THREAT_LIST_UPDATE = 0x276,
        UNIT_THREAT_SITUATION_UPDATE = 0x277,
        GLYPH_ADDED = 0x278,
        GLYPH_REMOVED = 0x279,
        GLYPH_UPDATED = 0x27A,
        GLYPH_ENABLED = 0x27B,
        GLYPH_DISABLED = 0x27C,
        USE_GLYPH = 0x27D,
        TRACKED_ACHIEVEMENT_UPDATE = 0x27E,
        ARENA_OPPONENT_UPDATE = 0x27F,
        INSPECT_ACHIEVEMENT_READY = 0x280,
        RAISED_AS_GHOUL = 0x281,
        PARTY_CONVERTED_TO_RAID = 0x282,
        PVPQUEUE_ANYWHERE_SHOW = 0x283,
        PVPQUEUE_ANYWHERE_UPDATE_AVAILABLE = 0x284,
        QUEST_ACCEPTED = 0x285,
        PLAYER_TALENT_UPDATE = 0x286,
        ACTIVE_TALENT_GROUP_CHANGED = 0x287,
        PET_TALENT_UPDATE = 0x288,
        PREVIEW_TALENT_POINTS_CHANGED = 0x289,
        PREVIEW_TALENT_PRIMARY_TREE_CHANGED = 0x28A,
        PREVIEW_PET_TALENT_POINTS_CHANGED = 0x28B,
        WEAR_EQUIPMENT_SET = 0x28C,
        EQUIPMENT_SETS_CHANGED = 0x28D,
        INSTANCE_LOCK_START = 0x28E,
        INSTANCE_LOCK_STOP = 0x28F,
        INSTANCE_LOCK_WARNING = 0x290,
        PLAYER_EQUIPMENT_CHANGED = 0x291,
        ITEM_LOCKED = 0x292,
        ITEM_UNLOCKED = 0x293,
        TRADE_SKILL_FILTER_UPDATE = 0x294,
        EQUIPMENT_SWAP_PENDING = 0x295,
        EQUIPMENT_SWAP_FINISHED = 0x296,
        NPC_PVPQUEUE_ANYWHERE = 0x297,
        UPDATE_MULTI_CAST_ACTIONBAR = 0x298,
        ENABLE_XP_GAIN = 0x299,
        DISABLE_XP_GAIN = 0x29A,
        BATTLEFIELD_MGR_ENTRY_INVITE = 0x29B,
        BATTLEFIELD_MGR_ENTERED = 0x29C,
        BATTLEFIELD_MGR_QUEUE_REQUEST_RESPONSE = 0x29D,
        BATTLEFIELD_MGR_EJECT_PENDING = 0x29E,
        BATTLEFIELD_MGR_EJECTED = 0x29F,
        BATTLEFIELD_MGR_QUEUE_INVITE = 0x2A0,
        BATTLEFIELD_MGR_STATE_CHANGE = 0x2A1,
        PVP_TYPES_ENABLED = 0x2A2,
        WORLD_STATE_UI_TIMER_UPDATE = 0x2A3,
        END_BOUND_TRADEABLE = 0x2A4,
        UPDATE_CHAT_COLOR_NAME_BY_CLASS = 0x2A5,
        GMRESPONSE_RECEIVED = 0x2A6,
        VEHICLE_UPDATE = 0x2A7,
        WOW_MOUSE_NOT_FOUND = 0x2A8,
        MAIL_SUCCESS = 0x2AA,
        TALENTS_INVOLUNTARILY_RESET = 0x2AB,
        INSTANCE_ENCOUNTER_ENGAGE_UNIT = 0x2AC,
        QUEST_QUERY_COMPLETE = 0x2AD,
        QUEST_POI_UPDATE = 0x2AE,
        PLAYER_DIFFICULTY_CHANGED = 0x2AF,
        CHAT_MSG_PARTY_LEADER = 0x2B0,
        VOTE_KICK_REASON_NEEDED = 0x2B1,
        ENABLE_LOW_LEVEL_RAID = 0x2B2,
        DISABLE_LOW_LEVEL_RAID = 0x2B3,
        CHAT_MSG_TARGETICONS = 0x2B4,
        AUCTION_HOUSE_DISABLED = 0x2B5,
        AUCTION_MULTISELL_START = 0x2B6,
        AUCTION_MULTISELL_UPDATE = 0x2B7,
        AUCTION_MULTISELL_FAILURE = 0x2B8,
        PET_SPELL_POWER_UPDATE = 0x2B9,
        BN_CONNECTED = 0x2BA,
        BN_DISCONNECTED = 0x2BB,
        BN_SELF_ONLINE = 0x2BC,
        BN_SELF_OFFLINE = 0x2BD,
        BN_FRIEND_LIST_SIZE_CHANGED = 0x2BE,
        BN_FRIEND_INVITE_LIST_INITIALIZED = 0x2BF,
        BN_FRIEND_INVITE_SEND_RESULT = 0x2C0,
        BN_FRIEND_INVITE_ADDED = 0x2C1,
        BN_FRIEND_INVITE_REMOVED = 0x2C2,
        BN_FRIEND_INFO_CHANGED = 0x2C3,
        BN_CUSTOM_MESSAGE_CHANGED = 0x2C4,
        BN_CUSTOM_MESSAGE_LOADED = 0x2C5,
        CHAT_MSG_BN_WHISPER = 0x2C6,
        CHAT_MSG_BN_WHISPER_INFORM = 0x2C7,
        BN_CHAT_WHISPER_UNDELIVERABLE = 0x2C8,
        BN_CHAT_CHANNEL_JOINED = 0x2C9,
        BN_CHAT_CHANNEL_LEFT = 0x2CA,
        BN_CHAT_CHANNEL_CLOSED = 0x2CB,
        CHAT_MSG_BN_CONVERSATION = 0x2CC,
        CHAT_MSG_BN_CONVERSATION_NOTICE = 0x2CD,
        CHAT_MSG_BN_CONVERSATION_LIST = 0x2CE,
        BN_CHAT_CHANNEL_MESSAGE_UNDELIVERABLE = 0x2CF,
        BN_CHAT_CHANNEL_MESSAGE_BLOCKED = 0x2D0,
        BN_CHAT_CHANNEL_MEMBER_JOINED = 0x2D1,
        BN_CHAT_CHANNEL_MEMBER_LEFT = 0x2D2,
        BN_CHAT_CHANNEL_MEMBER_UPDATED = 0x2D3,
        BN_CHAT_CHANNEL_CREATE_SUCCEEDED = 0x2D4,
        BN_CHAT_CHANNEL_CREATE_FAILED = 0x2D5,
        BN_CHAT_CHANNEL_INVITE_SUCCEEDED = 0x2D6,
        BN_CHAT_CHANNEL_INVITE_FAILED = 0x2D7,
        BN_BLOCK_LIST_UPDATED = 0x2D8,
        BN_SYSTEM_MESSAGE = 0x2D9,
        BN_REQUEST_FOF_SUCCEEDED = 0x2DA,
        BN_REQUEST_FOF_FAILED = 0x2DB,
        BN_NEW_PRESENCE = 0x2DC,
        BN_TOON_NAME_UPDATED = 0x2DD,
        BN_FRIEND_ACCOUNT_ONLINE = 0x2DE,
        BN_FRIEND_ACCOUNT_OFFLINE = 0x2DF,
        BN_FRIEND_TOON_ONLINE = 0x2E0,
        BN_FRIEND_TOON_OFFLINE = 0x2E1,
        BN_MATURE_LANGUAGE_FILTER = 0x2E2,
        MASTERY_UPDATE = 0x2E3,
        COMMENTATOR_SKIRMISH_QUEUE_REQUEST = 0x2E4,
        COMMENTATOR_SKIRMISH_MODE_REQUEST = 0x2E5,
        CHAT_MSG_BN_INLINE_TOAST_ALERT = 0x2E6,
        CHAT_MSG_BN_INLINE_TOAST_BROADCAST = 0x2E7,
        CHAT_MSG_BN_INLINE_TOAST_BROADCAST_INFORM = 0x2E8,
        CHAT_MSG_BN_INLINE_TOAST_CONVERSATION = 0x2E9,
        FORGE_MASTER_OPENED = 0x2EA,
        FORGE_MASTER_CLOSED = 0x2EB,
        FORGE_MASTER_SET_ITEM = 0x2EC,
        FORGE_MASTER_ITEM_CHANGED = 0x2ED,
        PLAYER_TRADE_CURRENCY = 0x2EE,
        TRADE_CURRENCY_CHANGED = 0x2EF,
        WEIGHTED_SPELL_UPDATED = 0x2F0,
        GUILD_XP_UPDATE = 0x2F1,
        GUILD_PERK_UPDATE = 0x2F2,
        GUILD_TRADESKILL_UPDATE = 0x2F3,
        UNIT_POWER = 0x2F4,
        UNIT_MAXPOWER = 0x2F5,
        ENABLE_DECLINE_GUILD_INVITE = 0x2F6,
        DISABLE_DECLINE_GUILD_INVITE = 0x2F7,
        GUILD_RECIPE_KNOWN_BY_MEMBERS = 0x2F8,
        ARTIFACT_UPDATE = 0x2F9,
        ARTIFACT_HISTORY_READY = 0x2FA,
        ARTIFACT_COMPLETE = 0x2FB,
        ARTIFACT_DIG_SITE_UPDATED = 0x2FC,
        ARCHAEOLOGY_TOGGLE = 0x2FD,
        ARCHAEOLOGY_CLOSED = 0x2FE,
        SPELL_FLYOUT_UPDATE = 0x2FF,
        UNIT_CONNECTION = 0x300,
        UNIT_HEAL_PREDICTION = 0x301,
        ENTERED_DIFFERENT_INSTANCE_FROM_PARTY = 0x302,
        UI_SCALE_CHANGED = 0x303,
        ROLE_CHANGED_INFORM = 0x304,
        GUILD_REWARDS_LIST = 0x305,
        ROLE_POLL_BEGIN = 0x306,
        REQUEST_CEMETERY_LIST_RESPONSE = 0x307,
        WARGAME_REQUESTED = 0x308,
        GUILD_NEWS_UPDATE = 0x309,
        CHAT_SERVER_DISCONNECTED = 0x30A,
        CHAT_SERVER_RECONNECTED = 0x30B,
        STREAMING_ICON = 0x30C,
        RECEIVED_ACHIEVEMENT_MEMBER_LIST = 0x30D,
        SPELL_ACTIVATION_OVERLAY_SHOW = 0x30E,
        SPELL_ACTIVATION_OVERLAY_HIDE = 0x30F,
        SPELL_ACTIVATION_OVERLAY_GLOW_SHOW = 0x310,
        SPELL_ACTIVATION_OVERLAY_GLOW_HIDE = 0x311,
        UNIT_PHASE = 0x312,
        UNIT_POWER_BAR_SHOW = 0x313,
        UNIT_POWER_BAR_HIDE = 0x314,
        GUILD_RANKS_UPDATE = 0x315,
        PVP_RATED_STATS_UPDATE = 0x316,
        CHAT_MSG_COMBAT_GUILD_XP_GAIN = 0x317,
        UNIT_GUILD_LEVEL = 0x318,
        GUILD_PARTY_STATE_UPDATED = 0x319,
        PLAYER_AVG_ITEM_LEVEL_READY = 0x31A,
        ECLIPSE_DIRECTION_CHANGE = 0x31B,
        QUEST_AUTOCOMPLETE_SOUND = 0x31C,
        GET_ITEM_INFO_RECEIVED = 0x31D,
        MAX_SPELL_START_RECOVERY_OFFSET_CHANGED = 0x31E,
    }

    [Flags]
    public enum WorldHitFlags : uint
    {
        HitTestNothing = 0x0,
        /// <summary>
        /// Models' bounding, ie. where you can't walk on a model. (Trees, smaller structures etc.)
        /// </summary>
        HitTestBoundingModels = 0x1,
        /// <summary>
        /// Structures like big buildings, Orgrimmar etc.
        /// </summary>
        HitTestWMO = 0x10,
        /// <summary>
        /// Used in ClickTerrain.
        /// </summary>
        HitTestUnknown = 0x40,
        /// <summary>
        /// The terrain.
        /// </summary>
        HitTestGround = 0x100,
        /// <summary>
        /// Tested on water - should work on lava and other liquid as well.
        /// </summary>
        HitTestLiquid = 0x10000,
        /// <summary>
        /// This flag works for liquid as well, but it also works for something else that I don't know (this hit while the liquid flag didn't hit) - called constantly by WoW.
        /// </summary>
        HitTestUnknown2 = 0x20000,
        /// <summary>
        /// Hits on movable objects - tested on UC elevator doors.
        /// </summary>
        HitTestMovableObjects = 0x100000,

        HitTestLOS = HitTestWMO | HitTestBoundingModels | HitTestMovableObjects,
        HitTestGroundAndStructures = HitTestLOS | HitTestGround
    }

    public enum ShapeshiftForm
    {
        Normal = 0,
        Cat = 1,
        TreeOfLife = 2,
        Travel = 3,
        Aqua = 4,
        Bear = 5,
        Ambient = 6,
        Ghoul = 7,
        DireBear = 8,
        CreatureBear = 14,
        CreatureCat = 15,
        GhostWolf = 16,
        BattleStance = 17,
        DefensiveStance = 18,
        BerserkerStance = 19,
        EpicFlightForm = 27,
        Shadow = 28,
        Stealth = 30,
        Moonkin = 31,
        SpiritOfRedemption = 32
    }

    public enum StandState : byte
    {
        Stand = 0,
        Sit = 1,
        SittingInChair = 2,
        Sleeping = 3,
        SittingInLowChair = 4,
        SittingInMediumChair = 5,
        SittingInHighChair = 6,
        Dead = 7,
        Kneeling = 8,
        Type9 = 9,
    }

    [Flags]
    public enum PvPState
    {
        None = 0,
        PVP = 0x1,
        FFAPVP = 0x4,
        InPvPSanctuary = 0x8,
    }

    public enum WoWItemType
    {
        Consumable,
        Container,
        Weapon,
        Gem,
        Armor,
        Reagent,
        Projectile,
        TradeGoods,
        Generic,
        Recipe,
        Money,
        Quiver,
        QUest,
        Key,
        Permanent,
        Misc
    }

    /*[Flags]
    public enum SimpleItemFlags : uint
    {
        None = 0x0,
        Soulbound = 0x1,
        Conjured = 0x2,
        Lootable = 0x4,
        WrapGift = 0x200,
        CreateItem = 0x400,
        Quest = 0x800,
        Refundable = 0x1000,
        Signable = 0x2000,
        Readable = 0x4000,
        EventReq = 0x10000,
        Prospectable = 0x40000,
        UniqueEquip = 0x80000,
        Thrown = 0x400000,
        ShapeshiftOK = 0x800000,
        AccountBound = 0x8000000,
        Millable = 0x20000000
    }*/

    [Obfuscation]
    public enum WoWPowerType
    {
        Mana,
        Rage,
        Focus,
        Energy,
        Happiness,
        RunicPower,
        Runes,
        Health,
        UNKNOWN
    }
    [Obfuscation]
    public enum RuneType : uint
    {
        Blood = 0,
        Unholy,
        Frost,
        Death
    }

    [Flags]
    public enum WoWObjectTypeFlag
    {
        Object = 0x1,
        Item = 0x2,
        Container = 0x4,
        Unit = 0x8,
        Player = 0x10,
        GameObject = 0x20,
        DynamicObject = 0x40,
        Corpse = 0x80,
        AiGroup = 0x100,
        AreaTrigger = 0x200,
    }

    public enum WoWGameObjectType : uint
    {
        Door = 0,
        Button = 1,
        QuestGiver = 2,
        Chest = 3,
        Binder = 4,
        Generic = 5,
        Trap = 6,
        Chair = 7,
        SpellFocus = 8,
        Text = 9,
        Goober = 0xa,
        Transport = 0xb,
        AreaDamage = 0xc,
        Camera = 0xd,
        WorldObj = 0xe,
        MapObjTransport = 0xf,
        DuelArbiter = 0x10,
        FishingBobber = 0x11, //FishingNode
        Ritual = 0x12,
        Mailbox = 0x13,
        AuctionHouse = 0x14,
        SpellCaster = 0x16,
        MeetingStone = 0x17,
        Unkown18 = 0x18,
        FishingPool = 0x19,
        FORCEDWORD = 0xFFFFFFFF,
    }

    public enum WoWEquipSlot
    {
        Head = 0,
        Neck,
        Shoulders,
        Body,
        Chest,
        Waist,
        Legs,
        Feet,
        Wrists,
        Hands,
        Finger1,
        Finger2,
        Trinket1,
        Trinket2,
        Back,
        MainHand,
        OffHand,
        Ranged,
        Tabard
    }

    public enum WoWProfession
    {
        None = 0,

        Alchemy,
        Blacksmithing,
        Enchanting,
        Engineering,
        Herbalism,
        Mining,
        Inscription,
        Jewelcrafting,
        Leatherworking,
        Skinning,
        Tailoring,

        Cooking,
        Fishing,
        FirstAid,
        Archaeology
    }

    [Obfuscation]
    public enum WoWClass : uint
    {
        None = 0,
        Warrior = 1,
        Paladin = 2,
        Hunter = 3,
        Rogue = 4,
        Priest = 5,
        DeathKnight = 6,
        Shaman = 7,
        Mage = 8,
        Warlock = 9,
        Druid = 11,
    }
    [Obfuscation]
    public enum WoWClassification : int
    {
        Normal = 0,
        Elite = 1,
        RareElite = 2,
        WorldBoss = 3,
        Rare = 4
    }
    [Obfuscation]
    public enum WoWRace
    {
        Human = 1,
        Orc,
        Dwarf,
        NightElf,
        Undead,
        Tauren,
        Gnome,
        Troll,
        Goblin,
        BloodElf,
        Draenei,
        FelOrc,
        Naga,
        Broken,
        Skeleton = 15,
    }
    [Obfuscation]
    public enum WoWCreatureType
    {
        Unknown = 0,
        Beast,
        Dragon,
        Demon,
        Elemental,
        Giant,
        Undead,
        Humanoid,
        Critter,
        Mechanical,
        NotSpecified,
        Totem,
        NonCombatPet,
        GasCloud
    }
    [Obfuscation]
    public enum WoWGender
    {
        Male,
        Female,
        Unknown
    }

    /*
   * 1 - Hated
   * 2 - Hostile
   * 3 - Unfriendly
   * 4 - Neutral
   * 5 - Friendly
   * 6 - Honored
   * 7 - Revered
   * 8 - Exalted
    */

    [Obfuscation]
    public enum WoWUnitRelation : uint
    {
        Hated = 1,
        Hostile,
        Unfriendly,
        Neutral,
        Friendly,
        Honored,
        Revered,
        Exalted
    }

    public enum WoWQuestType : uint
    {
        Group = 1,
        Life = 21,
        PvP = 41,
        Raid = 62,
        Dungeon = 81,
        WorldEvent = 82,
        Legendary = 83,
        Escort = 84,
        Heroic = 85,
        Raid_10 = 88,
        Raid_25 = 89,
    }

    public enum SheathType : sbyte
    {
        Undetermined = -1,
        None = 0,
        Melee = 1,
        Ranged = 2,

        Shield = 4,
        Rod = 5,
        Light = 7
    }

    [Flags]
    public enum MovementDirection : uint
    {
        None = 0,
        RMouse = 0x1,
        LMouse = 0x2,
        // 2 and 3 not used apparently. Possibly for flag masking?
        Forward = 0x10,
        Backward = 0x20,
        StrafeLeft = 0x40,
        StrafeRight = 0x80,
        TurnLeft = 0x100,
        TurnRight = 0x200,
        PitchUp = 0x400,// For flying/swimming
        PitchDown = 0x800, // For flying/swimming
        AutoRun = 0x1000,
        JumpAscend = 0x2000,// For flying/swimming
        Descend = 0x4000,// For flying/swimming

        ClickToMove = 0x400000,// Note: Only turns the CTM flag on or off. Has no effect on movement!
        IsCTMing = 0x200000,

        ForwardBackMovement = 0x10000,
        StrafeMovement = 0x20000,
        TurnMovement = 0x40000,

        All = 0xFFFFFFFF,
    }

    [Flags]
    public enum StateFlag
    {
        None = 0,
        AlwaysStand = 0x1,
        Sneaking = 0x2,
        UnTrackable = 0x4,
    }


    [Flags]
    public enum UnitDynamicFlags
    {
        None = 0,
        Lootable = 0x1,
        TrackUnit = 0x2,
        TaggedByOther = 0x4,
        TaggedByMe = 0x8,
        SpecialInfo = 0x10,
        Dead = 0x20,
        ReferAFriendLinked = 0x40,
        IsTappedByAllThreatList = 0x80,
    }

    [Flags]
    public enum UnitFlags : uint
    {
        UNK_0 = 0x00000001,
        NotAttackable = 0x00000002,           // not attackable
        DISABLE_MOVE = 0x00000004,
        PVP_ATTACKABLE = 0x00000008,           // allow apply pvp rules to attackable state in addition to faction dependent state
        RENAME = 0x00000010,
        PREPARATION = 0x00000020,           // don't take reagents for spells with SPELL_ATTR_EX5_NO_REAGENT_WHILE_PREP
        UNK_6 = 0x00000040,
        NOT_ATTACKABLE_1 = 0x00000080,           // ?? (PVP_ATTACKABLE | NOT_ATTACKABLE_1) is NON_PVP_ATTACKABLE
        OOC_NOT_ATTACKABLE = 0x00000100,           // 2.0.8 - (OOC Out Of Combat) Can not be attacked when not in combat. Removed if unit for some reason enter combat (flag probably removed for the attacked and it's party/group only)
        PASSIVE = 0x00000200,           // makes you unable to attack everything. Almost identical to our "civilian"-term. Will ignore it's surroundings and not engage in combat unless "called upon" or engaged by another unit.
        LOOTING = 0x00000400,           // loot animation
        PET_IN_COMBAT = 0x00000800,           // in combat?, 2.0.8
        PVP = 0x00001000,           // changed in 3.0.3
        SILENCED = 0x00002000,           // silenced, 2.1.1
        UNK_14 = 0x00004000,           // 2.0.8
        UNK_15 = 0x00008000,
        UNK_16 = 0x00010000,           // removes attackable icon
        PACIFIED = 0x00020000,           // 3.0.3 ok
        STUNNED = 0x00040000,           // 3.0.3 ok
        InCombat = 0x00080000,
        TAXI_FLIGHT = 0x00100000,           // disable casting at client side spell not allowed by taxi flight (mounted?), probably used with 0x4 flag
        DISARMED = 0x00200000,           // 3.0.3, disable melee spells casting..., "Required melee weapon" added to melee spells tooltip.
        CONFUSED = 0x00400000,
        FLEEING = 0x00800000,
        PLAYER_CONTROLLED = 0x01000000,           // used in spell Eyes of the Beast for pet... let attack by controlled creature
        NotSelectable = 0x02000000,
        SKINNABLE = 0x04000000,
        MOUNT = 0x08000000,
        UNK_28 = 0x10000000,
        UNK_29 = 0x20000000,           // used in Feing Death spell
        SHEATHE = 0x40000000,
        UNK_31 = 0x80000000            // set skinnable icon and also changes color of portrait
    }

    [Flags]
    public enum UnitFlags2
    {
        FEIGN_DEATH = 0x00000001,
        UNK1 = 0x00000002,           // Hides unit model (show only player equip)
        COMPREHEND_LANG = 0x00000008,
        FORCE_MOVE = 0x00000040,
        DISARM = 0x00000400,           // disarm or something
        REGENERATE_POWER = 0x00000800,
        WORGEN_TRANSFORM = 0x00080000,           // transform to worgen
        WORGEN_TRANSFORM2 = 0x00100000,           // transform to worgen, but less animation?
        WORGEN_TRANSFORM3 = 0x00200000            // transform to worgen, but less animation?
    }

    [Flags]
    public enum UnitNPCFlags
    {
        NONE = 0x00000000,
        GOSSIP = 0x00000001, // 100%
        QUESTGIVER = 0x00000002, // guessed, probably ok
        UNK1 = 0x00000004,
        UNK2 = 0x00000008,
        TRAINER = 0x00000010, // 100%
        TRAINER_CLASS = 0x00000020, // 100%
        TRAINER_PROFESSION = 0x00000040, // 100%
        VENDOR = 0x00000080, // 100%
        VENDOR_AMMO = 0x00000100, // 100%, general goods vendor
        VENDOR_FOOD = 0x00000200, // 100%
        VENDOR_POISON = 0x00000400, // guessed
        VENDOR_REAGENT = 0x00000800, // 100%
        REPAIR = 0x00001000, // 100%
        FLIGHTMASTER = 0x00002000, // 100%
        SPIRITHEALER = 0x00004000, // guessed
        SPIRITGUIDE = 0x00008000, // guessed
        INNKEEPER = 0x00010000, // 100%
        BANKER = 0x00020000, // 100%
        PETITIONER = 0x00040000, // 100% 0xC0000 = guild petitions, 0x40000 = arena team petitions
        TABARDDESIGNER = 0x00080000, // 100%
        BATTLEMASTER = 0x00100000, // 100%
        AUCTIONEER = 0x00200000, // 100%
        STABLEMASTER = 0x00400000, // 100%
        GUILD_BANKER = 0x00800000, // cause client to send 997 opcode
        SPELLCLICK = 0x01000000, // cause client to send 1015 opcode (spell click)
        GUARD = 0x10000000, // custom flag for guards
    }

    [Flags]
    public enum GameObjectFlags // :ushort
    {
        /// <summary>
        /// 0x1
        /// Disables interaction while animated
        /// </summary>
        InUse = 0x01,
        /// <summary>
        /// 0x2
        /// Requires a key, spell, event, etc to be opened. 
        /// Makes "Locked" appear in tooltip
        /// </summary>
        Locked = 0x02,
        /// <summary>
        /// 0x4
        /// Objects that require a condition to be met before they are usable
        /// </summary>
        ConditionalInteraction = 0x04,
        /// <summary>
        /// 0x8
        /// any kind of transport? Object can transport (elevator, boat, car)
        /// </summary>
        Transport = 0x08,
        GOFlag_0x10 = 0x10,
        /// <summary>
        /// 0x20
        /// These objects never de-spawn, but typically just change state in response to an event
        /// Ex: doors
        /// </summary>
        DoesNotDespawn = 0x20,
        /// <summary>
        /// 0x40
        /// Typically, summoned objects. Triggered by spell or other events
        /// </summary>
        Triggered = 0x40,

        GOFlag_0x80 = 0x80,
        GOFlag_0x100 = 0x100,
        GOFlag_0x200 = 0x200,
        GOFlag_0x400 = 0x400,
        GOFlag_0x800 = 0x800,
        GOFlag_0x1000 = 0x1000,
        GOFlag_0x2000 = 0x2000,
        GOFlag_0x4000 = 0x4000,
        GOFlag_0x8000 = 0x8000,

        Flag_0x10000 = 0x10000,
        Flag_0x20000 = 0x20000,
        Flag_0x40000 = 0x40000,
    }

    public enum CorpseFlags
    {
        CORPSE_FLAG_NONE = 0x00,
        CORPSE_FLAG_BONES = 0x01,
        CORPSE_FLAG_UNK1 = 0x02,
        CORPSE_FLAG_UNK2 = 0x04,
        CORPSE_FLAG_HIDE_HELM = 0x08,
        CORPSE_FLAG_HIDE_CLOAK = 0x10,
        CORPSE_FLAG_LOOTABLE = 0x20
    }
    #endregion

    #region stuff from SharedDefines.h
    public enum SpellEffectType
    {
        NONE = 0,
        INSTAKILL = 1,
        SCHOOL_DAMAGE = 2,
        DUMMY = 3,
        PORTAL_TELEPORT = 4,
        TELEPORT_UNITS = 5,
        APPLY_AURA = 6,
        ENVIRONMENTAL_DAMAGE = 7,
        POWER_DRAIN = 8,
        HEALTH_LEECH = 9,
        HEAL = 10,
        BIND = 11,
        PORTAL = 12,
        RITUAL_BASE = 13,
        RITUAL_SPECIALIZE = 14,
        RITUAL_ACTIVATE_PORTAL = 15,
        QUEST_COMPLETE = 16,
        WEAPON_DAMAGE_NOSCHOOL = 17,
        RESURRECT = 18,
        ADD_EXTRA_ATTACKS = 19,
        DODGE = 20,
        EVADE = 21,
        PARRY = 22,
        BLOCK = 23,
        CREATE_ITEM = 24,
        WEAPON = 25,
        DEFENSE = 26,
        PERSISTENT_AREA_AURA = 27,
        SUMMON = 28,
        LEAP = 29,
        ENERGIZE = 30,
        WEAPON_PERCENT_DAMAGE = 31,
        TRIGGER_MISSILE = 32,
        OPEN_LOCK = 33,
        SUMMON_CHANGE_ITEM = 34,
        APPLY_AREA_AURA_PARTY = 35,
        LEARN_SPELL = 36,
        SPELL_DEFENSE = 37,
        DISPEL = 38,
        LANGUAGE = 39,
        DUAL_WIELD = 40,
        JUMP = 41,
        JUMP2 = 42,
        TELEPORT_UNITS_FACE_CASTER = 43,
        SKILL_STEP = 44,
        ADD_HONOR = 45,
        SPAWN = 46,
        TRADE_SKILL = 47,
        STEALTH = 48,
        DETECT = 49,
        TRANS_DOOR = 50,
        FORCE_CRITICAL_HIT = 51,
        GUARANTEE_HIT = 52,
        ENCHANT_ITEM = 53,
        ENCHANT_ITEM_TEMPORARY = 54,
        TAMECREATURE = 55,
        SUMMON_PET = 56,
        LEARN_PET_SPELL = 57,
        WEAPON_DAMAGE = 58,
        CREATE_RANDOM_ITEM = 59,
        PROFICIENCY = 60,
        SEND_EVENT = 61,
        POWER_BURN = 62,
        THREAT = 63,
        TRIGGER_SPELL = 64,
        APPLY_AREA_AURA_RAID = 65,
        RESTORE_ITEM_CHARGES = 66,
        HEAL_MAX_HEALTH = 67,
        INTERRUPT_CAST = 68,
        DISTRACT = 69,
        PULL = 70,
        PICKPOCKET = 71,
        ADD_FARSIGHT = 72,
        UNTRAIN_TALENTS = 73,
        APPLY_GLYPH = 74,
        HEAL_MECHANICAL = 75,
        SUMMON_OBJECT_WILD = 76,
        SCRIPT_EFFECT = 77,
        ATTACK = 78,
        SANCTUARY = 79,
        ADD_COMBO_POINTS = 80,
        CREATE_HOUSE = 81,
        BIND_SIGHT = 82,
        DUEL = 83,
        STUCK = 84,
        SUMMON_PLAYER = 85,
        ACTIVATE_OBJECT = 86,
        WMO_DAMAGE = 87,
        WMO_REPAIR = 88,
        WMO_CHANGE = 89,
        KILL_CREDIT = 90,
        THREAT_ALL = 91,
        ENCHANT_HELD_ITEM = 92,
        BREAK_PLAYER_TARGETING = 93,
        SELF_RESURRECT = 94,
        SKINNING = 95,
        CHARGE = 96,
        SUMMON_ALL_TOTEMS = 97,
        KNOCK_BACK = 98,
        DISENCHANT = 99,
        INEBRIATE = 100,
        FEED_PET = 101,
        DISMISS_PET = 102,
        REPUTATION = 103,
        SUMMON_OBJECT_SLOT1 = 104,
        SUMMON_OBJECT_SLOT2 = 105,
        SUMMON_OBJECT_SLOT3 = 106,
        SUMMON_OBJECT_SLOT4 = 107,
        DISPEL_MECHANIC = 108,
        SUMMON_DEAD_PET = 109,
        DESTROY_ALL_TOTEMS = 110,
        DURABILITY_DAMAGE = 111,
        _112 = 112,           // old SUMMON_DEMON
        RESURRECT_NEW = 113,
        ATTACK_ME = 114,
        DURABILITY_DAMAGE_PCT = 115,
        SKIN_PLAYER_CORPSE = 116,
        SPIRIT_HEAL = 117,
        SKILL = 118,
        APPLY_AREA_AURA_PET = 119,
        TELEPORT_GRAVEYARD = 120,
        NORMALIZED_WEAPON_DMG = 121,
        _122 = 122,
        SEND_TAXI = 123,
        PLAYER_PULL = 124,
        MODIFY_THREAT_PERCENT = 125,
        STEAL_BENEFICIAL_BUFF = 126,
        PROSPECTING = 127,
        APPLY_AREA_AURA_FRIEND = 128,
        APPLY_AREA_AURA_ENEMY = 129,
        REDIRECT_THREAT = 130,
        _131 = 131,
        PLAY_MUSIC = 132,
        UNLEARN_SPECIALIZATION = 133,
        KILL_CREDIT2 = 134,
        CALL_PET = 135,
        HEAL_PCT = 136,
        ENERGIZE_PCT = 137,
        LEAP_BACK = 138,
        CLEAR_QUEST = 139,
        FORCE_CAST = 140,
        _141 = 141,
        TRIGGER_SPELL_WITH_VALUE = 142,
        APPLY_AREA_AURA_OWNER = 143,
        _144 = 144,
        _145 = 145,
        ACTIVATE_RUNE = 146,
        QUEST_FAIL = 147,
        _148 = 148,
        _149 = 149,
        _150 = 150,
        TRIGGER_SPELL_2 = 151,
        _152 = 152,
        _153 = 153,
        TEACH_TAXI_NODE = 154,
        TITAN_GRIP = 155,
        ENCHANT_ITEM_PRISMATIC = 156,
        CREATE_ITEM_2 = 157,
        MILLING = 158,
        ALLOW_RENAME_PET = 159,
        _160 = 160,
        TALENT_SPEC_COUNT = 161,
        TALENT_SPEC_SELECT = 162,
        _163 = 163,
        _164 = 164,
        //TOTAL_SPELL_EFFECTS = 165
    };

    public enum SpellDispelType : uint
    {
        NONE = 0,
        MAGIC = 1,
        CURSE = 2,
        DISEASE = 3,
        POISON = 4,
        STEALTH = 5,
        INVISIBILITY = 6,
        ALL = 7,
        SPE_NPC_ONLY = 8,
        ENRAGE = 9,
        ZG_TICKET = 10,
        OLD_UNUSED = 11
    }

    public enum SpellFamilyNames
    {
        GENERIC = 0,
        UNK1 = 1,                            // events, holidays
        // 2 - unused
        MAGE = 3,
        WARRIOR = 4,
        WARLOCK = 5,
        PRIEST = 6,
        DRUID = 7,
        ROGUE = 8,
        HUNTER = 9,
        PALADIN = 10,
        SHAMAN = 11,
        UNK2 = 12,                           // 2 spells (silence resistance)
        POTION = 13,
        // 14 - unused
        DEATHKNIGHT = 15,
        // 16 - unused
        PET = 17
    };

    public enum AuraType
    {
        NONE = 0,
        BIND_SIGHT = 1,
        MOD_POSSESS = 2,
        PERIODIC_DAMAGE = 3,
        DUMMY = 4,
        MOD_CONFUSE = 5,
        MOD_CHARM = 6,
        MOD_FEAR = 7,
        PERIODIC_HEAL = 8,
        MOD_ATTACKSPEED = 9,
        MOD_THREAT = 10,
        MOD_TAUNT = 11,
        MOD_STUN = 12,
        MOD_DAMAGE_DONE = 13,
        MOD_DAMAGE_TAKEN = 14,
        DAMAGE_SHIELD = 15,
        MOD_STEALTH = 16,
        MOD_STEALTH_DETECT = 17,
        MOD_INVISIBILITY = 18,
        MOD_INVISIBILITY_DETECTION = 19,
        OBS_MOD_HEALTH = 20,                         //20,21 unofficial
        OBS_MOD_MANA = 21,
        MOD_RESISTANCE = 22,
        PERIODIC_TRIGGER_SPELL = 23,
        PERIODIC_ENERGIZE = 24,
        MOD_PACIFY = 25,
        MOD_ROOT = 26,
        MOD_SILENCE = 27,
        REFLECT_SPELLS = 28,
        MOD_STAT = 29,
        MOD_SKILL = 30,
        MOD_INCREASE_SPEED = 31,
        MOD_INCREASE_MOUNTED_SPEED = 32,
        MOD_DECREASE_SPEED = 33,
        MOD_INCREASE_HEALTH = 34,
        MOD_INCREASE_ENERGY = 35,
        MOD_SHAPESHIFT = 36,
        EFFECT_IMMUNITY = 37,
        STATE_IMMUNITY = 38,
        SCHOOL_IMMUNITY = 39,
        DAMAGE_IMMUNITY = 40,
        DISPEL_IMMUNITY = 41,
        PROC_TRIGGER_SPELL = 42,
        PROC_TRIGGER_DAMAGE = 43,
        TRACK_CREATURES = 44,
        TRACK_RESOURCES = 45,
        SPELL_AURA_46 = 46,                                     // Ignore all Gear test spells
        MOD_PARRY_PERCENT = 47,
        SPELL_AURA_48 = 48,                                     // One periodic spell
        MOD_DODGE_PERCENT = 49,
        MOD_CRITICAL_HEALING_AMOUNT = 50,
        MOD_BLOCK_PERCENT = 51,
        MOD_CRIT_PERCENT = 52,
        PERIODIC_LEECH = 53,
        MOD_HIT_CHANCE = 54,
        MOD_SPELL_HIT_CHANCE = 55,
        TRANSFORM = 56,
        MOD_SPELL_CRIT_CHANCE = 57,
        MOD_INCREASE_SWIM_SPEED = 58,
        MOD_DAMAGE_DONE_CREATURE = 59,
        MOD_PACIFY_SILENCE = 60,
        MOD_SCALE = 61,
        PERIODIC_HEALTH_FUNNEL = 62,
        SPELL_AURA_63 = 63,                                     // old PERIODIC_MANA_FUNNEL
        PERIODIC_MANA_LEECH = 64,
        MOD_CASTING_SPEED_NOT_STACK = 65,
        FEIGN_DEATH = 66,
        MOD_DISARM = 67,
        MOD_STALKED = 68,
        SCHOOL_ABSORB = 69,
        EXTRA_ATTACKS = 70,
        MOD_SPELL_CRIT_CHANCE_SCHOOL = 71,
        MOD_POWER_COST_SCHOOL_PCT = 72,
        MOD_POWER_COST_SCHOOL = 73,
        REFLECT_SPELLS_SCHOOL = 74,
        MOD_LANGUAGE = 75,
        FAR_SIGHT = 76,
        MECHANIC_IMMUNITY = 77,
        MOUNTED = 78,
        MOD_DAMAGE_PERCENT_DONE = 79,
        MOD_PERCENT_STAT = 80,
        SPLIT_DAMAGE_PCT = 81,
        WATER_BREATHING = 82,
        MOD_BASE_RESISTANCE = 83,
        MOD_REGEN = 84,
        MOD_POWER_REGEN = 85,
        CHANNEL_DEATH_ITEM = 86,
        MOD_DAMAGE_PERCENT_TAKEN = 87,
        MOD_HEALTH_REGEN_PERCENT = 88,
        PERIODIC_DAMAGE_PERCENT = 89,
        SPELL_AURA_90 = 90,                                     // old MOD_RESIST_CHANCE
        MOD_DETECT_RANGE = 91,
        PREVENTS_FLEEING = 92,
        MOD_UNATTACKABLE = 93,
        INTERRUPT_REGEN = 94,
        GHOST = 95,
        SPELL_MAGNET = 96,
        MANA_SHIELD = 97,
        MOD_SKILL_TALENT = 98,
        MOD_ATTACK_POWER = 99,
        AURAS_VISIBLE = 100,
        MOD_RESISTANCE_PCT = 101,
        MOD_MELEE_ATTACK_POWER_VERSUS = 102,
        MOD_TOTAL_THREAT = 103,
        WATER_WALK = 104,
        FEATHER_FALL = 105,
        HOVER = 106,
        ADD_FLAT_MODIFIER = 107,
        ADD_PCT_MODIFIER = 108,
        ADD_TARGET_TRIGGER = 109,
        MOD_POWER_REGEN_PERCENT = 110,
        ADD_CASTER_HIT_TRIGGER = 111,
        OVERRIDE_CLASS_SCRIPTS = 112,
        MOD_RANGED_DAMAGE_TAKEN = 113,
        MOD_RANGED_DAMAGE_TAKEN_PCT = 114,
        MOD_HEALING = 115,
        MOD_REGEN_DURING_COMBAT = 116,
        MOD_MECHANIC_RESISTANCE = 117,
        MOD_HEALING_PCT = 118,
        SPELL_AURA_119 = 119,                                   // old SHARE_PET_TRACKING
        UNTRACKABLE = 120,
        EMPATHY = 121,
        MOD_OFFHAND_DAMAGE_PCT = 122,
        MOD_TARGET_RESISTANCE = 123,
        MOD_RANGED_ATTACK_POWER = 124,
        MOD_MELEE_DAMAGE_TAKEN = 125,
        MOD_MELEE_DAMAGE_TAKEN_PCT = 126,
        RANGED_ATTACK_POWER_ATTACKER_BONUS = 127,
        MOD_POSSESS_PET = 128,
        MOD_SPEED_ALWAYS = 129,
        MOD_MOUNTED_SPEED_ALWAYS = 130,
        MOD_RANGED_ATTACK_POWER_VERSUS = 131,
        MOD_INCREASE_ENERGY_PERCENT = 132,
        MOD_INCREASE_HEALTH_PERCENT = 133,
        MOD_MANA_REGEN_INTERRUPT = 134,
        MOD_HEALING_DONE = 135,
        MOD_HEALING_DONE_PERCENT = 136,
        MOD_TOTAL_STAT_PERCENTAGE = 137,
        MOD_HASTE = 138,
        FORCE_REACTION = 139,
        MOD_RANGED_HASTE = 140,
        MOD_RANGED_AMMO_HASTE = 141,
        MOD_BASE_RESISTANCE_PCT = 142,
        MOD_RESISTANCE_EXCLUSIVE = 143,
        SAFE_FALL = 144,
        MOD_PET_TALENT_POINTS = 145,
        ALLOW_TAME_PET_TYPE = 146,
        MECHANIC_IMMUNITY_MASK = 147,
        RETAIN_COMBO_POINTS = 148,
        REDUCE_PUSHBACK = 149,                      //    Reduce Pushback
        MOD_SHIELD_BLOCKVALUE_PCT = 150,
        TRACK_STEALTHED = 151,                      //    Track Stealthed
        MOD_DETECTED_RANGE = 152,                    //    Mod Detected Range
        SPLIT_DAMAGE_FLAT = 153,                     //    Split Damage Flat
        MOD_STEALTH_LEVEL = 154,                     //    Stealth Level Modifier
        MOD_WATER_BREATHING = 155,                   //    Mod Water Breathing
        MOD_REPUTATION_GAIN = 156,                   //    Mod Reputation Gain
        PET_DAMAGE_MULTI = 157,                      //    Mod Pet Damage
        MOD_SHIELD_BLOCKVALUE = 158,
        NO_PVP_CREDIT = 159,
        MOD_AOE_AVOIDANCE = 160,
        MOD_HEALTH_REGEN_IN_COMBAT = 161,
        POWER_BURN_MANA = 162,
        MOD_CRIT_DAMAGE_BONUS = 163,
        SPELL_AURA_164 = 164,
        MELEE_ATTACK_POWER_ATTACKER_BONUS = 165,
        MOD_ATTACK_POWER_PCT = 166,
        MOD_RANGED_ATTACK_POWER_PCT = 167,
        MOD_DAMAGE_DONE_VERSUS = 168,
        MOD_CRIT_PERCENT_VERSUS = 169,
        DETECT_AMORE = 170,
        MOD_SPEED_NOT_STACK = 171,
        MOD_MOUNTED_SPEED_NOT_STACK = 172,
        SPELL_AURA_173 = 173,                                   // old ALLOW_CHAMPION_SPELLS
        MOD_SPELL_DAMAGE_OF_STAT_PERCENT = 174,      // by defeult intelect, dependent from MOD_SPELL_HEALING_OF_STAT_PERCENT
        MOD_SPELL_HEALING_OF_STAT_PERCENT = 175,
        SPIRIT_OF_REDEMPTION = 176,
        AOE_CHARM = 177,
        MOD_DEBUFF_RESISTANCE = 178,
        MOD_ATTACKER_SPELL_CRIT_CHANCE = 179,
        MOD_FLAT_SPELL_DAMAGE_VERSUS = 180,
        SPELL_AURA_181 = 181,                                   // old MOD_FLAT_SPELL_CRIT_DAMAGE_VERSUS - possible flat spell crit damage versus
        MOD_RESISTANCE_OF_STAT_PERCENT = 182,
        MOD_CRITICAL_THREAT = 183,
        MOD_ATTACKER_MELEE_HIT_CHANCE = 184,
        MOD_ATTACKER_RANGED_HIT_CHANCE = 185,
        MOD_ATTACKER_SPELL_HIT_CHANCE = 186,
        MOD_ATTACKER_MELEE_CRIT_CHANCE = 187,
        MOD_ATTACKER_RANGED_CRIT_CHANCE = 188,
        MOD_RATING = 189,
        MOD_FACTION_REPUTATION_GAIN = 190,
        USE_NORMAL_MOVEMENT_SPEED = 191,
        HASTE_MELEE = 192,
        HASTE_ALL = 193,
        MOD_IGNORE_ABSORB_SCHOOL = 194,
        MOD_IGNORE_ABSORB_FOR_SPELL = 195,
        MOD_COOLDOWN = 196,                          // only 24818 Noxious Breath
        MOD_ATTACKER_SPELL_AND_WEAPON_CRIT_CHANCE = 197,
        SPELL_AURA_198 = 198,                                   // old MOD_ALL_WEAPON_SKILLS
        MOD_INCREASES_SPELL_PCT_TO_HIT = 199,
        MOD_KILL_XP_PCT = 200,
        FLY = 201,
        IGNORE_COMBAT_RESULT = 202,
        MOD_ATTACKER_MELEE_CRIT_DAMAGE = 203,
        MOD_ATTACKER_RANGED_CRIT_DAMAGE = 204,
        MOD_ATTACKER_SPELL_CRIT_DAMAGE = 205,
        MOD_FLIGHT_SPEED = 206,
        MOD_FLIGHT_SPEED_MOUNTED = 207,
        MOD_FLIGHT_SPEED_STACKING = 208,
        MOD_FLIGHT_SPEED_MOUNTED_STACKING = 209,
        MOD_FLIGHT_SPEED_NOT_STACKING = 210,
        MOD_FLIGHT_SPEED_MOUNTED_NOT_STACKING = 211,
        MOD_RANGED_ATTACK_POWER_OF_STAT_PERCENT = 212,
        MOD_RAGE_FROM_DAMAGE_DEALT = 213,
        SPELL_AURA_214 = 214,
        ARENA_PREPARATION = 215,
        HASTE_SPELLS = 216,
        SPELL_AURA_217 = 217,
        HASTE_RANGED = 218,
        MOD_MANA_REGEN_FROM_STAT = 219,
        MOD_RATING_FROM_STAT = 220,
        SPELL_AURA_221 = 221,
        SPELL_AURA_222 = 222,
        SPELL_AURA_223 = 223,
        SPELL_AURA_224 = 224,
        PRAYER_OF_MENDING = 225,
        PERIODIC_DUMMY = 226,
        PERIODIC_TRIGGER_SPELL_WITH_VALUE = 227,
        DETECT_STEALTH = 228,
        MOD_AOE_DAMAGE_AVOIDANCE = 229,
        SPELL_AURA_230 = 230,
        PROC_TRIGGER_SPELL_WITH_VALUE = 231,
        MECHANIC_DURATION_MOD = 232,
        SPELL_AURA_233 = 233,
        MECHANIC_DURATION_MOD_NOT_STACK = 234,
        MOD_DISPEL_RESIST = 235,
        CONTROL_VEHICLE = 236,
        MOD_SPELL_DAMAGE_OF_ATTACK_POWER = 237,
        MOD_SPELL_HEALING_OF_ATTACK_POWER = 238,
        MOD_SCALE_2 = 239,
        MOD_EXPERTISE = 240,
        FORCE_MOVE_FORWARD = 241,
        MOD_SPELL_DAMAGE_FROM_HEALING = 242,
        SPELL_AURA_243 = 243,
        COMPREHEND_LANGUAGE = 244,
        MOD_DURATION_OF_MAGIC_EFFECTS = 245,
        MOD_DURATION_OF_EFFECTS_BY_DISPEL = 246,
        SPELL_AURA_247 = 247,
        MOD_COMBAT_RESULT_CHANCE = 248,
        CONVERT_RUNE = 249,
        MOD_INCREASE_HEALTH_2 = 250,
        MOD_ENEMY_DODGE = 251,
        SLOW_ALL = 252,
        MOD_BLOCK_CRIT_CHANCE = 253,
        MOD_DISARM_SHIELD = 254,
        MOD_MECHANIC_DAMAGE_TAKEN_PERCENT = 255,
        NO_REAGENT_USE = 256,
        MOD_TARGET_RESIST_BY_SPELL_CLASS = 257,
        SPELL_AURA_258 = 258,
        SPELL_AURA_259 = 259,
        SCREEN_EFFECT = 260,
        PHASE = 261,
        SPELL_AURA_262 = 262,
        ALLOW_ONLY_ABILITY = 263,
        SPELL_AURA_264 = 264,
        SPELL_AURA_265 = 265,
        SPELL_AURA_266 = 266,
        MOD_IMMUNE_AURA_APPLY_SCHOOL = 267,
        MOD_ATTACK_POWER_OF_STAT_PERCENT = 268,
        MOD_IGNORE_DAMAGE_REDUCTION_SCHOOL = 269,
        MOD_IGNORE_TARGET_RESIST = 270,              // Possibly need swap vs 195 aura used only in 1 spell Chaos Bolt Passive
        MOD_DAMAGE_FROM_CASTER = 271,
        MAELSTROM_WEAPON = 272,
        X_RAY = 273,
        SPELL_AURA_274 = 274,
        MOD_IGNORE_SHAPESHIFT = 275,
        SPELL_AURA_276 = 276,                                   // Only "Test Mod Damage % Mechanic" spell, possible mod damage done
        MOD_MAX_AFFECTED_TARGETS = 277,
        MOD_DISARM_RANGED = 278,
        SPELL_AURA_279 = 279,
        MOD_TARGET_ARMOR_PCT = 280,
        MOD_HONOR_GAIN = 281,
        MOD_BASE_HEALTH_PCT = 282,
        MOD_HEALING_RECEIVED = 283,                  // Possibly only for some spell family class spells
        SPELL_AURA_284 = 284,
        MOD_ATTACK_POWER_OF_ARMOR = 285,
        ABILITY_PERIODIC_CRIT = 286,
        DEFLECT_SPELLS = 287,
        SPELL_AURA_288 = 288,
        SPELL_AURA_289 = 289,
        MOD_ALL_CRIT_CHANCE = 290,
        MOD_QUEST_XP_PCT = 291,
        SPELL_AURA_292 = 292,
        SPELL_AURA_293 = 293,
        SPELL_AURA_294 = 294,
        SPELL_AURA_295 = 295,
        SPELL_AURA_296 = 296,
        SPELL_AURA_297 = 297,
        SPELL_AURA_298 = 298,
        SPELL_AURA_299 = 299,
        SPELL_AURA_300 = 300,
        SPELL_AURA_301 = 301,
        SPELL_AURA_302 = 302,
        SPELL_AURA_303 = 303,
        SPELL_AURA_304 = 304,
        MOD_MINIMUM_SPEED = 305,
        SPELL_AURA_306 = 306,
        SPELL_AURA_307 = 307,
        SPELL_AURA_308 = 308,
        SPELL_AURA_309 = 309,
        SPELL_AURA_310 = 310,
        SPELL_AURA_311 = 311,
        SPELL_AURA_312 = 312,
        SPELL_AURA_313 = 313,
        SPELL_AURA_314 = 314,
        SPELL_AURA_315 = 315,
        SPELL_AURA_316 = 316,
        //TOTAL_AURAS = 317
    };

    public enum SpellMechanic
    {
        NONE = 0,
        CHARM = 1,
        DISORIENTED = 2,
        DISARM = 3,
        DISTRACT = 4,
        FEAR = 5,
        GRIP = 6,
        ROOT = 7,
        PACIFY = 8,    //0 spells use this mechanic
        SILENCE = 9,
        SLEEP = 10,
        SNARE = 11,
        STUN = 12,
        FREEZE = 13,
        KNOCKOUT = 14,
        BLEED = 15,
        BANDAGE = 16,
        POLYMORPH = 17,
        BANISH = 18,
        SHIELD = 19,
        SHACKLE = 20,
        MOUNT = 21,
        INFECTED = 22,
        TURN = 23,
        HORROR = 24,
        INVULNERABILITY = 25,
        INTERRUPT = 26,
        DAZE = 27,
        DISCOVERY = 28,
        IMMUNE_SHIELD = 29,    // Divine (Blessing) Shield/Protection and Ice Block
        SAPPED = 30,
        ENRAGED = 31
    };

    public enum SpellEffect
    {
        INSTAKILL = 1,
        SCHOOL_DAMAGE = 2,
        DUMMY = 3,
        PORTAL_TELEPORT = 4,
        TELEPORT_UNITS = 5,
        APPLY_AURA = 6,
        ENVIRONMENTAL_DAMAGE = 7,
        POWER_DRAIN = 8,
        HEALTH_LEECH = 9,
        HEAL = 10,
        BIND = 11,
        PORTAL = 12,
        RITUAL_BASE = 13,
        RITUAL_SPECIALIZE = 14,
        RITUAL_ACTIVATE_PORTAL = 15,
        QUEST_COMPLETE = 16,
        WEAPON_DAMAGE_NOSCHOOL = 17,
        RESURRECT = 18,
        ADD_EXTRA_ATTACKS = 19,
        DODGE = 20,
        EVADE = 21,
        PARRY = 22,
        BLOCK = 23,
        CREATE_ITEM = 24,
        WEAPON = 25,
        DEFENSE = 26,
        PERSISTENT_AREA_AURA = 27,
        SUMMON = 28,
        LEAP = 29,
        ENERGIZE = 30,
        WEAPON_PERCENT_DAMAGE = 31,
        TRIGGER_MISSILE = 32,
        OPEN_LOCK = 33,
        SUMMON_CHANGE_ITEM = 34,
        APPLY_AREA_AURA_PARTY = 35,
        LEARN_SPELL = 36,
        SPELL_DEFENSE = 37,
        DISPEL = 38,
        LANGUAGE = 39,
        DUAL_WIELD = 40,
        JUMP = 41,
        JUMP2 = 42,
        TELEPORT_UNITS_FACE_CASTER = 43,
        SKILL_STEP = 44,
        ADD_HONOR = 45,
        SPAWN = 46,
        TRADE_SKILL = 47,
        STEALTH = 48,
        DETECT = 49,
        TRANS_DOOR = 50,
        FORCE_CRITICAL_HIT = 51,
        GUARANTEE_HIT = 52,
        ENCHANT_ITEM = 53,
        ENCHANT_ITEM_TEMPORARY = 54,
        TAMECREATURE = 55,
        SUMMON_PET = 56,
        LEARN_PET_SPELL = 57,
        WEAPON_DAMAGE = 58,
        CREATE_RANDOM_ITEM = 59,
        PROFICIENCY = 60,
        SEND_EVENT = 61,
        POWER_BURN = 62,
        THREAT = 63,
        TRIGGER_SPELL = 64,
        APPLY_AREA_AURA_RAID = 65,
        CREATE_MANA_GEM = 66,
        HEAL_MAX_HEALTH = 67,
        INTERRUPT_CAST = 68,
        DISTRACT = 69,
        PULL = 70,
        PICKPOCKET = 71,
        ADD_FARSIGHT = 72,
        UNTRAIN_TALENTS = 73,
        APPLY_GLYPH = 74,
        HEAL_MECHANICAL = 75,
        SUMMON_OBJECT_WILD = 76,
        SCRIPT_EFFECT = 77,
        ATTACK = 78,
        SANCTUARY = 79,
        ADD_COMBO_POINTS = 80,
        CREATE_HOUSE = 81,
        BIND_SIGHT = 82,
        DUEL = 83,
        STUCK = 84,
        SUMMON_PLAYER = 85,
        ACTIVATE_OBJECT = 86,
        WMO_DAMAGE = 87,
        WMO_REPAIR = 88,
        WMO_CHANGE = 89,
        KILL_CREDIT = 90,
        THREAT_ALL = 91,
        ENCHANT_HELD_ITEM = 92,
        SUMMON_PHANTASM = 93, //unused
        SELF_RESURRECT = 94,
        SKINNING = 95,
        CHARGE = 96,
        CAST_BUTTON = 97,
        KNOCK_BACK = 98,
        DISENCHANT = 99,
        INEBRIATE = 100,
        FEED_PET = 101,
        DISMISS_PET = 102,
        REPUTATION = 103,
        SUMMON_OBJECT_SLOT1 = 104,
        SUMMON_OBJECT_SLOT2 = 105,
        SUMMON_OBJECT_SLOT3 = 106,
        SUMMON_OBJECT_SLOT4 = 107,
        DISPEL_MECHANIC = 108,
        SUMMON_DEAD_PET = 109,
        DESTROY_ALL_TOTEMS = 110,
        DURABILITY_DAMAGE = 111,
        EFFECT_112 = 112,
        RESURRECT_NEW = 113,
        ATTACK_ME = 114,
        DURABILITY_DAMAGE_PCT = 115,
        SKIN_PLAYER_CORPSE = 116,
        SPIRIT_HEAL = 117,
        SKILL = 118,
        APPLY_AREA_AURA_PET = 119,
        TELEPORT_GRAVEYARD = 120,
        NORMALIZED_WEAPON_DMG = 121,
        EFFECT_122 = 122,
        SEND_TAXI = 123,
        PLAYER_PULL = 124,
        MODIFY_THREAT_PERCENT = 125,
        STEAL_BENEFICIAL_BUFF = 126,
        PROSPECTING = 127,
        APPLY_AREA_AURA_FRIEND = 128,
        APPLY_AREA_AURA_ENEMY = 129,
        REDIRECT_THREAT = 130,
        EFFECT_131 = 131,
        PLAY_MUSIC = 132,
        UNLEARN_SPECIALIZATION = 133,
        KILL_CREDIT2 = 134,
        CALL_PET = 135,
        HEAL_PCT = 136,
        ENERGIZE_PCT = 137,
        LEAP_BACK = 138,
        CLEAR_QUEST = 139,
        FORCE_CAST = 140,
        EFFECT_141 = 141,
        TRIGGER_SPELL_WITH_VALUE = 142,
        APPLY_AREA_AURA_OWNER = 143,
        KNOCK_BACK_2 = 144,
        EFFECT_145 = 145,
        ACTIVATE_RUNE = 146,
        QUEST_FAIL = 147,
        EFFECT_148 = 148,
        EFFECT_149 = 149,
        EFFECT_150 = 150,
        TRIGGER_SPELL_2 = 151,
        EFFECT_152 = 152,
        EFFECT_153 = 153,
        EFFECT_154 = 154,
        TITAN_GRIP = 155,
        ENCHANT_ITEM_PRISMATIC = 156,
        CREATE_ITEM_2 = 157,
        MILLING = 158,
        ALLOW_RENAME_PET = 159,
        EFFECT_160 = 160,
        TALENT_SPEC_COUNT = 161,
        TALENT_SPEC_SELECT = 162,
        //TOTAL_SPELL_EFFECTS = 163
    };
    #endregion
}