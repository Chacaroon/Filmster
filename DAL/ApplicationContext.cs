using System.ComponentModel;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class ApplicationContext : IdentityDbContext<User, IdentityRole<long>, long>
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
		}

		public DbSet<Film> Films { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<Director> Directors { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Relationships

			modelBuilder.Entity<FilmGenre>()
				.HasKey(fg => new { fg.FilmId, fg.GenreId });

			modelBuilder.Entity<FilmActor>()
				.HasKey(fa => new { fa.ActorId, fa.FilmId });

			#endregion

			#region DataSeeding

			var user1 = new User("admin")
			{
				Id = 1,
				NormalizedUserName = "admin".ToUpper()
			};
			user1.PasswordHash = new PasswordHasher<User>().HashPassword(user1, "Password1");

			var user2 = new User("user1")
			{
				Id = 2,
				NormalizedUserName = "user1".ToUpper()
			};
			user2.PasswordHash = new PasswordHasher<User>().HashPassword(user2, "Password1");

			var user3 = new User("user2")
			{
				Id = 3,
				NormalizedUserName = "user2".ToUpper()
			};
			user3.PasswordHash = new PasswordHasher<User>().HashPassword(user3, "Password1");

			modelBuilder.Entity<User>()
				.HasData(user1, user2, user3);

			modelBuilder.Entity<Film>()
				.HasData(
					new Film() { Id = 1, Title = "film1", UserId = 1, DirectorId = 1 },
					new Film() { Id = 2, Title = "film2", UserId = 2, DirectorId = 2 },
					new Film() { Id = 3, Title = "film3", UserId = 3, DirectorId = 3 });

			modelBuilder.Entity<Genre>()
				.HasData(
					new Genre("genre1") { Id = 1 },
					new Genre("genre2") { Id = 2 },
					new Genre("genre3") { Id = 3 });

			modelBuilder.Entity<Actor>()
				.HasData(
					new Actor("actor1") { Id = 1 },
					new Actor("actor2") { Id = 2 },
					new Actor("actor3") { Id = 3 });

			modelBuilder.Entity<Director>()
				.HasData(
					new Director("director1") { Id = 1 },
					new Director("director2") { Id = 2 },
					new Director("director3") { Id = 3 });


			modelBuilder.Entity<FilmGenre>()
				.HasData(
					new FilmGenre() { FilmId = 1, GenreId = 2 },
					new FilmGenre() { FilmId = 1, GenreId = 3 },

					new FilmGenre() { FilmId = 2, GenreId = 2 },

					new FilmGenre() { FilmId = 3, GenreId = 1 },
					new FilmGenre() { FilmId = 3, GenreId = 3 });

			modelBuilder.Entity<FilmActor>()
				.HasData(
					new FilmActor() { FilmId = 1, ActorId = 2 },
					new FilmActor() { FilmId = 1, ActorId = 3 },

					new FilmActor() { FilmId = 2, ActorId = 2 },

					new FilmActor() { FilmId = 3, ActorId = 1 },
					new FilmActor() { FilmId = 3, ActorId = 3 });


			#endregion

			base.OnModelCreating(modelBuilder);
		}
	}
}
