using System;
using Bloodstream.Interfaces;
using Bloodstream.Patchables;

namespace Bloodstream.Lib.Spells
{
    public class Aura
    {
        public Aura(AuraEntry ae)
        {
            spellID = ae.auraID;
            Flags = (AuraFlags)ae.flags;
            Level = ae.level;
            Duration = TimeSpan.FromMilliseconds(ae.duration);
            Count = ae.count;
            creatorGUID = ae.creatorGUID;
            endTime = ae.endTime;
        }

        readonly uint spellID;
        public Spell Spell
        {
            get
            {
                return Spells.Spell.Get(spellID);
            }
        }

        public bool IsPositive { get { return Flags.HasFlag(AuraFlags.Positive); } }
        public bool IsNegative { get { return Flags.HasFlag(AuraFlags.Negative); } }

        public readonly byte ChargesLeft;
        public readonly byte Level;
        public readonly byte Count;
        public readonly TimeSpan Duration;
        public readonly AuraFlags Flags;

        uint endTime;
        public TimeSpan TimeLeft
        {
            get
            {
                return TimeSpan.FromMilliseconds(endTime - WowBase.Instance.Bridge.PerformanceCounter());
            }
        }

        ulong creatorGUID;
        public IUnit Caster
        {
            get
            {
                IUnit caster;
                WowBase.Instance.MapGUID(creatorGUID, out caster);

                return caster;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Spell.Name, Spell.ID);
        }
    }
}