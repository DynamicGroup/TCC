using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_CDROMDriveDAO
    {
        public static List<Win32_CDROMDrive> getWin32_CDROMDrive(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_CDROMDrive> win32_CDROMDrive = new List<Win32_CDROMDrive>();
            try
            {
                win32_CDROMDrive = WmiHelper.WmiSnapshot<Win32_CDROMDrive>().ToList();
                for (int i = 0; i < win32_CDROMDrive.Count; i++)
                {
                    win32_CDROMDrive[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_CDROMDrive;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_CDROMDrive;
            }
        }

        public static bool setWin32_CDROMDrive(List<Win32_CDROMDrive> win32_CDROMDrive, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_CDROMDrive.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_CDROMDrive[i], conn, trans)) { return false; }
                    setWin32_CDROMDrive_Capabilities(win32_CDROMDrive[i], conn, trans);
                    setWin32_CDROMDrive_PowerManagementCapabilities(win32_CDROMDrive[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_CDROMDrive_PowerManagementCapabilities(Win32_CDROMDrive win32_CDROMDrive, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_CDROMDrive.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_CDROMDrive.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_CDROMDrive_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_CDROMDrive.SerialNumber_Win32_ComputerSystem);
                    cmd.Parameters.AddWithValue("@DeviceID", win32_CDROMDrive.DeviceID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_CDROMDrive_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_CDROMDrive.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_CDROMDrive.DeviceID.GetDataValue());

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

        public static bool setWin32_CDROMDrive_Capabilities(Win32_CDROMDrive win32_CDROMDrive, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_CDROMDrive.Capabilities == null) { return true; }

            ushort[] Capabilities = win32_CDROMDrive.Capabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_CDROMDrive_Capabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_CDROMDrive.SerialNumber_Win32_ComputerSystem);
                    cmd.Parameters.AddWithValue("@DeviceID", win32_CDROMDrive.DeviceID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_CDROMDrive_Capabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < Capabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", Capabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_CDROMDrive.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_CDROMDrive.DeviceID.GetDataValue());

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
