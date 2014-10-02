using System;

namespace DynamicService
{
    class Win32_BIOS
    {
        public ushort[] BiosCharacteristics;
        public string[] BIOSVersion;
        public string BuildNumber;
        public string Caption;
        public string CodeSet;
        public string CurrentLanguage;
        public string Description;
        public string IdentificationCode;
        public ushort? InstallableLanguages;
        public DateTime? InstallDate;
        public string LanguageEdition;
        public string[] ListOfLanguages;
        public string Manufacturer;
        public string Name;
        public string OtherTargetOS;
        public bool PrimaryBIOS;
        public DateTime? ReleaseDate;
        public string SerialNumber;
        public string SMBIOSBIOSVersion;
        public ushort? SMBIOSMajorVersion;
        public ushort? SMBIOSMinorVersion;
        public bool SMBIOSPresent;
        public string SoftwareElementID;
        public ushort? SoftwareElementState;
        public string Status;
        public ushort? TargetOperatingSystem;
        public string Version;

        public Win32_BIOS()
        {

        }
    }
}
