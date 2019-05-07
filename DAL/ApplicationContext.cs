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
		public DbSet<Producer> Producers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Relationships

			modelBuilder.Entity<FilmGenre>()
				.HasKey(fg => new { fg.FilmId, fg.GenreId });

			modelBuilder.Entity<FilmActor>()
				.HasKey(fa => new { fa.ActorId, fa.FilmId });

			modelBuilder.Entity<FilmProducer>()
				.HasKey(fp => new { fp.FilmId, fp.ProducerId });


			modelBuilder.Entity<FilmGenre>()
				.HasOne(fg => fg.Film)
				.WithMany(f => f.FilmGenres)
				.HasForeignKey(fg => fg.FilmId);

			modelBuilder.Entity<FilmGenre>()
				.HasOne(fg => fg.Genre)
				.WithMany(g => g.FilmGenres)
				.HasForeignKey(fg => fg.GenreId);


			modelBuilder.Entity<FilmActor>()
				.HasOne(fa => fa.Actor)
				.WithMany(a => a.FilmActors)
				.HasForeignKey(fa => fa.ActorId);

			modelBuilder.Entity<FilmActor>()
				.HasOne(fa => fa.Film)
				.WithMany(f => f.FilmActors)
				.HasForeignKey(fa => fa.FilmId);


			modelBuilder.Entity<FilmProducer>()
				.HasOne(fp => fp.Film)
				.WithMany(f => f.FilmProducers)
				.HasForeignKey(fp => fp.FilmId);

			modelBuilder.Entity<FilmProducer>()
				.HasOne(fp => fp.Producer)
				.WithMany(p => p.FilmProducers)
				.HasForeignKey(fp => fp.ProducerId);

			#endregion

			#region DataSeeding



			#endregion

			base.OnModelCreating(modelBuilder);
		}
	}
}
