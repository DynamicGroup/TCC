using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicService
{
    class Win32_BaseBoardDAO
    {
        public static List<Win32_BaseBoard> getWin32_BaseBoard()
        {
            List<Win32_BaseBoard> win32_BaseBoard = new List<Win32_BaseBoard>();
            try
            {
                win32_BaseBoard = WmiHelper.WmiSnapshot<Win32_BaseBoard>().ToList();

                return win32_BaseBoard;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BaseBoard;
            }
        }
    }
}
