using Bloodstream.Interfaces;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public class Pet : Unit, IPet
    {
        internal Pet(uint addr) : base(addr) { }

        public string BaseName
        {
            get
            {
                return Memory.Read<string>(Pointer + (int)UnitExtras.AlternateName, (uint)UnitExtras.AlternateNameOffset, 0);
            }
        }
    }
}