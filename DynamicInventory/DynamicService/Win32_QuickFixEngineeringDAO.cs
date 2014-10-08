using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_QuickFixEngineeringDAO
    {
        public static List<Win32_QuickFixEngineering> getWin32_QuickFixEngineering(Win32_OperatingSystem win32_OperatingSystem)
        {
            List<Win32_QuickFixEngineering> win32_QuickFixEngineering = new List<Win32_QuickFixEngineering>();
            try
            {
                win32_QuickFixEngineering = WmiHelper.WmiSnapshot<Win32_QuickFixEngineering>().ToList();
                for (int i = 0; i < win32_QuickFixEngineering.Count; i++)
                {
                    win32_QuickFixEngineering[i].SerialNumber = win32_OperatingSystem.SerialNumber;
                    win32_QuickFixEngineering[i].SerialNumber_Win32_ComputerSystem = win32_OperatingSystem.SerialNumber_Win32_ComputerSystem;
                }
                return win32_QuickFixEngineering;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_QuickFixEngineering;
            }
        }

        public static bool setWin32_QuickFixEngineering(List<Win32_QuickFixEngineering> win32_QuickFixEngineering, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_QuickFixEngineering.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_QuickFixEngineering[i], conn, trans);
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
