using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class WindowHelper
    {
        private static int _tradeFormCount = 0;

        private const int SW_SHOWNOACTIVATE = 4;
        private const int HWND_TOPMOST = -1;
        private const uint SWP_NOACTIVATE = 0x0010;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
             int hWnd,             // Window handle
             int hWndInsertAfter,  // Placement-order handle
             int X,                // Horizontal position
             int Y,                // Vertical position
             int cx,               // Width
             int cy,               // Height
             uint uFlags);         // Window positioning flags


        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        //public static void ShowInactiveTopmost(Form form)
        //{
        //    _tradeFormCount++;
        //    form.Closed += form_Closed;

        //    Screen primaryScreen = Screen.PrimaryScreen;

        //    var left = (primaryScreen.WorkingArea.Right - form.Width) + (_tradeFormCount * -10);
        //    var top = (primaryScreen.WorkingArea.Bottom - form.Height) + (_tradeFormCount * -10) + 45;

        //    ShowWindow(form.Handle, SW_SHOWNOACTIVATE);
        //    SetWindowPos(form.Handle.ToInt32(), HWND_TOPMOST,
        //    left, top, form.Width, form.Height,
        //    SWP_NOACTIVATE);
        //}

        private static void form_Closed(object sender, EventArgs e)
        {
            _tradeFormCount--;
        }

        public static bool SetFocusToPathOfExileWindow()
        {
            Process process = new Process();
            var thirtyTwoProcess = Process.GetProcessesByName("PathOfExile");
            var sixtyFourProcess = Process.GetProcessesByName("PathOfExile_x64");
            var steamProcess = Process.GetProcessesByName("PathOfExileSteam");

            if (thirtyTwoProcess.Length > 0)
                process = thirtyTwoProcess[0];
            if (sixtyFourProcess.Length > 0)
                process = sixtyFourProcess[0];
            if (steamProcess.Length > 0)
                process = steamProcess[0];

            if (process != null && process.MainWindowHandle != null)
            {
                IntPtr hwnd = process.MainWindowHandle;
                if (hwnd == IntPtr.Zero)
                {
                    ShowWindow(process.Handle, ShowWindowEnum.Restore);
                }
                SetForegroundWindow(process.MainWindowHandle);
                return true;

            }

            return false;
        }
    }
}
