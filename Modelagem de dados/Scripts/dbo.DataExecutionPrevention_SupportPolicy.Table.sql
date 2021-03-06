USE [DI]
GO
INSERT [dbo].[DataExecutionPrevention_SupportPolicy] ([Value], [Meaning]) VALUES (0, N'DEP is turned off for all 32-bit applications on the computer with no exceptions. This setting is not available for the user interface.')
INSERT [dbo].[DataExecutionPrevention_SupportPolicy] ([Value], [Meaning]) VALUES (1, N'DEP is enabled for all 32-bit applications on the computer. This setting is not available for the user interface.')
INSERT [dbo].[DataExecutionPrevention_SupportPolicy] ([Value], [Meaning]) VALUES (2, N'DEP is enabled for a limited number of binaries, the kernel, and all Windows-based services. However, it is off by default for all 32-bit applications.')
INSERT [dbo].[DataExecutionPrevention_SupportPolicy] ([Value], [Meaning]) VALUES (3, N'DEP is enabled by default for all 32-bit applications. A user or administrator can explicitly remove support for a 32-bit application by adding the application to an exceptions list.')
