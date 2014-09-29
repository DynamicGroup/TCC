using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    public static class Query
    {
        public static string columnInfoQuery = "SELECT c.name ColumnName,t.name as TypeName,c.max_Length as Max_Length,c.is_nullable as Is_Nullable  FROM sys.columns c "
        + "JOIN sys.types AS t ON c.user_type_id=t.user_type_id where object_id=Object_Id('{0}')";
        public static string insertWin32_ComputerSystem = "INSERT INTO dbo.Win32_ComputerSystem (AdminPasswordStatus ,AutomaticManagedPagefile ,AutomaticResetBootOption ,AutomaticResetCapability ,BootOptionOnLimit ,BootOptionOnWatchDog ,BootROMSupported ,BootupState ,Caption ,ChassisBootupState ,CreationClassName ,CurrentTimeZone ,DaylightInEffect ,Description ,DNSHostName ,Domain ,DomainRole ,EnableDaylightSavingsTime ,FrontPanelResetStatus ,InfraredSupported ,InitialLoadInfo ,InstallDate ,KeyboardPasswordStatus ,LastLoadInfo ,Manufacturer ,Model ,Name ,NameFormat ,NetworkServerModeEnabled ,NumberOfLogicalProcessors ,NumberOfProcessors ,OEMLogoBitmap ,OEMStringArray ,PartOfDomain ,PauseAfterReset ,PCSystemType ,PowerManagementCapabilities ,PowerManagementSupported ,PowerOnPasswordStatus ,PowerState ,PowerSupplyState ,PrimaryOwnerContact ,PrimaryOwnerName ,ResetCapability ,ResetCount ,ResetLimit ,Roles ,Status ,SupportContactDescription ,SystemStartupDelay ,SystemStartupOptions ,SystemStartupSetting ,SystemType ,ThermalState ,TotalPhysicalMemory ,UserName ,WakeUpType ,Workgroup ,SerialNumber) VALUES (@AdminPasswordStatus ,@AutomaticManagedPagefile ,@AutomaticResetBootOption ,@AutomaticResetCapability ,@BootOptionOnLimit ,@BootOptionOnWatchDog ,@BootROMSupported ,@BootupState ,@Caption ,@ChassisBootupState ,@CreationClassName ,@CurrentTimeZone ,@DaylightInEffect ,@Description ,@DNSHostName ,@Domain ,@DomainRole ,@EnableDaylightSavingsTime ,@FrontPanelResetStatus ,@InfraredSupported ,@InitialLoadInfo ,@InstallDate ,@KeyboardPasswordStatus ,@LastLoadInfo ,@Manufacturer ,@Model ,@Name ,@NameFormat ,@NetworkServerModeEnabled ,@NumberOfLogicalProcessors ,@NumberOfProcessors ,@OEMLogoBitmap ,@OEMStringArray ,@PartOfDomain ,@PauseAfterReset ,@PCSystemType ,@PowerManagementCapabilities ,@PowerManagementSupported ,@PowerOnPasswordStatus ,@PowerState ,@PowerSupplyState ,@PrimaryOwnerContact ,@PrimaryOwnerName ,@ResetCapability ,@ResetCount ,@ResetLimit ,@Roles ,@Status ,@SupportContactDescription ,@SystemStartupDelay ,@SystemStartupOptions ,@SystemStartupSetting ,@SystemType ,@ThermalState ,@TotalPhysicalMemory ,@UserName ,@WakeUpType ,@Workgroup ,@SerialNumber)";
        public static string insertOEMStringArray = "INSERT INTO OEMStringArray (OEMStringArray, SerialNumber) VALUES (@OEMStringArray, @SerialNumber)";
        public static string insertWin32_ComputerSystem_PowerManagementCapabilities = "INSERT INTO Win32_ComputerSystem_PowerManagementCapabilities (Value, SerialNumber) VALUES (@Value, @SerialNumber)";
        public static string insertRoles = "INSERT INTO Roles (Roles, SerialNumber) VALUES (@Roles, @SerialNumber)";
        public static string insertSupportContactDescription = "INSERT INTO SupportContactDescription (SupportContactDescription, SerialNumber) VALUES (@SupportContactDescription, @SerialNumber)";
        public static string insertSystemStartupOptions = "INSERT INTO SystemStartupOptions (SystemStartupOptions, SerialNumber) VALUES (@SystemStartupOptions, @SerialNumber)";
    }
}
