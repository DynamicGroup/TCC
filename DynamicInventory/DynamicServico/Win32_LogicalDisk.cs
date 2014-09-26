using System;

namespace DynamicService
{
    class Win32_LogicalDisk
    {
        public short Access;
        public short Availability;
        public long BlockSize;
        public string Caption;
        public bool Compressed;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public int DriveType;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FileSystem;
        public long FreeSpace;
        public DateTime InstallDate;
        public int LastErrorCode;
        public int MaximumComponentLength;
        public int MediaType;
        public string Name;
        public long NumberOfBlocks;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProviderName;
        public string Purpose;
        public bool QuotasDisabled;
        public bool QuotasIncomplete;
        public bool QuotasRebuilding;
        public long Size;
        public string Status;
        public short StatusInfo;
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
