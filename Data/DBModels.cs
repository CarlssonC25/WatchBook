namespace WatchBook.Data
{
	public class Anime
	{
		public int ID { get; set; }
		public byte Rank { get; set; }
		public string Name { get; set; }
		public string OrginalName { get; set; }
		public string Text { get; set; }
		public byte Buy { get; set; }
		public byte[] IMG { get; set; } // Assuming img is stored as byte array
		public int AnimeID { get; set; }
		public string Link { get; set; }
		public int SearchCount { get; set; }
		public int Episodes { get; set; }
		public DateTime DateAired { get; set; }

		// Navigation properties
		public ICollection<WatchLaterAnime> WatchLaterAnimes { get; set; }
		public ICollection<AnimeGenre> AnimeGenres { get; set; }
	}

	public class WatchLaterAnime
	{
		public int AnimeID { get; set; }
		public string Comment { get; set; }

		// Navigation property
		public Anime Anime { get; set; }
	}

	public class Genre
	{
		public int ID { get; set; }
		public string Name { get; set; }

		// Navigation properties
		public ICollection<AnimeGenre> AnimeGenres { get; set; }
		public ICollection<MovieGenre> MovieGenres { get; set; }
	}

	public class AnimeGenre
	{
		public int AnimeID { get; set; }
		public int GenreID { get; set; }

		// Navigation properties
		public Anime Anime { get; set; }
		public Genre Genre { get; set; }
	}

	public class Movie
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public byte Buy { get; set; }
		public string Text { get; set; }
		public byte[] IMG { get; set; } // Assuming img is stored as byte array
		public int MovieID { get; set; }
		public byte Age { get; set; }
		public bool Favorit { get; set; }
		public DateTime DateAired { get; set; }
		public string Link { get; set; }

		// Navigation properties
		public ICollection<WatchLaterMovie> WatchLaterMovies { get; set; }
		public ICollection<MovieGenre> MovieGenres { get; set; }
	}

	public class WatchLaterMovie
	{
		public int MovieID { get; set; }
		public string Comment { get; set; }

		// Navigation property
		public Movie Movie { get; set; }
	}

	public class MovieGenre
	{
		public int MovieID { get; set; }
		public int GenreID { get; set; }

		// Navigation properties
		public Movie Movie { get; set; }
		public Genre Genre { get; set; }
	}

	public class Settings
	{
		public int ID { get; set; }
		public string Setting { get; set; }
		public string Comment { get; set; }
		public byte[] IMG { get; set; } // Assuming img is stored as byte array
	}
}
