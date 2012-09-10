using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using Bloodstream.Interfaces;
using Utils;

namespace Bloodstream.Lib
{
    [Obfuscation]
    [XmlRoot]
    public class Location : ILocation
    {
        [XmlAttribute]
        public virtual float X { get; set; }
        [XmlAttribute]
        public virtual float Y { get; set; }
        [XmlAttribute]
        public virtual float Z { get; set; }

        public Location(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Location(double x, double y, double z) : this(Convert.ToSingle(x), Convert.ToSingle(y), Convert.ToSingle(z)) { }
        public Location(ILocation l) : this(l.X, l.Y, l.Z) { }
        public Location()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public static ILocation FromVector(dynamic vec)
        {
            return new Location(vec.X, vec.Y, vec.Z);
        }
        public T ToVector<T>()
        {
            dynamic vec;

            try
            {
                vec = Activator.CreateInstance(typeof(T), X, Y, Z);
            }
            catch
            {
                vec = default(T);
                if (vec != null)
                {
                    vec.X = X;
                    vec.Y = Y;
                    vec.Z = Z;
                }
            }

            return vec;
        }

        public virtual double GetDistanceTo(ILocation loc)
        {
            return Math.Sqrt(Math.Pow((X - loc.X), 2) + Math.Pow((Y - loc.Y), 2) + Math.Pow((Z - loc.Z), 2));
        }
        public virtual double GetDistanceToFlat(ILocation loc)
        {
            return Math.Sqrt(Math.Pow((X - loc.X), 2) + Math.Pow((Y - loc.Y), 2));
        }
        public virtual double FacingTo(ILocation loc)
        {
            return Helper.NegativeAngle(Math.Atan2((loc.Y - Y), (loc.X - X)));
        }

        public override string ToString()
        {
            return string.Format("({0} {1} {2})", X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            return obj is ILocation && Equals((ILocation)obj);
        }

        public override int GetHashCode()
        {
            int hash = 17;

            hash = (hash * 23) + X.GetHashCode();
            hash = (hash * 23) + Y.GetHashCode();
            hash = (hash * 23) + Z.GetHashCode();

            return hash;
        }

        public bool Equals(ILocation other)
        {
            return other != null && X == other.X && Y == other.Y && Z == other.Z;
        }
    }

    public static class LocationHelper
    {
        public static ILocation FindClosest(this List<ILocation> locations, ILocation target)
        {
            return locations.Aggregate((closest, current) => current.GetDistanceTo(target) < closest.GetDistanceTo(target) ? current : closest);
        }

        public static double GetPathDistance(this List<ILocation> path)
        {
            return path != null ? path.Sum((loc) =>
            {
                var next = path.ElementAtOrDefault(path.IndexOf(loc) + 1);
                return next != null ? loc.GetDistanceTo(next) : 0;
            }) : 0;
        }
    }
}