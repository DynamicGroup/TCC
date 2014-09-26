using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_DiskDrive
    {
        public short Availability;
        public int BytesPerSector;
        public UInt16[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string CompressionMethod;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public long DefaultBlockSize;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string ErrorMethodology;
        public string FirmwareRevision;
        public int Index;
        public DateTime InstallDate;
        public string InterfaceType;
        public int LastErrorCode;
        public string Manufacturer;
        public long MaxBlockSize;
        public long MaxMediaSize;
        public bool MediaLoaded;
        public string MediaType;
        public long MinBlockSize;
        public string Model;
        public string Name;
        public bool NeedsCleaning;
        public int NumberOfMediaSupported;
        public int Partitions;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public int SCSIBus;
        public short SCSILogicalUnit;
        public short SCSIPort;
        public short SCSITargetId;
        public int SectorsPerTrack;
        public string SerialNumber;
        public int Signature;
        public long Size;
        public string Status;
        public short StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public long TotalCylinders;
        public int TotalHeads;
        public long TotalSectors;
        public long TotalTracks;
        public int TracksPerCylinder;

        public List<Win32_DiskPartition> DiskPartition;
        public List<Win32_PhysicalMedia> PhysicalMedia;

        public Win32_DiskDrive()
        {
            DiskPartition = new List<Win32_DiskPartition>();
            PhysicalMedia = new List<Win32_PhysicalMedia>();
        }
    }
}
