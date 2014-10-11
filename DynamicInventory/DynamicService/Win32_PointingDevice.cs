using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_PointingDevice
    {
        public ushort? Availability;
        public string Caption;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public ushort? DeviceInterface;
        public uint? DoubleSpeedThreshold;
        public bool ErrorCleared;
        public string ErrorDescription;
        public ushort? Handedness;
        public string HardwareType;
        public string InfFileName;
        public string InfSection;
        public DateTime? InstallDate;
        public bool IsLocked;
        public uint? LastErrorCode;
        public string Manufacturer;
        public string Name;
        public byte? NumberOfButtons;
        public string PNPDeviceID;
        public ushort? PointingType;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public uint? QuadSpeedThreshold;
        public uint? Resolution;
        public uint? SampleRate;
        public string Status;
        public ushort? StatusInfo;
        public uint? Synch;
        public string SystemCreationClassName;
        public string SystemName;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_PointingDevice()
        {

        }
    }
}
