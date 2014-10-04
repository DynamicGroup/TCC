using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_DiskPartitionDAO
    {
        public static List<Win32_DiskPartition> getWin32_DiskPartition(Win32_DiskDrive win32_DiskDrive)
        {
            string associators = "Associators Of {{Win32_DiskDrive.DeviceID=\"{0}\"}} WHERE AssocClass=Win32_DiskDriveToDiskPartition";

            List<Win32_DiskPartition> win32_DiskPartition = new List<Win32_DiskPartition>();
            try
            {
                win32_DiskPartition = WmiHelper.WmiSnapshot<Win32_DiskPartition>(string.Format(associators, win32_DiskDrive.DeviceID.Replace("\\", "\\\\"))).ToList();

                for (int i = 0; i < win32_DiskPartition.Count; i++)
                {
                    win32_DiskPartition[i].SerialNumber_Win32_ComputerSystem = win32_DiskDrive.SerialNumber_Win32_ComputerSystem;
                    win32_DiskPartition[i].DeviceID_Win32_DiskDrive = win32_DiskDrive.DeviceID;
                    win32_DiskPartition[i].LogicalDisk = Win32_LogicalDiskDAO.getWin32_LogicalDisk(win32_DiskPartition[i]);
                }

                return win32_DiskPartition;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_DiskPartition;
            }
        }

        public static bool setWin32_DiskPartition(List<Win32_DiskPartition> win32_DiskPartition, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_DiskPartition.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_DiskPartition[i], conn, trans)) { return false; }
                    setWin32_DiskPartition_PowerManagementCapabilities(win32_DiskPartition[i], conn, trans);
                    Win32_LogicalDiskDAO.setWin32_LogicalDisk(win32_DiskPartition[i].LogicalDisk, conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_DiskPartition_PowerManagementCapabilities(Win32_DiskPartition win32_DiskPartition, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_DiskPartition.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_DiskPartition.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_DiskPartition_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID and DeviceID_Win32_DiskDrive = @DeviceID_Win32_DiskDrive";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskPartition.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_DiskPartition.DeviceID.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskDrive", win32_DiskPartition.DeviceID_Win32_DiskDrive.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_DiskPartition_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_DiskPartition.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_DiskPartition.DeviceID.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID_Win32_DiskDrive", win32_DiskPartition.DeviceID_Win32_DiskDrive.GetDataValue());

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
