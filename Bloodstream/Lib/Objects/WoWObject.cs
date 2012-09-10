using Bloodstream.Interfaces;
using Bloodstream.Lib.Memory;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public partial class WowObject : IWowObject
    {
        public uint Pointer { get; private set; }

        protected readonly uint Descriptor;
        protected IMemoryProvider Memory { get { return MemoryProvider.Instance; } }

        protected WowBase Wow { get { return WowBase.Instance; } }

        internal WowObject(uint addr)
        {
            Pointer = addr;
            Descriptor = ReaderHelper.GetObjectDescriptors(Pointer);

            GUID = ReaderHelper.GetObjectGUID(Pointer);
            ID = Entry;
            Type = ReaderHelper.GetObjectType(Pointer);

            Valid = true;
        }
        internal void Invalidate()
        {
            //Objects are removed from the object manager before they are finalized.
            //This allows us some leeway between checking for validity and calling
            //members that would still give expected results, even though the object
            //had been invalidated by the refresher since the original validity check
            Valid = false;
        }

        public bool Valid { get; private set; }

        #region Init'd properties
        public uint ID { get; private set; }
        public WoWObjectType Type { get; private set; }
        public ulong GUID { get; private set; }
        #endregion

        public virtual string Name
        {
            get
            {
                return Wow.Bridge.GetObjectNameFromGuid(GUID);
            }
        }

        public virtual WoWMap Map
        {
            get
            {
                return (WoWMap)Wow.Bridge.GetMapID();
            }
        }

        public virtual IWorldLocation Location
        {
            get
            {
                return new WorldLocation(RawPosition.X, RawPosition.Y, RawPosition.Z, Map);
            }
        }

        public double DistanceToSelf
        {
            get
            {
                return Location.GetDistanceTo(Wow.Me.Location);
            }
        }

        public void Target()
        {
            Wow.Bridge.Target(GUID);
        }

        public void Interact()
        {
            Wow.Bridge.Interact(Pointer);
        }

        public override bool Equals(object obj)
        {
            var o = obj as WowObject;
            return o.Valid() ? o.GUID == GUID : false;
        }

        public override string ToString()
        {
            return (Valid ? "" : "[Invalid]") + Name;
        }

        private const float _LOS_Z = 2.5f;
        public bool HasLineOfSight(IWowObject target)
        {
            return HasLineOfSight(target.Location);
        }
        public bool HasLineOfSight(ILocation target)
        {
            Location
                modTarget = new Location(target),
                modMe = new Location(Wow.Me.Location);

            ILocation IntersectResult;

            float Completed;

            modTarget.Z += _LOS_Z;
            modMe.Z += _LOS_Z;

            return !Wow.Bridge.Traceline(modMe, modTarget, out IntersectResult, out Completed, WorldHitFlags.HitTestLOS);
        }
    }
}