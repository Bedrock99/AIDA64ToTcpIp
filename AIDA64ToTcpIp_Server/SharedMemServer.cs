#region Using...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

#endregion

namespace AIDA64ToTcpIp_Server
{
    class SharedMemSaver
    {
        #region Win32 API stuff

        public const int FILE_MAP_READ = 0x0004;

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr OpenFileMapping(int dwDesiredAccess,
            bool bInheritHandle, StringBuilder lpName);

        [DllImport("Kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr MapViewOfFile(IntPtr hFileMapping,
            int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow,
            int dwNumberOfBytesToMap);

        [DllImport("Kernel32.dll")]
        internal static extern bool UnmapViewOfFile(IntPtr map);

        [DllImport("kernel32.dll")]
        internal static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        internal static extern int GetLastError();

        #endregion

        private bool fileOpen = false;
        private IntPtr map;
        private IntPtr handle;

        ~SharedMemSaver()
        {
            CloseView();
        }

        public bool OpenView(string name_)
        {
            if (!fileOpen)
            {
                StringBuilder sharedMemFile = new StringBuilder(name_);
                handle = OpenFileMapping(FILE_MAP_READ, false, sharedMemFile);
                if (handle == IntPtr.Zero)
                {
                    return false;
                }
                map = MapViewOfFile(handle, FILE_MAP_READ, 0, 0, 0);
                if (map == IntPtr.Zero)
                {
                    return false;
                }
                fileOpen = true;
            }
            return fileOpen;
        }

        public void CloseView()
        {
            if (fileOpen)
            {
                UnmapViewOfFile(map);
                CloseHandle(handle);
            }
        }

        public string GetData()
        {
            if (fileOpen)
            {
                string data = (string)Marshal.PtrToStringAnsi(map);
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}