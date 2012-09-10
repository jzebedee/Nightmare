using System;
using System.Runtime.InteropServices;
using ADDR = System.UInt32;

namespace Bloodstream.Lib.Memory
{
    public static class WowMemory
    {
        public static readonly ADDR ModuleBase = (ADDR)System.Diagnostics.Process.GetCurrentProcess().MainModule.BaseAddress;

        public static T ReadSingle<T>(ADDR Address)
        {
            return SMemory.ReadSingle<T>(ModuleBase + Address);
        }

        public static T Read<T>(params ADDR[] Addresses)
        {
            Addresses[0] = ModuleBase + Addresses[0];
            return SMemory.Read<T>(Addresses);
        }

        public static byte[] ReadBytes(ADDR Address, int Count)
        {
            return SMemory.ReadBytes(ModuleBase + Address, Count);
        }

        public static bool Write<T>(ADDR Address, T value)
        {
            return SMemory.Write<T>(ModuleBase + Address, value);
        }

        public static TDest[] ConvertArray<TDest>(ADDR Address, int Count)
        {
            return SMemory.ConvertArray<TDest>(ModuleBase + Address, Count);
        }

        #region Extensions
        public static ADDR TargetAddress(this Delegate del)
        {
            return (ADDR)Marshal.GetFunctionPointerForDelegate(del);
        }

        public static IntPtr Rebase(this IntPtr ptr)
        {
            return IntPtr.Add(ptr, (int)WowMemory.ModuleBase);
        }

        /// <summary>
        /// Return a rebased pointer
        /// </summary>
        public static unsafe void* ToRebasedPointer(this Bloodstream.Patchables.Pointers ptr)
        {
            return IntPtr.Add((IntPtr)WowMemory.ModuleBase, (int)ptr).ToPointer();
        }
        #endregion
    }
}