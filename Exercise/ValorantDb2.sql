/*** Delete db if exist ***/
DROP DATABASE IF EXISTS [ValoDb2]
GO

/*** Create db ***/
CREATE DATABASE [ValoDb2]
GO

/*** Use DB ***/
USE [ValoDb2]
GO

/*** Drop Table ***/
DROP TABLE IF EXISTS [dbo].[Agent]
GO

/*** Create Role Table ***/
CREATE TABLE [dbo].[Role]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Description] NVARCHAR(80) NOT NULL,
)
GO


/*** Create Agent table ***/
CREATE TABLE [dbo].[Agent]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [RoleId] INT NOT NULL,
    CONSTRAINT FK_AgentRole FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role](Id)
)
GO

SET IDENTITY_INSERT [dbo].[Role] ON 
INSERT [dbo].[Role] ([Id], [Name], [Description])
VALUES (1, 'Duelist', 'Entry fragger and creates space for the team.');

INSERT [dbo].[Role] ([Id], [Name], [Description])
VALUES (2, 'Controller', 'Controls and divides the map using utilities.');

INSERT [dbo].[Role] ([Id], [Name], [Description])
VALUES (3, 'Initiator', 'Gathering information and control opponents using abililties.');

INSERT [dbo].[Role] ([Id], [Name], [Description])
VALUES (4, 'Sentinel', 'Defensive experts that have abilities that manipulate the battlefield.');

SET IDENTITY_INSERT [dbo].[Role] OFF 

INSERT [dbo].[Agent] ([Name], [Country], [RoleId]) 
VALUES ('Jett', 'Korea', 1);

INSERT [dbo].[Agent] ([Name], [Country], [RoleId]) 
VALUES ('Omen', 'Unknown', 2);

INSERT [dbo].[Agent] ([Name], [Country], [RoleId]) 
VALUES ('Sova', 'Russia', 3);

INSERT [dbo].[Agent] ([Name], [Country], [RoleId]) 
VALUES ('Sage', 'China', 4);

INSERT [dbo].[Agent] ([Name], [Country], [RoleId]) 
VALUES ('Neon', 'Philippines', 1);