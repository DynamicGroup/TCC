USE [DI]
GO
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (0, N'Unknown')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (1, N'CPU Enabled')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (2, N'CPU Disabled by User via BIOS Setup')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (3, N'CPU Disabled by BIOS (POST Error)')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (4, N'CPU Is Idle')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (5, N'Reserved')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (6, N'Reserved')
INSERT [dbo].[CpuStatus] ([Value], [Meaning]) VALUES (7, N'Other')
