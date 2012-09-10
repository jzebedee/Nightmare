using System;
using System.Linq;
using System.Runtime.InteropServices;
using Bloodstream.Lib.Injection;
using ADDR = System.UInt32;
using MemoryOperationFailedException = Utils.Memory.MemoryOperationFailedException;

namespace Bloodstream.Lib.Memory
{
    internal static class SMemory
    {
        internal static IntPtr ProcHandle { get; set; }

        static string GenerateAddressesString(params ADDR[] addresses)
        {
            return string.Join(", ", addresses.Select(a => "`0x" + a.ToString("X") + "`"));
        }

        public static uint Allocate(int size)
        {
            return Invokes.VirtualAllocEx(ProcHandle, IntPtr.Zero, size, 0x00001000, 0x40);
        }
        public static bool Free(ADDR addr)
        {
            return Invokes.VirtualFreeEx(ProcHandle, (IntPtr)addr, 0, 0x8000);
        }

        public static byte[] ReadBytes(ADDR Address, int Count)
        {
            byte[] retBytes = new byte[Count];

            int bytesRead;
            Invokes.ReadProcessMemory(ProcHandle, (IntPtr)Address, retBytes, Count, out bytesRead);
            if (bytesRead != Count)
                throw new MemoryOperationFailedException(string.Format("Read of `{0}` bytes from {1} failed", Count, GenerateAddressesString(Address)));
            return retBytes;
        }

        public static unsafe dynamic ReadSingle<T>(ADDR Address)
        {
            if (Address == 0)
                throw new ArgumentException("ReadSingle was called with a null address", "Address");

            try
            {
                switch (Type.GetTypeCode(typeof(T)))
                {
                    case TypeCode.Boolean:
                        return *(bool*)Address;
                    case TypeCode.Byte:
                        return *(byte*)Address;
                    case TypeCode.Char:
                        return *(char*)Address;
                    case TypeCode.DateTime:
                        return *(DateTime*)Address;
                    case TypeCode.Decimal:
                        return *(decimal*)Address;
                    case TypeCode.Double:
                        return *(double*)Address;
                    case TypeCode.Int16:
                        return *(short*)Address;
                    case TypeCode.Int32:
                        return *(int*)Address;
                    case TypeCode.Int64:
                        return *(long*)Address;
                    case TypeCode.SByte:
                        return *(sbyte*)Address;
                    case TypeCode.Single:
                        return *(float*)Address;
                    case TypeCode.String:
                        return Marshal.PtrToStringAnsi((IntPtr)Address);
                    case TypeCode.UInt16:
                        return *(ushort*)Address;
                    case TypeCode.UInt32:
                        return *(uint*)Address;
                    case TypeCode.UInt64:
                        return *(ulong*)Address;
                    case TypeCode.Object:
                    default:
                        return (T)Marshal.PtrToStructure((IntPtr)Address, typeof(T));
                }
            }
            catch (AccessViolationException ave)
            {
                throw new MemoryOperationFailedException(string.Format("Read of `{0}` from {1} failed", typeof(T), GenerateAddressesString(Address)), ave);
            }
        }
        public static T Read<T>(params ADDR[] addresses)
        {
            if (addresses == null || addresses.Length == 0)
                throw new ArgumentException("No valid addresses provided", "addresses");

            if (addresses.Length == 1)
                return ReadSingle<T>(addresses[0]);

            ADDR lastAddr = 0;
            for (int i = 0; i < addresses.Length; i++)
            {
                if (i == addresses.Length - 1)
                    return Read<T>(addresses[i] + lastAddr);
                lastAddr = Read<uint>(lastAddr + addresses[i]);
            }

            return default(T);
        }

        public static bool Write<T>(ADDR Address, T value)
        {
            var asType = typeof(T);

            try
            {
                if (asType == typeof(string))
                {
                    var strBytes = System.Text.Encoding.ASCII.GetBytes(value as string);
                    return Write<byte[]>(Address, strBytes);
                }
                else if (asType == typeof(byte[]))
                {
                    var bValue = value as byte[];
                    int written;
                    if (Invokes.WriteProcessMemory(ProcHandle, (IntPtr)Address, bValue, bValue.Length, out written))
                        return written == bValue.Length;
                }
                else
                {
                    Marshal.StructureToPtr(value, (IntPtr)Address, true);
                    return true;
                }
            }
            catch (AccessViolationException ave)
            {
                throw new MemoryOperationFailedException(string.Format("Write of `{0}` (of type `{1}`) to {2} failed", value, asType, GenerateAddressesString(Address)), ave);
            }

            return false;
        }

        public static TDest[] ConvertArray<TDest>(ADDR Addr, int Count)
        {
            var destTypeSize = Marshal.SizeOf(typeof(TDest));

            var destArray = new TDest[Count];
            for (int i = 0; i < Count; i++)
                destArray[i] = ReadSingle<TDest>(Addr + (ADDR)(destTypeSize * i));

            return destArray;
        }

        public static ADDR GetVFT(ADDR obj, uint func)
        {
            return Read<ADDR>(obj, func * 4);
        }
    }
}