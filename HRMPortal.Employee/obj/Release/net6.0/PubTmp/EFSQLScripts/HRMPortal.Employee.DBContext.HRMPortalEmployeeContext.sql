IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [Addresse] (
        [Id] int NOT NULL IDENTITY,
        [SuiteNumber] nvarchar(max) NOT NULL,
        [StreetLine] nvarchar(max) NOT NULL,
        [LandMark] nvarchar(max) NOT NULL,
        [Area] nvarchar(max) NOT NULL,
        [ZipCode] int NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [StateCode] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [Country] nvarchar(max) NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Addresse] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [EmployeeDetail] (
        [Id] int NOT NULL IDENTITY,
        [EmployeeCode] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [FirstName] nvarchar(max) NOT NULL,
        [MiddleName] nvarchar(max) NOT NULL,
        [LastName] nvarchar(max) NOT NULL,
        [Gender] int NOT NULL,
        [PersonalEmail] nvarchar(max) NOT NULL,
        [BusinessEmail] nvarchar(max) NOT NULL,
        [MobileNumber] nvarchar(max) NOT NULL,
        [BusinessUnit] nvarchar(max) NOT NULL,
        [Designation] int NOT NULL,
        [DateOfJoining] date NOT NULL,
        [ConfirmationDate] date NOT NULL,
        [AppraisalDate] date NOT NULL,
        [TotalExprience] float NOT NULL,
        [PermanentAddressId] int NULL,
        [PresentAddressId] int NULL,
        [EmergencyNumber] nvarchar(max) NULL,
        [BloodGroup] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_EmployeeDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EmployeeDetail_Addresse_PermanentAddressId] FOREIGN KEY ([PermanentAddressId]) REFERENCES [Addresse] ([Id]),
        CONSTRAINT [FK_EmployeeDetail_Addresse_PresentAddressId] FOREIGN KEY ([PresentAddressId]) REFERENCES [Addresse] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [BankDetail] (
        [Id] int NOT NULL IDENTITY,
        [Accounttype] int NULL,
        [AccountName] nvarchar(max) NOT NULL,
        [AccountNumber] float NOT NULL,
        [IFSCCode] nvarchar(max) NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_BankDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BankDetail_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [Document] (
        [Id] int NOT NULL IDENTITY,
        [DocumentName] nvarchar(max) NOT NULL,
        [DocumentTypes] int NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Document] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Document_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [EducationDetail] (
        [Id] int NOT NULL IDENTITY,
        [Certification] int NOT NULL,
        [DegreeName] nvarchar(max) NOT NULL,
        [YearOfPassing] date NOT NULL,
        [Score] nvarchar(max) NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_EducationDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_EducationDetail_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [LeaveBalance] (
        [Id] int NOT NULL IDENTITY,
        [LeaveType] int NOT NULL,
        [TotalLeave] float NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_LeaveBalance] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_LeaveBalance_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [Leaves] (
        [Id] int NOT NULL IDENTITY,
        [Guid] uniqueidentifier NOT NULL,
        [LeaveTypes] int NOT NULL,
        [LeaveDuration] int NOT NULL,
        [FromDate] datetime2 NOT NULL,
        [ToDate] datetime2 NOT NULL,
        [TotalDays] int NOT NULL,
        [Reason] nvarchar(max) NOT NULL,
        [LeaveStatus] int NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Leaves] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Leaves_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [PreviousExprience] (
        [Id] int NOT NULL IDENTITY,
        [CompanyName] nvarchar(max) NOT NULL,
        [Designation] nvarchar(max) NOT NULL,
        [DateOfJoining] date NOT NULL,
        [DateOfRelieving] date NOT NULL,
        [TotalExprience] float NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_PreviousExprience] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PreviousExprience_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE TABLE [Salary] (
        [Id] int NOT NULL IDENTITY,
        [UANNumber] nvarchar(max) NOT NULL,
        [PFNumber] nvarchar(max) NOT NULL,
        [ESICNumber] nvarchar(max) NOT NULL,
        [BankDetailId] int NOT NULL,
        [EmployeeDetailId] int NOT NULL,
        [CreatedBy] int NOT NULL,
        [UpdatedBy] int NOT NULL,
        [CreatedAt] datetime2 NOT NULL,
        [UpdatedAt] datetime2 NOT NULL,
        CONSTRAINT [PK_Salary] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Salary_BankDetail_BankDetailId] FOREIGN KEY ([BankDetailId]) REFERENCES [BankDetail] ([Id]),
        CONSTRAINT [FK_Salary_EmployeeDetail_EmployeeDetailId] FOREIGN KEY ([EmployeeDetailId]) REFERENCES [EmployeeDetail] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_BankDetail_EmployeeDetailId] ON [BankDetail] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_Document_EmployeeDetailId] ON [Document] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_EducationDetail_EmployeeDetailId] ON [EducationDetail] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_EmployeeDetail_PermanentAddressId] ON [EmployeeDetail] ([PermanentAddressId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_EmployeeDetail_PresentAddressId] ON [EmployeeDetail] ([PresentAddressId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_LeaveBalance_EmployeeDetailId] ON [LeaveBalance] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_Leaves_EmployeeDetailId] ON [Leaves] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_PreviousExprience_EmployeeDetailId] ON [PreviousExprience] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_Salary_BankDetailId] ON [Salary] ([BankDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    CREATE INDEX [IX_Salary_EmployeeDetailId] ON [Salary] ([EmployeeDetailId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230330111439_Inital')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230330111439_Inital', N'6.0.5');
END;
GO

COMMIT;
GO

