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
            Singleton.Instance.envioConcluido = false;

            List<Win32_ComputerSystem> win32_ComputerSystem = new List<Win32_ComputerSystem>();
            try
            {
                win32_ComputerSystem = WmiHelper.WmiSnapshot<Win32_ComputerSystem>().ToList();

                for (int i = 0; i < win32_ComputerSystem.Count; i++)
                {
                    win32_ComputerSystem[i].BaseBoard = Win32_BaseBoardDAO.getWin32_BaseBoard();
                    win32_ComputerSystem[i].BIOS = Win32_BIOSDAO.getWin32_BIOS();
                    win32_ComputerSystem[i].BootConfiguration = Win32_BootConfigurationDAO.getWin32_BootConfiguration();
                    win32_ComputerSystem[i].CDROMDrive = Win32_CDROMDriveDAO.getWin32_CDROMDrive();
                    win32_ComputerSystem[i].ComputerSystemProduct = Win32_ComputerSystemProductDAO.getWin32_ComputerSystemProduct();
                    win32_ComputerSystem[i].DiskDrive = Win32_DiskDriveDAO.getWin32_DiskDrive();
                    win32_ComputerSystem[i].NetworkAdapter = Win32_NetworkAdapterDAO.getWin32_NetworkAdapter();
                    win32_ComputerSystem[i].OperatingSystem = Win32_OperatingSystemDAO.getWin32_OperatingSystem();
                    win32_ComputerSystem[i].Printer = Win32_PrinterDAO.getWin32_Printer();
                    win32_ComputerSystem[i].Processor = Win32_ProcessorDAO.getWin32_Processor();
                    win32_ComputerSystem[i].Product = Win32_ProductDAO.getWin32_Product();
                    win32_ComputerSystem[i].Service = Win32_ServiceDAO.getWin32_Service();
                    win32_ComputerSystem[i].SerialNumber = Singleton.Instance.SerialNumber;
                }

                return win32_ComputerSystem;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_ComputerSystem;
            }
            finally
            {
                Singleton.Instance.envioConcluido = true;
            }
        }

        public static bool setWin32_ComputerSystem(List<Win32_ComputerSystem> win32_ComputerSystem)
        {
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
                            cmd.CommandText = Query.insertWin32_ComputerSystem;
                            for (int i = 0; i < win32_ComputerSystem.Count; i++)
                            {
                                cmd.Parameters.AddWithValue("@AdminPasswordStatus", win32_ComputerSystem[i].AdminPasswordStatus.GetDataValue());
                                cmd.Parameters.AddWithValue("@AutomaticManagedPagefile", win32_ComputerSystem[i].AutomaticManagedPagefile.GetDataValue());
                                cmd.Parameters.AddWithValue("@AutomaticResetBootOption", win32_ComputerSystem[i].AutomaticResetBootOption.GetDataValue());
                                cmd.Parameters.AddWithValue("@AutomaticResetCapability", win32_ComputerSystem[i].AutomaticResetCapability.GetDataValue());
                                cmd.Parameters.AddWithValue("@BootOptionOnLimit", win32_ComputerSystem[i].BootOptionOnLimit.GetDataValue());
                                cmd.Parameters.AddWithValue("@BootOptionOnWatchDog", win32_ComputerSystem[i].BootOptionOnWatchDog.GetDataValue());
                                cmd.Parameters.AddWithValue("@BootROMSupported", win32_ComputerSystem[i].BootROMSupported.GetDataValue());
                                cmd.Parameters.AddWithValue("@BootupState", win32_ComputerSystem[i].BootupState.GetDataValue());
                                cmd.Parameters.AddWithValue("@Caption", win32_ComputerSystem[i].Caption.GetDataValue());
                                cmd.Parameters.AddWithValue("@ChassisBootupState", win32_ComputerSystem[i].ChassisBootupState.GetDataValue());
                                cmd.Parameters.AddWithValue("@CreationClassName", win32_ComputerSystem[i].CreationClassName.GetDataValue());
                                cmd.Parameters.AddWithValue("@CurrentTimeZone", win32_ComputerSystem[i].CurrentTimeZone.GetDataValue());
                                cmd.Parameters.AddWithValue("@DaylightInEffect", win32_ComputerSystem[i].DaylightInEffect.GetDataValue());
                                cmd.Parameters.AddWithValue("@Description", win32_ComputerSystem[i].Description.GetDataValue());
                                cmd.Parameters.AddWithValue("@DNSHostName", win32_ComputerSystem[i].DNSHostName.GetDataValue());
                                cmd.Parameters.AddWithValue("@Domain", win32_ComputerSystem[i].Domain.GetDataValue());
                                cmd.Parameters.AddWithValue("@DomainRole", win32_ComputerSystem[i].DomainRole.GetDataValue());
                                cmd.Parameters.AddWithValue("@EnableDaylightSavingsTime", win32_ComputerSystem[i].EnableDaylightSavingsTime.GetDataValue());
                                cmd.Parameters.AddWithValue("@FrontPanelResetStatus", win32_ComputerSystem[i].FrontPanelResetStatus.GetDataValue());
                                cmd.Parameters.AddWithValue("@InfraredSupported", win32_ComputerSystem[i].InfraredSupported.GetDataValue());
                                cmd.Parameters.AddWithValue("@InitialLoadInfo", win32_ComputerSystem[i].InitialLoadInfo.GetDataValue());
                                cmd.Parameters.AddWithValue("@InstallDate", win32_ComputerSystem[i].InstallDate.GetDataValue());
                                cmd.Parameters.AddWithValue("@KeyboardPasswordStatus", win32_ComputerSystem[i].KeyboardPasswordStatus.GetDataValue());
                                cmd.Parameters.AddWithValue("@LastLoadInfo", win32_ComputerSystem[i].LastLoadInfo.GetDataValue());
                                cmd.Parameters.AddWithValue("@Manufacturer", win32_ComputerSystem[i].Manufacturer.GetDataValue());
                                cmd.Parameters.AddWithValue("@Model", win32_ComputerSystem[i].Model.GetDataValue());
                                cmd.Parameters.AddWithValue("@Name", win32_ComputerSystem[i].Name.GetDataValue());
                                cmd.Parameters.AddWithValue("@NameFormat", win32_ComputerSystem[i].NameFormat.GetDataValue());
                                cmd.Parameters.AddWithValue("@NetworkServerModeEnabled", win32_ComputerSystem[i].NetworkServerModeEnabled.GetDataValue());
                                cmd.Parameters.AddWithValue("@NumberOfLogicalProcessors", win32_ComputerSystem[i].NumberOfLogicalProcessors.GetDataValue());
                                cmd.Parameters.AddWithValue("@NumberOfProcessors", win32_ComputerSystem[i].NumberOfProcessors.GetDataValue());
                                cmd.Parameters.AddWithValue("@OEMLogoBitmap", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@OEMStringArray", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@PartOfDomain", win32_ComputerSystem[i].PartOfDomain.GetDataValue());
                                cmd.Parameters.AddWithValue("@PauseAfterReset", win32_ComputerSystem[i].PauseAfterReset.GetDataValue());
                                cmd.Parameters.AddWithValue("@PCSystemType", win32_ComputerSystem[i].PCSystemType.GetDataValue());
                                cmd.Parameters.AddWithValue("@PowerManagementCapabilities", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@PowerManagementSupported", win32_ComputerSystem[i].PowerManagementSupported.GetDataValue());
                                cmd.Parameters.AddWithValue("@PowerOnPasswordStatus", win32_ComputerSystem[i].PowerOnPasswordStatus.GetDataValue());
                                cmd.Parameters.AddWithValue("@PowerState", win32_ComputerSystem[i].PowerState.GetDataValue());
                                cmd.Parameters.AddWithValue("@PowerSupplyState", win32_ComputerSystem[i].PowerSupplyState.GetDataValue());
                                cmd.Parameters.AddWithValue("@PrimaryOwnerContact", win32_ComputerSystem[i].PrimaryOwnerContact.GetDataValue());
                                cmd.Parameters.AddWithValue("@PrimaryOwnerName", win32_ComputerSystem[i].PrimaryOwnerName.GetDataValue());
                                cmd.Parameters.AddWithValue("@ResetCapability", win32_ComputerSystem[i].ResetCapability.GetDataValue());
                                cmd.Parameters.AddWithValue("@ResetCount", win32_ComputerSystem[i].ResetCount.GetDataValue());
                                cmd.Parameters.AddWithValue("@ResetLimit", win32_ComputerSystem[i].ResetLimit.GetDataValue());
                                cmd.Parameters.AddWithValue("@Roles", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@Status", win32_ComputerSystem[i].Status.GetDataValue());
                                cmd.Parameters.AddWithValue("@SupportContactDescription", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@SystemStartupDelay", win32_ComputerSystem[i].SystemStartupDelay.GetDataValue());
                                cmd.Parameters.AddWithValue("@SystemStartupOptions", DataValue.GetDataValue(null));
                                cmd.Parameters.AddWithValue("@SystemStartupSetting", win32_ComputerSystem[i].SystemStartupSetting.GetDataValue());
                                cmd.Parameters.AddWithValue("@SystemType", win32_ComputerSystem[i].SystemType.GetDataValue());
                                cmd.Parameters.AddWithValue("@ThermalState", unchecked((short)win32_ComputerSystem[i].ThermalState).GetDataValue());
                                cmd.Parameters.AddWithValue("@TotalPhysicalMemory", unchecked((long)win32_ComputerSystem[i].TotalPhysicalMemory).GetDataValue());
                                cmd.Parameters.AddWithValue("@UserName", win32_ComputerSystem[i].UserName.GetDataValue());
                                cmd.Parameters.AddWithValue("@WakeUpType", unchecked((short)win32_ComputerSystem[i].WakeUpType).GetDataValue());
                                cmd.Parameters.AddWithValue("@Workgroup", win32_ComputerSystem[i].Workgroup.GetDataValue());
                                cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem[i].SerialNumber.GetDataValue());

                                cmd.ExecuteNonQuery();

                                setOEMStringArray(win32_ComputerSystem[i], conn, trans);
                                setWin32_ComputerSystem_PowerManagementCapabilities(win32_ComputerSystem[i], conn, trans);
                                setRoles(win32_ComputerSystem[i], conn, trans);
                                setSupportContactDescription(win32_ComputerSystem[i], conn, trans);
                                setSystemStartupOptions(win32_ComputerSystem[i], conn, trans);
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
        }

        public static bool setOEMStringArray(Win32_ComputerSystem win32_ComputerSystem, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_ComputerSystem.OEMStringArray == null) { return true; }
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM OEMStringArray WHERE SerialNumber = @SerialNumber";
                    cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Query.insertOEMStringArray;

                    for (int i = 0; i < win32_ComputerSystem.OEMStringArray.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@OEMStringArray", win32_ComputerSystem.OEMStringArray[i]);
                        cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);

                        cmd.ExecuteNonQuery();
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
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_ComputerSystem_PowerManagementCapabilities WHERE SerialNumber = @SerialNumber";
                    cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Query.insertWin32_ComputerSystem_PowerManagementCapabilities;

                    for (int i = 0; i < win32_ComputerSystem.PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", unchecked((short)win32_ComputerSystem.PowerManagementCapabilities[i]));
                        cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);

                        cmd.ExecuteNonQuery();
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
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Roles WHERE SerialNumber = @SerialNumber";
                    cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Query.insertRoles;

                    for (int i = 0; i < win32_ComputerSystem.Roles.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Roles", win32_ComputerSystem.Roles[i]);
                        cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);

                        cmd.ExecuteNonQuery();
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
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM SupportContactDescription WHERE SerialNumber = @SerialNumber";
                    cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Query.insertSupportContactDescription;

                    for (int i = 0; i < win32_ComputerSystem.SupportContactDescription.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SupportContactDescription", win32_ComputerSystem.SupportContactDescription[i]);
                        cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);

                        cmd.ExecuteNonQuery();
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
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM SystemStartupOptions WHERE SerialNumber = @SerialNumber";
                    cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = Query.insertSystemStartupOptions;

                    for (int i = 0; i < win32_ComputerSystem.SystemStartupOptions.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@SystemStartupOptions", win32_ComputerSystem.SystemStartupOptions[i]);
                        cmd.Parameters.AddWithValue("@SerialNumber", win32_ComputerSystem.SerialNumber);

                        cmd.ExecuteNonQuery();
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
