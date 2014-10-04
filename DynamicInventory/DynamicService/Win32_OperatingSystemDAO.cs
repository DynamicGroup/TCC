using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_OperatingSystemDAO
    {
        public static List<Win32_OperatingSystem> getWin32_OperatingSystem(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_OperatingSystem> win32_OperatingSystem = new List<Win32_OperatingSystem>();
            try
            {
                win32_OperatingSystem = WmiHelper.WmiSnapshot<Win32_OperatingSystem>().ToList();

                for (int i = 0; i < win32_OperatingSystem.Count; i++)
                {
                    win32_OperatingSystem[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                    win32_OperatingSystem[i].QuickFixEngineering = Win32_QuickFixEngineeringDAO.getWin32_QuickFixEngineering();
                }

                return win32_OperatingSystem;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_OperatingSystem;
            }
        }

        public static bool setWin32_OperatingSystem(List<Win32_OperatingSystem> win32_OperatingSystem, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_OperatingSystem.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_OperatingSystem[i], conn, trans)) { return false; }
                    setMUILanguages(win32_OperatingSystem[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setMUILanguages(Win32_OperatingSystem win32_OperatingSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_OperatingSystem.MUILanguages == null) { return true; }

            string[] MUILanguages = win32_OperatingSystem.MUILanguages.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("MUILanguages", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_OperatingSystem.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("MUILanguages", Acao.Insert, conn, trans);

                    for (int i = 0; i < MUILanguages.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MUILanguages", MUILanguages[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_OperatingSystem.SerialNumber_Win32_ComputerSystem.GetDataValue());

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            Singleton.Instance.registraLog(e.Message + e.StackTrace);
                        }
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
