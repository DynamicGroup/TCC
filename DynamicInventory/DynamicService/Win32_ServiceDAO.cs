using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_ServiceDAO
    {
        public static List<Win32_Service> getWin32_Service(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_Service> win32_Service = new List<Win32_Service>();
            try
            {
                win32_Service = WmiHelper.WmiSnapshot<Win32_Service>().ToList();
                for (int i = 0; i < win32_Service.Count; i++)
                {
                    win32_Service[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_Service;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Service;
            }
        }

        public static bool setWin32_Service(List<Win32_Service> win32_Service, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_Service.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_Service[i], conn, trans);
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
