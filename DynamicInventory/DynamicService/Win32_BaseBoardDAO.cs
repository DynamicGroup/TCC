using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

                for (int i = 0; i < win32_BaseBoard.Count; i++)
                {
                    win32_BaseBoard[i].SerialNumber_Win32_ComputerSystem = Singleton.Instance.SerialNumber;
                }

                return win32_BaseBoard;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BaseBoard;
            }
        }

        public static bool setWin32_BaseBoard(List<Win32_BaseBoard> win32_BaseBoard, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_BaseBoard.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_BaseBoard[i], conn, trans)) { return false; }
                    setConfigOptions(win32_BaseBoard[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setConfigOptions(Win32_BaseBoard win32_BaseBoard, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_BaseBoard.ConfigOptions == null) { return true; }

            string[] ConfigOptions = win32_BaseBoard.ConfigOptions.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("ConfigOptions", Acao.D, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_BaseBoard.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("ConfigOptions", Acao.I, conn, trans);

                    for (int i = 0; i < ConfigOptions.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ConfigOptions", ConfigOptions[i]);
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_BaseBoard.SerialNumber_Win32_ComputerSystem);

                        cmd.ExecuteNonQuery();
                    }
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
