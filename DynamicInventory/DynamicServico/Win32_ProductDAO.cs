using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_ProductDAO
    {
        public static List<Win32_Product> getWin32_Product()
        {
            List<Win32_Product> win32_Product = new List<Win32_Product>();
            try
            {
                win32_Product = WmiHelper.WmiSnapshot<Win32_Product>().ToList();

                return win32_Product;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Product;
            }
        }
    }
}
