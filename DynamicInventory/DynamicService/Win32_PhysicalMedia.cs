using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PhysicalMedia
    {
        public string Caption;
        public string Description;
        public DateTime? InstallDate;
        public string Name;
        public string Status;
        public string CreationClassName;
        public string Manufacturer;
        public string Model;
        public string SKU;
        public string SerialNumber;
        public string Tag;
        public string Version;
        public string PartNumber;
        public string OtherIdentifyingInfo;
        public bool PoweredOn;
        public bool Removable;
        public bool Replaceable;
        public bool HotSwappable;
        public ulong? Capacity;
        public ushort? MediaType;
        public string MediaDescription;
        public bool WriteProtectOn;
        public bool CleanerMedia;

        public Win32_PhysicalMedia()
        {

        }
    }
}
