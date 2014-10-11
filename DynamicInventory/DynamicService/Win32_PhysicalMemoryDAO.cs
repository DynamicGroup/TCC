using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PhysicalMemoryDAO
    {
        public static List<Win32_PhysicalMemory> getWin32_PhysicalMemory(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_PhysicalMemory> win32_PhysicalMemory = new List<Win32_PhysicalMemory>();
            try
            {
                win32_PhysicalMemory = WmiHelper.WmiSnapshot<Win32_PhysicalMemory>().ToList();
                for (int i = 0; i < win32_PhysicalMemory.Count; i++)
                {
                    win32_PhysicalMemory[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_PhysicalMemory;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_PhysicalMemory;
            }
        }

        public static bool setWin32_PhysicalMemory(List<Win32_PhysicalMemory> win32_PhysicalMemory, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_PhysicalMemory.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_PhysicalMemory[i], conn, trans);
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
