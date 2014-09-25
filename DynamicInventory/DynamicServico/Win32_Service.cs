using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_Service
    {
        public bool AcceptPause;
        public bool AcceptStop;
        public string Caption;
        public UInt32 CheckPoint;
        public string CreationClassName;
        public string Description;
        public bool DesktopInteract;
        public string DisplayName;
        public string ErrorControl;
        public UInt32 ExitCode;
        public DateTime InstallDate;
        public string Name;
        public string PathName;
        public UInt32 ProcessId;
        public UInt32 ServiceSpecificExitCode;
        public string ServiceType;
        public bool Started;
        public string StartMode;
        public string StartName;
        public string State;
        public string Status;
        public string SystemCreationClassName;
        public string SystemName;
        public UInt32 TagId;
        public UInt32 WaitHint;

        public Win32_Service()
        {

        }
    }
}
