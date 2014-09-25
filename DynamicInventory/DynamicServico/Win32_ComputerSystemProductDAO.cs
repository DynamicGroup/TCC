using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_ComputerSystemProductDAO
    {
        public static List<Win32_ComputerSystemProduct> getWin32_ComputerSystemProduct()
        {
            List<Win32_ComputerSystemProduct> win32_ComputerSystemProduct = new List<Win32_ComputerSystemProduct>();
            try
            {
                win32_ComputerSystemProduct = WmiHelper.WmiSnapshot<Win32_ComputerSystemProduct>().ToList();

                return win32_ComputerSystemProduct;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_ComputerSystemProduct;
            }
        }
    }
}
