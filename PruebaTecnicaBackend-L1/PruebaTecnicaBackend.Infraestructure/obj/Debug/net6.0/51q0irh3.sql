IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Classroom] (
    [ClassroomId] int NOT NULL IDENTITY,
    [Course] varchar(100) NOT NULL,
    CONSTRAINT [PK_Classroom] PRIMARY KEY ([ClassroomId])
);
GO

CREATE TABLE [Professor] (
    [ProfessorId] int NOT NULL IDENTITY,
    [FirstName] varchar(100) NOT NULL,
    [LastName] varchar(100) NOT NULL,
    [States] varchar(60) NOT NULL,
    [Turn] varchar(60) NULL,
    [DateCrete] varchar(60) NULL,
    [DateDelete] varchar(60) NULL,
    [Matter] varchar(200) NOT NULL,
    [ClassroomId] int NULL,
    CONSTRAINT [PK_Professor] PRIMARY KEY ([ProfessorId]),
    CONSTRAINT [FK__Professor__Class__4D94879B] FOREIGN KEY ([ClassroomId]) REFERENCES [Classroom] ([ClassroomId])
);
GO

CREATE TABLE [Student] (
    [StudentId] int NOT NULL IDENTITY,
    [FirstName] varchar(100) NOT NULL,
    [LastName] varchar(100) NOT NULL,
    [ClassroomId] int NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([StudentId]),
    CONSTRAINT [FK__Student__Classro__398D8EEE] FOREIGN KEY ([ClassroomId]) REFERENCES [Classroom] ([ClassroomId])
);
GO

CREATE INDEX [IX_Professor_ClassroomId] ON [Professor] ([ClassroomId]);
GO

CREATE INDEX [IX_Student_ClassroomId] ON [Student] ([ClassroomId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220908041404_AddBlogCreatedTimestamp', N'6.0.8');
GO

COMMIT;
GO

