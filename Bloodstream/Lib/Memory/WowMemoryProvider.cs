using System;
using Bloodstream.Interfaces;

namespace Bloodstream.Lib.Memory
{
    public class WowMemoryProvider : IMemoryProvider
    {
        private const string NotImplementedMessage = "Please use SMemory or a MemoryProvider to perform this function.";

        private static WowMemoryProvider _instance = null;
        private static object _instance_lock = new object();
        public static WowMemoryProvider Instance
        {
            get
            {
                lock (_instance_lock)
                {
                    if (_instance == null)
                        _instance = new WowMemoryProvider();

                    return _instance;
                }
            }
        }
        private WowMemoryProvider() : base() { }

        public uint Allocate(int Size)
        {
            throw new NotImplementedException(NotImplementedMessage);
        }
        public bool Free(uint Address)
        {
            throw new NotImplementedException(NotImplementedMessage);
        }

        public T Read<T>(params uint[] Addresses)
        {
            return WowMemory.Read<T>(Addresses);
        }
        public byte[] ReadBytes(uint Address, int Count)
        {
            return WowMemory.ReadBytes(Address, Count);
        }

        public bool Write<T>(uint Address, T Value)
        {
            return WowMemory.Write<T>(Address, Value);
        }

        public TDest[] ConvertArray<TDest>(uint Address, int Count) where TDest : struct
        {
            return WowMemory.ConvertArray<TDest>(Address, Count);
        }
    }
}