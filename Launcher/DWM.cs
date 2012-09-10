using System;
using System.Runtime.InteropServices;

namespace Launcher
{
    public static class DWM
    {
        [DllImport("user32.dll", EntryPoint = "GetWindowPlacement")]
        private static extern bool InternalGetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
        public static bool GetWindowPlacement(IntPtr hWnd, out WindowPlacement placement)
        {
            placement = new WindowPlacement();
            placement.Length = Marshal.SizeOf(typeof(WindowPlacement));
            return InternalGetWindowPlacement(hWnd, ref placement);
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, GetWindowCmd uCmd);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string classname, string title);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

        [DllImport("dwmapi.dll")]
        public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr source, out IntPtr hthumbnail);

        [DllImport("dwmapi.dll")]
        public static extern int DwmUnregisterThumbnail(IntPtr HThumbnail);

        [DllImport("dwmapi.dll")]
        public static extern int DwmUpdateThumbnailProperties(IntPtr HThumbnail, ref ThumbnailProperties props);

        [DllImport("dwmapi.dll")]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr HThumbnail, out Size size);

        public struct Point
        {
            public int x, y;
        }
        public struct Size
        {
            public int Width, Height;
        }

        public struct WindowPlacement
        {
            public int
                Length,
                Flags,
                ShowCmd;
            public Point
                MinPosition,
                MaxPosition;
            public Rect NormalPosition;
        }

        public struct ThumbnailProperties
        {
            public ThumbnailFlags Flags;
            public Rect
                Destination,
                Source;
            public Byte Opacity;
            public bool
                Visible,
                SourceClientAreaOnly;
        }

        public struct Rect
        {
            public Rect(int x, int y, int x1, int y1)
            {
                this.Left = x;
                this.Top = y;
                this.Right = x1;
                this.Bottom = y1;
            }
            public int Left, Top, Right, Bottom;
        }

        [Flags]
        public enum ThumbnailFlags : int
        {
            RectDetination = 1,
            RectSource = 2,
            Opacity = 4,
            Visible = 8,
            SourceClientAreaOnly = 16
        }

        public enum GetWindowCmd : uint
        {
            First = 0,
            Last = 1,
            Next = 2,
            Prev = 3,
            Owner = 4,
            Child = 5,
            EnabledPopup = 6
        }
    }
}