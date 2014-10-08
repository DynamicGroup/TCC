using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_ProcessorDAO
    {
        public static List<Win32_Processor> getWin32_Processor(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_Processor> win32_Processor = new List<Win32_Processor>();
            try
            {
                win32_Processor = WmiHelper.WmiSnapshot<Win32_Processor>().ToList();
                for (int i = 0; i < win32_Processor.Count; i++)
                {
                    win32_Processor[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_Processor;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Processor;
            }
        }

        public static bool setWin32_Processor(List<Win32_Processor> win32_Processor, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_Processor.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_Processor[i], conn, trans)) { return false; }
                    setWin32_Processor_PowerManagementCapabilities(win32_Processor[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_Processor_PowerManagementCapabilities(Win32_Processor win32_Processor, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Processor.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_Processor.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Processor_PowerManagementCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Processor.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Processor.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Processor_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Processor.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Processor.DeviceID.GetDataValue());

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
