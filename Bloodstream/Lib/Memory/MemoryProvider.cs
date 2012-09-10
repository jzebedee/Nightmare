using Bloodstream.Interfaces;

namespace Bloodstream.Lib.Memory
{
    public class MemoryProvider : IMemoryProvider
    {
        private static MemoryProvider _instance = null;
        private static object _instance_lock = new object();
        public static MemoryProvider Instance
        {
            get
            {
                lock (_instance_lock)
                {
                    if (_instance == null)
                        _instance = new MemoryProvider();

                    return _instance;
                }
            }
        }
        private MemoryProvider() { }

        public virtual T Read<T>(params uint[] Addresses)
        {
            return SMemory.Read<T>(Addresses);
        }

        public virtual byte[] ReadBytes(uint Address, int Count)
        {
            return SMemory.ReadBytes(Address, Count);
        }

        public virtual bool Write<T>(uint Address, T Value)
        {
            return SMemory.Write<T>(Address, Value);
        }

        public virtual uint Allocate(int Size)
        {
            return SMemory.Allocate(Size);
        }

        public virtual bool Free(uint Address)
        {
            return SMemory.Free(Address);
        }

        public virtual TDest[] ConvertArray<TDest>(uint Address, int Count) where TDest : struct
        {
            return SMemory.ConvertArray<TDest>(Address, Count);
        }
    }
}