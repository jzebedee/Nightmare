using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Bloodstream.Lib.Injection
{
    [SuppressUnmanagedCodeSecurity]
    public static class Invokes
    {
        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        [DllImport("kernel32", SetLastError = true)]
        internal static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32", SetLastError = true)]
        public static extern bool VirtualProtect(IntPtr lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);
        [DllImport("kernel32", SetLastError = true)]
        public static extern uint VirtualAllocEx(IntPtr hProcess, IntPtr dwAddress, int nSize, uint dwAllocationType, uint dwProtect);
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr dwAddress, int nSize, uint dwFreeType);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public static unsafe IntPtr GetD3DDevicePointer(IntPtr d3dBase)
        {
            for (int i = 0; i < 0x128000; i++)
            {
                IntPtr Base = d3dBase + i;
                if ((*(byte*)(Base + 0x00)) == 0xC7
                  && (*(byte*)(Base + 0x01)) == 0x06
                  && (*(byte*)(Base + 0x06)) == 0x89
                  && (*(byte*)(Base + 0x07)) == 0x86
                  && (*(byte*)(Base + 0x0C)) == 0x89
                  && (*(byte*)(Base + 0x0D)) == 0x86)
                    return Base + 2;
            }

            return IntPtr.Zero;
        }
    }
}