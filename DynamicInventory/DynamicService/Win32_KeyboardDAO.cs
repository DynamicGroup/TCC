using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_KeyboardDAO
    {
        public static List<Win32_Keyboard> getWin32_Keyboard(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_Keyboard> win32_Keyboard = new List<Win32_Keyboard>();
            try
            {
                win32_Keyboard = WmiHelper.WmiSnapshot<Win32_Keyboard>().ToList();
                for (int i = 0; i < win32_Keyboard.Count; i++)
                {
                    win32_Keyboard[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_Keyboard;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Keyboard;
            }
        }

        public static bool setWin32_Keyboard(List<Win32_Keyboard> win32_Keyboard, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_Keyboard.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_Keyboard[i], conn, trans)) { return false; }
                    setWin32_Keyboard_PowerManagementCapabilities(win32_Keyboard[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_Keyboard_PowerManagementCapabilities(Win32_Keyboard win32_Keyboard, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Keyboard.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_Keyboard.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Keyboard_PowerManagementCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Keyboard.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Keyboard.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Keyboard_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Keyboard.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Keyboard.DeviceID.GetDataValue());

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
