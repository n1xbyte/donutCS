using System;
using System.Runtime.InteropServices;

namespace Donut.Structs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DSModule
    {
        public int type;
        public int thread;
        public int compress;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME*2)]
        public byte[] runtime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME*2)]
        public byte[] domain;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME*2)]
        public byte[] cls;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME*2)]
        public byte[] method;
        public int param_cnt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public P[] p;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME)]
        public char[] sig;
        public UInt64 mac;
        public UInt64 len;
        public UInt64 zlen;
        public IntPtr data;  
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct P
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_NAME*2)]
        public byte[] param;
    }
}
