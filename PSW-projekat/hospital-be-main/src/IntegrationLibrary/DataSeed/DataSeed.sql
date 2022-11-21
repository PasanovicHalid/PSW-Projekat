USE [IntegrationDb]
GO
SET IDENTITY_INSERT [dbo].[BloodRequests] ON 

INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment], [BloodBankId]) VALUES (1, '2022-11-16 11:30:00', 5, 'Need it for operation', 5, 0, 0, null, 0)
SET IDENTITY_INSERT [dbo].[BloodRequests] OFF