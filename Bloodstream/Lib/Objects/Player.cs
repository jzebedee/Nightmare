using Bloodstream.Interfaces;

namespace Bloodstream.Lib
{
    public partial class Player : Unit, IPlayer
    {
        internal Player(uint addr) : base(addr) { }

        public bool IsGhost
        {
            get
            {
                return HealthPoints == 1;
            }
        }
        public override bool IsAlive
        {
            get
            {
                return HealthPoints > 1;
            }
        }

        public uint Money
        {
            get
            {
                return FIELD_COINAGE;
            }
        }
    }
}