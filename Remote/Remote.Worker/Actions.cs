using System;
using System.Runtime.InteropServices;

namespace Remote.Worker
{
    public class Actions
    {
        [DllImport("Powrprof.dll", SetLastError = true)]
        static extern uint SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr hWnd,
            UInt32 msg,
            IntPtr wParam,
            IntPtr lParam
        );

        /// <summary>
        /// Attempts to put the computer into sleep mode.
        /// </summary>
        public void Sleep()
        {
            SetSuspendState(false, false, false);
        }

        /// <summary>
        /// Attempts to set the computer into hibernation mode.
        /// </summary>
        public void Hibernate()
        {
            SetSuspendState(true, false, false);
        }

        /// <summary>
        /// Turns the screens off.
        /// </summary>
        public void ScreensOff()
        {
            SendMessage(
                (IntPtr)0xffff, // HWND_BROADCAST
                0x0112,         // WM_SYSCOMMAND
                (IntPtr)0xf170, // SC_MONITORPOWER
                (IntPtr)0x0002  // POWER_OFF
            );
        }
    }
}