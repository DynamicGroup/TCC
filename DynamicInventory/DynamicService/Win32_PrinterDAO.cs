using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_PrinterDAO
    {
        public static List<Win32_Printer> getWin32_Printer()
        {
            List<Win32_Printer> win32_Printer = new List<Win32_Printer>();
            try
            {
                win32_Printer = WmiHelper.WmiSnapshot<Win32_Printer>().ToList();

                return win32_Printer;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Printer;
            }
        }
    }
}
