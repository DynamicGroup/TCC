using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;

namespace DynamicService
{
    class Win32_ComputerSystemDAO
    {
        public static List<Win32_ComputerSystem> getWin32_ComputerSystem()
        {
            List<Win32_ComputerSystem> win32_ComputerSystem = new List<Win32_ComputerSystem>();
            try
            {
                win32_ComputerSystem = WmiHelper.WmiSnapshot<Win32_ComputerSystem>().ToList();

                for (int i = 0; i < win32_ComputerSystem.Count; i++)
                {
                    if (!Win32_PhysicalMediaDAO.getWin32_PhysicalMedia(win32_ComputerSystem[i])) { return win32_ComputerSystem; }       
                    win32_ComputerSystem[i].BaseBoard = Win32_BaseBoardDAO.getWin32_BaseBoard(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].BootConfiguration = Win32_BootConfigurationDAO.getWin32_BootConfiguration(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].CDROMDrive = Win32_CDROMDriveDAO.getWin32_CDROMDrive(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].ComputerSystemProduct = Win32_ComputerSystemProductDAO.getWin32_ComputerSystemProduct(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].DiskDrive = Win32_DiskDriveDAO.getWin32_DiskDrive(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].MonitorDetails = Win32_MonitorDetailsDAO.getWin32_MonitorDetails(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].NetworkAdapter = Win32_NetworkAdapterDAO.getWin32_NetworkAdapter(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].OperatingSystem = Win32_OperatingSystemDAO.getWin32_OperatingSystem(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].Printer = Win32_PrinterDAO.getWin32_Printer(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].Processor = Win32_ProcessorDAO.getWin32_Processor(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].Product = Win32_ProductDAO.getWin32_Product(win32_ComputerSystem[i]);
                    win32_ComputerSystem[i].Service = Win32_ServiceDAO.getWin32_Service(win32_ComputerSystem[i]);
                }

                return win32_ComputerSystem;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_ComputerSystem;
            }
        }

        public static bool setWin32_ComputerSystem(List<Win32_ComputerSystem> win32_ComputerSystem)
        {
            Singleton.Instance.envioConcluido = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(Singleton.Instance.stringConexao))
                {
                    conn.Open();

                    using (SqlTransaction trans = conn.BeginTransaction())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = trans;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "DELETE FROM Win32_ComputerSystem WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                            for (int i = 0; i < win32_ComputerSystem.Count; i++)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem[i].SerialNumber_Win32_ComputerSystem);
                                cmd.ExecuteNonQuery();

                                if (!SqlHelper.SqlSnapshot(win32_ComputerSystem[i], conn, trans)) { return false; }
                                setOEMStringArray(win32_ComputerSystem[i], conn, trans);
                                setWin32_ComputerSystem_PowerManagementCapabilities(win32_ComputerSystem[i], conn, trans);
                                setRoles(win32_ComputerSystem[i], conn, trans);
                                setSupportContactDescription(win32_ComputerSystem[i], conn, trans);
                                setSystemStartupOptions(win32_ComputerSystem[i], conn, trans);

                                Win32_BaseBoardDAO.setWin32_BaseBoard(win32_ComputerSystem[i].BaseBoard, conn, trans);
                                Win32_BootConfigurationDAO.setWin32_BootConfiguration(win32_ComputerSystem[i].BootConfiguration, conn, trans);
                                Win32_CDROMDriveDAO.setWin32_CDROMDrive(win32_ComputerSystem[i].CDROMDrive, conn, trans);
                                Win32_ComputerSystemProductDAO.setWin32_ComputerSystemProduct(win32_ComputerSystem[i].ComputerSystemProduct, conn, trans);
                                Win32_DiskDriveDAO.setWin32_DiskDrive(win32_ComputerSystem[i].DiskDrive, conn, trans);
                                Win32_MonitorDetailsDAO.setWin32_MonitorDetails(win32_ComputerSystem[i].MonitorDetails, conn, trans);
                                Win32_NetworkAdapterDAO.setWin32_NetworkAdapter(win32_ComputerSystem[i].NetworkAdapter, conn, trans);
                                Win32_OperatingSystemDAO.setWin32_OperatingSystem(win32_ComputerSystem[i].OperatingSystem, conn, trans);
                                Win32_PrinterDAO.setWin32_Printer(win32_ComputerSystem[i].Printer, conn, trans);
                                Win32_ProcessorDAO.setWin32_Processor(win32_ComputerSystem[i].Processor, conn, trans);
                                Win32_ProductDAO.setWin32_Product(win32_ComputerSystem[i].Product, conn, trans);
                                Win32_ServiceDAO.setWin32_Service(win32_ComputerSystem[i].Service, conn, trans);
                            }
                        }

                        trans.Commit();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
            finally
            {
                Singleton.Instance.envioConcluido = true;
            }
        }

        public static bool setOEMStringArray(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.OEMStringArray == null) { return true; }

            string[] OEMStringArray = win32_ComputerSystem.OEMStringArray.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("OEMStringArray", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("OEMStringArray", Acao.Insert, conn, trans);

                    for (int i = 0; i < OEMStringArray.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@OEMStringArray", OEMStringArray[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);

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

        public static bool setWin32_ComputerSystem_PowerManagementCapabilities(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_ComputerSystem.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_ComputerSystem_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);

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

        public static bool setRoles(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.Roles == null) { return true; }

            string[] Roles = win32_ComputerSystem.Roles.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("Roles", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Roles", Acao.Insert, conn, trans);

                    for (int i = 0; i < Roles.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Roles", Roles[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);

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

        public static bool setSupportContactDescription(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.SupportContactDescription == null) { return true; }

            string[] SupportContactDescription = win32_ComputerSystem.SupportContactDescription.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("SupportContactDescription", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("SupportContactDescription", Acao.Insert, conn, trans);

                    for (int i = 0; i < SupportContactDescription.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SupportContactDescription", SupportContactDescription[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);

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

        public static bool setSystemStartupOptions(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.SystemStartupOptions == null) { return true; }

            string[] SystemStartupOptions = win32_ComputerSystem.SystemStartupOptions.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript(SystemStartupOptions.GetType().Name, Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript(SystemStartupOptions.GetType().Name, Acao.Insert, conn, trans);

                    for (int i = 0; i < SystemStartupOptions.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SystemStartupOptions", SystemStartupOptions[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_ComputerSystem.SerialNumber_Win32_ComputerSystem);

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
