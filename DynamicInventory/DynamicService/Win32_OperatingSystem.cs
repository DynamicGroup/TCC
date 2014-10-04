using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_OperatingSystem
    {
        public string BootDevice;
        public string BuildNumber;
        public string BuildType;
        public string Caption;
        public string CodeSet;
        public string CountryCode;
        public string CreationClassName;
        public string CSCreationClassName;
        public string CSDVersion;
        public string CSName;
        public short? CurrentTimeZone;
        public bool DataExecutionPrevention_Available;
        public bool DataExecutionPrevention_32BitApplications;
        public bool DataExecutionPrevention_Drivers;
        public byte? DataExecutionPrevention_SupportPolicy;
        public bool Debug;
        public string Description;
        public bool Distributed;
        public uint? EncryptionLevel;
        public byte? ForegroundApplicationBoost;
        public ulong? FreePhysicalMemory;
        public ulong? FreeSpaceInPagingFiles;
        public ulong? FreeVirtualMemory;
        public DateTime? InstallDate;
        public uint? LargeSystemCache;
        public DateTime? LastBootUpTime;
        public DateTime? LocalDateTime;
        public string Locale;
        public string Manufacturer;
        public uint? MaxNumberOfProcesses;
        public ulong? MaxProcessMemorySize;
        public string[] MUILanguages;
        public string Name;
        public uint? NumberOfLicensedUsers;
        public uint? NumberOfProcesses;
        public uint? NumberOfUsers;
        public uint? OperatingSystemSKU;
        public string Organization;
        public string OSArchitecture;
        public uint? OSLanguage;
        public uint? OSProductSuite;
        public ushort? OSType;
        public string OtherTypeDescription;
        public bool PAEEnabled;
        public string PlusProductID;
        public string PlusVersionNumber;
        public bool PortableOperatingSystem;
        public bool Primary;
        public uint? ProductType;
        public string RegisteredUser;
        public string SerialNumber;
        public ushort? ServicePackMajorVersion;
        public ushort? ServicePackMinorVersion;
        public ulong? SizeStoredInPagingFiles;
        public string Status;
        //public uint? SuiteMask;
        public string SystemDevice;
        public string SystemDirectory;
        public string SystemDrive;
        public ulong? TotalSwapSpaceSize;
        public ulong? TotalVirtualMemorySize;
        public ulong? TotalVisibleMemorySize;
        public string Version;
        public string WindowsDirectory;

        public string SerialNumber_Win32_ComputerSystem;

        public List<Win32_QuickFixEngineering> QuickFixEngineering;

        public Win32_OperatingSystem()
        {
            QuickFixEngineering = new List<Win32_QuickFixEngineering>();
        }
    }
}
