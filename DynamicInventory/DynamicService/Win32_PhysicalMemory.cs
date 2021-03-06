﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PhysicalMemory
    {
        public string BankLabel;
        public ulong? Capacity;
        public string Caption;
        public string CreationClassName;
        public ushort? DataWidth;
        public string Description;
        public string DeviceLocator;
        public ushort? FormFactor;
        public bool HotSwappable;
        public DateTime? InstallDate;
        public ushort? InterleaveDataDepth;
        public uint? InterleavePosition;
        public string Manufacturer;
        public ushort? MemoryType;
        public string Model;
        public string Name;
        public string OtherIdentifyingInfo;
        public string PartNumber;
        public uint? PositionInRow;
        public bool PoweredOn;
        public bool Removable;
        public bool Replaceable;
        public string SerialNumber;
        public string SKU;
        public uint? Speed;
        public string Status;
        public string Tag;
        public ushort? TotalWidth;
        public ushort? TypeDetail;
        public string Version;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_PhysicalMemory()
        {

        }
    }
}
