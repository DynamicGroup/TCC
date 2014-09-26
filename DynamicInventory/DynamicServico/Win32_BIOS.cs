using System;

namespace DynamicService
{
    class Win32_BIOS
    {
        public short[] BiosCharacteristics;
        public string[] BIOSVersion;
        public string BuildNumber;
        public string Caption;
        public string CodeSet;
        public string CurrentLanguage;
        public string Description;
        public string IdentificationCode;
        public short InstallableLanguages;
        public DateTime InstallDate;
        public string LanguageEdition;
        public string[] ListOfLanguages;
        public string Manufacturer;
        public string Name;
        public string OtherTargetOS;
        public bool PrimaryBIOS;
        public DateTime ReleaseDate;
        public string SerialNumber;
        public string SMBIOSBIOSVersion;
        public short SMBIOSMajorVersion;
        public short SMBIOSMinorVersion;
        public bool SMBIOSPresent;
        public string SoftwareElementID;
        public short SoftwareElementState;
        public string Status;
        public short TargetOperatingSystem;
        public string Version;


        public Win32_BIOS()
        {

        }
    }
}
