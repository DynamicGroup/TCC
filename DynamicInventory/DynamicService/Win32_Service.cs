using System;

namespace DynamicService
{
    class Win32_Service
    {
        public bool AcceptPause;
        public bool AcceptStop;
        public string Caption;
        public uint? CheckPoint;
        public string CreationClassName;
        public string Description;
        public bool DesktopInteract;
        public string DisplayName;
        public string ErrorControl;
        public uint? ExitCode;
        public DateTime? InstallDate;
        public string Name;
        public string PathName;
        public uint? ProcessId;
        public uint? ServiceSpecificExitCode;
        public string ServiceType;
        public bool Started;
        public string StartMode;
        public string StartName;
        public string State;
        public string Status;
        public string SystemCreationClassName;
        public string SystemName;
        public uint? TagId;
        public uint? WaitHint;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_Service()
        {

        }
    }
}
