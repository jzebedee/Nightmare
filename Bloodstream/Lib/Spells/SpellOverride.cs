using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Bloodstream.Lib.Spells
{
    public class SpellOverride
    {
        static ConcurrentDictionary<int, SpellOverride> overrides = new ConcurrentDictionary<int, SpellOverride>();
        public static SpellOverride Get(Spell spell)
        {
            return overrides.GetOrAdd(spell.ID, id => Create(spell));
        }

        static SpellOverride Create(Spell spell)
        {
            SpellOverride sOverride;
            switch (spell.ID)
            {
                case 19740: //Blessing of Might
                    sOverride = new SpellOverride(OverrideCode.PartyBuff);
                    sOverride.AlternateIDs.AddRange(new[] { 79101, 79102 });
                    return sOverride;
                case 20217: //Blessing of Kings
                    sOverride = new SpellOverride(OverrideCode.PartyBuff);
                    sOverride.AlternateIDs.AddRange(new[] { 79062, 79063 });
                    return sOverride;
            }

            return null;
        }

        SpellOverride(OverrideCode Code) {
            this.Code = Code;
        }

        public readonly OverrideCode Code;
        public readonly List<int> AlternateIDs = new List<int>();
    }
}
