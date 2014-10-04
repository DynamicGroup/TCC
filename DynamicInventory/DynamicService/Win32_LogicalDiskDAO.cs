using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_LogicalDiskDAO
    {
        public static List<Win32_LogicalDisk> getWin32_LogicalDisk(Win32_DiskPartition win32_DiskPartition)
        {
            string associators = "Associators Of {{Win32_DiskPartition.DeviceID=\"{0}\"}} WHERE AssocClass=Win32_LogicalDiskToPartition";

            List<Win32_LogicalDisk> win32_LogicalDisk = new List<Win32_LogicalDisk>();
            try
            {
                win32_LogicalDisk = WmiHelper.WmiSnapshot<Win32_LogicalDisk>(string.Format(associators, win32_DiskPartition.DeviceID.Replace("\\", "\\\\"))).ToList();
                for (int i = 0; i < win32_LogicalDisk.Count; i++)
                {
                    win32_LogicalDisk[i].DeviceID_Win32_DiskDrive = win32_DiskPartition.DeviceID_Win32_DiskDrive;
                    win32_LogicalDisk[i].DeviceID_Win32_DiskPartition = win32_DiskPartition.DeviceID;
                    win32_LogicalDisk[i].SerialNumber_Win32_ComputerSystem = win32_DiskPartition.SerialNumber_Win32_ComputerSystem;
                }

                return win32_LogicalDisk;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_LogicalDisk;
            }
        }

        public static bool setWin32_LogicalDisk(List<Win32_LogicalDisk> win32_LogicalDisk, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_LogicalDisk.Count; i++)
                {
                    SqlHelper.SqlSnapshot(win32_LogicalDisk[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_LogicalDisk_PowerManagementCapabilities(Win32_LogicalDisk win32_LogicalDisk, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_LogicalDisk.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_LogicalDisk.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_LogicalDisk_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID and DeviceID_Win32_DiskDrive = @DeviceID_Win32_DiskDrive AND DeviceID_Win32_DiskPartition = @DeviceID_Win32_DiskPartition";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_LogicalDisk.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_LogicalDisk.DeviceID.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskDrive", win32_LogicalDisk.DeviceID_Win32_DiskDrive.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskPartition", win32_LogicalDisk.DeviceID_Win32_DiskPartition.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_LogicalDisk_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_LogicalDisk.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_LogicalDisk.DeviceID.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskDrive", win32_LogicalDisk.DeviceID_Win32_DiskDrive.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskPartition", win32_LogicalDisk.DeviceID_Win32_DiskPartition.GetDataValue());

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
