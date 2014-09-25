using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_QuickFixEngineeringDAO
    {
        public static List<Win32_QuickFixEngineering> getWin32_QuickFixEngineering()
        {
            List<Win32_QuickFixEngineering> win32_QuickFixEngineering = new List<Win32_QuickFixEngineering>();
            try
            {
                win32_QuickFixEngineering = WmiHelper.WmiSnapshot<Win32_QuickFixEngineering>().ToList();

                return win32_QuickFixEngineering;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_QuickFixEngineering;
            }
        }
    }
}
