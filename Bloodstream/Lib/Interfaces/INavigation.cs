using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Bloodstream.Interfaces
{
    [Obfuscation]
    public interface INavigation : IDisposable
    {
        string Continent { get; set; }

        List<ILocation> GeneratePath(ILocation from, ILocation to, float tolerance = 5.0F, CancellationToken token = new CancellationToken(), int timeout = 15000);

        bool IsUnderwater(ILocation loc);
        float GetZ(float X, float Y);
        bool IsInWaterOrInAir(ILocation location);
        void BlackList(ILocation from, ILocation to);
        bool Initialize();
    }
}