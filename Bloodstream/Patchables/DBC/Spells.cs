using System.Runtime.InteropServices;

namespace Bloodstream.Patchables.DBC
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEntry
    {
        /*
        SpellActivationOverlay = 0x00798EE0,
        SpellChainEffects = 0x00798FA4,
        SpellDispelType = 0x00799030,
        SpellEffect = 0x00799068,
        SpellEffectCameraShakes = 0x00799084,
        SpellFlyout = 0x007990BC,
        SpellFlyoutItem = 0x007990D8,
        SpellFocusObject = 0x007990F4,
        SpellItemEnchantment = 0x00799148,
        SpellItemEnchantmentCondition = 0x00799164,
        SpellMechanic = 0x0079919C,
        SpellRadius = 0x0079920C,
        */

        public int ID;
        public uint attributes;
        public uint attributesEx;
        public uint attributesExB;
        public uint attributesExC;
        public uint attributesExD;
        public uint attributesExE;
        public uint attributesExF;
        public uint attributesExG;
        public uint attributesExH;
        public uint unk_400_1;
        public int castingTimeIndex; //SpellCastTimes = 0x00798F50,
        public int durationIndex; //SpellDuration = 0x0079904C,
        public SpellPowerType powerType;
        public int rangeIndex; //SpellRange = 0x00799228,
        public float speed;

        /*
        SpellVisual = 0x00799394,
        SpellVisualEffectName = 0x00799324,
        SpellVisualKit = 0x00799340,
        SpellVisualKitAreaModel = 0x0079935C,
        SpellVisualKitModelAttach = 0x00799378,
        */
        public uint spellVisualID_1;
        public uint spellVisualID_2;

        public int spellIconID; //SpellIcon = 0x00799110,
        public int activeIconID;

        [MarshalAs(UnmanagedType.LPStr)]
        public string
            name,
            nameSubtext,
            description,
            auraDescription;

        public int schoolMask;
        public int runeCostID; //SpellRuneCost = 0x00799244,

        /*
        SpellMissile = 0x007991B8,
        SpellMissileMotion = 0x007991D4,
        */
        public int spellMissileID;

        public int spellDescriptionVariableID; //SpellDescriptionVariables = 0x00798FF8,
        public int spellDifficultyID; //SpellDifficulty = 0x00799014,
        public float unk_f1;
        public int spellScalingID; //SpellScaling = 0x00799298,
        public int SpellAuraOptionsId; //SpellAuraOptions = 0x00798EFC,
        public int SpellAuraRestrictionsId; //SpellAuraRestrictions = 0x00798F18,
        public int SpellCastingRequirementsId; //SpellCastingRequirements = 0x00798F34,

        //SpellCategory = 0x00798F88,
        public int SpellCategoriesId; //SpellCategories = 0x00798F6C

        public int SpellClassOptionsId; //SpellClassOptions = 0x00798FC0,
        public int SpellCooldownsId; //SpellCooldowns = 0x00798FDC,
        public int unk_i1;
        public int SpellEquippedItemsId; //SpellEquippedItems = 0x007990A0,
        public int SpellInterruptsId; //SpellInterrupts = 0x0079912C,
        public int SpellLevelsId; //SpellLevels = 0x00799180,
        public int SpellPowerId; //SpellPower = 0x007991F0,
        public int SpellReagentsId; //SpellReagents = 0x00799260,

        /*
        SpellShapeshift = 0x007992B4,
        SpellShapeshiftForm = 0x007992D0,
        */
        public int SpellShapeshiftId;

        public int SpellTargetRestrictionsId; //SpellTargetRestrictions = 0x007992EC,
        public int SpellTotemsId; //SpellTotems = 0x00799308,
        public int unk_i2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellLevelsEntry
    {
        public uint ID;                                           // 0        m_ID
        public uint BaseLevel;                                    // 41       m_baseLevel
        public uint MaxLevel;                                     // 40       m_maxLevel
        public uint SpellLevel;                                   // 42       m_spellLevel
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEffectEntry
    {
        public uint ID;
        public SpellEffectType Type;

        float m_effectAmplitude; //float     EffectMultipleValue;                          // 106-108  m_effectAmplitude
        public AuraType Aura; //uint32    EffectApplyAuraName;                          // 100-102  m_effectAura
        uint m_effectAuraPeriod; //uint32    EffectAmplitude;                              // 103-105  m_effectAuraPeriod
        public int BasePoints; //int32     EffectBasePoints;                             // 82-84    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        float m_effectUnk_320; //float   unk_320_4;                                    // 169-171  3.2.0
        float m_effectChainAmplitude; //float DmgMultiplier;                                // 156-158  m_effectChainAmplitude
        uint EffectChainTarget;
        int EffectDieSides;
        uint EffectItemType;
        SpellMechanic EffectMechanic;
        public int MiscValueA;
        public int MiscValueB;
        float EffectPointsPerComboPoint;
        uint EffectRadiusIndex;
        uint EffectRadiusMaxIndex;
        float EffectRealPointsPerLevel;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] SpellClassMasks;
        public int TriggerSpell;
        uint EffectImplicitTargetA;
        uint EffectImplicitTargetB;
        public uint SpellId;
        public uint Index;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellRuneCostEntry
    {
        public int ID;
        public int BloodRuneCost;
        public int UnholyRuneCost;
        public int FrostRuneCost;
        public int RunicPowerGain;
    }

    /*
    internal class SpellDuration
    {
        public uint DurationID { get; set; }
        public uint BaseDuration { get; set; }
        public uint PerLevel { get; set; }
        public uint MaxDuration { get; set; }
    }

    internal class SpellRadius
    {
        public uint RadiusID { get; set; }
        public float EffectRadius { get; set; }
        public float PerLevel { get; set; }
        public float MaxRadius { get; set; }
    }

    internal class SpellCastTimes
    {
        public uint CastTimeID { get; set; }
        public uint BaseTime { get; set; }
        public uint UnknownTime { get; set; }
        public uint MinTime { get; set; }
    }

    internal class SpellMechanic
    {
        public uint MechanicID { get; set; }
        public string MechRefName { get; set; }
    }
    */

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellCategoriesEntry //from mangos
    {
        public uint ID;                    // 0        m_ID
        public uint Category;              // 1        m_category
        public uint DmgClass;              // 153      m_defenseType
        public SpellDispelType Dispel;     // 2        m_dispelType
        public SpellMechanic Mechanic;     // 3        m_mechanic
        public uint PreventionType;        // 154      m_preventionType
        public uint StartRecoveryCategory; // 145      m_startRecoveryCategory
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellClassOptionsEntry
    {
        public uint ID;         // 0        m_ID
        uint modalNextSpell;    // 50       m_modalNextSpell not used
        ulong SpellFamilyFlags; // 149-150  m_spellClassMask NOTE: size is 12 bytes!!!
        uint SpellFamilyFlags2; // 151      addition to m_spellClassMask
        public SpellFamilyNames SpellFamilyName;   // 148      m_spellClassSet
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellCategory
    {
        int ID;
        byte used_unk_mask;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellRangeEntry
    {
        public int ID;
        public float MinRangeFoe;
        public float MinRangeFriend;
        public float MaxRangeFoe;
        public float MaxRangeFriend;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellAuraNames
    {
        public int ID;
        [MarshalAs(UnmanagedType.LPStr)]
        public string
            Name,
            Description;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellCastTimes
    {
        int id;
        int CastTime;
        int CastTimePerLevel;
        int MinCastTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellDispelTypeEntry
    {
        int id;
        string name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellDuration
    {
        int id;
        int ms_base;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellEffectNames
    {
        int id;
        string name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellFocusObject
    {
        int id;
        string name;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellIcon
    {
        int id;
        string icon;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellItemEnchantmentCondition
    {
        int m_ID;
        byte m_lt_operandType1;
        byte m_lt_operandType2;
        byte m_lt_operandType3;
        byte m_lt_operandType4;
        byte m_lt_operandType5;
        uint m_lt_operand1;
        uint m_lt_operand2;
        uint m_lt_operand3;
        uint m_lt_operand4;
        uint m_lt_operand5;
        byte m_operator1;
        byte m_operator2;
        byte m_operator3;
        byte m_operator4;
        byte m_operator5;
        byte m_rt_operandType1;
        byte m_rt_operandType2;
        byte m_rt_operandType3;
        byte m_rt_operandType4;
        byte m_rt_operandType5;
        uint m_rt_operand1;
        uint m_rt_operand2;
        uint m_rt_operand3;
        uint m_rt_operand4;
        uint m_rt_operand5;
        byte m_logic1;
        byte m_logic2;
        byte m_logic3;
        byte m_logic4;
        byte m_logic5;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellRadius
    {
        int id;
        float yards;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SpellShapeshiftForm
    {
        int id;
        string name;
    }
}