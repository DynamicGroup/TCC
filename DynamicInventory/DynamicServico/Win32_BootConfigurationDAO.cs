using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_BootConfigurationDAO
    {
        public static List<Win32_BootConfiguration> getWin32_BootConfiguration()
        {
            List<Win32_BootConfiguration> win32_BootConfiguration = new List<Win32_BootConfiguration>();
            try
            {
                win32_BootConfiguration = WmiHelper.WmiSnapshot<Win32_BootConfiguration>().ToList();

                return win32_BootConfiguration;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BootConfiguration;
            }
        }
    }
}
