using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensModify
{
    class Mouse
    {
        public bool Enabled { get; set; }
        public int Sensitivity { get; set; }
    }

    class Display
    {
        public bool Enabled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Frequency { get; set; }
    }

    class JsonSettings
    {
        public string Program { get; set; }
        public Mouse mouse { get; set; }
        public Display display { get; set; }
    }
}
