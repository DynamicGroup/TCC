using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_DiskPartition
    {
        public short Access;
        public short Availability;
        public long BlockSize;
        public bool Bootable;
        public bool BootPartition;
        public string Caption;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public int DiskIndex;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public int HiddenSectors;
        public int Index;
        public DateTime InstallDate;
        public int LastErrorCode;
        public string Name;
        public long NumberOfBlocks;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public bool PrimaryPartition;
        public string Purpose;
        public bool RewritePartition;
        public long Size;
        public long StartingOffset;
        public string Status;
        public short StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public string Type;


        public List<Win32_LogicalDisk> LogicalDisk;

        public Win32_DiskPartition()
        {
            LogicalDisk = new List<Win32_LogicalDisk>();
        }
    }
}
