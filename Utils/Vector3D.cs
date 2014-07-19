using System.Runtime.InteropServices;

namespace Utils
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3D
    {
        public Vector3D(float X, float Y, float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public float X, Y, Z;
    }
}