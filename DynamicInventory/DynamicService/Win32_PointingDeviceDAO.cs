using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PointingDeviceDAO
    {
        public static List<Win32_PointingDevice> getWin32_PointingDevice(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_PointingDevice> win32_PointingDevice = new List<Win32_PointingDevice>();
            try
            {
                win32_PointingDevice = WmiHelper.WmiSnapshot<Win32_PointingDevice>().ToList();
                for (int i = 0; i < win32_PointingDevice.Count; i++)
                {
                    win32_PointingDevice[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_PointingDevice;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_PointingDevice;
            }
        }

        public static bool setWin32_PointingDevice(List<Win32_PointingDevice> win32_PointingDevice, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_PointingDevice.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_PointingDevice[i], conn, trans)) { return false; }
                    setWin32_PointingDevice_PowerManagementCapabilities(win32_PointingDevice[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_PointingDevice_PowerManagementCapabilities(Win32_PointingDevice win32_PointingDevice, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_PointingDevice.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_PointingDevice.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_PointingDevice_PowerManagementCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_PointingDevice.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_PointingDevice.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_PointingDevice_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_PointingDevice.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_PointingDevice.DeviceID.GetDataValue());

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
