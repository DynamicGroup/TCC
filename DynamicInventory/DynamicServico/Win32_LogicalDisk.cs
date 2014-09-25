using System;

namespace DynamicService
{
    class Win32_LogicalDisk
    {
        public UInt16 Access;
        public UInt16 Availability;
        public ulong BlockSize;
        public string Caption;
        public bool Compressed;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public UInt32 DriveType;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FileSystem;
        public ulong FreeSpace;
        public DateTime InstallDate;
        public UInt32 LastErrorCode;
        public UInt32 MaximumComponentLength;
        public UInt32 MediaType;
        public string Name;
        public ulong NumberOfBlocks;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProviderName;
        public string Purpose;
        public bool QuotasDisabled;
        public bool QuotasIncomplete;
        public bool QuotasRebuilding;
        public ulong Size;
        public string Status;
        public UInt16 StatusInfo;
        public bool SupportsDiskQuotas;
        public bool SupportsFileBasedCompression;
        public string SystemCreationClassName;
        public string SystemName;
        public bool VolumeDirty;
        public string VolumeName;
        public string VolumeSerialNumber;

        public Win32_LogicalDisk()
        {

        }
    }
}
