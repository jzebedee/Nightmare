using System;
using System.Runtime.InteropServices;

namespace Bloodstream.Lib.Injection
{
    internal static class Functions
    {
        static Functions()
        {
            System.Diagnostics.Debug.Assert(!AppDomain.CurrentDomain.IsDefaultAppDomain(), "Lib.Injection.Functions reached its ctor in a non-MeatHook appdomain!");
        }

        static T WrapFunction<T>(IntPtr p) where T : class
        {
            return Marshal.GetDelegateForFunctionPointer(p, typeof(T)) as T;
        }
    }
}