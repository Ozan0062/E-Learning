INSERT INTO [dbo].[User] ([Email], [Password])
VALUES 
('johndoe@example.com', 'password123'),
('janedoe@example.com', 'letmein'),
('bobsmith@example.com', 'qwerty'),
('alicejohnson@example.com', 'abc123'),
('sarahparker@example.com', 'iloveyou');

CREATE TABLE [dbo].[Course] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL
);

