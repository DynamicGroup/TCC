using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_LogicalDiskDAO
    {
        public static List<Win32_LogicalDisk> getWin32_LogicalDisk(Win32_DiskPartition win32_DiskPartition)
        {
            string associators = "Associators Of {{Win32_DiskPartition.DeviceID=\"{0}\"}} WHERE AssocClass=Win32_LogicalDiskToPartition";

            List<Win32_LogicalDisk> win32_LogicalDisk = new List<Win32_LogicalDisk>();
            try
            {
                win32_LogicalDisk = WmiHelper.WmiSnapshot<Win32_LogicalDisk>(string.Format(associators, win32_DiskPartition.DeviceID.Replace("\\", "\\\\"))).ToList();

                return win32_LogicalDisk;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_LogicalDisk;
            }
        }
    }
}
