CREATE TABLE [dbo].[Genres] (
    [Id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED ([Id] ASC)
);

