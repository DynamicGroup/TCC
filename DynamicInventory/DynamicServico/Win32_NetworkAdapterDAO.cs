using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_NetworkAdapterDAO
    {
        public static List<Win32_NetworkAdapter> getWin32_NetworkAdapter()
        {
            string query = "select * from Win32_NetworkAdapter where Manufacturer != 'Microsoft' and not PNPDeviceID LIKE 'ROOT\\\\%'";

            List<Win32_NetworkAdapter> win32_NetworkAdapter = new List<Win32_NetworkAdapter>();
            try
            {
                win32_NetworkAdapter = WmiHelper.WmiSnapshot<Win32_NetworkAdapter>(query).ToList();

                for (int i = 0; i < win32_NetworkAdapter.Count; i++)
                {
                    win32_NetworkAdapter[i].NetworkAdapterConfiguration = Win32_NetworkAdapterConfigurationDAO.getWin32_NetworkAdapterConfiguration(win32_NetworkAdapter[i]);
                }

                return win32_NetworkAdapter;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_NetworkAdapter;
            }
        }
    }
}
