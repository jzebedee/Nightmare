using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bloodstream.Interfaces;
using Utils;

namespace Bloodstream.Lib.Navigation
{
    public class WaypointGraph
    {
        public static readonly WaypointGraph Instance = new WaypointGraph();

        private WaypointGraph()
        {
            Applied = false;
        }

        public bool Applied { get; private set; }

        public void Start()
        {
            if (!Applied)
            {
                WowBase.Instance.OnRefresh += GraphingPulse;
                Applied = true;
            }
        }
        public void Stop()
        {
            if (Applied)
            {
                WowBase.Instance.OnRefresh -= GraphingPulse;
                Applied = false;
            }
        }

        public void Test()
        {
            Task.Factory.StartNew(() => Lib.Movement.Mover.Instance.FollowPath(FindPath(WowBase.Instance.Me.Location, Graph.First())));
        }

        List<ILocation> FindPath(ILocation Start, ILocation End)
        {
            var Path = new List<ILocation>() { Start };

            if (!(IsConnected(Start) && IsConnected(End)))
                throw new ArgumentException("Start or End location was not connected to the graph");

            Log.Full("Building path from {0} to {1}", Start, End);
            var PQ = new PriorityQueue<double, ILocation>(Graph.Count);
            while (!Path.Contains(End))
            {
                PQ.Clear();
                foreach (var spot in Graph)
                    PQ.Enqueue(spot.GetDistanceTo(End), spot);

                while (!PQ.IsEmpty)
                {
                    var loc = PQ.DequeueValue();
                    var last = Path.LastOrDefault(l => !l.Equals(loc));
                    if (last != null && QuickTrace(loc, last))
                        continue;

                    Path.Add(loc);
                    Log.Full("Added {0}, {1}yds remaining", loc, loc.GetDistanceTo(End));
                }

                Log.Full("Path failed as incomplete");
                break;
            }

            return Path;
        }

        LinkedList<ILocation> Graph = new LinkedList<ILocation>();
        void GraphingPulse()
        {
            var Pos = WowBase.Instance.Me.Location;
            if (Graph.LastOrDefault(n => !QuickTrace(n, Pos) && Pos.GetDistanceTo(n) <= 30) == null)
            {
                Graph.AddLast(Pos);
                Utils.Log.Full("Graphed {0}", Pos);
            }
        }

        bool IsConnected(ILocation Pos)
        {
            return Graph.LastOrDefault(n => !QuickTrace(n, Pos)) != null;
        }

        bool QuickTrace(ILocation A, ILocation B)
        {
            ILocation sect_result;
            float sect_dist;
            return WowBase.Instance.Bridge.Traceline(A, B, out sect_result, out sect_dist, Patchables.WorldHitFlags.HitTestGroundAndStructures);
        }
    }
}