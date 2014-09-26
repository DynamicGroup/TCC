using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PhysicalMediaDAO
    {
        public static List<Win32_PhysicalMedia> getWin32_PhysicalMedia(Win32_DiskDrive win32_DiskDrive)
        {
            string associators = "Associators Of {{Win32_DiskDrive.DeviceID=\"{0}\"}} WHERE ResultClass=Win32_PhysicalMedia";

            List<Win32_PhysicalMedia> win32_PhysicalMedia = new List<Win32_PhysicalMedia>();
            try
            {
                win32_PhysicalMedia = WmiHelper.WmiSnapshot<Win32_PhysicalMedia>(string.Format(associators, win32_DiskDrive.DeviceID.Replace("\\", "\\\\"))).ToList();
                for (int i = 0; i < win32_PhysicalMedia.Count; i++)
                {
                    Singleton.Instance.SerialNumber = win32_PhysicalMedia[i].SerialNumber;
                }

                return win32_PhysicalMedia;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_PhysicalMedia;
            }
        }
    }
}
