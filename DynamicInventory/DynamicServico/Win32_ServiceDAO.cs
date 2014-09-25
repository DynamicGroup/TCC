using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_ServiceDAO
    {
        public static List<Win32_Service> getWin32_Service()
        {
            List<Win32_Service> win32_Service = new List<Win32_Service>();
            try
            {
                win32_Service = WmiHelper.WmiSnapshot<Win32_Service>().ToList();

                return win32_Service;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Service;
            }
        }
    }
}
