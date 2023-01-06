USE [IntegrationDb]
GO
SET IDENTITY_INSERT [dbo].[BloodRequests] ON 
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (1, '2022-12-16 11:30:00', 1, 'Need it for operation', 5, 0, 0, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (2, '2022-12-17 11:30:00', 1, 'Need it for operation', 3, 0, 1, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (3, '2022-12-11 11:30:00', 1, 'Need it for operation', 3, 0, 2, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (4, '2023-01-16 11:30:00', 3, 'Need it for operation', 4, 1, 3, null, 2)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (5, '2022-12-18 11:30:00', 4, 'Need it for operation', 3, 1, 4, null, 3)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (6, '2022-12-19 11:30:00', 5, 'Need it for operation', 4, 1, 5, null, 1)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (7, '2022-12-21 11:30:00', 6, 'Need it for operation', 4, 1, 0, null, 2)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (8, '2022-12-12 11:30:00', 7, 'Need it for operation', 4, 0, 4, null, 0)
INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (9, '2022-12-12 11:30:00', 2, 'Need it for operation', 4, 1, 6, null, 2)
SET IDENTITY_INSERT [dbo].[BloodRequests] OFF

GO
SET IDENTITY_INSERT [dbo].[ReportSettings] ON 
INSERT [dbo].[ReportSettings] ([Id], [StartDeliveryDate], [CalculationDays], [CalculationMonths], [CalculationYears], [DeliveryDays], [DeliveryMonths], [DeliveryYears]) VALUES (1, '2022-11-16 11:30:00', 0, 1, 0, 0, 1, 0)
SET IDENTITY_INSERT [dbo].[ReportSettings] OFF

GO
SET IDENTITY_INSERT [dbo].[BloodBanks] ON 
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress], [GRPCServerAddress]) VALUES (1, 1, '4rijtG2K/XHcaesRU2gLHS5LC0QJoqMmKGKQrj4OmNLoxQjsjwUc+w60BFi3fR+0pO/BtrSma8yEJ1+bwAoQHQ==', '{"LocalPart": "bloodymary", "DomainName": "gmail.com"}', 'Bloody Mary', '123', '5lSxho6OJIAMKE2CzURTLcpOPIVeCp5becYHSgj26BIpLcE5DXARRiJFUtPupqpNWdIFqY1EhEFNx1QQsTFxbj', 'http://localhost:8086/', 'localhost:12689')
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress], [GRPCServerAddress]) VALUES (2, 1, 'W3QW1vpKFX9NUJ94HF0klON+lRaPBaSgx7mwAgV0b0ml4uVu7t2+2FoNDLqweFKzw4drCuaf0mPRbylQaja3Nw==', '{"LocalPart": "bloodyhell", "DomainName": "gmail.com"}', 'Bloody Hell', '123', '4UHf68tCV7GfsjAyYtCnackqmphU28PzwH7AFNHARy3PnMLuDbFD5Ec3Q2nBX8JW2rkXnQSTCvfeklOOgqwhH7', 'http://localhost:8086/', null)
INSERT [dbo].[BloodBanks] ([Id], [AccountStatus], [ApiKey], [Email], [Name], [Password], [PasswordResetKey], [ServerAddress], [GRPCServerAddress]) VALUES (3, 1, 'tLeiJ6w79JdrILqI34F6kYM3UAWENV8RjeZvi0LVtJochrXWJ7mpt0Cdedka8lVWUPnCFLZOhJbcS8ao9VFgwQ==', '{"LocalPart": "newlife", "DomainName": "gmail.com"}', 'New Life', '123', '4UHf68tCV7GfsjAyYtCnackqmphU28PzwH7AFNHARy3PnMLuDbFD5Ec3Q2nBX8JW2rkXnQSTCvfeklOOgqwhH7', 'http://localhost:8086/', 'localhost:12689')

SET IDENTITY_INSERT [dbo].[BloodBanks] OFF

GO
SET IDENTITY_INSERT [dbo].[Newses] ON 
INSERT [dbo].[Newses] ([Id], [Title], [Text], [Status], [DateTime], [BloodBankId]) VALUES (1, 'sadfasddas', 'sadsdasdasdasda', 0, '2022-11-16 11:30:00', 1)
SET IDENTITY_INSERT [dbo].[Newses] OFF


GO
SET IDENTITY_INSERT [dbo].[Tenders] ON 
INSERT [dbo].[Tenders] ([Id], [DueDate], [State], [Demands], [Bids]) VALUES (1, '2022-12-31 11:30:00', 0, '[{"BloodType":1,"Quantity":5},{"BloodType":5,"Quantity":9}]', '[{"DeliveryDate":"2022-12-30T17:26:21.8995755+01:00","Price":1000,"BloodBankId":1,"Status":0},{"DeliveryDate":"2022-12-30T17:26:21.8999264+01:00","Price":1000,"BloodBankId":2,"Status":0},{"DeliveryDate":"2022-12-30T17:26:22.3624763+01:00","Price":3000,"BloodBankId":1,"Status":0}]')
SET IDENTITY_INSERT [dbo].[Tenders] OFF

