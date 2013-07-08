using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public static class ItemCache
    {
        static ConcurrentDictionary<uint, ItemCacheEntry> ItemInfos = new ConcurrentDictionary<uint, ItemCacheEntry>();
        public static ItemCacheEntry Get(uint index)
        {
            return WowBase.Instance.InGame ? ItemInfos.GetOrAdd(index, id => WowBase.Instance.Bridge.GetInfoBlockByID(id)) : null;
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class ItemCacheEntry
    {
        internal void Debug()
        {
            foreach (var FI in typeof(ItemCacheEntry).GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public))
                Log.Normal("{0}: {1}", FI.Name, FI.GetValue(this));
        }

        public string GetName()
        {
            var Names = new string[] { name1, name2, name3, name4 };
            foreach (var name in Names)
                if (!string.IsNullOrWhiteSpace(name))
                    return name;

            return "";
        }

        public List<Spell> GetSpells()
        {
            var ids = new int[] { spellid_1, spellid_2, spellid_3, spellid_4, spellid_5 };
            return ids.Where(id => id > 0).Select(id => Spell.Get(id)).ToList();
        }

        public int itemID; //
        public int qualityID; //Quality Types 
        public ItemFlags Flags;//BitMask  //Item Types // 0x200 = quest
        uint unkFlags2;
        public int buyPrice; //Value is in Copper 
        public int sellPrice; //Value is in Copper
        public int inventoryType; //Inventory Slots 
        public int allowableClass;//BitMask //ChrClasses.dbc - Class Types 
        public int allowableRace;//BitMask  //ChrRaces.dbc - Race Types 
        public int itemLevel; //The actual base level of an item
        public int requiredLevel; //Player's required level to use 
        public int requiredSkill; //SkillLine.dbc - Required Skill to use 
        public int requiredSkillLevel; //Level of Skill required 
        public int requiredSpell; //Spell.dbc - Spell required to use the item

        int RequiredHonorRank;
        int RequiredCityRank;
        int RequiredReputationFaction;
        int RequiredReputationRank;
        int MaxCount;
        int Stackable;
        int ContainerSlots;

        int stat_type1;
        int stat_type2;
        int stat_type3;
        int stat_type4;
        int stat_type5;
        int stat_type6;
        int stat_type7;
        int stat_type8;
        int stat_type9;
        int stat_type10;

        int stat_value1;
        int stat_value2;
        int stat_value3;
        int stat_value4;
        int stat_value5;
        int stat_value6;
        int stat_value7;
        int stat_value8;
        int stat_value9;
        int stat_value10;

        int stat_unk1_1;
        int stat_unk1_2;
        int stat_unk1_3;
        int stat_unk1_4;
        int stat_unk1_5;
        int stat_unk1_6;
        int stat_unk1_7;
        int stat_unk1_8;
        int stat_unk1_9;
        int stat_unk1_10;
        int stat_unk2_1;
        int stat_unk2_2;
        int stat_unk2_3;
        int stat_unk2_4;
        int stat_unk2_5;
        int stat_unk2_6;
        int stat_unk2_7;
        int stat_unk2_8;
        int stat_unk2_9;
        int stat_unk2_10;

        int scalingstatdistribution;
        int damagetype;
        int delay;
        float rangedmodrange;

        public int
            spellid_1,
            spellid_2,
            spellid_3,
            spellid_4,
            spellid_5;

        int spelltrigger_1;
        int spelltrigger_2;
        int spelltrigger_3;
        int spelltrigger_4;
        int spelltrigger_5;

        int spellcharges_1;
        int spellcharges_2;
        int spellcharges_3;
        int spellcharges_4;
        int spellcharges_5;

        int spellcooldown_1;
        int spellcooldown_2;
        int spellcooldown_3;
        int spellcooldown_4;
        int spellcooldown_5;

        int spellcategory_1;
        int spellcategory_2;
        int spellcategory_3;
        int spellcategory_4;
        int spellcategory_5;

        int spellcategorycooldown_1;
        int spellcategorycooldown_2;
        int spellcategorycooldown_3;
        int spellcategorycooldown_4;
        int spellcategorycooldown_5;

        int bonding;

        [MarshalAs(UnmanagedType.LPStr)]
        public string
            name1,
            name2,
            name3,
            name4,
            description;

        int pagetext;
        int languageid;
        int pagematerial;
        int startquest;
        int lockid;
        int material;
        int sheath;
        int randomproperty;
        int randomsuffix;
        int itemset;
        int maxdurability;
        int area;
        int map;
        int bagfamily;
        int totemcategory;

        int socketcolor_1;
        int socketcolor_2;
        int socketcolor_3;

        int socketcontent_1;
        int socketcontent_2;
        int socketcontent_3;

        int socketbonus;

        int gemproperties;

        float armordamagemodifier;
        int duration;
        int itemlimitcategory;
        int holidayid;
        float statscalingfactor;

        /*
        int field_130;
        int field_131;
        */
    }
}