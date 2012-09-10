using System.Collections.Generic;
using System.Linq;
using Bloodstream.Interfaces;

namespace Bloodstream.Lib
{
    public partial class Container : Item, IContainer
    {
        internal Container(uint addr) : base(addr) { }

        public List<IItem> Contained
        {
            get
            {
                return Wow.MapGUIDs<IItem>(SLOT_1).ToList();
            }
        }

        public int Slots
        {
            get
            {
                return Contained.Count;
            }
        }

        public int FreeSlots
        {
            get { return Contained.Sum(slot => slot.Invalid() ? 1 : 0); }
        }
    }
}