IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE[name] = 'TEK-Careers')
BEGIN
	CREATE DATABASE [TEK-Careers]
END

GO
USE [TEK-Careers]

IF NOT EXISTS (SELECT [name] FROM sys.Tables WHERE[name] = 'Departments')
BEGIN
	CREATE TABLE [dbo].[Departments](
		[ID] [bigint] NOT NULL IDENTITY (1, 1),		
		[Title] [varchar](200) NOT NULL,
		[CreatedDate] [datetime] NOT NULL,
		[UpdatedDate] [datetime] NOT NULL,
		[IsActive] [bit] NOT NULL,
		CONSTRAINT [PK_Departments_ID] PRIMARY KEY NONCLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80));
		
	SELECT 'Departments Table created successfully'	
END

IF NOT EXISTS (SELECT [name] FROM sys.Tables WHERE[name] = 'Locations')
BEGIN
	CREATE TABLE [dbo].[Locations](
		[ID] [bigint] NOT NULL IDENTITY (1, 1),
		[Title] [varchar](200) NOT NULL,
		[City] [varchar](50) NOT NULL,
		[State] [varchar](50) NOT NULL,
		[Country] [varchar](50) NOT NULL,
		[Zip] [bigint] NOT NULL,
		[CreatedDate] [datetime] NOT NULL,
		[UpdatedDate] [datetime] NOT NULL,
		[IsActive] [bit] NOT NULL,
		CONSTRAINT [PK_Locations_ID] PRIMARY KEY NONCLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80));
		
	SELECT 'Locations Table created successfully'	
END



IF NOT EXISTS (SELECT [name] FROM sys.Tables WHERE[name] = 'Jobs')
BEGIN
	CREATE TABLE dbo.[Jobs] (
	[ID]		  BIGINT IDENTITY (1, 1) NOT NULL,	
	[Code]        VARCHAR(200)      NOT NULL,	
	[Title]        VARCHAR(200)      NOT NULL,	
	[Description]        VARCHAR(200)      NOT NULL,	
	[DepartmentID]      BIGINT NULL, 
	[LocationID]      BIGINT NULL, 
	[PostedDate] DATETIME NOT NULL,
	[ClosingDate] DATETIME NOT NULL,
	[CreatedDate] DATETIME NOT NULL,
	[UpdatedDate] DATETIME NOT NULL,
	[IsActive]    BIT      NOT NULL,
	CONSTRAINT [PK_Jobs_ID] PRIMARY KEY NONCLUSTERED ([ID] ASC) WITH (FILLFACTOR = 80)
	);		

	ALTER TABLE [Jobs] WITH NOCHECK
	ADD CONSTRAINT [FK_Jobs_DepartmentID_Department_ID]
	FOREIGN KEY ([DepartmentID])
	REFERENCES [Departments] ([ID])
	ON DELETE NO ACTION ON UPDATE NO ACTION;   	
		
	ALTER TABLE [Jobs] WITH NOCHECK
	ADD CONSTRAINT [FK_Jobs_LocationID_Location_ID]
	FOREIGN KEY ([LocationID])
	REFERENCES [Locations] ([ID])
	ON DELETE NO ACTION ON UPDATE NO ACTION;   	
			
	SELECT 'Jobs Table created successfully'	
END