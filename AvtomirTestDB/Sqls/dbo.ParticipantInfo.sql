CREATE TABLE [dbo].[ParticipantInfo] (
    [Id]                  bigint            NOT NULL IDENTITY,
    [BICDirectoryEntryId] bigint            NOT NULL,
    [NameP]               NVARCHAR (150) NULL,
    [CntrCd]              NVARCHAR (150) NULL,
    [Rgn]                 NVARCHAR (150) NULL,
    [Ind]                 NVARCHAR (150) NULL,
    [Tnp]                 NVARCHAR (150) NULL,
    [Nnp]                 NVARCHAR (150) NULL,
    [Adr]                 NVARCHAR (150) NULL,
    [DateIn]              NVARCHAR (150) NULL,
    [PtType]              NVARCHAR (150) NULL,
    [Srvcs]               NVARCHAR (150) NULL,
    [XchType]             NVARCHAR (150) NULL,
    [UID]                 NVARCHAR (150) NULL,
    [ParticipantStatus]   NVARCHAR (150) NULL,
    [RegN]                NVARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

