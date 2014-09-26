﻿using System;
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
                            cmd.CommandText = "";
                            for (int i = 0; i < win32_ComputerSystem.Count; i++)
                            {
                                cmd.Parameters.AddWithValue("@AdminPasswordStatus", win32_ComputerSystem[i].AdminPasswordStatus);
                                cmd.Parameters.AddWithValue("@AutomaticManagedPagefile", win32_ComputerSystem[i].AutomaticManagedPagefile);
                            }
                        }
                        string sql = "";
                        SqlHelper.SqlSnapshot(win32_ComputerSystem[0], sql, conn, trans);       
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
