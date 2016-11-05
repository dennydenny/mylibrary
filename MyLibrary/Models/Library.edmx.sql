
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/05/2016 16:45:08
-- Generated from EDMX file: C:\Developer\C#\MyLibrary\MyLibrary\Models\Library.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyLibrary];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CardSet] DROP CONSTRAINT [FK_BookCard];
GO
IF OBJECT_ID(N'[dbo].[FK_ReaderCard]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CardSet] DROP CONSTRAINT [FK_ReaderCard];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BookSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookSet];
GO
IF OBJECT_ID(N'[dbo].[ReaderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReaderSet];
GO
IF OBJECT_ID(N'[dbo].[CardSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CardSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BookSet'
CREATE TABLE [dbo].[BookSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Year] int  NOT NULL,
    [Publishing] nvarchar(max)  NOT NULL,
    [Discription] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Count] int  NOT NULL
);
GO

-- Creating table 'ReaderSet'
CREATE TABLE [dbo].[ReaderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CardSet'
CREATE TABLE [dbo].[CardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookId1] int  NOT NULL,
    [ReaderId1] int  NOT NULL,
    [Direction] int  NOT NULL,
    [Timestamp] datetime  NOT NULL,
    [Count] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BookSet'
ALTER TABLE [dbo].[BookSet]
ADD CONSTRAINT [PK_BookSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReaderSet'
ALTER TABLE [dbo].[ReaderSet]
ADD CONSTRAINT [PK_ReaderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [PK_CardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BookId1] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [FK_BookCard]
    FOREIGN KEY ([BookId1])
    REFERENCES [dbo].[BookSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookCard'
CREATE INDEX [IX_FK_BookCard]
ON [dbo].[CardSet]
    ([BookId1]);
GO

-- Creating foreign key on [ReaderId1] in table 'CardSet'
ALTER TABLE [dbo].[CardSet]
ADD CONSTRAINT [FK_ReaderCard]
    FOREIGN KEY ([ReaderId1])
    REFERENCES [dbo].[ReaderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ReaderCard'
CREATE INDEX [IX_FK_ReaderCard]
ON [dbo].[CardSet]
    ([ReaderId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------