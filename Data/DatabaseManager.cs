
using System.Xml.Linq;
using WatchBook.Models;

namespace WatchBook.Data
{
	public class DatabaseManager
	{
		private readonly MyDbContext _context;

		public DatabaseManager(MyDbContext context)
		{
			_context = context;
		}

		private void GenreInsert(List<int> genreIDs, int itemID, string type)
		{
			foreach	(var genreID in genreIDs) 
			{
				if (type == "anime")
				{
					_context.AnimeGenres.Add(new AnimeGenre { AnimeID = itemID, GenreID = genreID });
				} else if (type == "movie")
				{
					_context.MovieGenres.Add(new MovieGenre { MovieID = itemID, GenreID = genreID });
				}

				_context.SaveChanges();
			}
		}

		public void insertData(object item)
		{
			if (item.GetType() == typeof(AnimeModel))
			{
				AnimeModel rawAnime = (AnimeModel)item;

				Anime anime = new Anime 
				{ 
					ID = rawAnime.Item.ID,
					Rank = rawAnime.Rank,
					Name = rawAnime.Item.Name,
					OrginalName = rawAnime.OriginalName,
					Text = rawAnime.Item.Text,
					Buy = rawAnime.Item.Buy,
					IMG = rawAnime.Item.IMG,
					AnimeID = rawAnime.Item.ParentID,
					Link = rawAnime.Item.Link,
					SearchCount = 0,
					Episodes = rawAnime.Episodes,
					DateAired = rawAnime.Item.Date
				}; 

				_context.Animes.Add(anime);
				_context.SaveChanges();
				GenreInsert(rawAnime.Item.Genres, rawAnime.Item.ID, "anime");

			} else if (item.GetType() == typeof(MovieModel))
			{
				MovieModel movie = (MovieModel)item;


				GenreInsert(movie.Item.Genres, movie.Item.ID, "movie");

			} else if (item.GetType() == typeof(GenreModel))
            {

			} else if (item.GetType() == typeof(SettingsModel))
			{

			} else if (item.GetType() == typeof(WatchLaterAnimeModel))
			{

			} else if (item.GetType() == typeof(WatchLaterMovieModel))
			{

			}
		}

		static void readData(object item)
		{

		}
	}
}
