using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using Bloodstream.Interfaces;
using Bloodstream.Patchables;

namespace Bloodstream.Lib
{
    public class WorldLocation : Location, IWorldLocation
    {
        [XmlAttribute]
        public virtual WoWMap Map { get; set; }

        public WorldLocation(float X, float Y, float Z, WoWMap Map)
            : base(X, Y, Z)
        {
            this.Map = Map;
        }
        public WorldLocation(double X, double Y, double Z, WoWMap Map)
            : base(X, Y, Z)
        {
            this.Map = Map;
        }
        public WorldLocation(ILocation loc, WoWMap Map)
            : base(loc)
        {
            this.Map = Map;
        }

        public override int GetHashCode()
        {
            int hash = 31;

            hash = (hash * 19) + base.GetHashCode();
            hash = (hash * 19) + Map.GetHashCode();

            return hash;
        }
        public override bool Equals(object obj)
        {
            return obj is IWorldLocation && Equals((IWorldLocation)obj);
        }

        public bool Equals(IWorldLocation other)
        {
            return base.Equals(other) && other.Map == Map;
        }

        static Regex locationRegex = new Regex(@"((.+?)?)\((.+?) (.+?) (.+?)\)", RegexOptions.Compiled);
        public static IWorldLocation ParseSingle(string locationString)
        {
            var locations = Parse(locationString);

            if (locations.Count > 0)
                return locations[0];
            return null;
        }
        public static List<IWorldLocation> Parse(string locationsString)
        {
            var Locations = locationRegex.Matches(locationsString).Cast<Match>().Select(m =>
                new WorldLocation(
                   float.Parse(m.Groups[3].Value),
                   float.Parse(m.Groups[4].Value),
                   float.Parse(m.Groups[5].Value),
                   (WoWMap)Enum.Parse(typeof(WoWMap), m.Groups[1].Value)
               )).ToList<IWorldLocation>();

            return Locations;
        }
    }
}