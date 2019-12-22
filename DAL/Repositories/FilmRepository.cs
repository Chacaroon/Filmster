using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL.Entities;
using DAL.QueryParams;
using Dapper;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.DAL.Repositories;

namespace DAL.Repositories
{
	public class FilmRepository : Repository<Film, FilmParams>
	{
		public FilmRepository(ApplicationContext dbContext)
			: base(dbContext)
		{
		}

		public override IQueryable<Film> GetAll(FilmParams @params)
		{
			using var connection = DbContext.Database.GetDbConnection();
			connection.Open();

			var films = connection.Query<Film, FilmGenre, Genre, FilmActor, Actor, Director, Film>("dbo.GetFilms",
				(f, fg, g, fa, a, d) =>
				{
					fg.Film = f;
					fg.Genre = g;
					f.FilmGenres.Add(fg);

					fa.Film = f;
					fa.Actor = a;
					f.FilmActors.Add(fa);

					f.Director = d;

					return f;
				},
				new 
				{ 
					@searchQuery = @params.Title, 
					@genreIds = string.Join(",", @params.GenresFilter),
					@actorIds = string.Join(",", @params.ActorsFilter), 
					@directorIds = string.Join(",", @params.DirectorsFilter)
				},
				splitOn: "FilmId, Id, FilmId, Id, Id",
				commandType: CommandType.StoredProcedure)

				.GroupBy(f => f.Id, (id, films) => 
				{
					var film = films.First(x => x.Id == id);

					film.FilmGenres = films.SelectMany(x => x.FilmGenres).Distinct().ToList();
					film.FilmActors = films.SelectMany(x => x.FilmActors).Distinct().ToList();

					return film;
				});

			return films.AsQueryable();
		}

		//public override IQueryable<Film> GetAll() =>
		//	base.GetAll()
		//		.Include(f => f.User)
		//		.Include(f => f.FilmGenres)
		//		.ThenInclude(fg => fg.Genre)
		//		.Include(f => f.FilmActors)
		//		.ThenInclude(fa => fa.Actor)
		//		.Include(f => f.Director);
	}
}
