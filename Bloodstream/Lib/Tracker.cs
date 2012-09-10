using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Bloodstream.Interfaces;
using Utils;

namespace Bloodstream.Lib
{
    public class Tracker : IDisposable
    {
        ConcurrentDictionary<uint, HashSet<ILocation>> Tracked = new ConcurrentDictionary<uint, HashSet<ILocation>>();

        public Tracker()
        {
            WowBase.Instance.OnRefresh += Pulse;
        }
        ~Tracker()
        {
            Dispose(false);
        }

        public void Pulse()
        {
            var wow = WowBase.Instance;

            foreach (var GO in wow.GameObjects)
                if (Tracked.GetOrAdd(GO.ID, id => new HashSet<ILocation>()).Add(GO.Location))
                    Log.Instance("Tracker").Full("Logged {0} ({1}) at {2}", GO.Name, GO.ID, GO.Location);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
                WowBase.Instance.OnRefresh -= Pulse;
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}