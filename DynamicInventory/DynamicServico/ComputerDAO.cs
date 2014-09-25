using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace DynamicService
{
    class ComputerDAO
    {
        public static List<Win32_ComputerSystem> getComputador()
        {
            string queryNetworkAdapter = "select * from Win32_NetworkAdapter where Manufacturer != 'Microsoft' and not PNPDeviceID LIKE 'ROOT\\\\%'";
            string associatorsNetworkAdapter = "Associators Of {{Win32_NetworkAdapter.DeviceID=\"{0}\"}} WHERE ResultClass=Win32_NetworkAdapterConfiguration";
            Singleton.Instance.envioConcluido = false;

            List<Win32_ComputerSystem> win32_ComputerSystem = new List<Win32_ComputerSystem>();
            try
            {
                win32_ComputerSystem = WmiHelper.WmiSnapshot<Win32_ComputerSystem>().ToList();

                win32_ComputerSystem[0].BaseBoard = WmiHelper.WmiSnapshot<Win32_BaseBoard>().ToList();
                win32_ComputerSystem[0].BIOS = WmiHelper.WmiSnapshot<Win32_BIOS>().ToList();
                win32_ComputerSystem[0].BootConfiguration = WmiHelper.WmiSnapshot<Win32_BootConfiguration>().ToList();
                win32_ComputerSystem[0].CDROMDrive = WmiHelper.WmiSnapshot<Win32_CDROMDrive>().ToList();
                win32_ComputerSystem[0].ComputerSystemProduct = WmiHelper.WmiSnapshot<Win32_ComputerSystemProduct>().ToList();
                win32_ComputerSystem[0].DiskDrive = WmiHelper.WmiSnapshot<Win32_DiskDrive>().ToList();
                win32_ComputerSystem[0].NetworkAdapter = WmiHelper.WmiSnapshot<Win32_NetworkAdapter>(queryNetworkAdapter).ToList();
                for (int i = 0; i < win32_ComputerSystem[0].NetworkAdapter.Count; i++)
                {
                    win32_ComputerSystem[0].NetworkAdapter[i].NetworkAdapterConfiguration = WmiHelper.WmiSnapshot<Win32_NetworkAdapterConfiguration>(string.Format(associatorsNetworkAdapter, win32_ComputerSystem[0].NetworkAdapter[i].DeviceID)).ToList();
                }                
                win32_ComputerSystem[0].OperatingSystem = WmiHelper.WmiSnapshot<Win32_OperatingSystem>().ToList();
                win32_ComputerSystem[0].OperatingSystem[0].QuickFixEngineering = WmiHelper.WmiSnapshot<Win32_QuickFixEngineering>().ToList();
                win32_ComputerSystem[0].Printer = WmiHelper.WmiSnapshot<Win32_Printer>().ToList();
                win32_ComputerSystem[0].Processor = WmiHelper.WmiSnapshot<Win32_Processor>().ToList();
                win32_ComputerSystem[0].Product = WmiHelper.WmiSnapshot<Win32_Product>().ToList();
                win32_ComputerSystem[0].Service = WmiHelper.WmiSnapshot<Win32_Service>().ToList();

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
    }
}
