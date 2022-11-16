using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpDX.DXGI;

namespace SensModify
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }

    [Flags]
    enum DisplayDeviceStateFlags : int
    {
        /// <summary>The device is part of the desktop.</summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>The device is part of the desktop.</summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>The device is removable; it cannot be the primary display.</summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DEVMODE
    {
        // You can define the following constant
        // but OUTSIDE the structure because you know
        // that size and layout of the structure
        // is very important
        // CCHDEVICENAME = 32 = 0x50
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmDeviceName;
        // In addition you can define the last character array
        // as following:
        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        //public Char[] dmDeviceName;

        // After the 32-bytes array
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmSpecVersion;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverVersion;

        [MarshalAs(UnmanagedType.U2)]
        public short dmSize;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmDriverExtra;

        [MarshalAs(UnmanagedType.U4)]
        public uint dmFields;

        public POINTL dmPosition;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayOrientation;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFixedOutput;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmColor;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmDuplex;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmYResolution;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmTTOption;

        [MarshalAs(UnmanagedType.I2)]
        public Int16 dmCollate;

        // CCHDEVICENAME = 32 = 0x50
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string dmFormName;
        // Also can be defined as
        //[MarshalAs(UnmanagedType.ByValArray,
        //    SizeConst = 32, ArraySubType = UnmanagedType.U1)]
        //public Byte[] dmFormName;

        [MarshalAs(UnmanagedType.U2)]
        public UInt16 dmLogPixels;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmBitsPerPel;

        [MarshalAs(UnmanagedType.U4)]
        public int dmPelsWidth;

        [MarshalAs(UnmanagedType.U4)]
        public int dmPelsHeight;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDisplayFlags;

        [MarshalAs(UnmanagedType.U4)]
        public int dmDisplayFrequency;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMMethod;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmICMIntent;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmMediaType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmDitherType;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved1;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmReserved2;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningWidth;

        [MarshalAs(UnmanagedType.U4)]
        public UInt32 dmPanningHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINTL
    {
        [MarshalAs(UnmanagedType.I4)]
        public int x;
        [MarshalAs(UnmanagedType.I4)]
        public int y;
    }

   // internal enum DMDUP : short;

    /// <summary>
    /// Selects duplex or double-sided printing for printers capable of duplex printing.
    /// </summary>
    enum DM : uint
    {
        /// <summary>
        /// Unknown setting.
        /// </summary>
        DMDUP_UNKNOWN = 0,

        /// <summary>
        /// Normal (nonduplex) printing.
        /// </summary>
        DMDUP_SIMPLEX = 1,

        /// <summary>
        /// Long-edge binding, that is, the long edge of the page is vertical.
        /// </summary>
        DMDUP_VERTICAL = 2,

        /// <summary>
        /// Short-edge binding, that is, the long edge of the page is horizontal.
        /// </summary>
        DMDUP_HORIZONTAL = 3,

        Orientation = 0x1,
        PaperSize = 0x2,
        PaperLength = 0x4,
        PaperWidth = 0x8,
        Scale = 0x10,
        Position = 0x20,
        NUP = 0x40,
        DisplayOrientation = 0x80,
        Copies = 0x100,
        DefaultSource = 0x200,
        PrintQuality = 0x400,
        Color = 0x800,
        Duplex = 0x1000,
        YResolution = 0x2000,
        TTOption = 0x4000,
        Collate = 0x8000,
        FormName = 0x10000,
        LogPixels = 0x20000,
        BitsPerPixel = 0x40000,
        PelsWidth = 0x80000,
        PelsHeight = 0x100000,
        DisplayFlags = 0x200000,
        DisplayFrequency = 0x400000,
        ICMMethod = 0x800000,
        ICMIntent = 0x1000000,
        MeduaType = 0x2000000,
        DitherType = 0x4000000,
        PanningWidth = 0x8000000,
        PanningHeight = 0x10000000,
        DisplayFixedOutput = 0x20000000
    }

    /// <summary>
    /// Specifies whether collation should be used when printing multiple copies.
    /// </summary>
    enum DMCOLLATE : short
    {
        /// <summary>
        /// Do not collate when printing multiple copies.
        /// </summary>
        DMCOLLATE_FALSE = 0,

        /// <summary>
        /// Collate when printing multiple copies.
        /// </summary>
        DMCOLLATE_TRUE = 1
    }

    /// <summary>
    /// Switches between color and monochrome on color printers.
    /// </summary>
    enum DMCOLOR : short
    {
        DMCOLOR_UNKNOWN = 0,
        DMCOLOR_MONOCHROME = 1,
        DMCOLOR_COLOR = 2
    }

    enum DISP_CHANGE : int
    {
        Successful = 0,
        Restart = 1,
        Failed = -1,
        BadMode = -2,
        NotUpdated = -3,
        BadFlags = -4,
        BadParam = -5,
        BadDualView = -6
    }

    [Flags()]
    public enum ChangeDisplaySettingsFlags : uint
    {
        CDS_NONE = 0,
        CDS_UPDATEREGISTRY = 0x00000001,
        CDS_TEST = 0x00000002,
        CDS_FULLSCREEN = 0x00000004,
        CDS_GLOBAL = 0x00000008,
        CDS_SET_PRIMARY = 0x00000010,
        CDS_VIDEOPARAMETERS = 0x00000020,
        CDS_ENABLE_UNSAFE_MODES = 0x00000100,
        CDS_DISABLE_UNSAFE_MODES = 0x00000200,
        CDS_RESET = 0x40000000,
        CDS_RESET_EX = 0x20000000,
        CDS_NORESET = 0x10000000
    }

    class DisplaySettings
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool EnumDisplayDevices(string lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DEVMODE devMode, uint flags);

        [DllImport("user32.dll")]
        static extern DISP_CHANGE ChangeDisplaySettingsEx(string lpszDeviceName, ref DEVMODE lpDevMode, IntPtr hwnd, ChangeDisplaySettingsFlags dwflags, IntPtr lParam);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern bool AllocConsole();

        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int CDS_UPDATEREGISTRY = 0x01;
        public const int CDS_TEST = 0x02;
        public const int DISP_CHANGE_SUCCESSFUL = 0;
        public const int DISP_CHANGE_RESTART = 1;
        public const int DISP_CHANGE_FAILED = -1;
        public const int DM_DISPLAYFREQUENCY = 0x00400000;

        public void PrintDisplays()
        {
            DISPLAY_DEVICE device = new DISPLAY_DEVICE();
            device.cb = Marshal.SizeOf(device);

            try
            {
                for (uint id = 0; EnumDisplayDevices(null, id, ref device, 0); id++)
                {
                    Console.WriteLine(
                        String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                 id,
                                 device.DeviceName,
                                 device.DeviceString,
                                 device.StateFlags,
                                 device.DeviceID,
                                 device.DeviceKey));
                    device.cb = Marshal.SizeOf(device);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DISPLAY_DEVICE GetPrimaryMonitor()
        {
            DISPLAY_DEVICE device = new DISPLAY_DEVICE();
            device.cb = Marshal.SizeOf(device);

            try
            {
                for (uint id = 0; EnumDisplayDevices(null, id, ref device, 0); id++)
                {
                    if (device.StateFlags.HasFlag(DisplayDeviceStateFlags.PrimaryDevice))
                    {
                        return device;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0}", ex.ToString()));
            }

            device.DeviceName = "ERROR";

            return device;
        }

        public void Alloc()
        {
            AllocConsole();
        }

        public DEVMODE GetDisplaySettings()
        {
            DEVMODE mode = new DEVMODE();

            if (EnumDisplaySettings(null, -1, ref mode))
            {
                return mode;
            }

            mode.dmDeviceName = "ERROR";

            return mode;
        }

        // https://www.codeproject.com/Articles/6810/Dynamic-Screen-Resolution
        public bool ChangeResolution(int width, int height, int freq, bool fullscreen = false)
        {
            bool bSuccess = false;

            DEVMODE mode = new DEVMODE();

            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref mode))
            {
                mode.dmPelsWidth = width;
                mode.dmPelsHeight = height;
                mode.dmDisplayFrequency = freq;
                mode.dmFields = (uint)(DM.PelsWidth | DM.PelsHeight | DM.DisplayFrequency);

                int iRet;

                if (fullscreen)
                    iRet = ChangeDisplaySettings(ref mode, (uint)(ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY | ChangeDisplaySettingsFlags.CDS_FULLSCREEN));
                else
                    iRet = ChangeDisplaySettings(ref mode, (uint)ChangeDisplaySettingsFlags.CDS_UPDATEREGISTRY);

                switch (iRet)
                {
                    case DISP_CHANGE_SUCCESSFUL:
                        bSuccess = true;
                        break;

                    case DISP_CHANGE_RESTART:
                        MessageBox.Show("Description: You Need To Reboot For The Change To Happen.\n If You Feel Any Problem After Rebooting Your Machine\nThen Try To Change Resolution In Safe Mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("Description: Failed To Change The Resolution.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Unable to process your request");
                MessageBox.Show("Description: Unable To Process Your Request. Sorry For This Inconvenience.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return bSuccess;
        }

        public void PopulateResolutions(ComboBox elem)
        {
            List<string> resolutions = new List<string>();

            Factory1 dxgiFactory = new Factory1();
            Adapter adapter = dxgiFactory.Adapters.First();
            Output output = adapter.Outputs.First();

            ModeDescription[] supported_modes = output.GetDisplayModeList(
                Format.B8G8R8A8_UNorm, 
                DisplayModeEnumerationFlags.Scaling
            );

            supported_modes = (from mode in supported_modes
                               where mode.Scaling == DisplayModeScaling.Unspecified
                               select mode).ToArray();

            foreach (var mode in supported_modes)
            {
                float refresh_rate = (float)mode.RefreshRate.Numerator / (float)mode.RefreshRate.Denominator;
                double fract = refresh_rate - (int)refresh_rate;

                int rate;

                if (fract < 0.5)
                {
                    rate = (int)Math.Floor(refresh_rate);
                }
                else if (fract > 0.5)
                {
                    rate = (int)Math.Ceiling(refresh_rate);
                }
                else
                {
                    rate = (int)refresh_rate;
                }

                resolutions.Add(String.Format("{0} x {1} @ {2}", mode.Width, mode.Height, rate));
            }

            DEVMODE current_mode = GetDisplaySettings();

            elem.DataSource = resolutions;
            elem.SelectedIndex = elem.Items.IndexOf(String.Format("{0} x {1} @ {2}", current_mode.dmPelsWidth, current_mode.dmPelsHeight, current_mode.dmDisplayFrequency));
        }
    }
}
