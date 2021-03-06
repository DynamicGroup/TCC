USE [DI]
GO
INSERT [dbo].[StartMode] ([Value], [Meaning]) VALUES (N'Boot', N'Device driver started by the operating system loader (valid only for driver services).')
INSERT [dbo].[StartMode] ([Value], [Meaning]) VALUES (N'System', N'Device driver started by the operating system initialization process. This value is valid only for driver services.')
INSERT [dbo].[StartMode] ([Value], [Meaning]) VALUES (N'Auto', N'Service to be started automatically by the service control manager during system startup. Auto services are started even if a user does not log on.')
INSERT [dbo].[StartMode] ([Value], [Meaning]) VALUES (N'Manual', N'Service to be started by the Service Control Manager when a process calls the StartService method. These services do not start unless a user logs on and starts them.')
INSERT [dbo].[StartMode] ([Value], [Meaning]) VALUES (N'Disabled', N'Service that cannot be started until its StartMode is changed to either Auto or Manual.')
