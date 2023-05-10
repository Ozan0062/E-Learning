CREATE TABLE [dbo].[Instructor] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]   INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PhoneNumber_Instructor] CHECK ([PhoneNumber] >= 0 AND [PhoneNumber] <= 9999999999)
);