using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PhysicalMediaDAO
    {
        public static bool getWin32_PhysicalMedia(Win32_ComputerSystem win32_ComputerSystem)
        {
            string associators = "Associators Of {Win32_DiskDrive.DeviceID=\"\\\\\\\\.\\\\PHYSICALDRIVE0\"} WHERE AssocClass=Win32_DiskDrivePhysicalMedia";

            try
            {
                List<Win32_PhysicalMedia> win32_PhysicalMedia = WmiHelper.WmiSnapshot<Win32_PhysicalMedia>(associators).ToList();

                if (win32_PhysicalMedia.Count == 0) { throw new Exception("Não foi possivel obter o SerialNumber do HD"); }
                for (int i = 0; i < win32_PhysicalMedia.Count; i++)
                {
                    if (!win32_PhysicalMedia[i].SerialNumber.Trim().Equals(String.Empty))
                        win32_ComputerSystem.SerialNumber_Win32_ComputerSystem = win32_PhysicalMedia[i].SerialNumber;
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }
    }
}
