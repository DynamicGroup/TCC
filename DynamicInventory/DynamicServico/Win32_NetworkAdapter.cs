using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_NetworkAdapter
    {
        public string AdapterType;
        public UInt16 AdapterTypeID;
        public bool AutoSense;
        public UInt16 Availability;
        public string Caption;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string GUID;
        public UInt32 Index;
        public DateTime InstallDate;
        public bool Installed;
        public UInt32 InterfaceIndex;
        public UInt32 LastErrorCode;
        public string MACAddress;
        public string Manufacturer;
        public UInt32 MaxNumberControlled;
        public ulong MaxSpeed;
        public string Name;
        public string NetConnectionID;
        public UInt16 NetConnectionStatus;
        public bool NetEnabled;
        public string[] NetworkAddresses;
        public string PermanentAddress;
        public bool PhysicalAdapter;
        public string PNPDeviceID;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProductName;
        public string ServiceName;
        public ulong Speed;
        public string Status;
        public UInt16 StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime TimeOfLastReset;

        public List<Win32_NetworkAdapterConfiguration> NetworkAdapterConfiguration;

        public Win32_NetworkAdapter()
        {
            NetworkAdapterConfiguration = new List<Win32_NetworkAdapterConfiguration>();
        }
    }
}
