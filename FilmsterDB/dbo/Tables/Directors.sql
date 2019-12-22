CREATE TABLE [dbo].[Directors] (
    [Id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

