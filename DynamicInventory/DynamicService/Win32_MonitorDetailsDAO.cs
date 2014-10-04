using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_MonitorDetailsDAO
    {
        public static List<Win32_MonitorDetails> getWin32_MonitorDetails(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_MonitorDetails> win32_MonitorDetails = new List<Win32_MonitorDetails>();
            try
            {
                win32_MonitorDetails = WmiHelper.GetMonitorDetails().ToList();
                for (int i = 0; i < win32_MonitorDetails.Count; i++)
                {
                    win32_MonitorDetails[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_MonitorDetails;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_MonitorDetails;
            }
        }

        public static bool setWin32_MonitorDetails(List<Win32_MonitorDetails> win32_MonitorDetails, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_MonitorDetails.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_MonitorDetails[i], conn, trans);
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
