﻿using System;
using System.Collections.Generic;

namespace DynamicService
{
    class Win32_NetworkAdapter
    {
        public string AdapterType;
        public short AdapterTypeID;
        public bool AutoSense;
        public short Availability;
        public string Caption;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string GUID;
        public int Index;
        public DateTime InstallDate;
        public bool Installed;
        public int InterfaceIndex;
        public int LastErrorCode;
        public string MACAddress;
        public string Manufacturer;
        public int MaxNumberControlled;
        public long MaxSpeed;
        public string Name;
        public string NetConnectionID;
        public short NetConnectionStatus;
        public bool NetEnabled;
        public string[] NetworkAddresses;
        public string PermanentAddress;
        public bool PhysicalAdapter;
        public string PNPDeviceID;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string ProductName;
        public string ServiceName;
        public long Speed;
        public string Status;
        public short StatusInfo;
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
