using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DynamicService
{
    class Win32_PrinterDAO
    {
        public static List<Win32_Printer> getWin32_Printer(Win32_ComputerSystem win32_ComputerSystem)
        {
            List<Win32_Printer> win32_Printer = new List<Win32_Printer>();
            try
            {
                win32_Printer = WmiHelper.WmiSnapshot<Win32_Printer>().ToList();
                for (int i = 0; i < win32_Printer.Count; i++)
                {
                    win32_Printer[i].SerialNumber_Win32_ComputerSystem = win32_ComputerSystem.SerialNumber_Win32_ComputerSystem;    
                }

                return win32_Printer;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return win32_Printer;
            }
        }

        public static bool setWin32_Printer(List<Win32_Printer> win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                for (int i = 0; i < win32_Printer.Count; i++)
                {
                    if (!SqlHelper.SqlSnapshot(win32_Printer[i], conn, trans)) { return false; }
                    setAvailableJobSheets(win32_Printer[i], conn, trans);
                    setCharSetsSupported(win32_Printer[i], conn, trans);
                    setErrorInformation(win32_Printer[i], conn, trans);
                    setMimeTypesSupported(win32_Printer[i], conn, trans);
                    setPaperTypesAvailable(win32_Printer[i], conn, trans);
                    setPrinterPaperNames(win32_Printer[i], conn, trans);
                    setWin32_Printer_Capabilities_Printer(win32_Printer[i], conn, trans);
                    setWin32_Printer_CurrentCapabilities(win32_Printer[i], conn, trans);
                    setWin32_Printer_DefaultCapabilities(win32_Printer[i], conn, trans);
                    setWin32_Printer_LanguagesSupported(win32_Printer[i], conn, trans);
                    setWin32_Printer_PaperSizesSupported(win32_Printer[i], conn, trans);
                    setWin32_Printer_PowerManagementCapabilities(win32_Printer[i], conn, trans);
                }

                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public static bool setAvailableJobSheets(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.AvailableJobSheets == null) { return true; }

            string[] AvailableJobSheets = win32_Printer.AvailableJobSheets.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("AvailableJobSheets", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("AvailableJobSheets", Acao.Insert, conn, trans);

                    for (int i = 0; i < AvailableJobSheets.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@AvailableJobSheets", AvailableJobSheets[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_Capabilities_Printer(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.Capabilities == null) { return true; }

            ushort[] Capabilities = win32_Printer.Capabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_Capabilities_Printer WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_Capabilities_Printer", Acao.Insert, conn, trans);

                    for (int i = 0; i < Capabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", Capabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setCharSetsSupported(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.CharSetsSupported == null) { return true; }

            string[] CharSetsSupported = win32_Printer.CharSetsSupported.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("CharSetsSupported", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("CharSetsSupported", Acao.Insert, conn, trans);

                    for (int i = 0; i < CharSetsSupported.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@CharSetsSupported", CharSetsSupported[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_CurrentCapabilities(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.CurrentCapabilities == null) { return true; }

            ushort[] CurrentCapabilities = win32_Printer.CurrentCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_CurrentCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_CurrentCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < CurrentCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", CurrentCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_DefaultCapabilities(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.DefaultCapabilities == null) { return true; }

            ushort[] DefaultCapabilities = win32_Printer.DefaultCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_DefaultCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_DefaultCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < DefaultCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", DefaultCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setErrorInformation(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.ErrorInformation == null) { return true; }

            string[] ErrorInformation = win32_Printer.ErrorInformation.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("ErrorInformation", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("ErrorInformation", Acao.Insert, conn, trans);

                    for (int i = 0; i < ErrorInformation.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@ErrorInformation", ErrorInformation[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_LanguagesSupported(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.LanguagesSupported == null) { return true; }

            ushort[] LanguagesSupported = win32_Printer.LanguagesSupported.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_LanguagesSupported WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_LanguagesSupported", Acao.Insert, conn, trans);

                    for (int i = 0; i < LanguagesSupported.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", LanguagesSupported[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setMimeTypesSupported(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.MimeTypesSupported == null) { return true; }

            string[] MimeTypesSupported = win32_Printer.MimeTypesSupported.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("MimeTypesSupported", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("MimeTypesSupported", Acao.Insert, conn, trans);

                    for (int i = 0; i < MimeTypesSupported.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@MimeTypesSupported", MimeTypesSupported[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_PaperSizesSupported(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.PaperSizesSupported == null) { return true; }

            ushort[] PaperSizesSupported = win32_Printer.PaperSizesSupported.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_PaperSizesSupported WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_PaperSizesSupported", Acao.Insert, conn, trans);

                    for (int i = 0; i < PaperSizesSupported.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PaperSizesSupported[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setPaperTypesAvailable(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.PaperTypesAvailable == null) { return true; }

            string[] PaperTypesAvailable = win32_Printer.PaperTypesAvailable.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("PaperTypesAvailable", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("PaperTypesAvailable", Acao.Insert, conn, trans);

                    for (int i = 0; i < PaperTypesAvailable.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@PaperTypesAvailable", PaperTypesAvailable[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setWin32_Printer_PowerManagementCapabilities(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.PowerManagementCapabilities == null) { return true; }

            ushort[] PowerManagementCapabilities = win32_Printer.PowerManagementCapabilities.Distinct().ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Win32_Printer_PowerManagementCapabilities WHERE DeviceID = @DeviceID AND SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("Win32_Printer_PowerManagementCapabilities", Acao.Insert, conn, trans);

                    for (int i = 0; i < PowerManagementCapabilities.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Value", PowerManagementCapabilities[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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

        public static bool setPrinterPaperNames(Win32_Printer win32_Printer, SqlConnection conn, SqlTransaction trans)
        {
            if (win32_Printer.PrinterPaperNames == null) { return true; }

            string[] PrinterPaperNames = win32_Printer.PrinterPaperNames.Distinct().Where(x => !x.Trim().Equals(String.Empty)).ToArray();
            try
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SqlHelper.GenerateScript("PrinterPaperNames", Acao.Delete, conn, trans);
                    cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                    cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = SqlHelper.GenerateScript("PrinterPaperNames", Acao.Insert, conn, trans);

                    for (int i = 0; i < PrinterPaperNames.Length; i++)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@PrinterPaperNames", PrinterPaperNames[i].GetDataValue());
                        cmd.Parameters.AddWithValue("@SerialNumber_Win32_ComputerSystem", win32_Printer.SerialNumber_Win32_ComputerSystem.GetDataValue());
                        cmd.Parameters.AddWithValue("@DeviceID", win32_Printer.DeviceID.GetDataValue());

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
