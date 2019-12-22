CREATE TABLE [dbo].[FilmGenre] (
    [FilmId]  BIGINT NOT NULL,
    [GenreId] BIGINT NOT NULL,
    CONSTRAINT [PK_FilmGenre] PRIMARY KEY CLUSTERED ([FilmId] ASC, [GenreId] ASC),
    CONSTRAINT [FK_FilmGenre_Films_FilmId] FOREIGN KEY ([FilmId]) REFERENCES [dbo].[Films] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FilmGenre_Genres_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_FilmGenre_GenreId]
    ON [dbo].[FilmGenre]([GenreId] ASC);

