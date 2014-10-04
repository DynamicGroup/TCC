using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_MonitorDetails
    {
        public string PnPID;
        public string SerialNumber;
        public string Model;
        public string MonitorID;
        public string Name;
        public string SizeDiagInch;
        public string SizeHorCM;
        public string SizeVerCM;

        public string SerialNumber_Win32_ComputerSystem;

        public Win32_MonitorDetails(string sPnPID, string sSerialNumber, string sModel, string sMonitorID, string sName, string sSize, string sHSize, string sVSize)
        {
            PnPID = sPnPID;
            SerialNumber = sSerialNumber;
            Model = sModel;
            MonitorID = sMonitorID;
            Name = sName;
            SizeDiagInch = sSize;
            SizeHorCM = sHSize;
            SizeVerCM = sVSize;
        }
    }
}
