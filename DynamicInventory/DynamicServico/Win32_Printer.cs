using System;

namespace DynamicService
{
    class Win32_Printer
    {
        public int Attributes;
        public short Availability;
        public string[] AvailableJobSheets;
        public int AveragePagesPerMinute;
        public short[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string[] CharSetsSupported;
        public string Comment;
        public int ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public short[] CurrentCapabilities;
        public string CurrentCharSet;
        public short CurrentLanguage;
        public string CurrentMimeType;
        public string CurrentNaturalLanguage;
        public string CurrentPaperType;
        public bool Default;
        public short[] DefaultCapabilities;
        public int DefaultCopies;
        public short DefaultLanguage;
        public string DefaultMimeType;
        public int DefaultNumberUp;
        public string DefaultPaperType;
        public int DefaultPriority;
        public string Description;
        public short DetectedErrorState;
        public string DeviceID;
        public bool Direct;
        public bool DoCompleteFirst;
        public string DriverName;
        public bool EnableBIDI;
        public bool EnableDevQueryPrint;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string[] ErrorInformation;
        public short ExtendedDetectedErrorState;
        public short ExtendedPrinterStatus;
        public bool Hidden;
        public int HorizontalResolution;
        public DateTime InstallDate;
        public int JobCountSinceLastReset;
        public bool KeepPrintedJobs;
        public short[] LanguagesSupported;
        public int LastErrorCode;
        public bool Local;
        public string Location;
        public short MarkingTechnology;
        public int MaxCopies;
        public int MaxNumberUp;
        public int MaxSizeSupported;
        public string[] MimeTypesSupported;
        public string Name;
        public string[] NaturalLanguagesSupported;
        public bool Network;
        public short[] PaperSizesSupported;
        public string[] PaperTypesAvailable;
        public string Parameters;
        public string PNPDeviceID;
        public string PortName;
        public short[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string[] PrinterPaperNames;
        public int PrinterState;
        public short PrinterStatus;
        public string PrintJobDataType;
        public string PrintProcessor;
        public int Priority;
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
        public short StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime TimeOfLastReset;
        public DateTime UntilTime;
        public int VerticalResolution;
        public bool WorkOffline;


        public Win32_Printer()
        {

        }
    }
}
