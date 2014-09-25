using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_Printer
    {
        public UInt32 Attributes;
        public UInt16 Availability;
        public string[] AvailableJobSheets;
        public UInt32 AveragePagesPerMinute;
        public UInt16[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string[] CharSetsSupported;
        public string Comment;
        public UInt32 ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public UInt16[] CurrentCapabilities;
        public string CurrentCharSet;
        public UInt16 CurrentLanguage;
        public string CurrentMimeType;
        public string CurrentNaturalLanguage;
        public string CurrentPaperType;
        public bool Default;
        public UInt16[] DefaultCapabilities;
        public UInt32 DefaultCopies;
        public UInt16 DefaultLanguage;
        public string DefaultMimeType;
        public UInt32 DefaultNumberUp;
        public string DefaultPaperType;
        public UInt32 DefaultPriority;
        public string Description;
        public UInt16 DetectedErrorState;
        public string DeviceID;
        public bool Direct;
        public bool DoCompleteFirst;
        public string DriverName;
        public bool EnableBIDI;
        public bool EnableDevQueryPrint;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string[] ErrorInformation;
        public UInt16 ExtendedDetectedErrorState;
        public UInt16 ExtendedPrinterStatus;
        public bool Hidden;
        public UInt32 HorizontalResolution;
        public DateTime InstallDate;
        public UInt32 JobCountSinceLastReset;
        public bool KeepPrintedJobs;
        public UInt16[] LanguagesSupported;
        public UInt32 LastErrorCode;
        public bool Local;
        public string Location;
        public UInt16 MarkingTechnology;
        public UInt32 MaxCopies;
        public UInt32 MaxNumberUp;
        public UInt32 MaxSizeSupported;
        public string[] MimeTypesSupported;
        public string Name;
        public string[] NaturalLanguagesSupported;
        public bool Network;
        public UInt16[] PaperSizesSupported;
        public string[] PaperTypesAvailable;
        public string Parameters;
        public string PNPDeviceID;
        public string PortName;
        public UInt16[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string[] PrinterPaperNames;
        public UInt32 PrinterState;
        public UInt16 PrinterStatus;
        public string PrintJobDataType;
        public string PrintProcessor;
        public UInt32 Priority;
        public bool Published;
        public bool Queued;
        public bool RawOnly;
        public string SeparatorFile;
        public string ServerName;
        public bool Shared;
        public string ShareName;
        public bool SpoolEnabled;
        public DateTime StartTime;
        public string Status;
        public UInt16 StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime TimeOfLastReset;
        public DateTime UntilTime;
        public UInt32 VerticalResolution;
        public bool WorkOffline;

        public Win32_Printer()
        {

        }
    }
}
