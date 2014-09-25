using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_DiskPartitionDAO
    {
        public static List<Win32_DiskPartition> getWin32_DiskPartition(Win32_DiskDrive win32_DiskDrive)
        {
            string associators = "Associators Of {{Win32_DiskDrive.DeviceID=\"{0}\"}} WHERE AssocClass=Win32_DiskDriveToDiskPartition";

            List<Win32_DiskPartition> win32_DiskPartition = new List<Win32_DiskPartition>();
            try
            {
                win32_DiskPartition = WmiHelper.WmiSnapshot<Win32_DiskPartition>(string.Format(associators, win32_DiskDrive.DeviceID.Replace("\\", "\\\\"))).ToList();

                for (int i = 0; i < win32_DiskPartition.Count; i++)
                {
                    win32_DiskPartition[i].LogicalDisk = Win32_LogicalDiskDAO.getWin32_LogicalDisk(win32_DiskPartition[i]);
                }

                return win32_DiskPartition;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_DiskPartition;
            }
        }
    }
}
