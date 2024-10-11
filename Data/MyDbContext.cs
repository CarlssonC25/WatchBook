using System;
using Microsoft.EntityFrameworkCore;

namespace WatchBook.Data
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{
		}

		public DbSet<Anime> Animes { get; set; }
		public DbSet<WatchLaterAnime> WatchLaterAnimes { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<AnimeGenre> AnimeGenres { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<WatchLaterMovie> WatchLaterMovies { get; set; }
		public DbSet<MovieGenre> MovieGenres { get; set; }
		public DbSet<Settings> Settings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Zusammengesetzter Primärschlüssel für AnimeGenre
			modelBuilder.Entity<AnimeGenre>()
				.HasKey(ag => new { ag.AnimeID, ag.GenreID });

			// Fremdschlüssel für AnimeGenre
			modelBuilder.Entity<AnimeGenre>()
				.HasOne(ag => ag.Anime)
				.WithMany(a => a.AnimeGenres)
				.HasForeignKey(ag => ag.AnimeID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<AnimeGenre>()
				.HasOne(ag => ag.Genre)
				.WithMany(g => g.AnimeGenres)
				.HasForeignKey(ag => ag.GenreID)
				.OnDelete(DeleteBehavior.Cascade);

			// Zusammengesetzter Primärschlüssel für MovieGenre
			modelBuilder.Entity<MovieGenre>()
				.HasKey(mg => new { mg.MovieID, mg.GenreID });

			// Fremdschlüssel für MovieGenre
			modelBuilder.Entity<MovieGenre>()
				.HasOne(mg => mg.Movie)
				.WithMany(m => m.MovieGenres)
				.HasForeignKey(mg => mg.MovieID)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<MovieGenre>()
				.HasOne(mg => mg.Genre)
				.WithMany(g => g.MovieGenres)
				.HasForeignKey(mg => mg.GenreID)
				.OnDelete(DeleteBehavior.Cascade);

			// WatchLaterAnime -> Zusammengesetzter Primärschlüssel
			modelBuilder.Entity<WatchLaterAnime>()
				.HasKey(wla => new { wla.AnimeID, wla.Comment });

			// WatchLaterAnime -> Anime (Foreign Key)
			modelBuilder.Entity<WatchLaterAnime>()
				.HasOne(wla => wla.Anime)
				.WithMany(a => a.WatchLaterAnimes)
				.HasForeignKey(wla => wla.AnimeID)
				.OnDelete(DeleteBehavior.Cascade);

			// WatchLaterMovie -> Zusammengesetzter Primärschlüssel
			modelBuilder.Entity<WatchLaterMovie>()
				.HasKey(wlm => new { wlm.MovieID, wlm.Comment });

			// WatchLaterMovie -> Movie (Foreign Key)
			modelBuilder.Entity<WatchLaterMovie>()
				.HasOne(wlm => wlm.Movie)
				.WithMany(m => m.WatchLaterMovies)
				.HasForeignKey(wlm => wlm.MovieID)
				.OnDelete(DeleteBehavior.Cascade);

			base.OnModelCreating(modelBuilder);
		}
	}
}
