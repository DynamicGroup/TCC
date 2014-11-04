--Quantidade Sistema Operacional
select Caption "Sistema Operacional", COUNT(*) "Quantidade" from Win32_OperatingSystem where CADC_Ativo = 1
group by Caption
--Maquinas Inventariadas Hoje
select  Manufacturer, Model, Name, CADC_Ativo "Ativo", CADC_DataColeta "Data Coleta", CADC_DataDesativacao "Data Desativação" 
from Win32_ComputerSystem 
where cast(CADC_DataColeta as date) = cast(GETDATE() as date)
--Maquinas Inventariadas nos ultimos 30 dias
select  Manufacturer, Model, Name, CADC_Ativo "Ativo", CADC_DataColeta "Data Coleta", CADC_DataDesativacao "Data Desativação" 
from Win32_ComputerSystem 
where CADC_DataColeta between DATEADD(DAY, -30, GETDATE()) and GETDATE()
--Maquinas com Memória acima de 2000MB
select  Manufacturer, Model, Name, (TotalPhysicalMemory / 1048576) "Memoria Total (MB)", CADC_Ativo "Ativo", CADC_DataColeta "Data Coleta", CADC_DataDesativacao "Data Desativação" 
from Win32_ComputerSystem 
where (TotalPhysicalMemory / 1048576) >= 2000
--Maquinas com processadores de frequência acima de 2000Mhz
select  c.Manufacturer, Model, c.Name, p.Name "Processador",p.NumberOfCores "Quantidade de Nucleos", p.MaxClockSpeed "Velocidade por Nucleo (Mhz)", c.CADC_Ativo "Ativo", CADC_DataColeta "Data Coleta", c.CADC_DataDesativacao "Data Desativação" 
from Win32_ComputerSystem c
left join Win32_Processor p on p.SerialNumber_Win32_ComputerSystem = c.SerialNumber_Win32_ComputerSystem
where p.MaxClockSpeed >= 2000
--Tipos de maquinas e Quantidades
select p.Meaning "Tipo de PC", COUNT(*) "Quantidade" from Win32_ComputerSystem c
left join PCSystemType p on p.Value = c.PCSystemType
group by p.Meaning