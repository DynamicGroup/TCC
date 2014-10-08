using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_ProductDAO
    {
        public static List<Win32_Product> getWin32_Product(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_Product> win32_Product = new List<Win32_Product>();
            try
            {
                win32_Product = WmiHelper.WmiSnapshot<Win32_Product>().ToList();
                for (int i = 0; i < win32_Product.Count; i++)
                {
                    win32_Product[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_Product;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Product;
            }
        }

        public static bool setWin32_Product(List<Win32_Product> win32_Product, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_Product.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_Product[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }
    }
}
