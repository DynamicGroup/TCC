using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_NetworkAdapterConfigurationDAO
    {
        public static List<Win32_NetworkAdapterConfiguration> getWin32_NetworkAdapterConfiguration(Win32_NetworkAdapter win32_NetworkAdapter)
        {
            string associators = "Associators Of {{Win32_NetworkAdapter.DeviceID=\"{0}\"}} WHERE ResultClass=Win32_NetworkAdapterConfiguration";

            List<Win32_NetworkAdapterConfiguration> win32_NetworkAdapterConfiguration = new List<Win32_NetworkAdapterConfiguration>();
            try
            {
                win32_NetworkAdapterConfiguration = WmiHelper.WmiSnapshot<Win32_NetworkAdapterConfiguration>(string.Format(associators, win32_NetworkAdapter.DeviceID)).ToList();

                return win32_NetworkAdapterConfiguration;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_NetworkAdapterConfiguration;
            }
        }
    }
}
