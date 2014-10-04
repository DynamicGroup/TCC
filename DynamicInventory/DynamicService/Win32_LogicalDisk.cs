using System;

namespace DynamicService
{
    class Win32_LogicalDisk
    {
        public ushort? Access;
        public ushort? Availability;
        public ulong? BlockSize;
        public string Caption;
        public bool Compressed;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public uint? DriveType;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FileSystem;
        public ulong? FreeSpace;
        public DateTime? InstallDate;
        public uint? LastErrorCode;
        public uint? MaximumComponentLength;
        public uint? MediaType;
        public string Name;
        public ulong? NumberOfBlocks;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProviderName;
        public string Purpose;
        public bool QuotasDisabled;
        public bool QuotasIncomplete;
        public bool QuotasRebuilding;
        public ulong? Size;
        public string Status;
        public ushort? StatusInfo;
        public bool SupportsDiskQuotas;
        public bool SupportsFileBasedCompression;
        public string SystemCreationClassName;
        public string SystemName;
        public bool VolumeDirty;
        public string VolumeName;
        public string VolumeSerialNumber;

        public string DeviceID_Win32_DiskPartition;
        public string DeviceID_Win32_DiskDrive;
        public string SerialNumber_Win32_ComputerSystem;

        public Win32_LogicalDisk()
        {

        }
    }
}
