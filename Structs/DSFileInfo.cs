using System;
using System.Runtime.InteropServices;

namespace Donut.Structs
{
    public struct DSFileInfo
    {
        public int fd;
        public UInt32 data;
        public UInt32 zdata;
        public UInt32 len;
        public UInt32 zlen;
        public byte map;
        public int type;
        public int arch;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_VER_LEN)]
        public char[] ver;
    }
}
