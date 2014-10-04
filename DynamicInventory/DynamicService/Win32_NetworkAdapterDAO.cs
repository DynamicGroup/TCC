using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_NetworkAdapterDAO
    {
        public static List<Win32_NetworkAdapter> getWin32_NetworkAdapter(Win32_ComputerSystem win32_ComputerSystem)
        {
            string query = "select * from Win32_NetworkAdapter where Manufacturer != 'Microsoft' and not PNPDeviceID LIKE 'ROOT\\\\%'";

            List<Win32_NetworkAdapter> win32_NetworkAdapter = new List<Win32_NetworkAdapter>();
            try
            {
                win32_NetworkAdapter = WmiHelper.WmiSnapshot<Win32_NetworkAdapter>(query).ToList();

                for (int i = 0; i < win32_NetworkAdapter.Count; i++)
                {
                    win32_NetworkAdapter[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                    win32_NetworkAdapter[i].NetworkAdapterConfiguration = Win32_NetworkAdapterConfigurationDAO.getWin32_NetworkAdapterConfiguration(win32_NetworkAdapter[i]);
                }

                return win32_NetworkAdapter;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_NetworkAdapter;
            }
        }

        public static bool setWin32_NetworkAdapter(List<Win32_NetworkAdapter> win32_NetworkAdapter, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_NetworkAdapter.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_NetworkAdapter[i], conn, trans)) { return false; }
                    setWin32_NetworkAdapter_PowerManagementCapabilities(win32_NetworkAdapter[i], conn, trans);
                    setNetworkAddresses(win32_NetworkAdapter[i], conn, trans);
                    Win32_NetworkAdapterConfigurationDAO.setWin32_NetworkAdapterConfiguration(win32_NetworkAdapter[i].NetworkAdapterConfiguration, conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_NetworkAdapter_PowerManagementCapabilities(Win32_NetworkAdapter win32_NetworkAdapter, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapter.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_NetworkAdapter.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_NetworkAdapter_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapter.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapter.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_NetworkAdapter_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapter.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapter.DeviceID.GetDataValue());

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

        public static bool setNetworkAddresses(Win32_NetworkAdapter win32_NetworkAdapter, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapter.NetworkAddresses == null) { return true; }

            string[] NetworkAddresses = win32_NetworkAdapter.NetworkAddresses.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM NetworkAddresses WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapter.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapter.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("NetworkAddresses", Acao.Insert, conn, trans);

                    for (int i = 0; i < NetworkAddresses.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", NetworkAddresses[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapter.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapter.DeviceID.GetDataValue());

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
