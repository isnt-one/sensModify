using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SensModify
{
    class GameWindows
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern int FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        public bool IsWindowOpen(string name)
        {
            return FindWindowByCaption(IntPtr.Zero, name) != 0;
        }
    }
}
