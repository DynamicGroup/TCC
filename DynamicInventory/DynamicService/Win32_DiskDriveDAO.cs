using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_DiskDriveDAO
    {
        public static List<Win32_DiskDrive> getWin32_DiskDrive(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_DiskDrive> win32_DiskDrive = new List<Win32_DiskDrive>();
            try
            {
                win32_DiskDrive = WmiHelper.WmiSnapshot<Win32_DiskDrive>().ToList();

                for (int i = 0; i < win32_DiskDrive.Count; i++)
                {
                    win32_DiskDrive[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                    win32_DiskDrive[i].DiskPartition = Win32_DiskPartitionDAO.getWin32_DiskPartition(win32_DiskDrive[i]);
                }

                return win32_DiskDrive;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_DiskDrive;
            }
        }

        public static bool setWin32_DiskDrive(List<Win32_DiskDrive> win32_DiskDrive, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_DiskDrive.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_DiskDrive[i], conn, trans)) { return false; }
                    setWin32_DiskDrive_PowerManagementCapabilities(win32_DiskDrive[i], conn, trans);
                    setWin32_DiskDrive_Capabilities(win32_DiskDrive[i], conn, trans);
                    Win32_DiskPartitionDAO.setWin32_DiskPartition(win32_DiskDrive[i].DiskPartition, conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_DiskDrive_PowerManagementCapabilities(Win32_DiskDrive win32_DiskDrive, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_DiskDrive.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_DiskDrive.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_DiskDrive_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskDrive.SerialNumber_Win32_ComputerSystem);
                    cmd.Parameters.AddWithValue("@DeviceID", win32_DiskDrive.DeviceID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_DiskDrive_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskDrive.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_DiskDrive.DeviceID.GetDataValue());

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

        public static bool setWin32_DiskDrive_Capabilities(Win32_DiskDrive win32_DiskDrive, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_DiskDrive.Capabilities == null) { return true; }

            ushort[] Capabilities = win32_DiskDrive.Capabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_DiskDrive_Capabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskDrive.SerialNumber_Win32_ComputerSystem);
                    cmd.Parameters.AddWithValue("@DeviceID", win32_DiskDrive.DeviceID);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_DiskDrive_Capabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < Capabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", Capabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskDrive.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_DiskDrive.DeviceID.GetDataValue());

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
