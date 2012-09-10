using System;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;
using Utils;

namespace Bloodstream.Lib
{
    public static class ReaderHelper
    {
        public static ulong GetObjectGUID(uint Pointer)
        {
            return SMemory.Read<UInt64>(Pointer + (int)ObjectExtras.Guid);
        }
        public static WoWObjectType GetObjectType(uint Pointer)
        {
            return (WoWObjectType)SMemory.Read<UInt32>(Pointer + (int)ObjectExtras.Type);
        }
        public static uint GetObjectDescriptors(uint Pointer)
        {
            return SMemory.Read<uint>(Pointer + (int)ObjectExtras.Descriptor);
        }
    }

    public partial class WowObject
    {
        UInt64 FIELD_GUID { get { return Memory.Read<UInt64>(Descriptor + (int)ObjectFields.GUID); } } //CONV
        Int32 FIELD_TYPE { get { return Memory.Read<Int32>(Descriptor + (int)ObjectFields.TYPE); } } //CONV
        UInt32 Entry { get { return Memory.Read<UInt32>(Descriptor + (int)ObjectFields.ENTRY); } }
        float SCALE_X { get { return Memory.Read<float>(Descriptor + (int)ObjectFields.SCALE_X); } } //CONV
        ulong DATA { get { return Memory.Read<ulong>(Descriptor + (int)ObjectFields.DATA); } } //CONV
        uint PADDING { get { return Memory.Read<uint>(Descriptor + (int)ObjectFields.PADDING); } } //CONV

        public virtual float Facing { get { return Memory.Read<float>(Pointer + (int)WowObjectExtras.Facing); } }
        protected virtual Vector3D RawPosition { get { return Memory.Read<Vector3D>(Pointer + (int)WowObjectExtras.Location); } }
    }

    public partial class Unit
    {
        public UInt64 AttackedGUID { get { return Memory.Read<UInt64>(Pointer + (int)UnitExtras.AttackedGUID); } }
        public UInt64 TransportGUID { get { return Memory.Read<UInt64>(Pointer + (int)UnitExtras.TransportGUID); } }

        public WoWClassification Classification { get { return (WoWClassification)Memory.Read<int>(Pointer + (int)UnitExtras.ClassificationBase, (uint)UnitExtras.ClassficationOffset); } }

        public UInt32 Casting { get { return Memory.Read<UInt32>(Pointer + (int)UnitExtras.Casting); } }
        public UInt32 ChanneledCasting { get { return Memory.Read<UInt32>(Pointer + (int)UnitExtras.ChanneledCasting); } }

        //UInt32 PADDING { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.PADDING); } } //CONV
        public UInt64 CharmGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.CHARM); } } //CONV
        public UInt64 SummonGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.SUMMON); } } //CONV
        public UInt64 CritterGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.CRITTER); } } //CONV
        public UInt64 CharmedByGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.CHARMEDBY); } } //CONV
        public UInt64 SummonedByGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.SUMMONEDBY); } } //CONV
        public UInt64 CreatedByGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.CREATEDBY); } } //CONV
        public UInt64 TargetGUID { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.TARGET); } } //CONV
        UInt64 CHANNEL_OBJECT { get { return Memory.Read<UInt64>(Descriptor + (int)UnitFields.CHANNEL_OBJECT); } } //CONV
        UInt32 CHANNEL_SPELL { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.CHANNEL_SPELL); } } //CONV
        Byte[] BYTES_0 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)UnitFields.BYTES_0, 4); } } //CONV

        public UInt32 HealthPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.HEALTH); } } //CONV
        public UInt32 ManaPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER1); } } //CONV
        public UInt32 RagePoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER2); } } //CONV
        public UInt32 FocusPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER3); } } //CONV
        public UInt32 EnergyPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER4); } } //CONV
        public UInt32 HappinessPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER5); } } //CONV
        //public UInt32 RunesPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER6); } } //CONV
        public UInt32 RunicPowerPoints { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POWER7); } } //CONV
        public uint SoulShardPoints { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.POWER8); } } //CONV
        public uint EclipsePoints { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.POWER9); } } //CONV
        public uint HolyPowerPoints { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.POWER10); } } //CONV
        uint POWER11 { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.POWER11); } } //CONV

        public UInt32 MaxHealth { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXHEALTH); } } //CONV
        public UInt32 MaxMana { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER1); } } //CONV
        public UInt32 MaxRage { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER2); } } //CONV
        public UInt32 MaxFocus { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER3); } } //CONV
        public UInt32 MaxEnergy { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER4); } } //CONV
        public UInt32 MaxHappiness { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER5); } } //CONV
        //public UInt32 MaxRunes { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER6); } } //CONV
        public UInt32 MaxRunicPower { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MAXPOWER7); } } //CONV
        public uint MaxSoulShards { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.MAXPOWER8); } } //CONV
        public uint MaxEclipse { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.MAXPOWER9); } } //CONV
        public uint MaxHolyPower { get { return Memory.Read<uint>(Descriptor + (int)UnitFields.MAXPOWER10); } } //CONV
        object MAXPOWER11 { get { return Memory.Read<object>(Descriptor + (int)UnitFields.MAXPOWER11); } } //CONV

        Single[] POWER_REGEN_FLAT_MODIFIER { get { return Memory.ConvertArray<Single>(Descriptor + (int)UnitFields.POWER_REGEN_FLAT_MODIFIER, 7); } } //CONV
        Single[] POWER_REGEN_INTERRUPTED_FLAT_MODIFIER { get { return Memory.ConvertArray<Single>(Descriptor + (int)UnitFields.POWER_REGEN_INTERRUPTED_FLAT_MODIFIER, 7); } } //CONV
        public Int32 Level { get { return Memory.Read<Int32>(Descriptor + (int)UnitFields.LEVEL); } } //CONV
        UInt32 FactionTemplate { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.FACTIONTEMPLATE); } } //CONV
        UInt32[] VIRTUAL_ITEM_SLOT_ID { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.VIRTUAL_ITEM_SLOT_ID, 3); } } //CONV
        public UnitFlags Flags { get { return (UnitFlags)Memory.Read<UInt32>(Descriptor + (int)UnitFields.FLAGS); } } //CONV
        public UnitFlags2 Flags2 { get { return (UnitFlags2)Memory.Read<UInt32>(Descriptor + (int)UnitFields.FLAGS_2); } } //CONV
        UInt32 AURASTATE { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.AURASTATE); } } //CONV
        UInt32[] BASEATTACKTIME { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.BASEATTACKTIME, 2); } } //CONV
        UInt32 RANGEDATTACKTIME { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.RANGEDATTACKTIME); } } //CONV
        Single BOUNDINGRADIUS { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.BOUNDINGRADIUS); } } //CONV
        Single COMBATREACH { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.COMBATREACH); } } //CONV
        UInt32 DISPLAYID { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.DISPLAYID); } } //CONV
        UInt32 NATIVEDISPLAYID { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NATIVEDISPLAYID); } } //CONV
        public UInt32 MountDisplayID { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.MOUNTDISPLAYID); } } //CONV
        Single MINDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MINDAMAGE); } } //CONV
        Single MAXDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MAXDAMAGE); } } //CONV
        Single MINOFFHANDDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MINOFFHANDDAMAGE); } } //CONV
        Single MAXOFFHANDDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MAXOFFHANDDAMAGE); } } //CONV
        Byte[] BYTES_1 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)UnitFields.BYTES_1, 4); } } //CONV
        UInt32 PETNUMBER { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.PETNUMBER); } } //CONV
        UInt32 PET_NAME_TIMESTAMP { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.PET_NAME_TIMESTAMP); } } //CONV
        UInt32 PETEXPERIENCE { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.PETEXPERIENCE); } } //CONV
        UInt32 PETNEXTLEVELEXP { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.PETNEXTLEVELEXP); } } //CONV
        public UnitDynamicFlags DynamicFlags { get { return (UnitDynamicFlags)Memory.Read<UInt32>(Descriptor + (int)UnitFields.DYNAMIC_FLAGS); } } //CONV
        Single MOD_CAST_SPEED { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MOD_CAST_SPEED); } } //CONV
        UInt32 CREATED_BY_SPELL { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.CREATED_BY_SPELL); } } //CONV
        public UnitNPCFlags NPCFlags { get { return (UnitNPCFlags)Memory.Read<UInt32>(Descriptor + (int)UnitFields.NPC_FLAGS); } } //CONV
        UInt32 NPC_EMOTESTATE { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NPC_EMOTESTATE); } } //CONV
        UInt32 STAT0 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.STAT0); } } //CONV
        UInt32 STAT1 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.STAT1); } } //CONV
        UInt32 STAT2 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.STAT2); } } //CONV
        UInt32 STAT3 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.STAT3); } } //CONV
        UInt32 STAT4 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.STAT4); } } //CONV
        UInt32 POSSTAT0 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POSSTAT0); } } //CONV
        UInt32 POSSTAT1 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POSSTAT1); } } //CONV
        UInt32 POSSTAT2 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POSSTAT2); } } //CONV
        UInt32 POSSTAT3 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POSSTAT3); } } //CONV
        UInt32 POSSTAT4 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.POSSTAT4); } } //CONV
        UInt32 NEGSTAT0 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NEGSTAT0); } } //CONV
        UInt32 NEGSTAT1 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NEGSTAT1); } } //CONV
        UInt32 NEGSTAT2 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NEGSTAT2); } } //CONV
        UInt32 NEGSTAT3 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NEGSTAT3); } } //CONV
        UInt32 NEGSTAT4 { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.NEGSTAT4); } } //CONV
        UInt32[] RESISTANCES { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.RESISTANCES, 7); } } //CONV
        UInt32[] RESISTANCEBUFFMODSPOSITIVE { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.RESISTANCEBUFFMODSPOSITIVE, 7); } } //CONV
        UInt32[] RESISTANCEBUFFMODSNEGATIVE { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.RESISTANCEBUFFMODSNEGATIVE, 7); } } //CONV

        public UInt32 BaseMana { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.BASE_MANA); } } //CONV
        public UInt32 BaseHealth { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.BASE_HEALTH); } } //CONV

        Byte[] BYTES_2 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)UnitFields.BYTES_2, 4); } } //CONV
        UInt32 ATTACK_POWER { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.ATTACK_POWER); } } //CONV
        object ATTACK_POWER_MOD_POS { get { return Memory.Read<object>(Descriptor + (int)UnitFields.ATTACK_POWER_MOD_POS); } } //AUTO
        object ATTACK_POWER_MOD_NEG { get { return Memory.Read<object>(Descriptor + (int)UnitFields.ATTACK_POWER_MOD_NEG); } } //AUTO
        Single ATTACK_POWER_MULTIPLIER { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.ATTACK_POWER_MULTIPLIER); } } //CONV
        UInt32 RANGED_ATTACK_POWER { get { return Memory.Read<UInt32>(Descriptor + (int)UnitFields.RANGED_ATTACK_POWER); } } //CONV
        object RANGED_ATTACK_POWER_MOD_POS { get { return Memory.Read<object>(Descriptor + (int)UnitFields.RANGED_ATTACK_POWER_MOD_POS); } } //AUTO
        object RANGED_ATTACK_POWER_MOD_NEG { get { return Memory.Read<object>(Descriptor + (int)UnitFields.RANGED_ATTACK_POWER_MOD_NEG); } } //AUTO
        Single RANGED_ATTACK_POWER_MULTIPLIER { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.RANGED_ATTACK_POWER_MULTIPLIER); } } //CONV
        Single MINRANGEDDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MINRANGEDDAMAGE); } } //CONV
        Single MAXRANGEDDAMAGE { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MAXRANGEDDAMAGE); } } //CONV
        UInt32[] POWER_COST_MODIFIER { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)UnitFields.POWER_COST_MODIFIER, 7); } } //CONV
        Single[] POWER_COST_MULTIPLIER { get { return Memory.ConvertArray<Single>(Descriptor + (int)UnitFields.POWER_COST_MULTIPLIER, 7); } } //CONV
        Single MAXHEALTHMODIFIER { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.MAXHEALTHMODIFIER); } } //CONV
        Single HOVERHEIGHT { get { return Memory.Read<Single>(Descriptor + (int)UnitFields.HOVERHEIGHT); } } //CONV
        object MAXITEMLEVEL { get { return Memory.Read<object>(Descriptor + (int)UnitFields.MAXITEMLEVEL); } } //CONV
    }
    public partial class Player
    {
        UInt64 DUEL_ARBITER { get { return Memory.Read<UInt64>(Descriptor + (int)PlayerFields.DUEL_ARBITER); } } //CONV
        ItemFlags Flags { get { return (ItemFlags)Memory.Read<UInt32>(Descriptor + (int)ItemFields.FLAGS); } } //CONV
        UInt32 GUILDRANK { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.GUILDRANK); } } //CONV
        object GUILDDELETE_DATE { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.GUILDDELETE_DATE); } } //CONV
        object GUILDLEVEL { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.GUILDLEVEL); } } //CONV
        Byte[] BYTES { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.BYTES, 4); } } //CONV
        Byte[] BYTES_2 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.BYTES_2, 4); } } //CONV
        Byte[] BYTES_3 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.BYTES_3, 4); } } //CONV
        UInt32 DUEL_TEAM { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.DUEL_TEAM); } } //CONV
        UInt32 GUILD_TIMESTAMP { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.GUILD_TIMESTAMP); } } //CONV
        UInt32 QUEST_LOG_1_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_1_1); } } //CONV
        UInt32 QUEST_LOG_1_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_1_2); } } //CONV
        Int32[] QUEST_LOG_1_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_1_3, 2); } } //CONV
        UInt32 QUEST_LOG_1_4 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_1_4); } } //CONV
        UInt32 QUEST_LOG_2_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_2_1); } } //CONV
        UInt32 QUEST_LOG_2_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_2_2); } } //CONV
        Int32[] QUEST_LOG_2_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_2_3, 2); } } //CONV
        UInt32 QUEST_LOG_2_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_2_5); } } //CONV
        UInt32 QUEST_LOG_3_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_3_1); } } //CONV
        UInt32 QUEST_LOG_3_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_3_2); } } //CONV
        Int32[] QUEST_LOG_3_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_3_3, 2); } } //CONV
        UInt32 QUEST_LOG_3_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_3_5); } } //CONV
        UInt32 QUEST_LOG_4_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_4_1); } } //CONV
        UInt32 QUEST_LOG_4_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_4_2); } } //CONV
        Int32[] QUEST_LOG_4_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_4_3, 2); } } //CONV
        UInt32 QUEST_LOG_4_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_4_5); } } //CONV
        UInt32 QUEST_LOG_5_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_5_1); } } //CONV
        UInt32 QUEST_LOG_5_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_5_2); } } //CONV
        Int32[] QUEST_LOG_5_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_5_3, 2); } } //CONV
        UInt32 QUEST_LOG_5_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_5_5); } } //CONV
        UInt32 QUEST_LOG_6_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_6_1); } } //CONV
        UInt32 QUEST_LOG_6_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_6_2); } } //CONV
        Int32[] QUEST_LOG_6_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_6_3, 2); } } //CONV
        UInt32 QUEST_LOG_6_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_6_5); } } //CONV
        UInt32 QUEST_LOG_7_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_7_1); } } //CONV
        UInt32 QUEST_LOG_7_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_7_2); } } //CONV
        Int32[] QUEST_LOG_7_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_7_3, 2); } } //CONV
        UInt32 QUEST_LOG_7_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_7_5); } } //CONV
        UInt32 QUEST_LOG_8_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_8_1); } } //CONV
        UInt32 QUEST_LOG_8_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_8_2); } } //CONV
        Int32[] QUEST_LOG_8_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_8_3, 2); } } //CONV
        UInt32 QUEST_LOG_8_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_8_5); } } //CONV
        UInt32 QUEST_LOG_9_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_9_1); } } //CONV
        UInt32 QUEST_LOG_9_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_9_2); } } //CONV
        Int32[] QUEST_LOG_9_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_9_3, 2); } } //CONV
        UInt32 QUEST_LOG_9_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_9_5); } } //CONV
        UInt32 QUEST_LOG_10_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_10_1); } } //CONV
        UInt32 QUEST_LOG_10_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_10_2); } } //CONV
        Int32[] QUEST_LOG_10_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_10_3, 2); } } //CONV
        UInt32 QUEST_LOG_10_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_10_5); } } //CONV
        UInt32 QUEST_LOG_11_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_11_1); } } //CONV
        UInt32 QUEST_LOG_11_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_11_2); } } //CONV
        Int32[] QUEST_LOG_11_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_11_3, 2); } } //CONV
        UInt32 QUEST_LOG_11_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_11_5); } } //CONV
        UInt32 QUEST_LOG_12_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_12_1); } } //CONV
        UInt32 QUEST_LOG_12_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_12_2); } } //CONV
        Int32[] QUEST_LOG_12_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_12_3, 2); } } //CONV
        UInt32 QUEST_LOG_12_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_12_5); } } //CONV
        UInt32 QUEST_LOG_13_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_13_1); } } //CONV
        UInt32 QUEST_LOG_13_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_13_2); } } //CONV
        Int32[] QUEST_LOG_13_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_13_3, 2); } } //CONV
        UInt32 QUEST_LOG_13_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_13_5); } } //CONV
        UInt32 QUEST_LOG_14_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_14_1); } } //CONV
        UInt32 QUEST_LOG_14_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_14_2); } } //CONV
        Int32[] QUEST_LOG_14_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_14_3, 2); } } //CONV
        UInt32 QUEST_LOG_14_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_14_5); } } //CONV
        UInt32 QUEST_LOG_15_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_15_1); } } //CONV
        UInt32 QUEST_LOG_15_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_15_2); } } //CONV
        Int32[] QUEST_LOG_15_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_15_3, 2); } } //CONV
        UInt32 QUEST_LOG_15_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_15_5); } } //CONV
        UInt32 QUEST_LOG_16_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_16_1); } } //CONV
        UInt32 QUEST_LOG_16_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_16_2); } } //CONV
        Int32[] QUEST_LOG_16_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_16_3, 2); } } //CONV
        UInt32 QUEST_LOG_16_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_16_5); } } //CONV
        UInt32 QUEST_LOG_17_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_17_1); } } //CONV
        UInt32 QUEST_LOG_17_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_17_2); } } //CONV
        Int32[] QUEST_LOG_17_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_17_3, 2); } } //CONV
        UInt32 QUEST_LOG_17_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_17_5); } } //CONV
        UInt32 QUEST_LOG_18_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_18_1); } } //CONV
        UInt32 QUEST_LOG_18_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_18_2); } } //CONV
        Int32[] QUEST_LOG_18_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_18_3, 2); } } //CONV
        UInt32 QUEST_LOG_18_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_18_5); } } //CONV
        UInt32 QUEST_LOG_19_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_19_1); } } //CONV
        UInt32 QUEST_LOG_19_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_19_2); } } //CONV
        Int32[] QUEST_LOG_19_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_19_3, 2); } } //CONV
        UInt32 QUEST_LOG_19_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_19_5); } } //CONV
        UInt32 QUEST_LOG_20_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_20_1); } } //CONV
        UInt32 QUEST_LOG_20_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_20_2); } } //CONV
        Int32[] QUEST_LOG_20_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_20_3, 2); } } //CONV
        UInt32 QUEST_LOG_20_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_20_5); } } //CONV
        UInt32 QUEST_LOG_21_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_21_1); } } //CONV
        UInt32 QUEST_LOG_21_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_21_2); } } //CONV
        Int32[] QUEST_LOG_21_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_21_3, 2); } } //CONV
        UInt32 QUEST_LOG_21_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_21_5); } } //CONV
        UInt32 QUEST_LOG_22_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_22_1); } } //CONV
        UInt32 QUEST_LOG_22_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_22_2); } } //CONV
        Int32[] QUEST_LOG_22_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_22_3, 2); } } //CONV
        UInt32 QUEST_LOG_22_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_22_5); } } //CONV
        UInt32 QUEST_LOG_23_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_23_1); } } //CONV
        UInt32 QUEST_LOG_23_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_23_2); } } //CONV
        Int32[] QUEST_LOG_23_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_23_3, 2); } } //CONV
        UInt32 QUEST_LOG_23_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_23_5); } } //CONV
        UInt32 QUEST_LOG_24_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_24_1); } } //CONV
        UInt32 QUEST_LOG_24_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_24_2); } } //CONV
        Int32[] QUEST_LOG_24_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_24_3, 2); } } //CONV
        UInt32 QUEST_LOG_24_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_24_5); } } //CONV
        UInt32 QUEST_LOG_25_1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_25_1); } } //CONV
        UInt32 QUEST_LOG_25_2 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_25_2); } } //CONV
        Int32[] QUEST_LOG_25_3 { get { return Memory.ConvertArray<Int32>(Descriptor + (int)PlayerFields.QUEST_LOG_25_3, 2); } } //CONV
        UInt32 QUEST_LOG_25_5 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.QUEST_LOG_25_5); } } //CONV
        object QUEST_LOG_26_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_26_1); } } //CONV
        object QUEST_LOG_26_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_26_2); } } //CONV
        object QUEST_LOG_26_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_26_3); } } //CONV
        object QUEST_LOG_26_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_26_5); } } //CONV
        object QUEST_LOG_27_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_27_1); } } //CONV
        object QUEST_LOG_27_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_27_2); } } //CONV
        object QUEST_LOG_27_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_27_3); } } //CONV
        object QUEST_LOG_27_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_27_5); } } //CONV
        object QUEST_LOG_28_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_28_1); } } //CONV
        object QUEST_LOG_28_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_28_2); } } //CONV
        object QUEST_LOG_28_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_28_3); } } //CONV
        object QUEST_LOG_28_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_28_5); } } //CONV
        object QUEST_LOG_29_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_29_1); } } //CONV
        object QUEST_LOG_29_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_29_2); } } //CONV
        object QUEST_LOG_29_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_29_3); } } //CONV
        object QUEST_LOG_29_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_29_5); } } //CONV
        object QUEST_LOG_30_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_30_1); } } //CONV
        object QUEST_LOG_30_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_30_2); } } //CONV
        object QUEST_LOG_30_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_30_3); } } //CONV
        object QUEST_LOG_30_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_30_5); } } //CONV
        object QUEST_LOG_31_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_31_1); } } //CONV
        object QUEST_LOG_31_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_31_2); } } //CONV
        object QUEST_LOG_31_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_31_3); } } //CONV
        object QUEST_LOG_31_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_31_5); } } //CONV
        object QUEST_LOG_32_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_32_1); } } //CONV
        object QUEST_LOG_32_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_32_2); } } //CONV
        object QUEST_LOG_32_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_32_3); } } //CONV
        object QUEST_LOG_32_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_32_5); } } //CONV
        object QUEST_LOG_33_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_33_1); } } //CONV
        object QUEST_LOG_33_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_33_2); } } //CONV
        object QUEST_LOG_33_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_33_3); } } //CONV
        object QUEST_LOG_33_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_33_5); } } //CONV
        object QUEST_LOG_34_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_34_1); } } //CONV
        object QUEST_LOG_34_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_34_2); } } //CONV
        object QUEST_LOG_34_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_34_3); } } //CONV
        object QUEST_LOG_34_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_34_5); } } //CONV
        object QUEST_LOG_35_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_35_1); } } //CONV
        object QUEST_LOG_35_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_35_2); } } //CONV
        object QUEST_LOG_35_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_35_3); } } //CONV
        object QUEST_LOG_35_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_35_5); } } //CONV
        object QUEST_LOG_36_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_36_1); } } //CONV
        object QUEST_LOG_36_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_36_2); } } //CONV
        object QUEST_LOG_36_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_36_3); } } //CONV
        object QUEST_LOG_36_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_36_5); } } //CONV
        object QUEST_LOG_37_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_37_1); } } //CONV
        object QUEST_LOG_37_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_37_2); } } //CONV
        object QUEST_LOG_37_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_37_3); } } //CONV
        object QUEST_LOG_37_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_37_5); } } //CONV
        object QUEST_LOG_38_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_38_1); } } //CONV
        object QUEST_LOG_38_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_38_2); } } //CONV
        object QUEST_LOG_38_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_38_3); } } //CONV
        object QUEST_LOG_38_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_38_5); } } //CONV
        object QUEST_LOG_39_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_39_1); } } //CONV
        object QUEST_LOG_39_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_39_2); } } //CONV
        object QUEST_LOG_39_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_39_3); } } //CONV
        object QUEST_LOG_39_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_39_5); } } //CONV
        object QUEST_LOG_40_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_40_1); } } //CONV
        object QUEST_LOG_40_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_40_2); } } //CONV
        object QUEST_LOG_40_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_40_3); } } //CONV
        object QUEST_LOG_40_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_40_5); } } //CONV
        object QUEST_LOG_41_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_41_1); } } //CONV
        object QUEST_LOG_41_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_41_2); } } //CONV
        object QUEST_LOG_41_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_41_3); } } //CONV
        object QUEST_LOG_41_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_41_5); } } //CONV
        object QUEST_LOG_42_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_42_1); } } //CONV
        object QUEST_LOG_42_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_42_2); } } //CONV
        object QUEST_LOG_42_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_42_3); } } //CONV
        object QUEST_LOG_42_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_42_5); } } //CONV
        object QUEST_LOG_43_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_43_1); } } //CONV
        object QUEST_LOG_43_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_43_2); } } //CONV
        object QUEST_LOG_43_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_43_3); } } //CONV
        object QUEST_LOG_43_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_43_5); } } //CONV
        object QUEST_LOG_44_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_44_1); } } //CONV
        object QUEST_LOG_44_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_44_2); } } //CONV
        object QUEST_LOG_44_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_44_3); } } //CONV
        object QUEST_LOG_44_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_44_5); } } //CONV
        object QUEST_LOG_45_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_45_1); } } //CONV
        object QUEST_LOG_45_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_45_2); } } //CONV
        object QUEST_LOG_45_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_45_3); } } //CONV
        object QUEST_LOG_45_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_45_5); } } //CONV
        object QUEST_LOG_46_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_46_1); } } //CONV
        object QUEST_LOG_46_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_46_2); } } //CONV
        object QUEST_LOG_46_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_46_3); } } //CONV
        object QUEST_LOG_46_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_46_5); } } //CONV
        object QUEST_LOG_47_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_47_1); } } //CONV
        object QUEST_LOG_47_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_47_2); } } //CONV
        object QUEST_LOG_47_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_47_3); } } //CONV
        object QUEST_LOG_47_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_47_5); } } //CONV
        object QUEST_LOG_48_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_48_1); } } //CONV
        object QUEST_LOG_48_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_48_2); } } //CONV
        object QUEST_LOG_48_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_48_3); } } //CONV
        object QUEST_LOG_48_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_48_5); } } //CONV
        object QUEST_LOG_49_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_49_1); } } //CONV
        object QUEST_LOG_49_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_49_2); } } //CONV
        object QUEST_LOG_49_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_49_3); } } //CONV
        object QUEST_LOG_49_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_49_5); } } //CONV
        object QUEST_LOG_50_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_50_1); } } //CONV
        object QUEST_LOG_50_2 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_50_2); } } //CONV
        object QUEST_LOG_50_3 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_50_3); } } //CONV
        object QUEST_LOG_50_5 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.QUEST_LOG_50_5); } } //CONV
        UInt32 VISIBLE_ITEM_1_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_1_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_1_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_1_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_2_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_2_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_2_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_2_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_3_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_3_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_3_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_3_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_4_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_4_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_4_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_4_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_5_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_5_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_5_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_5_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_6_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_6_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_6_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_6_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_7_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_7_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_7_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_7_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_8_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_8_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_8_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_8_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_9_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_9_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_9_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_9_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_10_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_10_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_10_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_10_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_11_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_11_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_11_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_11_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_12_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_12_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_12_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_12_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_13_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_13_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_13_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_13_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_14_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_14_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_14_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_14_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_15_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_15_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_15_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_15_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_16_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_16_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_16_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_16_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_17_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_17_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_17_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_17_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_18_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_18_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_18_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_18_ENCHANTMENT); } } //CONV
        UInt32 VISIBLE_ITEM_19_ENTRYID { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_19_ENTRYID); } } //CONV
        Int32 VISIBLE_ITEM_19_ENCHANTMENT { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.VISIBLE_ITEM_19_ENCHANTMENT); } } //CONV
        UInt32 CHOSEN_TITLE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.CHOSEN_TITLE); } } //CONV
        UInt32 FAKE_INEBRIATION { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.FAKE_INEBRIATION); } } //CONV
        object PAD_0 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.PAD_0); } } //CONV
        protected UInt64[] FIELD_INV_SLOT_HEAD { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.INV_SLOT_HEAD, 23); } } //CONV
        protected UInt64[] FIELD_PACK_SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.PACK_SLOT_1, 16); } } //CONV
        UInt64[] FIELD_BANK_SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.BANK_SLOT_1, 28); } } //CONV
        UInt64[] FIELD_BANKBAG_SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.BANKBAG_SLOT_1, 7); } } //CONV
        UInt64[] FIELD_VENDORBUYBACK_SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.VENDORBUYBACK_SLOT_1, 12); } } //CONV
        UInt64[] FIELD_KEYRING_SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)PlayerFields.KEYRING_SLOT_1, 32); } } //CONV
        UInt64 FARSIGHT { get { return Memory.Read<UInt64>(Descriptor + (int)PlayerFields.FARSIGHT); } } //CONV
        UInt64 FIELD_KNOWN_TITLES { get { return Memory.Read<UInt64>(Descriptor + (int)PlayerFields.FIELD_KNOWN_TITLES); } } //CONV
        UInt64 FIELD_KNOWN_TITLES1 { get { return Memory.Read<UInt64>(Descriptor + (int)PlayerFields.FIELD_KNOWN_TITLES1); } } //CONV
        UInt64 FIELD_KNOWN_TITLES2 { get { return Memory.Read<UInt64>(Descriptor + (int)PlayerFields.FIELD_KNOWN_TITLES2); } } //CONV
        protected UInt32 XP { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.XP); } } //CONV
        protected UInt32 NEXT_LEVEL_XP { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.NEXT_LEVEL_XP); } } //CONV
        protected PlayerSkillEntry[] SKILL_INFO { get { return Memory.ConvertArray<PlayerSkillEntry>(Descriptor + (int)PlayerFields.SKILL_INFO_1_1, 128); } } //CONV
        UInt32 CHARACTER_POINTS1 { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.CHARACTER_POINTS); } } //CONV
        UInt32 TRACK_CREATURES { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.TRACK_CREATURES); } } //CONV
        UInt32 TRACK_RESOURCES { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.TRACK_RESOURCES); } } //CONV
        Single BLOCK_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.BLOCK_PERCENTAGE); } } //CONV
        Single DODGE_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.DODGE_PERCENTAGE); } } //CONV
        Single PARRY_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.PARRY_PERCENTAGE); } } //CONV
        UInt32 EXPERTISE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.EXPERTISE); } } //CONV
        UInt32 OFFHAND_EXPERTISE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.OFFHAND_EXPERTISE); } } //CONV
        Single CRIT_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.CRIT_PERCENTAGE); } } //CONV
        Single RANGED_CRIT_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.RANGED_CRIT_PERCENTAGE); } } //CONV
        Single OFFHAND_CRIT_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.OFFHAND_CRIT_PERCENTAGE); } } //CONV
        Single[] SPELL_CRIT_PERCENTAGE1 { get { return Memory.ConvertArray<Single>(Descriptor + (int)PlayerFields.SPELL_CRIT_PERCENTAGE1, 7); } } //CONV
        UInt32 SHIELD_BLOCK { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.SHIELD_BLOCK); } } //CONV
        Single SHIELD_BLOCK_CRIT_PERCENTAGE { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.SHIELD_BLOCK_CRIT_PERCENTAGE); } } //CONV
        object MASTERY { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.MASTERY); } } //CONV
        Byte[] EXPLORED_ZONES_1 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.EXPLORED_ZONES_1, 512); } } //CONV
        UInt32 REST_STATE_EXPERIENCE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.REST_STATE_EXPERIENCE); } } //CONV
        UInt32 FIELD_COINAGE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.COINAGE); } } //CONV
        UInt32[] FIELD_MOD_DAMAGE_DONE_POS { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.MOD_DAMAGE_DONE_POS, 7); } } //CONV
        UInt32[] FIELD_MOD_DAMAGE_DONE_NEG { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.MOD_DAMAGE_DONE_NEG, 7); } } //CONV
        UInt32[] FIELD_MOD_DAMAGE_DONE_PCT { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.MOD_DAMAGE_DONE_PCT, 7); } } //CONV
        UInt32 FIELD_MOD_HEALING_DONE_POS { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.MOD_HEALING_DONE_POS); } } //CONV
        Single FIELD_MOD_HEALING_PCT { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.MOD_HEALING_PCT); } } //CONV
        Single FIELD_MOD_HEALING_DONE_PCT { get { return Memory.Read<Single>(Descriptor + (int)PlayerFields.MOD_HEALING_DONE_PCT); } } //CONV
        object MOD_SPELL_POWER_PCT { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.MOD_SPELL_POWER_PCT); } } //CONV
        UInt32 FIELD_MOD_TARGET_RESISTANCE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.MOD_TARGET_RESISTANCE); } } //CONV
        UInt32 FIELD_MOD_TARGET_PHYSICAL_RESISTANCE { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.MOD_TARGET_PHYSICAL_RESISTANCE); } } //CONV
        Byte[] FIELD_BYTES { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.FIELD_BYTES, 4); } } //CONV
        UInt32 SELF_RES_SPELL { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.SELF_RES_SPELL); } } //CONV
        UInt32 FIELD_PVP_MEDALS { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.PVP_MEDALS); } } //CONV
        UInt32[] FIELD_BUYBACK_PRICE_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.BUYBACK_PRICE_1, 12); } } //CONV
        UInt32[] FIELD_BUYBACK_TIMESTAMP_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.BUYBACK_TIMESTAMP_1, 12); } } //CONV
        Int32 FIELD_KILLS { get { return Memory.Read<Int32>(Descriptor + (int)PlayerFields.KILLS); } } //CONV
        UInt32 FIELD_LIFETIME_HONORBALE_KILLS { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.LIFETIME_HONORBALE_KILLS); } } //CONV
        Byte[] FIELD_BYTES2 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)PlayerFields.BYTES2, 4); } } //CONV
        UInt32 FIELD_WATCHED_FACTION_INDEX { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.WATCHED_FACTION_INDEX); } } //CONV
        UInt32[] FIELD_COMBAT_RATING_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.COMBAT_RATING_1, 25); } } //CONV
        UInt32[] FIELD_ARENA_TEAM_INFO_1_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.ARENA_TEAM_INFO_1_1, 21); } } //CONV
        object BATTLEGROUND_RATING { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.BATTLEGROUND_RATING); } } //CONV
        UInt32 FIELD_MAX_LEVEL { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.MAX_LEVEL); } } //CONV
        UInt32[] FIELD_DAILY_QUESTS_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.DAILY_QUESTS_1, 25); } } //CONV
        Single[] RUNE_REGEN_1 { get { return Memory.ConvertArray<Single>(Descriptor + (int)PlayerFields.RUNE_REGEN_1, 4); } } //CONV
        UInt32[] NO_REAGENT_COST_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.NO_REAGENT_COST_1, 3); } } //CONV
        UInt32[] FIELD_GLYPH_SLOTS_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.GLYPH_SLOTS_1, 6); } } //CONV
        UInt32[] FIELD_GLYPHS_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)PlayerFields.GLYPHS_1, 6); } } //CONV
        UInt32 GLYPHS_ENABLED { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.GLYPHS_ENABLED); } } //CONV
        UInt32 PET_SPELL_POWER { get { return Memory.Read<UInt32>(Descriptor + (int)PlayerFields.PET_SPELL_POWER); } } //CONV
        object RESEARCHING_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.RESEARCHING_1); } } //CONV
        object RESERACH_SITE_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.RESERACH_SITE_1); } } //CONV
        object PROFESSION_SKILL_LINE_1 { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.PROFESSION_SKILL_LINE_1); } } //CONV
        object UI_HIT_MODIFIER { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.UI_HIT_MODIFIER); } } //CONV
        object UI_SPELL_HIT_MODIFIER { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.UI_SPELL_HIT_MODIFIER); } } //CONV
        object HOME_REALM_TIME_OFFSET { get { return Memory.Read<object>(Descriptor + (int)PlayerFields.HOME_REALM_TIME_OFFSET); } } //CONV
    }
    public partial class Item
    {
        public UInt64 OwnerGUID { get { return Memory.Read<UInt64>(Descriptor + (int)ItemFields.OWNER); } } //CONV

        UInt64 CONTAINED { get { return Memory.Read<UInt64>(Descriptor + (int)ItemFields.CONTAINED); } } //CONV
        UInt64 CREATOR { get { return Memory.Read<UInt64>(Descriptor + (int)ItemFields.CREATOR); } } //CONV
        UInt64 GIFTCREATOR { get { return Memory.Read<UInt64>(Descriptor + (int)ItemFields.GIFTCREATOR); } } //CONV
        UInt32 STACK_COUNT { get { return Memory.Read<UInt32>(Descriptor + (int)ItemFields.STACK_COUNT); } } //CONV
        UInt32 DURATION { get { return Memory.Read<UInt32>(Descriptor + (int)ItemFields.DURATION); } } //CONV
        UInt32[] SPELL_CHARGES { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.SPELL_CHARGES, 5); } } //CONV

        public ItemFlags Flags { get { return (ItemFlags)Memory.Read<UInt32>(Descriptor + (int)ItemFields.FLAGS); } } //CONV

        UInt32[] ENCHANTMENT_1_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_1_1, 2); } } //CONV
        Int32 ENCHANTMENT_1_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_1_3); } } //CONV
        UInt32[] ENCHANTMENT_2_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_2_1, 2); } } //CONV
        Int32 ENCHANTMENT_2_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_2_3); } } //CONV
        UInt32[] ENCHANTMENT_3_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_3_1, 2); } } //CONV
        Int32 ENCHANTMENT_3_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_3_3); } } //CONV
        UInt32[] ENCHANTMENT_4_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_4_1, 2); } } //CONV
        Int32 ENCHANTMENT_4_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_4_3); } } //CONV
        UInt32[] ENCHANTMENT_5_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_5_1, 2); } } //CONV
        Int32 ENCHANTMENT_5_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_5_3); } } //CONV
        UInt32[] ENCHANTMENT_6_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_6_1, 2); } } //CONV
        Int32 ENCHANTMENT_6_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_6_3); } } //CONV
        UInt32[] ENCHANTMENT_7_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_7_1, 2); } } //CONV
        Int32 ENCHANTMENT_7_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_7_3); } } //CONV
        UInt32[] ENCHANTMENT_8_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_8_1, 2); } } //CONV
        Int32 ENCHANTMENT_8_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_8_3); } } //CONV
        UInt32[] ENCHANTMENT_9_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_9_1, 2); } } //CONV
        Int32 ENCHANTMENT_9_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_9_3); } } //CONV
        UInt32[] ENCHANTMENT_10_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_10_1, 2); } } //CONV
        Int32 ENCHANTMENT_10_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_10_3); } } //CONV
        UInt32[] ENCHANTMENT_11_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_11_1, 2); } } //CONV
        Int32 ENCHANTMENT_11_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_11_3); } } //CONV
        UInt32[] ENCHANTMENT_12_1 { get { return Memory.ConvertArray<UInt32>(Descriptor + (int)ItemFields.ENCHANTMENT_12_1, 2); } } //CONV
        Int32 ENCHANTMENT_12_3 { get { return Memory.Read<Int32>(Descriptor + (int)ItemFields.ENCHANTMENT_12_3); } } //CONV
        object ENCHANTMENT_13_1 { get { return Memory.Read<object>(Descriptor + (int)ItemFields.ENCHANTMENT_13_1); } } //CONV
        object ENCHANTMENT_13_3 { get { return Memory.Read<object>(Descriptor + (int)ItemFields.ENCHANTMENT_13_3); } } //CONV
        object ENCHANTMENT_14_1 { get { return Memory.Read<object>(Descriptor + (int)ItemFields.ENCHANTMENT_14_1); } } //CONV
        object ENCHANTMENT_14_3 { get { return Memory.Read<object>(Descriptor + (int)ItemFields.ENCHANTMENT_14_3); } } //CONV
        UInt32 PROPERTY_SEED { get { return Memory.Read<UInt32>(Descriptor + (int)ItemFields.PROPERTY_SEED); } } //CONV
        UInt32 RANDOM_PROPERTIES_ID { get { return Memory.Read<UInt32>(Descriptor + (int)ItemFields.RANDOM_PROPERTIES_ID); } } //CONV

        public float DurabilityPoints { get { return Memory.Read<float>(Descriptor + (int)ItemFields.DURABILITY); } } //CONV
        public float MaxDurability { get { return Memory.Read<float>(Descriptor + (int)ItemFields.MAXDURABILITY); } } //CONV

        UInt32 CREATE_PLAYED_TIME { get { return Memory.Read<UInt32>(Descriptor + (int)ItemFields.CREATE_PLAYED_TIME); } } //CONV
        object PAD { get { return Memory.Read<object>(Descriptor + (int)ItemFields.PAD); } } //CONV
    }
    public partial class Container
    {
        UInt32 NUM_SLOTS { get { return Memory.Read<UInt32>(Descriptor + (int)ContainerFields.NUM_SLOTS); } } //CONV
        Byte[] ALIGN_PAD { get { return Memory.ConvertArray<Byte>(Descriptor + (int)ContainerFields.ALIGN_PAD, 4); } } //CONV
        UInt64[] SLOT_1 { get { return Memory.ConvertArray<UInt64>(Descriptor + (int)ContainerFields.SLOT_1, (int)NUM_SLOTS); } } //CONV
    }
    public partial class GameObject
    {
        protected override Vector3D RawPosition { get { return Memory.Read<Vector3D>(Pointer + (int)GameObjectExtras.Location); } }

        public ulong CreatorGUID { get { return Memory.Read<ulong>(Descriptor + (int)GameObjectFields.OBJECT_FIELD_CREATED_BY); } }
        UInt32 DisplayID { get { return Memory.Read<UInt32>(Descriptor + (int)GameObjectFields.DISPLAYID); } } //CONV
        public GameObjectFlags Flags { get { return (GameObjectFlags)Memory.Read<UInt32>(Descriptor + (int)GameObjectFields.FLAGS); } } //CONV
        Single[] ParentRotation { get { return Memory.ConvertArray<Single>(Descriptor + (int)GameObjectFields.PARENTROTATION, 4); } } //CONV
        Int32 DYNAMIC { get { return Memory.Read<Int32>(Descriptor + (int)GameObjectFields.DYNAMIC); } } //CONV
        Int32 FactionID { get { return Memory.Read<int>(Descriptor + (int)GameObjectFields.FACTION); } } //CONV
        public UInt32 Level { get { return Memory.Read<UInt32>(Descriptor + (int)GameObjectFields.LEVEL); } } //CONV
        Byte[] BYTES_1 { get { return Memory.ConvertArray<Byte>(Descriptor + (int)GameObjectFields.BYTES_1, 4); } } //CONV
    }
}