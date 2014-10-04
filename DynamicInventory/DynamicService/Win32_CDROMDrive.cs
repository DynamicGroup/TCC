using System;

namespace DynamicService
{
    class Win32_CDROMDrive
    {
        public ushort? Availability;
        public ushort[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string CompressionMethod;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public ulong? DefaultBlockSize;
        public string Description;
        public string DeviceID;
        public string Drive;
        public bool DriveIntegrity;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public ushort? FileSystemFlags;
        public uint? FileSystemFlagsEx;
        public string Id;
        public DateTime? InstallDate;
        public uint? LastErrorCode;
        public string Manufacturer;
        public ulong? MaxBlockSize;
        public uint? MaximumComponentLength;
        public ulong? MaxMediaSize;
        public bool MediaLoaded;
        public string MediaType;
        public string MfrAssignedRevisionLevel;
        public ulong? MinBlockSize;
        public string Name;
        public bool NeedsCleaning;
        public uint? NumberOfMediaSupported;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string RevisionLevel;
        public uint? SCSIBus;
        public ushort? SCSILogicalUnit;
        public ushort? SCSIPort;
        public ushort? SCSITargetId;
        public ushort? SerialNumber;
        public ulong? Size;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public decimal TransferRate;
        public string VolumeName;
        public string VolumeSerialNumber;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_CDROMDrive()
        {

        }
    }
}
