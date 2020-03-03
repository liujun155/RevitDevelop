using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Common
{
    /// <summary>
    /// Revit状态栏
    /// </summary>
    public class RevitStatusBar
    {
        private IntPtr m_StatusBar = IntPtr.Zero;

        protected RevitStatusBar()
        {
            IntPtr mainWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
            if (mainWindowHandle != IntPtr.Zero)
            {
                this.m_StatusBar = FindWindowEx(mainWindowHandle, IntPtr.Zero, "msctls_statusbar32", "");
            }
        }

        public static RevitStatusBar Create()
        {
            return new RevitStatusBar();
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        /// 设置状态信息
        /// <summary>
        /// 设置状态信息
        /// </summary>
        /// <param name="msg"></param>
        public void Set(string msg)
        {
            try
            {
                if (this.m_StatusBar != IntPtr.Zero)
                {
                    SetWindowPos(this.m_StatusBar, 0, 0, 0, 0, 0, 0x37);
                    SetWindowText(this.m_StatusBar, msg);
                }
            }
            catch { }
        }
    }
}
