CREATE TABLE [dbo].[Admin] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]    INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CK_PhoneNumber_Admin] CHECK ([PhoneNumber] BETWEEN 0 AND 9999999999)
);