using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_ComputerSystemProductDAO
    {
        public static List<Win32_ComputerSystemProduct> getWin32_ComputerSystemProduct(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_ComputerSystemProduct> win32_ComputerSystemProduct = new List<Win32_ComputerSystemProduct>();
            try
            {
                win32_ComputerSystemProduct = WmiHelper.WmiSnapshot<Win32_ComputerSystemProduct>().ToList();
                for (int i = 0; i < win32_ComputerSystemProduct.Count; i++)
                {
                    win32_ComputerSystemProduct[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_ComputerSystemProduct;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_ComputerSystemProduct;
            }
        }

        public static bool setWin32_ComputerSystemProduct(List<Win32_ComputerSystemProduct> win32_ComputerSystemProduct, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_ComputerSystemProduct.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_ComputerSystemProduct[i], conn, trans);
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
