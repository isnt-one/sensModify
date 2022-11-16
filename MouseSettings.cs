using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SensModify
{
    class MouseSettings
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref uint pvParam, SPIF fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, uint pvParam, SPIF fWinIni);

        [Flags]
        private enum SPIF
        {
            None = 0x00,
            SPIF_UPDATEINIFILE = 0x01,
            SPIF_SENDCHANGE = 0x02,
            SPIF_SENDWININICHANGE = 0x02
        }

        [Flags]
        private enum SPI {
            GETMOUSESPEED = 0x0070,
            SETMOUSESPEED = 0x0071
        };

        public void GetMouseSensitivity(out int speed)
        {
            uint temp = 0;
            SystemParametersInfo(SPI.GETMOUSESPEED, 0, ref temp, 0);
            speed = Convert.ToInt32(temp);
        }

        public void SetMouseSensitivity(int val)
        {
            SystemParametersInfo(SPI.SETMOUSESPEED, 0, Convert.ToUInt32(val), SPIF.SPIF_UPDATEINIFILE | SPIF.SPIF_SENDCHANGE | SPIF.SPIF_SENDWININICHANGE);
        }
    }
}
