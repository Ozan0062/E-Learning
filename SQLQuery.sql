CREATE TABLE [dbo].[User] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Email]       NVARCHAR (MAX) NOT NULL,
    [Password]    NVARCHAR (MAX) NOT NULL,
    [Address]    NVARCHAR (MAX) NOT NULL,
    [City]        NVARCHAR (MAX) NOT NULL,
    [PostalCode]  INT            NOT NULL,
    [PhoneNumber] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PostalCode] CHECK ([PostalCode]>=(0) AND [PostalCode]<=(9999)),
    CONSTRAINT [CK_PhoneNumber] CHECK ([PhoneNumber]>=(0) AND [PhoneNumber]<=(9999999999.))
);

CREATE TABLE [dbo].[Admin] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]    INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PhoneNumber_Admin] CHECK ([PhoneNumber] BETWEEN 0 AND 9999999999)
);

CREATE TABLE [dbo].[Instructor] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]   INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PhoneNumber_Instructor] CHECK ([PhoneNumber] >= 0 AND [PhoneNumber] <= 9999999999)
);

CREATE TABLE [dbo].[Course] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [EducationId] INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Course_Education_EducationId] FOREIGN KEY ([EducationId]) REFERENCES [dbo].[Education] ([Id])
);

INSERT INTO [dbo].[Admin] (
    [Id], [Name], [Email], [Password], [PhoneNumber]) 
    VALUES (1, 'Admin', 'admin@gmail.com', 12345678
);

CREATE TABLE [dbo].[Education] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);

