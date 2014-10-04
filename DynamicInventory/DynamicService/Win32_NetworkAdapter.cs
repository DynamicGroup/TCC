using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_NetworkAdapter
    {
        public string AdapterType;
        public ushort? AdapterTypeID;
        public bool AutoSense;
        public ushort? Availability;
        public string Caption;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string GUID;
        public uint? Index;
        public DateTime? InstallDate;
        public bool Installed;
        public uint? InterfaceIndex;
        public uint? LastErrorCode;
        public string MACAddress;
        public string Manufacturer;
        public uint? MaxNumberControlled;
        public ulong? MaxSpeed;
        public string Name;
        public string NetConnectionID;
        public ushort? NetConnectionStatus;
        public bool NetEnabled;
        public string[] NetworkAddresses;
        public string PermanentAddress;
        public bool PhysicalAdapter;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProductName;
        public string ServiceName;
        public ulong? Speed;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime? TimeOfLastReset;

        public string SerialNumber_Win32_ComputerSystem;

        public List<Win32_NetworkAdapterConfiguration> NetworkAdapterConfiguration;

        public Win32_NetworkAdapter()
        {
            NetworkAdapterConfiguration = new List<Win32_NetworkAdapterConfiguration>();
        }
    }
}
