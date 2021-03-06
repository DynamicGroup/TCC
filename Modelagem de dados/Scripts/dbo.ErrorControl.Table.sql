USE [DI]
GO
INSERT [dbo].[ErrorControl] ([Value], [Meaning]) VALUES (N'Ignore', N'User is not notified.')
INSERT [dbo].[ErrorControl] ([Value], [Meaning]) VALUES (N'Normal', N'User is notified. Usually this will be a message box display notifying the user of the problem.')
INSERT [dbo].[ErrorControl] ([Value], [Meaning]) VALUES (N'Severe', N'System is restarted with the last-known-good configuration.')
INSERT [dbo].[ErrorControl] ([Value], [Meaning]) VALUES (N'Critical', N'System attempts to restart with a good configuration. If the service fails to start a second time, startup fails.')
INSERT [dbo].[ErrorControl] ([Value], [Meaning]) VALUES (N'Unknown', N'Severity of the error is unknown.')
