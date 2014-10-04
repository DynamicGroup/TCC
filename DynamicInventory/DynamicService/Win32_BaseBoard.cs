using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_BaseBoard
    {
        public string Caption;
        public string[] ConfigOptions;
        public string CreationClassName;
        public decimal Depth;
        public string Description;
        public decimal Height;
        public bool HostingBoard;
        public bool HotSwappable;
        public DateTime? InstallDate;
        public string Manufacturer;
        public string Model;
        public string Name;
        public string OtherIdentifyingInfo;
        public string PartNumber;
        public bool PoweredOn;
        public string Product;
        public bool Removable;
        public bool Replaceable;
        public string RequirementsDescription;
        public bool RequiresDaughterBoard;
        public string SerialNumber;
        public string SKU;
        public string SlotLayout;
        public bool SpecialRequirements;
        public string Status;
        public string Tag;
        public string Version;
        public decimal Weight;
        public decimal Width;

        public string SerialNumber_Win32_ComputerSystem;

        public List<Win32_BIOS> BIOS;

        public Win32_BaseBoard()
        {
            BIOS = new List<Win32_BIOS>();
            SerialNumber_Win32_ComputerSystem = Singleton.Instance.SerialNumber;
        }
    }
}
