using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_BIOSDAO
    {
        public static List<Win32_BIOS> getWin32_BIOS()
        {
            List<Win32_BIOS> win32_BIOS = new List<Win32_BIOS>();
            try
            {
                win32_BIOS = WmiHelper.WmiSnapshot<Win32_BIOS>().ToList();

                return win32_BIOS;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BIOS;
            }
        }
    }
}
