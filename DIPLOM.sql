CREATE DATABASE [PersonnelDepartment]

USE [PersonnelDepartment]

CREATE TABLE [MainInfo]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Name]										NVARCHAR(MAX),
[Surname]									NVARCHAR(MAX),
[Patronymic]								NVARCHAR(MAX),
[ServiceNote]								NVARCHAR(MAX),
[idPhotoEmployee]		INT CONSTRAINT		MainInfo_idPhotoEmployeen_PhotoEmployee_ID					FOREIGN KEY REFERENCES [PhotoEmployee]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
[idAdditionalInformation] INT CONSTRAINT	MainInfo_idAdditionalInformation_AdditionalInformation_ID	FOREIGN KEY REFERENCES [AdditionalInformation]([ID]) ON DELETE CASCADE ON UPDATE CASCADE NOT NULL,
[idPassport] INT CONSTRAINT					MainInfo_idPassport_Passport_ID								FOREIGN KEY REFERENCES [Passport]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
[idEmploymentRecord] INT CONSTRAINT			MainInfo_idEmploymentRecord_EmploymentRecord_ID				FOREIGN KEY REFERENCES [EmploymentRecord]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
[idWorkSchedule] INT CONSTRAINT				MainInfo_idWorkSchedule_WorkSchedule_ID						FOREIGN KEY REFERENCES [WorkSchedule]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,	
[idSalary] INT CONSTRAINT					MainInfo_idSalary_Salary_ID									FOREIGN KEY REFERENCES [Salary]([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
[idEmployeeStatus] INT CONSTRAINT			MainInfo_idEmployeeStatus_EmployeeStatus_ID					FOREIGN KEY REFERENCES [EmployeeStatus]([ID]) ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE [PhotoEmployee]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Photo]			IMAGE
)


CREATE TABLE [EmployeeStatus]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Condition]			NVARCHAR(MAX)
)

CREATE TABLE [AdditionalInformation]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[DateOfBirth]	DATE,
[Nationality]	NVARCHAR(MAX),
[Citizenship]	NVARCHAR(MAX),
[PhoneNumber]	NVARCHAR(MAX),
[idGender]		INT CONSTRAINT				AdditionalInformation_idGender_GenderTable_ID				FOREIGN KEY REFERENCES [GenderTable]([ID])   NOT NULL
)

CREATE TABLE [GenderTable]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Gender] NVARCHAR(MAX)
)

CREATE TABLE [Passport]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Issued]		NVARCHAR(MAX),
[DateOfIssue]	DATE,
[DivisionCode]	NVARCHAR(MAX),
[SerialNumber]	NVARCHAR(MAX),
[PassportCode]	NVARCHAR(MAX)
)

CREATE TABLE [WorkSchedule]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[StartDate] DATE,
[ShiftType]	NVARCHAR(MAX)
)

CREATE TABLE [EmploymentRecord]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[Education]				NVARCHAR(MAX),
[Specialization]		NVARCHAR(MAX),
[DateOfFillingIn]		DATE,
[TotalWorkExperience]	NVARCHAR(MAX)
)



CREATE TABLE [Salary]
(
[ID] INT IDENTITY (1,1) PRIMARY KEY,
[TheAmount]				NVARCHAR(MAX),
[Allowance]				NVARCHAR(MAX),
[LastIssueDate]			DATE
)