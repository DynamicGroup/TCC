using System;
using System.Collections.Generic;
using System.Management;
using System.Reflection;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Collections;

namespace DynamicService
{
    class WmiHelper
    {
        public static IEnumerable<T> WmiSnapshot<T>(string query = "")
        {
            ManagementObjectSearcher searcher = null;

            if (query == String.Empty)
            {
                searcher = new ManagementObjectSearcher(new SelectQuery(Activator.CreateInstance<T>().GetType().Name));
            }
            else
            {
                searcher = new ManagementObjectSearcher(query);
            }

            List<string> properties = new List<string>();

            foreach (ManagementObject managementObject in searcher.Get())
            {
                if (properties.Count == 0)
                {
                    foreach (PropertyData property in managementObject.Properties)
                    {
                        properties.Add(property.Name);
                    }
                }

                var listItem = Activator.CreateInstance<T>();
                var fields = listItem.GetType().GetFields();

                foreach (FieldInfo field in fields)
                {
                    if (properties.Contains(field.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        if (managementObject[field.Name] != null)
                        {
                            field.SetValue(listItem, CimConvert.Cim2SystemValue(managementObject.Properties[field.Name]));
                        }
                    }
                }

                yield return listItem;
            }
        }

        static public IEnumerable<Win32_MonitorDetails> GetMonitorDetails()
        {
            List<string> sKeys = new List<string>();
            System.Management.ManagementObjectSearcher MOS = new System.Management.ManagementObjectSearcher("root\\cimv2", "SELECT * FROM Win32_PnPEntity WHERE Service = 'monitor'");
            foreach (ManagementObject MO in MOS.Get())
            {
                string sSerial = "";
                string sModel = "";
                string sName = "";
                string sHWID = "";
                string sSize = "";
                string sHSize = "";
                string sVSize = "";
                string sPnPDeviceID = "";
                try
                {
                    sPnPDeviceID = MO["PNPDeviceID"].ToString();
                    sKeys.Add(@"SYSTEM\CurrentControlSet\Enum\" + sPnPDeviceID + @"\Device Parameters");
                    string sKey = @"SYSTEM\CurrentControlSet\Enum\" + sPnPDeviceID + @"\Device Parameters";
                    RegistryKey Display = Registry.LocalMachine.OpenSubKey(sKey, false);

                    sName = MO["Name"].ToString();
                    sHWID = ((string[])MO["HardwareID"])[0].ToString().Replace("MONITOR\\", "");

                    //Define Search Keys
                    string sSerFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xff });
                    string sModFind = new string(new char[] { (char)00, (char)00, (char)00, (char)0xfc });

                    //Get the EDID code
                    byte[] bObj = Display.GetValue("EDID", null) as byte[];
                    if (bObj != null)
                    {
                        //Get the 4 Vesa descriptor blocks
                        string[] sDescriptor = new string[4];
                        sDescriptor[0] = Encoding.Default.GetString(bObj, 0x36, 18);
                        sDescriptor[1] = Encoding.Default.GetString(bObj, 0x48, 18);
                        sDescriptor[2] = Encoding.Default.GetString(bObj, 0x5A, 18);
                        sDescriptor[3] = Encoding.Default.GetString(bObj, 0x6C, 18);


                        try
                        {
                            double iHorizontal = double.Parse(((byte)bObj.GetValue(0x15)).ToString());
                            double iVertical = double.Parse(((byte)bObj.GetValue(0x16)).ToString());
                            sHSize = iHorizontal.ToString();
                            sVSize = iVertical.ToString();

                            double dDiag = Math.Sqrt((iHorizontal * iHorizontal) + (iVertical * iVertical)) * 0.3937007874015748;
                            sSize = Math.Round(dDiag, 1).ToString();
                        }
                        catch { }

                        //Search the Keys
                        foreach (string sDesc in sDescriptor)
                        {
                            if (sDesc.Contains(sSerFind))
                            {
                                sSerial = sDesc.Substring(4).Replace("\0", "").Trim();
                            }
                            if (sDesc.Contains(sModFind))
                            {
                                sModel = sDesc.Substring(4).Replace("\0", "").Trim();
                            }
                        }


                    }
                }
                catch { continue; }

                if (!string.IsNullOrEmpty(sPnPDeviceID + sSerial + sModel + sHWID + sName))
                {
                    yield return new Win32_MonitorDetails(sPnPDeviceID, sSerial, sModel, sHWID, sName, sSize, sHSize, sVSize);
                }
            }
        }
    }
}
