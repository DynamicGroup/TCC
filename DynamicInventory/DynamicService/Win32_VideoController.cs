using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_VideoController
    {
        public ushort[] AcceleratorCapabilities;
        public string AdapterCompatibility;
        public string AdapterDACType;
        public uint? AdapterRAM;
        public ushort? Availability;
        public string[] CapabilityDescriptions;
        public string Caption;
        public uint? ColorTableEntries;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public uint? CurrentBitsPerPixel;
        public uint? CurrentHorizontalResolution;
        public ulong? CurrentNumberOfColors;
        public uint? CurrentNumberOfColumns;
        public uint? CurrentNumberOfRows;
        public uint? CurrentRefreshRate;
        public ushort? CurrentScanMode;
        public uint? CurrentVerticalResolution;
        public string Description;
        public string DeviceID;
        public uint? DeviceSpecificPens;
        public uint? DitherType;
        public DateTime? DriverDate;
        public string DriverVersion;
        public bool ErrorCleared;
        public string ErrorDescription;
        public uint? ICMIntent;
        public uint? ICMMethod;
        public string InfFilename;
        public string InfSection;
        public DateTime? InstallDate;
        public string InstalledDisplayDrivers;
        public uint? LastErrorCode;
        public uint? MaxMemorySupported;
        public uint? MaxNumberControlled;
        public uint? MaxRefreshRate;
        public uint? MinRefreshRate;
        public bool Monochrome;
        public string Name;
        public ushort? NumberOfColorPlanes;
        public uint? NumberOfVideoPages;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public ushort? ProtocolSupported;
        public uint? ReservedSystemPaletteEntries;
        public uint? SpecificationVersion;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public uint? SystemPaletteEntries;
        public DateTime? TimeOfLastReset;
        public ushort? VideoArchitecture;
        public ushort? VideoMemoryType;
        public ushort? VideoMode;
        public string VideoModeDescription;
        public string VideoProcessor;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_VideoController()
        {

        }
    }
}
