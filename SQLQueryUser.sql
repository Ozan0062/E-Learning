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