using System;

namespace DynamicService
{
    class Win32_Printer
    {
        public uint? Attributes;
        public ushort? Availability;
        public string[] AvailableJobSheets;
        public uint? AveragePagesPerMinute;
        public ushort[] Capabilities;
        public string[] CapabilityDescriptions;
        public string Caption;
        public string[] CharSetsSupported;
        public string Comment;
        public uint? ConfigManagerErrorCode;
        public bool ConfigManagerUserConfig;
        public string CreationClassName;
        public ushort[] CurrentCapabilities;
        public string CurrentCharSet;
        public ushort? CurrentLanguage;
        public string CurrentMimeType;
        public string CurrentNaturalLanguage;
        public string CurrentPaperType;
        public bool Default;
        public ushort[] DefaultCapabilities;
        public uint? DefaultCopies;
        public ushort? DefaultLanguage;
        public string DefaultMimeType;
        public uint? DefaultNumberUp;
        public string DefaultPaperType;
        public uint? DefaultPriority;
        public string Description;
        public ushort? DetectedErrorState;
        public string DeviceID;
        public bool Direct;
        public bool DoCompleteFirst;
        public string DriverName;
        public bool EnableBIDI;
        public bool EnableDevQueryPrint;
        public bool ErrorCleared;
        public string ErrorDescription;
        public string[] ErrorInformation;
        public ushort? ExtendedDetectedErrorState;
        public ushort? ExtendedPrinterStatus;
        public bool Hidden;
        public uint? HorizontalResolution;
        public DateTime? InstallDate;
        public uint? JobCountSinceLastReset;
        public bool KeepPrintedJobs;
        public ushort[] LanguagesSupported;
        public uint? LastErrorCode;
        public bool Local;
        public string Location;
        public ushort? MarkingTechnology;
        public uint? MaxCopies;
        public uint? MaxNumberUp;
        public uint? MaxSizeSupported;
        public string[] MimeTypesSupported;
        public string Name;
        public string[] NaturalLanguagesSupported;
        public bool Network;
        public ushort[] PaperSizesSupported;
        public string[] PaperTypesAvailable;
        public string Parameters;
        public string PNPDeviceID;
        public string PortName;
        public ushort[] PowerManagementCapabilities;
        public bool PowerManagementSupported;
        public string[] PrinterPaperNames;
        public uint? PrinterState;
        public ushort? PrinterStatus;
        public string PrintJobDataType;
        public string PrintProcessor;
        public uint? Priority;
        public bool Published;
        public bool Queued;
        public bool RawOnly;
        public string SeparatorFile;
        public string ServerName;
        public bool Shared;
        public string ShareName;
        public bool SpoolEnabled;
        public DateTime? StartTime;
        public string Status;
        public ushort? StatusInfo;
        public string SystemCreationClassName;
        public string SystemName;
        public DateTime? TimeOfLastReset;
        public DateTime? UntilTime;
        public uint? VerticalResolution;
        public bool WorkOffline;

        public Win32_Printer()
        {

        }
    }
}
