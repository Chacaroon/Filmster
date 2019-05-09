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

			#endregion

			#region DataSeeding



			#endregion

			base.OnModelCreating(modelBuilder);
		}
	}
}
