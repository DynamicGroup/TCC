using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_DiskPartition
    {
        public ushort Access;
        public ushort Availability;
        public ulong BlockSize;
        public bool Bootable;
        public bool BootPartition;
        public string Caption;
        public uint ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public uint DiskIndex;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public uint HiddenSectors;
        public uint Index;
        public DateTime InstallDate;
        public uint LastErrorCode;
        public string Name;
        public ulong NumberOfBlocks;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public bool PrimaryPartition;
        public string Purpose;
        public bool RewritePartition;
        public ulong Size;
        public ulong StartingOffset;
        public string Status;
        public ushort StatusInfo;
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
