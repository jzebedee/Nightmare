using Bloodstream.Patchables;

namespace Bloodstream.Lib.Spells
{
    public class Mount
    {
        public Mount(int ID)
        {
            spellID = (uint)ID;
        }

        readonly uint spellID;
        public Spell Spell
        {
            get
            {
                return Spells.Spell.Get(spellID);
            }
        }

        public MountType Type
        {
            get
            {
                return (MountType)Spell.SpellEffects[0].MiscValueB;
            }
        }

        public bool Flight
        {
            get
            {
                switch (Type)
                {
                    case MountType.Flight:
                    case MountType.ProfessionMount:
                    case MountType.Scaling:
                    case MountType.TransformFlight:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public bool Aquatic
        {
            get
            {
                switch (Type)
                {
                    case MountType.Aquatic:
                    case MountType.AquaticVashjir:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}