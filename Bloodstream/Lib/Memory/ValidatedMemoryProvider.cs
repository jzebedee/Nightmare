using System.Diagnostics;
using Bloodstream.Interfaces;

namespace Bloodstream.Lib.Memory
{
    public class ValidatedMemoryProvider : IMemoryProvider
    {
        private IMemoryProvider baseProvider;
        private IValidatable baseObj;
        public ValidatedMemoryProvider(IValidatable baseObj, IMemoryProvider baseProvider)
        {
            this.baseObj = baseObj;
            this.baseProvider = baseProvider;
        }

        private void AssertValid()
        {
            Trace.Assert(baseObj.Valid, "Calling code did not check object validity before invoking a memory operation.");
        }

        public T Read<T>(params uint[] Addresses)
        {
            AssertValid();
            return baseProvider.Read<T>(Addresses);
        }

        public byte[] ReadBytes(uint Address, int Count)
        {
            AssertValid();
            return baseProvider.ReadBytes(Address, Count);
        }

        public bool Write<T>(uint Address, T Value)
        {
            AssertValid();
            return baseProvider.Write<T>(Address, Value);
        }

        public uint Allocate(int Size)
        {
            AssertValid();
            return baseProvider.Allocate(Size);
        }

        public bool Free(uint Address)
        {
            AssertValid();
            return baseProvider.Free(Address);
        }

        public TDest[] ConvertArray<TDest>(uint Address, int Count) where TDest : struct
        {
            AssertValid();
            return baseProvider.ConvertArray<TDest>(Address, Count);
        }
    }
}