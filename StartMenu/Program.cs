using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StartMenu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ShowStartMenu();
            Application.Exit();
        }
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);
        private const byte UP = 2;
        private const byte CTRL = 17;
        private const byte ESC = 27;
        private static void ShowStartMenu()
        {
            // key down event:
            const byte keyControl = 0x11;
            const byte keyEscape = 0x1B;
            keybd_event(keyControl, 0, 0,UIntPtr.Zero);
            keybd_event(keyEscape, 0, 0, UIntPtr.Zero);

            // key up event:
            const uint KEYEVENTF_KEYUP = 0x02;
            keybd_event(keyControl, 0, KEYEVENTF_KEYUP,UIntPtr.Zero);
            keybd_event(keyEscape, 0, KEYEVENTF_KEYUP,UIntPtr.Zero);
        }
    }
}
