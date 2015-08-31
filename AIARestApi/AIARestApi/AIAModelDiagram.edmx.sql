
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/27/2015 15:15:09
-- Generated from EDMX file: C:\Projects\Team4\AIARestApi\AIARestApi\AIAModelDiagram.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
--USE [WebAgentProDb];
--GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_QuoteDriver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Drivers] DROP CONSTRAINT [FK_QuoteDriver];
GO
IF OBJECT_ID(N'[dbo].[FK_VehicleDriver]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_VehicleDriver];
GO
IF OBJECT_ID(N'[dbo].[FK_QuoteVehicle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [FK_QuoteVehicle];
GO
IF OBJECT_ID(N'[dbo].[FK_UserQuote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Quotes] DROP CONSTRAINT [FK_UserQuote];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Drivers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Drivers];
GO
IF OBJECT_ID(N'[dbo].[Quotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Quotes];
GO
IF OBJECT_ID(N'[dbo].[Rules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rules];
GO
IF OBJECT_ID(N'[dbo].[AIAUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AIAUsers];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Drivers'
CREATE TABLE [dbo].[Drivers] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [NameSuffix] nvarchar(5)  NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [MiddleInitial] nvarchar(1)  NULL,
    [Address] nvarchar(255)  NOT NULL,
    [Phone] nvarchar(14)  NOT NULL,
    [Dob] datetime  NOT NULL,
    [Ssn] nvarchar(11)  NOT NULL,
    [Gender] nchar(1)  NOT NULL,
    [Relationship] nvarchar(15)  NOT NULL,
    [LicenseState] nchar(2)  NOT NULL,
    [LicenseNumber] nvarchar(20)  NOT NULL,
    [LicenseDateStart] datetime  NOT NULL,
    [SafeDrivingSchool] bit  NOT NULL,
    [QuoteId] bigint  NOT NULL,
    [NonDriver] bit  NOT NULL
);
GO

-- Creating table 'Quotes'
CREATE TABLE [dbo].[Quotes] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [AIAUserId] int  NOT NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Submitted] bit  NOT NULL,
    [SubmissionTime] datetime  NOT NULL,
    [State] nchar(2)  NOT NULL,
    [MovingViolation] bit  NOT NULL,
    [PreviousCarrier] nvarchar(50)  NOT NULL,
    [ClaimInLastFive] bit  NOT NULL,
    [CustomerFirstName] nvarchar(30)  NOT NULL,
    [CustomerLastName] nvarchar(30)  NOT NULL,
    [CustomerAddress] nvarchar(255)  NOT NULL,
    [CustomerPhone] nvarchar(14)  NOT NULL,
    [CustomerSsn] nvarchar(11)  NOT NULL,
    [CustomerDob] datetime  NOT NULL,
    [ForceMultiDiscount] bit  NOT NULL
);
GO

-- Creating table 'Rules'
CREATE TABLE [dbo].[Rules] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [Scope] nvarchar(10)  NOT NULL,
    [State] nchar(2)  NOT NULL,
    [DiscountPercentage] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'AIAUsers'
CREATE TABLE [dbo].[AIAUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(15)  NOT NULL,
    [FirstName] nvarchar(30)  NOT NULL,
    [LastName] nvarchar(30)  NOT NULL,
    [CanUseSystem] int  NOT NULL,
    [ApplicationUserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Make] nvarchar(20)  NOT NULL,
    [CarModel] nvarchar(20)  NOT NULL,
    [Year] int  NOT NULL,
    [Mileage] decimal(18,0)  NOT NULL,
    [CurrentValue] int  NOT NULL,
    [DaysDrivenPerWeek] int  NOT NULL,
    [Vin] nvarchar(30)  NOT NULL,
    [AnnualMiles] decimal(18,0)  NOT NULL,
    [HasDaytimeRunningLights] bit  NOT NULL,
    [HasAntilockBrakingSystem] bit  NOT NULL,
    [PassiveRestraints] bit  NOT NULL,
    [AntiTheft] bit  NOT NULL,
    [ReduceUse] bit  NOT NULL,
    [GarageDifferent] bit  NOT NULL,
    [QuoteId] bigint  NOT NULL,
    [MilesDrivenToWork] decimal(18,0)  NOT NULL,
    [DriverId] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [PK_Drivers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [PK_Quotes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rules'
ALTER TABLE [dbo].[Rules]
ADD CONSTRAINT [PK_Rules]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AIAUsers'
ALTER TABLE [dbo].[AIAUsers]
ADD CONSTRAINT [PK_AIAUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [QuoteId] in table 'Drivers'
ALTER TABLE [dbo].[Drivers]
ADD CONSTRAINT [FK_QuoteDriver]
    FOREIGN KEY ([QuoteId])
    REFERENCES [dbo].[Quotes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuoteDriver'
CREATE INDEX [IX_FK_QuoteDriver]
ON [dbo].[Drivers]
    ([QuoteId]);
GO

-- Creating foreign key on [DriverId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_VehicleDriver]
    FOREIGN KEY ([DriverId])
    REFERENCES [dbo].[Drivers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehicleDriver'
CREATE INDEX [IX_FK_VehicleDriver]
ON [dbo].[Vehicles]
    ([DriverId]);
GO

-- Creating foreign key on [QuoteId] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [FK_QuoteVehicle]
    FOREIGN KEY ([QuoteId])
    REFERENCES [dbo].[Quotes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_QuoteVehicle'
CREATE INDEX [IX_FK_QuoteVehicle]
ON [dbo].[Vehicles]
    ([QuoteId]);
GO

-- Creating foreign key on [AIAUserId] in table 'Quotes'
ALTER TABLE [dbo].[Quotes]
ADD CONSTRAINT [FK_UserQuote]
    FOREIGN KEY ([AIAUserId])
    REFERENCES [dbo].[AIAUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserQuote'
CREATE INDEX [IX_FK_UserQuote]
ON [dbo].[Quotes]
    ([AIAUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------