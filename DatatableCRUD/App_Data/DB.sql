CREATE TABLE [dbo].[Employees] (
    [EmployeeId] INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (50)  NOT NULL,
    [LastName]   NVARCHAR (50)  NOT NULL,
    [EmailID]    NVARCHAR (200) NULL,
    [City]       NVARCHAR (50)  NULL,
    [Country]    NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC)
);




SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (1, N'Nancy', N'Davolio', N'nancy@gmail.com', N'507 - 20th Ave. E.', N'Seattle')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (2, N'Janet', N'Leverling', N'janet@gmail.com', N'722 Moss Bay Blvd.', N'Kirkland')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (3, N'Margaret', N'Peacock', N'Margaret@gmail.com', N'4110 Old Redmond Rd.', N'Redmond')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (4, N'Steven', N'Buchanan', N'steven@gmail.com', N'14 Garrett Hill', N'London')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (5, N'Michael', N'Suyama', N'michael@gmail.com', N'Coventry House Miner Rd.', N'London')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (6, N'Robert', N'King', N'robert@gmail.com', N'Edgeham Hollow Winchester Way', N'London')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (7, N'Laura', N'Callahan', N'laura@gmail.com', N'4726 - 11th Ave. N.E.', N'Seattle')
INSERT INTO [dbo].[Employees] ([EmployeeId], [FirstName], [LastName], [EmailID], [City], [Country]) VALUES (8, N'Anne', N'Dodsworth', N'Anne@gmail.com', N'7 Houndsooth Rd.', N'London')
SET IDENTITY_INSERT [dbo].[Employees] OFF