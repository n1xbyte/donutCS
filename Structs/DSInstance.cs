﻿using System;
using System.Runtime.InteropServices;

namespace Donut.Structs
{
    public struct DSInstance
    {
        public UInt32 len;
        public DSCrypt key;
        public UInt64 iv;
        public API api;
        public int api_cnt;
        public int dll_cnt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.DONUT_MAX_DLL)]
        public DLL[] d;
        public AMSI amsi;
        public int bypass;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] clr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] wldp;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wldpQuery;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wldpIsApproved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiInit;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiScanBuf;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] amsiScanStr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] wscript;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] wscript_exe;

        public Guid xIID_IUnknown;
        public Guid xIID_IDispatch;

        // GUID required to load .NET assemblies
        public Guid xCLSID_CLRMetaHost;
        public Guid xIID_ICLRMetaHost;
        public Guid xIID_ICLRRuntimeInfo;
        public Guid xCLSID_CorRuntimeHost;
        public Guid xIID_ICorRuntimeHost;
        public Guid xIID_AppDomain;

        // GUID required to run VBS and JS files
        public Guid xCLSID_ScriptLanguage;
        public Guid xIID_IHost;
        public Guid xIID_IActiveScript;
        public Guid xIID_IActiveScriptSite;
        public Guid xIID_IActiveScriptSiteWindow;
        public Guid xIID_IActiveScriptParse32;
        public Guid xIID_IActiveScriptParse64;

        // GUID required to run XSL files
        public Guid xCLSID_DOMDocument30;
        public Guid xIID_IXMLDOMDocument;
        public Guid xIID_IXMLDOMNode;

        public int type;

        public DSHttp http;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] sig;
        public UInt64 mac;
        public DSCrypt mod_key;
        public UInt64 mod_len;
        public MODULE module;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct API
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        [FieldOffset(0)] public UInt64[] hash;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        [FieldOffset(0)] public void*[] addr;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct DLL
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public char[] dll_name;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct MODULE
    {
        [FieldOffset(0)] public IntPtr x;
        [FieldOffset(0)] public IntPtr p;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct AMSI
    {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    [FieldOffset(0)] public char[] s;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    [FieldOffset(0)] public UInt32[] w;
    }
}
