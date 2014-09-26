using System;

namespace DynamicService
{
    class Win32_Service
    {
        public bool AcceptPause;
        public bool AcceptStop;
        public string Caption;
        public int CheckPoint;
        public string CreationClassName;
        public string Description;
        public bool DesktopInteract;
        public string DisplayName;
        public string ErrorControl;
        public int ExitCode;
        public DateTime InstallDate;
        public string Name;
        public string PathName;
        public int ProcessId;
        public int ServiceSpecificExitCode;
        public string ServiceType;
        public bool Started;
        public string StartMode;
        public string StartName;
        public string State;
        public string Status;
        public string SystemCreationClassName;
        public string SystemName;
        public int TagId;
        public int WaitHint;

        public Win32_Service()
        {

        }
    }
}
