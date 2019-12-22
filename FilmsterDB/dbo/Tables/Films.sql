CREATE TABLE [dbo].[Films] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NULL,
    [Year]        INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [Rating]      TINYINT        NOT NULL,
    [URI]         NVARCHAR (MAX) NULL,
    [Duration]    TIME (7)       NOT NULL,
    [DirectorId]  BIGINT         NOT NULL,
    [UserId]      BIGINT         NOT NULL,
    CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Films_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Films_Directors_DirectorId] FOREIGN KEY ([DirectorId]) REFERENCES [dbo].[Directors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Films_UserId]
    ON [dbo].[Films]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Films_DirectorId]
    ON [dbo].[Films]([DirectorId] ASC);

