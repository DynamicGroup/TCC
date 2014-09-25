using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_ComputerSystem
    {
        public UInt16 AdminPasswordStatus;
        public bool AutomaticManagedPagefile;
        public bool AutomaticResetBootOption;
        public bool AutomaticResetCapability;
        public UInt16 BootOptionOnLimit;
        public UInt16 BootOptionOnWatchDog;
        public bool BootROMSupported;
        public string BootupState;
        public string Caption;
        public UInt16 ChassisBootupState;
        public string CreationClassName;
        public short CurrentTimeZone;
        public bool DaylightInEffect;
        public string Description;
        public string DNSHostName;
        public string Domain;
        public UInt16 DomainRole;
        public bool EnableDaylightSavingsTime;
        public UInt16 FrontPanelResetStatus;
        public bool InfraredSupported;
        public string InitialLoadInfo;
        public DateTime InstallDate;
        public UInt16 KeyboardPasswordStatus;
        public string LastLoadInfo;
        public string Manufacturer;
        public string Model;
        public string Name;
        public string NameFormat;
        public bool NetworkServerModeEnabled;
        public UInt32 NumberOfLogicalProcessors;
        public UInt32 NumberOfProcessors;
        public byte[] OEMLogoBitmap;
        public string[] OEMpublic;
        public bool PartOfDomain;
        public long PauseAfterReset;
        public UInt16 PCSystemType;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public UInt16 PowerOnPasswordStatus;
        public UInt16 PowerState;
        public UInt16 PowerSupplyState;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public UInt16 ResetCapability;
        public short ResetCount;
        public short ResetLimit;
        public string[] Roles;
        public string Status;
        public string[] SupportContactDescription;
        public UInt16 SystemStartupDelay;
        public string[] SystemStartupOptions;
        public byte SystemStartupSetting;
        public string SystemType;
        public UInt16 ThermalState;
        public UInt64 TotalPhysicalMemory;
        public string UserName;
        public UInt16 WakeUpType;
        public string Workgroup;

        public List<Win32_BaseBoard> BaseBoard;
        public List<Win32_BIOS> BIOS;
        public List<Win32_BootConfiguration> BootConfiguration;
        public List<Win32_CDROMDrive> CDROMDrive;
        public List<Win32_ComputerSystemProduct> ComputerSystemProduct;
        public List<Win32_DiskDrive> DiskDrive;
        public List<Win32_NetworkAdapter> NetworkAdapter;
        public List<Win32_OperatingSystem> OperatingSystem;
        public List<Win32_Printer> Printer;
        public List<Win32_Processor> Processor;
        public List<Win32_Product> Product;
        public List<Win32_Service> Service;

        public Win32_ComputerSystem()
        {
            BaseBoard = new List<Win32_BaseBoard>();
            BIOS = new List<Win32_BIOS>();
            BootConfiguration = new List<Win32_BootConfiguration>();
            CDROMDrive = new List<Win32_CDROMDrive>();
            ComputerSystemProduct = new List<Win32_ComputerSystemProduct>();
            DiskDrive = new List<Win32_DiskDrive>();
            NetworkAdapter = new List<Win32_NetworkAdapter>();
            OperatingSystem = new List<Win32_OperatingSystem>();
            Printer = new List<Win32_Printer>();
            Processor = new List<Win32_Processor>();
            Product = new List<Win32_Product>();
            Service = new List<Win32_Service>();
        }
    }
}
