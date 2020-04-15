CREATE TABLE [dbo].[Accounts] (
    [Id]                    bigint            NOT NULL IDENTITY,
    [BICDirectoryEntryId]   bigint            NOT NULL,
    [Account]               NVARCHAR (150) NULL,
    [RegulationAccountType] NVARCHAR (150) NULL,
    [CK]                    NVARCHAR (150) NULL,
    [AccountCBRBIC]         NVARCHAR (150) NULL,
    [DateIn]                NVARCHAR (150) NULL,
    [AccountStatus]         NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

