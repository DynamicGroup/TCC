using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_BootConfigurationDAO
    {
        public static List<Win32_BootConfiguration> getWin32_BootConfiguration(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_BootConfiguration> win32_BootConfiguration = new List<Win32_BootConfiguration>();
            try
            {
                win32_BootConfiguration = WmiHelper.WmiSnapshot<Win32_BootConfiguration>().ToList();
                for (int i = 0; i < win32_BootConfiguration.Count; i++)
                {
                    win32_BootConfiguration[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_BootConfiguration;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BootConfiguration;
            }
        }

        public static bool setWin32_BootConfiguration(List<Win32_BootConfiguration> win32_BootConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_BootConfiguration.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_BootConfiguration[i], conn, trans);
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
