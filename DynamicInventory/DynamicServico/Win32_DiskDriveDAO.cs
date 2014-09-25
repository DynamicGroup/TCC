using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_DiskDriveDAO
    {
        public static List<Win32_DiskDrive> getWin32_DiskDrive()
        {
            List<Win32_DiskDrive> win32_DiskDrive = new List<Win32_DiskDrive>();
            try
            {
                win32_DiskDrive = WmiHelper.WmiSnapshot<Win32_DiskDrive>().ToList();

                for (int i = 0; i < win32_DiskDrive.Count; i++)
                {
                    win32_DiskDrive[i].DiskPartition = Win32_DiskPartitionDAO.getWin32_DiskPartition(win32_DiskDrive[i]);
                }

                return win32_DiskDrive;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_DiskDrive;
            }
        }
    }
}
