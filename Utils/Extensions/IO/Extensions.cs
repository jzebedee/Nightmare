using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Utils.Extensions.IO
{
    public static class Extensions
    {
        public static string ReadCString(this BinaryReader reader)
        {
            var builder = new StringBuilder();

            char cur;
            while ((cur = reader.ReadChar()) != '\0') builder.Append(cur);

            return builder.ToString();
        }

        public static T ReadStruct<T>(this BinaryReader reader, int? Size = null) where T : struct
        {
            int structSize = Size ?? Marshal.SizeOf(typeof(T));
            byte[] readBytes = reader.ReadBytes(structSize);
            if (readBytes.Length != structSize)
                throw new ArgumentException("Size of bytes read did not match struct size");

            var pin_bytes = GCHandle.Alloc(readBytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(pin_bytes.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                pin_bytes.Free();
            }
        }
    }
}