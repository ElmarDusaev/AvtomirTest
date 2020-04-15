CREATE TABLE [dbo].[BICDirectoryEntry] (
    [Id]  bigint            NOT NULL IDENTITY,
    [BIC] NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

