USE [IntegrationDb]
GO
SET IDENTITY_INSERT [dbo].[BloodRequests] ON 
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (1, '2022-11-16 11:30:00', 5, 'Need it for operation', 5, 0, 0, null, 0)
SET IDENTITY_INSERT [dbo].[BloodRequests] OFF

GO
SET IDENTITY_INSERT [dbo].[ReportSettings] ON 
INSERT [dbo].[ReportSettings] ([Id], [StartDeliveryDate], [CalculationDays], [CalculationMonths], [CalculationYears], [DeliveryDays], [DeliveryMonths], [DeliveryYears]) VALUES (1, '2022-11-16 11:30:00', 1, 0, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[ReportSettings] OFF

GO
SET IDENTITY_INSERT [dbo].[BloodBanks] ON 
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress]) VALUES (1, 0, 'T/CRVF6LGXrz052+le+XV+/js62cbXWi4PdWo0AcVHdG6bGDTiNxz6eTEg9wSmaQ6p/CmRhC+8uVNwZeDMJvMg==', 'bloodymary@gmail.com', 'Bloody Mary', 'ldyYwFG6d1BZJ0fO', '5lSxho6OJIAMKE2CzURTLcpOPIVeCp5becYHSgj26BIpLcE5DXARRiJFUtPupqpNWdIFqY1EhEFNx1QQsTFxbj', 'https://www.instagram.com/')
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress]) VALUES (2, 0, 'xQQ7XWi00MaJ/jNcf+KjqjJMIDf+q0jOGNnUL1AP80cLsxDug1vx7j14X76G14+zKOeXXEckrHsdUB4YU//u9Q==', 'bloodyhell@gmail.com', 'Bloody Hell', 'sTDtSjegVZykV1EC', '4UHf68tCV7GfsjAyYtCnackqmphU28PzwH7AFNHARy3PnMLuDbFD5Ec3Q2nBX8JW2rkXnQSTCvfeklOOgqwhH7', 'https://www.instagram.com/123')
SET IDENTITY_INSERT [dbo].[BloodBanks] OFF

GO
SET IDENTITY_INSERT [dbo].[Newses] ON 
INSERT [dbo].[Newses] ([Id], [Name], [DateTime], [BloodBankId], [Status]) VALUES (1, 'sadfasddas', '2022-11-16 11:30:00', 1, 0)
SET IDENTITY_INSERT [dbo].[Newses] OFF