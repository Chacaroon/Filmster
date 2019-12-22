CREATE TABLE [dbo].[FilmActor] (
    [FilmId]  BIGINT NOT NULL,
    [ActorId] BIGINT NOT NULL,
    CONSTRAINT [PK_FilmActor] PRIMARY KEY CLUSTERED ([ActorId] ASC, [FilmId] ASC),
    CONSTRAINT [FK_FilmActor_Actors_ActorId] FOREIGN KEY ([ActorId]) REFERENCES [dbo].[Actors] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FilmActor_Films_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [dbo].[Films] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FilmActor_FilmId]
    ON [dbo].[FilmActor]([FilmId] ASC);

