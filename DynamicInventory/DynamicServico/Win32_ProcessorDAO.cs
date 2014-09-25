using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_ProcessorDAO
    {
        public static List<Win32_Processor> getWin32_Processor()
        {
            List<Win32_Processor> win32_Processor = new List<Win32_Processor>();
            try
            {
                win32_Processor = WmiHelper.WmiSnapshot<Win32_Processor>().ToList();

                return win32_Processor;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Processor;
            }
        }
    }
}
