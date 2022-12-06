USE [IntegrationDb]
GO
SET IDENTITY_INSERT [dbo].[BloodRequests] ON 
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (1, '2022-11-16 11:30:00', 5, 'Need it for operation', 5, 0, 0, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (2, '2022-11-17 11:30:00', 1, 'Need it for operation', 3, 0, 1, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (3, '2022-11-11 11:30:00', 2, 'Need it for operation', 3, 1, 2, null, 1)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (4, '2022-11-16 11:30:00', 3, 'Need it for operation', 4, 1, 3, null, 2)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (5, '2022-11-18 11:30:00', 4, 'Need it for operation', 3, 1, 4, null, 3)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (6, '2022-11-19 11:30:00', 5, 'Need it for operation', 4, 1, 5, null, 1)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (7, '2022-11-21 11:30:00', 6, 'Need it for operation', 4, 1, 0, null, 2)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (8, '2022-11-16 11:30:00', 7, 'Need it for operation', 4, 1, 4, null, 2)
SET IDENTITY_INSERT [dbo].[BloodRequests] OFF

GO
SET IDENTITY_INSERT [dbo].[ReportSettings] ON 
INSERT [dbo].[ReportSettings] ([Id], [StartDeliveryDate], [CalculationDays], [CalculationMonths], [CalculationYears], [DeliveryDays], [DeliveryMonths], [DeliveryYears]) VALUES (1, '2022-11-16 11:30:00', 0, 1, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[ReportSettings] OFF

GO
SET IDENTITY_INSERT [dbo].[BloodBanks] ON 
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress]) VALUES (1, 1, '4rijtG2K/XHcaesRU2gLHS5LC0QJoqMmKGKQrj4OmNLoxQjsjwUc+w60BFi3fR+0pO/BtrSma8yEJ1+bwAoQHQ==', 'bloodymary@gmail.com', 'Bloody Mary', '123', '5lSxho6OJIAMKE2CzURTLcpOPIVeCp5becYHSgj26BIpLcE5DXARRiJFUtPupqpNWdIFqY1EhEFNx1QQsTFxbj', 'http://localhost:8086/')
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress]) VALUES (2, 0, 'W3QW1vpKFX9NUJ94HF0klON+lRaPBaSgx7mwAgV0b0ml4uVu7t2+2FoNDLqweFKzw4drCuaf0mPRbylQaja3Nw==', 'bloodyhell@gmail.com', 'Bloody Hell', 'sTDtSjegVZykV1EC', '4UHf68tCV7GfsjAyYtCnackqmphU28PzwH7AFNHARy3PnMLuDbFD5Ec3Q2nBX8JW2rkXnQSTCvfeklOOgqwhH7', 'http://localhost:8086/')
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress]) VALUES (3, 0, 'tLeiJ6w79JdrILqI34F6kYM3UAWENV8RjeZvi0LVtJochrXWJ7mpt0Cdedka8lVWUPnCFLZOhJbcS8ao9VFgwQ==', 'newlife@gmail.com', 'New Life', 'sTDtSjegVZykV1EC', '4UHf68tCV7GfsjAyYtCnackqmphU28PzwH7AFNHARy3PnMLuDbFD5Ec3Q2nBX8JW2rkXnQSTCvfeklOOgqwhH7', 'http://localhost:8086/')
SET IDENTITY_INSERT [dbo].[BloodBanks] OFF

GO
SET IDENTITY_INSERT [dbo].[Newses] ON 
INSERT [dbo].[Newses] ([Id], [Title], [Text], [Status], [DateTime], [BloodBankId]) VALUES (1, 'sadfasddas', 'sadsdasdasdasda', 0, '2022-11-16 11:30:00', 1)
SET IDENTITY_INSERT [dbo].[Newses] OFF

GO
SET IDENTITY_INSERT [dbo].[Tenders] ON 
INSERT [dbo].[Tenders] ([Id], [DueDate], [State]) VALUES (1, '2022-12-12 12:00:00', 0)
SET IDENTITY_INSERT [dbo].[Tenders] OFF

GO
SET IDENTITY_INSERT [dbo].[Demands] ON 
INSERT [dbo].[Demands] ([Id], [BloodType], [Quantity], [TenderId]) VALUES (1, 0, 5, 1)
INSERT [dbo].[Demands] ([Id], [BloodType], [Quantity], [TenderId]) VALUES (2, 3, 3, 1)
INSERT [dbo].[Demands] ([Id], [BloodType], [Quantity], [TenderId]) VALUES (3, 5, 7, 1)
SET IDENTITY_INSERT [dbo].[Demands] OFF