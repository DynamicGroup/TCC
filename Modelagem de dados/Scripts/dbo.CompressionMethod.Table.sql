USE [DI]
GO
INSERT [dbo].[CompressionMethod] ([Value], [Meaning]) VALUES (N'Unknown', N'Whether the device supports compression capabilities or not is not known.')
INSERT [dbo].[CompressionMethod] ([Value], [Meaning]) VALUES (N'Compressed', N'The device supports compression capabilities but its compression scheme is not known or not disclosed.')
INSERT [dbo].[CompressionMethod] ([Value], [Meaning]) VALUES (N'Not Compressed', N'The device does not support compression.')
