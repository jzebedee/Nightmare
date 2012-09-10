using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Bloodstream.Interfaces;
using Bloodstream.Patchables;
using Bloodstream.Patchables.DBC;
using Utils;

namespace Bloodstream.Lib.Spells
{
    public sealed class Spell : IEquatable<Spell>
    {
        const int MAX_SPELLEFFECT_INDEX = 3;

        #region Static retrievers and ctor
        static ConcurrentDictionary<int, Spell> _spellDict = new ConcurrentDictionary<int, Spell>();

        public static Spell Get(int ID)
        {
            return _spellDict.GetOrAdd(ID, (inID) => new Spell(inID));
        }
        public static Spell Get(uint ID)
        {
            return Get((int)ID);
        }
        public static Spell Get(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                return null;

            return _spellDict.Values.Where(s => Name.Equals(s.Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }

        Spell(int Id)
        {
            var DBC = Lib.DBC.Instance;
            var SpellRow = DBC[ClientDb.Spell].GetRow(Id);
            if (!SpellRow.Valid())
                return;

            pSpellRow = SpellRow._address;

            SpellDetail = SpellRow.GetStruct<SpellEntry>();

            DBC.SafePull<SpellLevelsEntry>(ClientDb.SpellLevels, SpellDetail.SpellLevelsId, out SpellLevels);
            DBC.SafePull<SpellRangeEntry>(ClientDb.SpellRange, SpellDetail.rangeIndex, out SpellRanges);
            DBC.SafePull<SpellCategoriesEntry>(ClientDb.SpellCategories, SpellDetail.SpellCategoriesId, out SpellCategories);
            DBC.SafePull<SpellClassOptionsEntry>(ClientDb.SpellClassOptions, SpellDetail.SpellClassOptionsId, out SpellClassOptions);
            DBC.SafePull<SpellRuneCostEntry>(ClientDb.SpellRuneCost, SpellDetail.runeCostID, out SpellRuneCosts);

            SpellEffects = new SpellEffectEntry[3];
            for (uint i = 0; i < MAX_SPELLEFFECT_INDEX; i++)
                SpellEffects[i] = WowBase.Instance.Bridge.GetSpellEffectID((uint)ID, i);
        }
        #endregion

        uint pSpellRow;

        SpellEntry SpellDetail;
        SpellLevelsEntry? SpellLevels;
        SpellCategoriesEntry? SpellCategories;
        SpellClassOptionsEntry? SpellClassOptions;
        SpellRangeEntry? SpellRanges;
        SpellRuneCostEntry? SpellRuneCosts;
        internal SpellEffectEntry[] SpellEffects;

        #region Properties
        public string Name { get { return SpellDetail.name; } }
        public int ID { get { return SpellDetail.ID; } }

        public string Tooltip { get { return SpellDetail.description; } }

        public uint Category
        {
            get
            {
                return SpellCategories.GetValueOrDefault().Category;
            }
        }

        public uint PowerCost
        {
            get
            {
                return (uint)WowBase.Instance.Bridge.GetSpellPowerCost((IntPtr)pSpellRow);
            }
        }

        public SpellFamilyNames FamilyName
        {
            get
            {
                return SpellClassOptions.GetValueOrDefault().SpellFamilyName;
            }
        }

        public SpellLevelsEntry LevelInfo
        {
            get
            {
                return SpellLevels.GetValueOrDefault();
            }
        }

        public SpellRuneCostEntry RuneCost
        {
            get
            {
                if (!SpellRuneCosts.HasValue)
                    throw new NotSupportedException("This is not a spell that uses rune cost");

                return SpellRuneCosts.Value;
            }
        }

        public SpellPowerType PowerType { get { return SpellDetail.powerType; } }

        public bool IsBuff
        {
            get
            {
                if (Override != null)
                    switch (Override.Code)
                    {
                        case OverrideCode.PartyBuff:
                            return true;
                    }

                return false; //TODO: fix
            }
        }
        public bool IsDebuff
        {
            get
            {
                return false; //TODO: fix
            }
        }
        public bool IsAura
        {
            get
            {
                if (Override != null)
                    switch (Override.Code)
                    {
                        case OverrideCode.PartyBuff:
                            return true;
                    }

                foreach (var effectEntry in SpellEffects) //taken from Spell__HasApplyAuraEffect
                    switch (effectEntry.Type)
                    {
                        case SpellEffectType.APPLY_AURA:
                        case SpellEffectType.PERSISTENT_AREA_AURA:
                        case SpellEffectType.APPLY_AREA_AURA_PARTY:
                        case SpellEffectType.APPLY_AREA_AURA_RAID:
                        case SpellEffectType.APPLY_AREA_AURA_PET:
                        case SpellEffectType.APPLY_AREA_AURA_FRIEND:
                        case SpellEffectType.APPLY_AREA_AURA_ENEMY:
                        case SpellEffectType.APPLY_AREA_AURA_OWNER:
                            //case 174:
                            return true;
                    }

                return AurasApplied.Any();
            }
        }

        public SpellOverride Override
        {
            get
            {
                return SpellOverride.Get(this);
            }
        }

        public SpellMechanic Mechanic
        {
            get
            {
                return SpellCategories.GetValueOrDefault().Mechanic;
            }
        }

        public List<int> AurasApplied
        {
            get
            {
                if (Override != null)
                    switch (Override.Code)
                    {
                        case OverrideCode.PartyBuff:
                            if (Override.AlternateIDs.Any())
                                return Override.AlternateIDs;
                            break;
                    }

                return (from se in SpellEffects
                        let id = se.TriggerSpell
                        where id != 0
                        select id).ToList();
            }
        }

        public SpellRangeEntry Ranges
        {
            get
            {
                return SpellRanges.GetValueOrDefault();
            }
        }
        #endregion

        public override string ToString()
        {
            return Name;
        }

        internal void Debug()
        {
            foreach (var FI in SpellDetail.GetType().GetFields())
                Log.Normal("{0}: {1}", FI.Name, FI.GetValue(SpellDetail));
        }

        public bool Equals(Spell other)
        {
            return other != null && ID == other.ID;
        }
    }
}