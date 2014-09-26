using System;

namespace DynamicService
{
    class Win32_Processor
    {
        public short AddressWidth;
        public short Architecture;
        public short Availability;
        public string Caption;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public short CpuStatus;
        public string CreationClassName;
        public int CurrentClockSpeed;
        public short CurrentVoltage;
        public short DataWidth;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public int ExtClock;
        public short Family;
        public DateTime InstallDate;
        public int L2CacheSize;
        public int L2CacheSpeed;
        public int L3CacheSize;
        public int L3CacheSpeed;
        public int LastErrorCode;
        public short Level;
        public short LoadPercentage;
        public string Manufacturer;
        public int MaxClockSpeed;
        public string Name;
        public int NumberOfCores;
        public int NumberOfLogicalProcessors;
        public string OtherFamilyDescription;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProcessorId;
        public short ProcessorType;
        public short Revision;
        public string Role;
        public string SocketDesignation;
        public string Status;
        public short StatusInfo;
        public string Stepping;
        public string SystemCreationClassName;
        public string SystemName;
        public string UniqueId;
        public short UpgradeMethod;
        public string Version;
        public int VoltageCaps;


        public Win32_Processor()
        {

        }
    }
}
