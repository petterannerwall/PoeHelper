using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using Core;
using ExileHelper.Models;

namespace ExileHelper
{
    public class HotkeyManager
    {
        private InputSender _inputSender;
        private Window _window;
        public delegate void HotkeyEventHandler(object sender, HotkeyPressedEventArgs args);
        public static HotkeyEventHandler HotkeyPressed;

        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
        [In] IntPtr hWnd,
        [In] int id,
        [In] uint fsModifiers,
        [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        private HwndSource _source;
        private const int F1HotkeyId = 9000;
        private const int F2HotkeyId = 9001;
        private const int F3HotkeyId = 9002;
        private const int F4HotkeyId = 9003;

        public HotkeyManager(Window window)
        {
            _inputSender = new InputSender();
            _window = window;
        }


        public void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(_window);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            const uint VK_F1 = 0x70;
            const uint VK_F2 = 0x71;
            const uint VK_F3 = 0x72;
            const uint VK_F4 = 0x73;
            const int NOMOD = 0x0000;
            if (!RegisterHotKey(helper.Handle, F1HotkeyId, NOMOD, VK_F1))
            {
                // handle error
            }
            else
            {
                RegisterHotKey(helper.Handle, F2HotkeyId, NOMOD, VK_F2);
                RegisterHotKey(helper.Handle, F3HotkeyId, NOMOD, VK_F3);
                RegisterHotKey(helper.Handle, F4HotkeyId, NOMOD, VK_F4);
            }
        }

        public void UnregisterHotKey()
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            var helper = new WindowInteropHelper(_window);
            UnregisterHotKey(helper.Handle, F1HotkeyId);
            UnregisterHotKey(helper.Handle, F2HotkeyId);
            UnregisterHotKey(helper.Handle, F3HotkeyId);
            UnregisterHotKey(helper.Handle, F4HotkeyId);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case F1HotkeyId:
                            OnHotKeyPressed(F1HotkeyId);
                            handled = true;
                            break;
                        case F2HotkeyId:
                            OnHotKeyPressed(F2HotkeyId);
                            handled = true;
                            break;
                        case F3HotkeyId:
                            OnHotKeyPressed(F3HotkeyId);
                            handled = true;
                            break;
                        case F4HotkeyId:
                            OnHotKeyPressed(F4HotkeyId);
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        private void OnHotKeyPressed(int hotkey_id)
        {
            switch (hotkey_id)
            {
                case 9000:
                    HotkeyPressed(null, new HotkeyPressedEventArgs("F1"));
                    _inputSender.SendCommand("/hideout");
                    break;
                case 9001:
                    HotkeyPressed(null, new HotkeyPressedEventArgs("F2"));
                    _inputSender.SendCommand("/remaining");
                    break;
                case 9002:
                    HotkeyPressed(null, new HotkeyPressedEventArgs("F3"));
                    break;
                case 9003:
                    HotkeyPressed(null, new HotkeyPressedEventArgs("F4"));
                    break;
            }

            
        }
    }
}
