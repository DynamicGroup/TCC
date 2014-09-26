using System;

namespace DynamicService
{
    class Win32_CDROMDrive
    {
        public short Availability;
        public short[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string CompressionMethod;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public long DefaultBlockSize;
        public string Description;
        public string DeviceID;
        public string Drive;
        public bool DriveIntegrity;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public short FileSystemFlags;
        public int FileSystemFlagsEx;
        public string Id;
        public DateTime InstallDate;
        public int LastErrorCode;
        public string Manufacturer;
        public long MaxBlockSize;
        public int MaximumComponentLength;
        public long MaxMediaSize;
        public bool MediaLoaded;
        public string MediaType;
        public string MfrAssignedRevisionLevel;
        public long MinBlockSize;
        public string Name;
        public bool NeedsCleaning;
        public int NumberOfMediaSupported;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string RevisionLevel;
        public int SCSIBus;
        public short SCSILogicalUnit;
        public short SCSIPort;
        public short SCSITargetId;
        public short SerialNumber;
        public long Size;
        public string Status;
        public short StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public decimal TransferRate;
        public string VolumeName;
        public string VolumeSerialNumber;


        public Win32_CDROMDrive()
        {

        }
    }
}
