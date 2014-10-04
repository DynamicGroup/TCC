using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_BIOSDAO
    {
        public static List<Win32_BIOS> getWin32_BIOS(Win32_BaseBoard win32_BaseBoard)
        {
            List<Win32_BIOS> win32_BIOS = new List<Win32_BIOS>();
            try
            {
                win32_BIOS = WmiHelper.WmiSnapshot<Win32_BIOS>().ToList();
                for (int i = 0; i < win32_BIOS.Count; i++)
                {
                    win32_BIOS[i].SerialNumber_Win32_ComputerSystem = win32_BaseBoard.SerialNumber_Win32_ComputerSystem;
                }

                return win32_BIOS;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_BIOS;
            }
        }

        public static bool setWin32_BIOS(List<Win32_BIOS> win32_BIOS, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_BIOS.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_BIOS[i], conn, trans)) { return false; }
                    setWin32_BIOS_BiosCharacteristics(win32_BIOS[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_BIOS_BiosCharacteristics(Win32_BIOS win32_BIOS, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_BIOS.BiosCharacteristics == null) { return true; }

            ushort[] BiosCharacteristics = win32_BIOS.BiosCharacteristics.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_BIOS_BiosCharacteristics WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_BIOS.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_BIOS_BiosCharacteristics", Acao.Insert, conn, trans);

                    for (int i = 0; i < BiosCharacteristics.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", BiosCharacteristics[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_BIOS.SerialNumber_Win32_ComputerSystem);

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
