using System;
using System.Collections.Generic;
using System.Text;

// This is struct for converting to a DSConfig
namespace Donut.Structs
{
    public struct DonutConfig
    {
        public int Arch;
        public int Bypass;
        public string Domain;
        public string Class;
        public string Method;
        public string Args;
        public string InputFile;
        public string Runtime;
        public string Payload;
        public string URL;
    }
}
