using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_OperatingSystemDAO
    {
        public static List<Win32_OperatingSystem> getWin32_OperatingSystem()
        {
            List<Win32_OperatingSystem> win32_OperatingSystem = new List<Win32_OperatingSystem>();
            try
            {
                win32_OperatingSystem = WmiHelper.WmiSnapshot<Win32_OperatingSystem>().ToList();

                for (int i = 0; i < win32_OperatingSystem.Count; i++)
                {
                    win32_OperatingSystem[i].QuickFixEngineering = Win32_QuickFixEngineeringDAO.getWin32_QuickFixEngineering();
                }

                return win32_OperatingSystem;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_OperatingSystem;
            }
        }
    }
}
