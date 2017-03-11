using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormHelper
{
    public static class WindowHelper
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);
        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hwnd);
        public static void SetFocusToPathOfExileWindow()
        {
            string processName = "PathOfExile_x64.exe";
            //get the process
            Process process = new Process();
            var sixtyFourProcess = Process.GetProcessesByName("PathOfExile_x64");
            var steamProcess = Process.GetProcessesByName("PathOfExileSteam");

            if (sixtyFourProcess.Length > 0)
                process = sixtyFourProcess[0];
            if (steamProcess.Length > 0)
                process = steamProcess[0];

            if (process != null)
            {
                //get the  hWnd of the process
                IntPtr hwnd = process.MainWindowHandle;
                if (hwnd == IntPtr.Zero)
                {
                    //the window is hidden so try to restore it before setting focus.
                    ShowWindow(process.Handle, ShowWindowEnum.Restore);
                }
                //set user the focus to the window
                SetForegroundWindow(process.MainWindowHandle);
            }
        }
    }
}
