using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_NetworkAdapterConfigurationDAO
    {
        public static List<Win32_NetworkAdapterConfiguration> getWin32_NetworkAdapterConfiguration(Win32_NetworkAdapter win32_NetworkAdapter)
        {
            string associators = "Associators Of {{Win32_NetworkAdapter.DeviceID=\"{0}\"}} WHERE ResultClass=Win32_NetworkAdapterConfiguration";

            List<Win32_NetworkAdapterConfiguration> win32_NetworkAdapterConfiguration = new List<Win32_NetworkAdapterConfiguration>();
            try
            {
                win32_NetworkAdapterConfiguration = WmiHelper.WmiSnapshot<Win32_NetworkAdapterConfiguration>(string.Format(associators, win32_NetworkAdapter.DeviceID)).ToList();
                for (int i = 0; i < win32_NetworkAdapterConfiguration.Count; i++)
                {
                    win32_NetworkAdapterConfiguration[i].SerialNumber_Win32_ComputerSystem = win32_NetworkAdapter.SerialNumber_Win32_ComputerSystem;
                    win32_NetworkAdapterConfiguration[i].DeviceID = win32_NetworkAdapter.DeviceID;
                }
                return win32_NetworkAdapterConfiguration;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_NetworkAdapterConfiguration;
            }
        }

        public static bool setWin32_NetworkAdapterConfiguration(List<Win32_NetworkAdapterConfiguration> win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_NetworkAdapterConfiguration.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_NetworkAdapterConfiguration[i], conn, trans)) { return false; }
                    setDefaultIPGateway(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setDNSDomainSuffixSearchOrder(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setDNSServerSearchOrder(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setGatewayCostMetric(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPAddress(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPSecPermitIPProtocols(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPSecPermitTCPPorts(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPSecPermitUDPPorts(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPSubnet(win32_NetworkAdapterConfiguration[i], conn, trans);
                    setIPXNetworkNumber(win32_NetworkAdapterConfiguration[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setDefaultIPGateway(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.DefaultIPGateway == null) { return true; }

            string[] DefaultIPGateway = win32_NetworkAdapterConfiguration.DefaultIPGateway.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM DefaultIPGateway WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("DefaultIPGateway", Acao.Insert, conn, trans);

                    for (int i = 0; i < DefaultIPGateway.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@DefaultIPGateway", DefaultIPGateway[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setDNSDomainSuffixSearchOrder(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.DNSDomainSuffixSearchOrder == null) { return true; }

            string[] DNSDomainSuffixSearchOrder = win32_NetworkAdapterConfiguration.DNSDomainSuffixSearchOrder.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM DNSDomainSuffixSearchOrder WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("DNSDomainSuffixSearchOrder", Acao.Insert, conn, trans);

                    for (int i = 0; i < DNSDomainSuffixSearchOrder.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@DNSDomainSuffixSearchOrder", DNSDomainSuffixSearchOrder[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setDNSServerSearchOrder(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.DNSServerSearchOrder == null) { return true; }

            string[] DNSServerSearchOrder = win32_NetworkAdapterConfiguration.DNSServerSearchOrder.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM DNSServerSearchOrder WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("DNSServerSearchOrder", Acao.Insert, conn, trans);

                    for (int i = 0; i < DNSServerSearchOrder.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@DNSServerSearchOrder", DNSServerSearchOrder[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setGatewayCostMetric(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.GatewayCostMetric == null) { return true; }

            ushort[] GatewayCostMetric = win32_NetworkAdapterConfiguration.GatewayCostMetric.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM GatewayCostMetric WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("GatewayCostMetric", Acao.Insert, conn, trans);

                    for (int i = 0; i < GatewayCostMetric.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@GatewayCostMetric", GatewayCostMetric[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPAddress(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPAddress == null) { return true; }

            string[] IPAddress = win32_NetworkAdapterConfiguration.IPAddress.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPAddress WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPAddress", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPAddress.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPAddress", IPAddress[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPSecPermitIPProtocols(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPSecPermitIPProtocols == null) { return true; }

            string[] IPSecPermitIPProtocols = win32_NetworkAdapterConfiguration.IPSecPermitIPProtocols.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPSecPermitIPProtocols WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPSecPermitIPProtocols", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPSecPermitIPProtocols.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPSecPermitIPProtocols", IPSecPermitIPProtocols[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPSecPermitTCPPorts(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPSecPermitTCPPorts == null) { return true; }

            string[] IPSecPermitTCPPorts = win32_NetworkAdapterConfiguration.IPSecPermitTCPPorts.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPSecPermitTCPPorts WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPSecPermitTCPPorts", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPSecPermitTCPPorts.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPSecPermitTCPPorts", IPSecPermitTCPPorts[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPSecPermitUDPPorts(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPSecPermitUDPPorts == null) { return true; }

            string[] IPSecPermitUDPPorts = win32_NetworkAdapterConfiguration.IPSecPermitUDPPorts.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPSecPermitUDPPorts WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPSecPermitUDPPorts", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPSecPermitUDPPorts.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPSecPermitUDPPorts", IPSecPermitUDPPorts[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPSubnet(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPSubnet == null) { return true; }

            string[] IPSubnet = win32_NetworkAdapterConfiguration.IPSubnet.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPSubnet WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPSubnet", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPSubnet.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPSubnet", IPSubnet[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setWin32_NetworkAdapterConfiguration_IPXFrameType(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPXFrameType == null) { return true; }

            uint[] IPXFrameType = win32_NetworkAdapterConfiguration.IPXFrameType.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_NetworkAdapterConfiguration_IPXFrameType WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_NetworkAdapterConfiguration_IPXFrameType", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPXFrameType.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", IPXFrameType[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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

        public static bool setIPXNetworkNumber(Win32_NetworkAdapterConfiguration win32_NetworkAdapterConfiguration, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_NetworkAdapterConfiguration.IPXNetworkNumber == null) { return true; }

            string[] IPXNetworkNumber = win32_NetworkAdapterConfiguration.IPXNetworkNumber.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM IPXNetworkNumber WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem AND DeviceID = @DeviceID";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("IPXNetworkNumber", Acao.Insert, conn, trans);

                    for (int i = 0; i < IPXNetworkNumber.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@IPXNetworkNumber", IPXNetworkNumber[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_NetworkAdapterConfiguration.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_NetworkAdapterConfiguration.DeviceID.GetDataValue());

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
