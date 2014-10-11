using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_ComputerSystem
    {
        public ushort? AdminPasswordStatus;
        public bool AutomaticManagedPagefile;
        public bool AutomaticResetBootOption;
        public bool AutomaticResetCapability;
        public ushort? BootOptionOnLimit;
        public ushort? BootOptionOnWatchDog;
        public bool BootROMSupported;
        public string BootupState;
        public string Caption;
        public ushort? ChassisBootupState;
        public string CreationClassName;
        public short? CurrentTimeZone;
        public bool DaylightInEffect;
        public string Description;
        public string DNSHostName;
        public string Domain;
        public ushort? DomainRole;
        public bool EnableDaylightSavingsTime;
        public ushort? FrontPanelResetStatus;
        public bool InfraredSupported;
        public string InitialLoadInfo;
        public DateTime? InstallDate;
        public ushort? KeyboardPasswordStatus;
        public string LastLoadInfo;
        public string Manufacturer;
        public string Model;
        public string Name;
        public string NameFormat;
        public bool NetworkServerModeEnabled;
        public uint? NumberOfLogicalProcessors;
        public uint? NumberOfProcessors;
        public byte[] OEMLogoBitmap;
        public string[] OEMStringArray;
        public bool PartOfDomain;
        public long? PauseAfterReset;
        public ushort? PCSystemType;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public ushort? PowerOnPasswordStatus;
        public ushort? PowerState;
        public ushort? PowerSupplyState;
        public string PrimaryOwnerContact;
        public string PrimaryOwnerName;
        public ushort? ResetCapability;
        public short? ResetCount;
        public short? ResetLimit;
        public string[] Roles;
        public string Status;
        public string[] SupportContactDescription;
        public ushort? SystemStartupDelay;
        public string[] SystemStartupOptions;
        public byte? SystemStartupSetting;
        public string SystemType;
        public ushort? ThermalState;
        public ulong? TotalPhysicalMemory;
        public string UserName;
        public ushort? WakeUpType;
        public string Workgroup;

        public string SerialNumber_Win32_ComputerSystem;

        public List<Win32_BaseBoard> BaseBoard;
        public List<Win32_BootConfiguration> BootConfiguration;
        public List<Win32_CDROMDrive> CDROMDrive;
        public List<Win32_ComputerSystemProduct> ComputerSystemProduct;
        public List<Win32_DiskDrive> DiskDrive;
        public List<Win32_Keyboard> Keyboard;
        public List<Win32_MonitorDetails> MonitorDetails;
        public List<Win32_NetworkAdapter> NetworkAdapter;
        public List<Win32_OperatingSystem> OperatingSystem;
        public List<Win32_PhysicalMemory> PhysicalMemory;
        public List<Win32_PointingDevice> PointingDevice;
        public List<Win32_Printer> Printer;
        public List<Win32_Processor> Processor;
        public List<Win32_Product> Product;
        public List<Win32_Service> Service;
        public List<Win32_VideoController> VideoController;

        public Win32_ComputerSystem()
        {
            BaseBoard = new List<Win32_BaseBoard>();
            BootConfiguration = new List<Win32_BootConfiguration>();
            CDROMDrive = new List<Win32_CDROMDrive>();
            ComputerSystemProduct = new List<Win32_ComputerSystemProduct>();
            DiskDrive = new List<Win32_DiskDrive>();
            Keyboard = new List<Win32_Keyboard>();
            NetworkAdapter = new List<Win32_NetworkAdapter>();
            OperatingSystem = new List<Win32_OperatingSystem>();
            PhysicalMemory = new List<Win32_PhysicalMemory>();
            PointingDevice = new List<Win32_PointingDevice>();
            Printer = new List<Win32_Printer>();
            Processor = new List<Win32_Processor>();
            Product = new List<Win32_Product>();
            Service = new List<Win32_Service>();
            VideoController = new List<Win32_VideoController>();
        }
    }
}
