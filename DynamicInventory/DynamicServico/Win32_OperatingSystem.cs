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
        public short CurrentTimeZone;
        public bool DataExecutionPrevention_Available;
        public bool DataExecutionPrevention_32BitApplications;
        public bool DataExecutionPrevention_Drivers;
        public byte DataExecutionPrevention_SupportPolicy;
        public bool Debug;
        public string Description;
        public bool Distributed;
        public int EncryptionLevel;
        public byte ForegroundApplicationBoost;
        public long FreePhysicalMemory;
        public long FreeSpaceInPagingFiles;
        public long FreeVirtualMemory;
        public DateTime InstallDate;
        public int LargeSystemCache;
        public DateTime LastBootUpTime;
        public DateTime LocalDateTime;
        public string Locale;
        public string Manufacturer;
        public int MaxNumberOfProcesses;
        public long MaxProcessMemorySize;
        public string[] MUILanguages;
        public string Name;
        public int NumberOfLicensedUsers;
        public int NumberOfProcesses;
        public int NumberOfUsers;
        public int OperatingSystemSKU;
        public string Organization;
        public string OSArchitecture;
        public int OSLanguage;
        public int OSProductSuite;
        public short OSType;
        public string OtherTypeDescription;
        public bool PAEEnabled;
        public string PlusProductID;
        public string PlusVersionNumber;
        public bool PortableOperatingSystem;
        public bool Primary;
        public int ProductType;
        public string RegisteredUser;
        public string SerialNumber;
        public short ServicePackMajorVersion;
        public short ServicePackMinorVersion;
        public long SizeStoredInPagingFiles;
        public string Status;
        public int SuiteMask;
        public string SystemDevice;
        public string SystemDirectory;
        public string SystemDrive;
        public long TotalSwapSpaceSize;
        public long TotalVirtualMemorySize;
        public long TotalVisibleMemorySize;
        public string Version;
        public string WindowsDirectory;


        public List<Win32_QuickFixEngineering> QuickFixEngineering;

        public Win32_OperatingSystem()
        {
            QuickFixEngineering = new List<Win32_QuickFixEngineering>();
        }
    }
}
