CREATE TABLE [dbo].[Actors] (
    [Id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

