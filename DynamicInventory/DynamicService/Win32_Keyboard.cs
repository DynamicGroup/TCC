using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_Keyboard
    {
        public ushort? Availability;
        public string Caption;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public string Description;
        public string DeviceID;
        public bool ErrorCleared;
        public string ErrorDescription;
        public DateTime? InstallDate;
        public bool IsLocked;
        public uint? LastErrorCode;
        public string Layout;
        public string Name;
        public ushort? NumberOfFunctionKeys;
        public ushort? Password;
        public string PNPDeviceID;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_Keyboard()
        {

        }
    }
}
