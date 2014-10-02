using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_CDROMDriveDAO
    {
        public static List<Win32_CDROMDrive> getWin32_CDROMDrive()
        {
            List<Win32_CDROMDrive> win32_CDROMDrive = new List<Win32_CDROMDrive>();
            try
            {
                win32_CDROMDrive = WmiHelper.WmiSnapshot<Win32_CDROMDrive>().ToList();

                return win32_CDROMDrive;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_CDROMDrive;
            }
        }
    }
}
