using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_ComputerSystem
    {
        public short AdminPasswordStatus;
        public bool AutomaticManagedPagefile;
        public bool AutomaticResetBootOption;
        public bool AutomaticResetCapability;
        public short BootOptionOnLimit;
        public short BootOptionOnWatchDog;
        public bool BootROMSupported;
        public string BootupState;
        public string Caption;
        public short ChassisBootupState;
        public string CreationClassName;
        public short CurrentTimeZone;
        public bool DaylightInEffect;
        public string Description;
        public string DNSHostName;
        public string Domain;
        public short DomainRole;
        public bool EnableDaylightSavingsTime;
        public short FrontPanelResetStatus;
        public bool InfraredSupported;
        public string InitialLoadInfo;
        public DateTime InstallDate;
        public short KeyboardPasswordStatus;
        public string LastLoadInfo;
        public string Manufacturer;
        public string Model;
        public string Name;
        public string NameFormat;
        public bool NetworkServerModeEnabled;
        public int NumberOfLogicalProcessors;
        public int NumberOfProcessors;
        public byte[] OEMLogoBitmap;
        public string[] OEMStringArray;
        public bool PartOfDomain;
        public long PauseAfterReset;
        public short PCSystemType;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public short PowerOnPasswordStatus;
        public short PowerState;
        public short PowerSupplyState;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public short ResetCapability;
        public short ResetCount;
        public short ResetLimit;
        public string[] Roles;
        public string Status;
        public string[] SupportContactDescription;
        public short SystemStartupDelay;
        public string[] SystemStartupOptions;
        public byte SystemStartupSetting;
        public string SystemType;
        public short ThermalState;
        public long TotalPhysicalMemory;
        public string UserName;
        public short WakeUpType;
        public string Workgroup;

        public string SerialNumber;


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
