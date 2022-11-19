USE [IntegrationDb]
GO
SET IDENTITY_INSERT [dbo].[BloodRequests] ON 

INSERT [dbo].[BloodRequests] ([Id], [RequiredForDate], [BloodQuantity], [Reason], [DoctorId], [RequestState], [BloodType], [Comment]) VALUES (1, '2022-11-16 11:30:00', 5, 'Need it for operation', 4, 0, 0, null)
SET IDENTITY_INSERT [dbo].[BloodRequests] OFF