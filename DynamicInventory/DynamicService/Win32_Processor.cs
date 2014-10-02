using System;

namespace DynamicService
{
    class Win32_Processor
    {
        public ushort? AddressWidth;
        public ushort? Architecture;
        public ushort? Availability;
        public string Caption;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public ushort? CpuStatus;
        public string CreationClassName;
        public uint? CurrentClockSpeed;
        public ushort? CurrentVoltage;
        public ushort? DataWidth;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public uint? ExtClock;
        public ushort? Family;
        public DateTime? InstallDate;
        public uint? L2CacheSize;
        public uint? L2CacheSpeed;
        public uint? L3CacheSize;
        public uint? L3CacheSpeed;
        public uint? LastErrorCode;
        public ushort? Level;
        public ushort? LoadPercentage;
        public string Manufacturer;
        public uint? MaxClockSpeed;
        public string Name;
        public uint? NumberOfCores;
        public uint? NumberOfLogicalProcessors;
        public string OtherFamilyDescription;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProcessorId;
        public ushort? ProcessorType;
        public ushort? Revision;
        public string Role;
        public string SocketDesignation;
        public string Status;
        public ushort? StatusInfo;
        public string Stepping;
        public string SystemCreationClassName;
        public string SystemName;
        public string UniqueId;
        public ushort? UpgradeMethod;
        public string Version;
        public uint? VoltageCaps;

        public Win32_Processor()
        {

        }
    }
}
