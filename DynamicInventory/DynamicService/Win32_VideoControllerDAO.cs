using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_VideoControllerDAO
    {
        public static List<Win32_VideoController> getWin32_VideoController(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_VideoController> win32_VideoController = new List<Win32_VideoController>();
            try
            {
                win32_VideoController = WmiHelper.WmiSnapshot<Win32_VideoController>().ToList();
                for (int i = 0; i < win32_VideoController.Count; i++)
                {
                    win32_VideoController[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;
                }

                return win32_VideoController;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_VideoController;
            }
        }

        public static bool setWin32_VideoController(List<Win32_VideoController> win32_VideoController, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_VideoController.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_VideoController[i], conn, trans)) { return false; }
                    setWin32_VideoController_PowerManagementCapabilities(win32_VideoController[i], conn, trans);
                    setWin32_VideoController_AcceleratorCapabilities(win32_VideoController[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setWin32_VideoController_PowerManagementCapabilities(Win32_VideoController win32_VideoController, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_VideoController.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_VideoController.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_VideoController_PowerManagementCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_VideoController.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_VideoController.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_VideoController_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_VideoController.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_VideoController.DeviceID.GetDataValue());

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

        public static bool setWin32_VideoController_AcceleratorCapabilities(Win32_VideoController win32_VideoController, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_VideoController.AcceleratorCapabilities == null) { return true; }

            ushort[] AcceleratorCapabilities = win32_VideoController.AcceleratorCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_VideoController_AcceleratorCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_VideoController.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_VideoController.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_VideoController_AcceleratorCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < AcceleratorCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", AcceleratorCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_VideoController.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_VideoController.DeviceID.GetDataValue());

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
