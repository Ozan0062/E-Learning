CREATE TABLE [dbo].[Exercise] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [CourseId] INT            NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Purpose] NVARCHAR (MAX),
    [Description] NVARCHAR (MAX) NOT NULL,
    [Step] NVARCHAR (MAX) NOT NULL,
    [Hint] NVARCHAR (MAX),

    PRIMARY KEY CLUSTERED ([Id] ASC) WITH (FILLFACTOR = 90),
    CONSTRAINT [FK_Exercise_Course_CourseId] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
);