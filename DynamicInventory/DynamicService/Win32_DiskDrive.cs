using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_DiskDrive
    {
        public ushort? Availability;
        public uint? BytesPerSector;
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
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FirmwareRevision;
        public uint? Index;
        public DateTime? InstallDate;
        public string InterfaceType;
        public uint? LastErrorCode;
        public string Manufacturer;
        public ulong? MaxBlockSize;
        public ulong? MaxMediaSize;
        public bool MediaLoaded;
        public string MediaType;
        public ulong? MinBlockSize;
        public string Model;
        public string Name;
        public bool NeedsCleaning;
        public uint? NumberOfMediaSupported;
        public uint? Partitions;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public uint? SCSIBus;
        public ushort? SCSILogicalUnit;
        public ushort? SCSIPort;
        public ushort? SCSITargetId;
        public uint? SectorsPerTrack;
        public string SerialNumber;
        public uint? Signature;
        public ulong? Size;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public ulong? TotalCylinders;
        public uint? TotalHeads;
        public ulong? TotalSectors;
        public ulong? TotalTracks;
        public uint? TracksPerCylinder;

        public string SerialNumber_Win32_ComputerSystem;

        public List<Win32_DiskPartition> DiskPartition;
        public List<Win32_PhysicalMedia> PhysicalMedia;

        public Win32_DiskDrive()
        {
            DiskPartition = new List<Win32_DiskPartition>();
            PhysicalMedia = new List<Win32_PhysicalMedia>();
        }
    }
}
