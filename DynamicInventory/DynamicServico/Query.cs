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

        public static string GetPrimaryKey = "SELECT B.COLUMN_NAME" +
        " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS A, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE B" +
        " WHERE CONSTRAINT_TYPE = 'PRIMARY KEY' AND A.CONSTRAINT_NAME = B.CONSTRAINT_NAME" +
        " AND A.TABLE_NAME='{0}'";

        public static string Win32_ComputerSystem = "IF EXISTS(SELECT 1 FROM dbo.Win32_ComputerSystem WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem) "+
        "UPDATE dbo.Win32_ComputerSystem SET AdminPasswordStatus = @AdminPasswordStatus, AutomaticManagedPagefile = @AutomaticManagedPagefile, AutomaticResetBootOption = @AutomaticResetBootOption, AutomaticResetCapability = @AutomaticResetCapability, BootOptionOnLimit = @BootOptionOnLimit, BootOptionOnWatchDog = @BootOptionOnWatchDog, BootROMSupported = @BootROMSupported, BootupState = @BootupState, Caption = @Caption, ChassisBootupState = @ChassisBootupState, CreationClassName = @CreationClassName, CurrentTimeZone = @CurrentTimeZone, DaylightInEffect = @DaylightInEffect, Description = @Description, DNSHostName = @DNSHostName, Domain = @Domain, DomainRole = @DomainRole, EnableDaylightSavingsTime = @EnableDaylightSavingsTime, FrontPanelResetStatus = @FrontPanelResetStatus, InfraredSupported = @InfraredSupported, InitialLoadInfo = @InitialLoadInfo, InstallDate = @InstallDate, KeyboardPasswordStatus = @KeyboardPasswordStatus, LastLoadInfo = @LastLoadInfo, Manufacturer = @Manufacturer, Model = @Model, Name = @Name, NameFormat = @NameFormat, NetworkServerModeEnabled = @NetworkServerModeEnabled, NumberOfLogicalProcessors = @NumberOfLogicalProcessors, NumberOfProcessors = @NumberOfProcessors, OEMLogoBitmap = @OEMLogoBitmap, OEMStringArray = @OEMStringArray, PartOfDomain = @PartOfDomain, PauseAfterReset = @PauseAfterReset, PCSystemType = @PCSystemType, PowerManagementCapabilities = @PowerManagementCapabilities, PowerManagementSupported = @PowerManagementSupported, PowerOnPasswordStatus = @PowerOnPasswordStatus, PowerState = @PowerState, PowerSupplyState = @PowerSupplyState, PrimaryOwnerContact = @PrimaryOwnerContact, PrimaryOwnerName = @PrimaryOwnerName, ResetCapability = @ResetCapability, ResetCount = @ResetCount, ResetLimit = @ResetLimit, Roles = @Roles, Status = @Status, SupportContactDescription = @SupportContactDescription, SystemStartupDelay = @SystemStartupDelay, SystemStartupOptions = @SystemStartupOptions, SystemStartupSetting = @SystemStartupSetting, SystemType = @SystemType, ThermalState = @ThermalState, TotalPhysicalMemory = @TotalPhysicalMemory, UserName = @UserName, WakeUpType = @WakeUpType, Workgroup = @Workgroup, SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem "+
        "ELSE "+
        "INSERT INTO dbo.Win32_ComputerSystem (AdminPasswordStatus ,AutomaticManagedPagefile ,AutomaticResetBootOption ,AutomaticResetCapability ,BootOptionOnLimit ,BootOptionOnWatchDog ,BootROMSupported ,BootupState ,Caption ,ChassisBootupState ,CreationClassName ,CurrentTimeZone ,DaylightInEffect ,Description ,DNSHostName ,Domain ,DomainRole ,EnableDaylightSavingsTime ,FrontPanelResetStatus ,InfraredSupported ,InitialLoadInfo ,InstallDate ,KeyboardPasswordStatus ,LastLoadInfo ,Manufacturer ,Model ,Name ,NameFormat ,NetworkServerModeEnabled ,NumberOfLogicalProcessors ,NumberOfProcessors ,OEMLogoBitmap ,OEMStringArray ,PartOfDomain ,PauseAfterReset ,PCSystemType ,PowerManagementCapabilities ,PowerManagementSupported ,PowerOnPasswordStatus ,PowerState ,PowerSupplyState ,PrimaryOwnerContact ,PrimaryOwnerName ,ResetCapability ,ResetCount ,ResetLimit ,Roles ,Status ,SupportContactDescription ,SystemStartupDelay ,SystemStartupOptions ,SystemStartupSetting ,SystemType ,ThermalState ,TotalPhysicalMemory ,UserName ,WakeUpType ,Workgroup ,SerialNumber_Win32_ComputerSystem) VALUES (@AdminPasswordStatus ,@AutomaticManagedPagefile ,@AutomaticResetBootOption ,@AutomaticResetCapability ,@BootOptionOnLimit ,@BootOptionOnWatchDog ,@BootROMSupported ,@BootupState ,@Caption ,@ChassisBootupState ,@CreationClassName ,@CurrentTimeZone ,@DaylightInEffect ,@Description ,@DNSHostName ,@Domain ,@DomainRole ,@EnableDaylightSavingsTime ,@FrontPanelResetStatus ,@InfraredSupported ,@InitialLoadInfo ,@InstallDate ,@KeyboardPasswordStatus ,@LastLoadInfo ,@Manufacturer ,@Model ,@Name ,@NameFormat ,@NetworkServerModeEnabled ,@NumberOfLogicalProcessors ,@NumberOfProcessors ,@OEMLogoBitmap ,@OEMStringArray ,@PartOfDomain ,@PauseAfterReset ,@PCSystemType ,@PowerManagementCapabilities ,@PowerManagementSupported ,@PowerOnPasswordStatus ,@PowerState ,@PowerSupplyState ,@PrimaryOwnerContact ,@PrimaryOwnerName ,@ResetCapability ,@ResetCount ,@ResetLimit ,@Roles ,@Status ,@SupportContactDescription ,@SystemStartupDelay ,@SystemStartupOptions ,@SystemStartupSetting ,@SystemType ,@ThermalState ,@TotalPhysicalMemory ,@UserName ,@WakeUpType ,@Workgroup ,@SerialNumber_Win32_ComputerSystem)";

        public static string OEMStringArrayDelete = "DELETE FROM OEMStringArray WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem;";
        public static string OEMStringArrayInsert = "INSERT INTO OEMStringArray (OEMStringArray, SerialNumber_Win32_ComputerSystem) VALUES (@OEMStringArray, @SerialNumber_Win32_ComputerSystem);";

        public static string Win32_ComputerSystem_PowerManagementCapabilitiesDelete = "DELETE FROM Win32_ComputerSystem_PowerManagementCapabilities WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
        public static string Win32_ComputerSystem_PowerManagementCapabilitiesInsert = "INSERT INTO Win32_ComputerSystem_PowerManagementCapabilities (Value, SerialNumber) VALUES (@Value, @SerialNumber)";

        public static string RolesDelete = "DELETE FROM Roles WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
        public static string RolesInsert = "INSERT INTO Roles (Roles, SerialNumber_Win32_ComputerSystem) VALUES (@Roles, @SerialNumber_Win32_ComputerSystem)";

        public static string SupportContactDescriptionDelete = "DELETE FROM SupportContactDescription WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
        public static string SupportContactDescriptionInsert = "INSERT INTO SupportContactDescription (SupportContactDescription, SerialNumber_Win32_ComputerSystem) VALUES (@SupportContactDescription, @SerialNumber_Win32_ComputerSystem)";

        public static string SystemStartupOptionsDelete = "DELETE FROM SystemStartupOptions WHERE SerialNumber_Win32_ComputerSystem = @SerialNumber_Win32_ComputerSystem";
        public static string SystemStartupOptionsInsert = "INSERT INTO SystemStartupOptions (SystemStartupOptions, SerialNumber_Win32_ComputerSystem) VALUES (@SystemStartupOptions, @SerialNumber_Win32_ComputerSystem)";
    }
}
