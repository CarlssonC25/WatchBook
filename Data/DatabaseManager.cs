
using Microsoft.EntityFrameworkCore;
using System.Runtime;
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

		private void GenreInsert(List<GenreModel> genres, int itemID, string type)
		{
			foreach	(var genre in genres) 
			{
				if (!ExistsItem(genre))
				{
					if (type == "anime")
					{
						_context.AnimeGenres.Add(new AnimeGenre { AnimeID = itemID, GenreID = genre.Id });
					}
					else if (type == "movie")
					{
						_context.MovieGenres.Add(new MovieGenre { MovieID = itemID, GenreID = genre.Id });
					}

					_context.SaveChanges();
				} else
				{
					// TODO go to Update----------------------------------------------------------------
				}
			}
		}

		private bool ExistsItem(object item)
		{
			if (item.GetType() == typeof(AnimeModel))
			{
				AnimeModel anime = (AnimeModel)item;
				return _context.Animes.FirstOrDefault(a => a.Name == anime.Item.Name) != null;

			}
			else if (item.GetType() == typeof(MovieModel))
			{
				MovieModel movie = (MovieModel)item;
				return _context.Movies.FirstOrDefault(m => m.Name == movie.Item.Name) != null;

			}
			else if (item.GetType() == typeof(GenreModel))
			{
				GenreModel genre = (GenreModel)item;
				return _context.Genres.FirstOrDefault(g => g.Name == genre.Name) != null;

			}
			else if (item.GetType() == typeof(SettingsModel))
			{
				SettingsModel settings = (SettingsModel)item;
				return _context.Settings.FirstOrDefault(s => s.Setting == settings.Setting) != null;

			}
			else if (item.GetType() == typeof(WatchLaterAnimeModel))
			{
				WatchLaterAnimeModel watchLaterAnime = (WatchLaterAnimeModel)item;
				return _context.WatchLaterAnimes.FirstOrDefault(a => a.AnimeID == watchLaterAnime.Id) != null;

			}
			else if (item.GetType() == typeof(WatchLaterMovieModel))
			{
				WatchLaterMovieModel watchLaterMovie = (WatchLaterMovieModel)item;
				return _context.WatchLaterMovies.FirstOrDefault(m => m.MovieID == watchLaterMovie.Id) != null;
			}
			return false;
		}

		public void InsertData(object item)
		{
			if (item.GetType() == typeof(AnimeModel))
			{
				AnimeModel rawAnime = (AnimeModel)item;
				if(!ExistsItem(rawAnime))
				{
					Anime anime = new Anime
					{
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
				}
				else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}

			} else if (item.GetType() == typeof(MovieModel))
			{
				MovieModel rawMovie = (MovieModel)item;
				if (!ExistsItem(rawMovie))
				{
					Movie movie = new Movie
					{
						Name = rawMovie.Item.Name,
						Buy = rawMovie.Item.Buy,
						Text = rawMovie.Item.Text,
						IMG = rawMovie.Item.IMG,
						MovieID = rawMovie.Item.ParentID,
						Age = rawMovie.FSK,
						Favorit = rawMovie.Favourite,
						DateAired = rawMovie.Item.Date,
						Link = rawMovie.Item.Link
					};

					_context.Movies.Add(movie);
					_context.SaveChanges();
					GenreInsert(rawMovie.Item.Genres, rawMovie.Item.ID, "movie");
				} else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}

			} else if (item.GetType() == typeof(GenreModel))
            {
				GenreModel rawGenre = (GenreModel)item;
				if (!ExistsItem(rawGenre)) 
				{
					Genre genre = new Genre
					{
						Name = rawGenre.Name
					};

					_context.Genres.Add(genre);
					_context.SaveChanges();

				} else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}

			} else if (item.GetType() == typeof(SettingsModel))
			{
				SettingsModel rawSettings = (SettingsModel)item;
				if(!ExistsItem(rawSettings))
				{
					Settings settings = new Settings
					{
						Setting = rawSettings.Setting,
						Comment = rawSettings.Comment,
						IMG = rawSettings.IMG
					};

					_context.Settings.Add(settings);
					_context.SaveChanges();
				} else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}


			} else if (item.GetType() == typeof(WatchLaterAnimeModel))
			{
				WatchLaterAnimeModel rawWatchLaterAnime = (WatchLaterAnimeModel)item;
				if (!ExistsItem(rawWatchLaterAnime))
				{
					WatchLaterAnime watchLaterAnime = new WatchLaterAnime
					{
						AnimeID = rawWatchLaterAnime.AnimeID,
						Comment = rawWatchLaterAnime.Comment
					};

					_context.WatchLaterAnimes.Add(watchLaterAnime);
					_context.SaveChanges();
				}
				else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}

			} else if (item.GetType() == typeof(WatchLaterMovieModel))
			{
				WatchLaterMovieModel RawWatchLaterMovie = (WatchLaterMovieModel)item;
				if (!ExistsItem(RawWatchLaterMovie)) 
				{
					WatchLaterMovie watchLaterMovie = new WatchLaterMovie
					{
						MovieID = RawWatchLaterMovie.MovieID,
						Comment = RawWatchLaterMovie.Comment
					};

					_context.WatchLaterMovies.Add(watchLaterMovie);
					_context.SaveChanges();
				} else
				{
					// TODO return messeag(Exists) ----------------------------------------------------
				}
			}
		}

		public void UpdateData(object item)
		{
			if (item.GetType() == typeof(AnimeModel))
			{
				AnimeModel upAnime = (AnimeModel)item;
				// TODO -------------------------------------------------

			}
			else if (item.GetType() == typeof(MovieModel))
			{
				MovieModel upMovie = (MovieModel)item;
				// TODO -------------------------------------------------

			}
			else if (item.GetType() == typeof(GenreModel))
			{
				GenreModel upGenre = (GenreModel)item;

				var genre = _context.Genres.FirstOrDefault(g => g.ID == upGenre.Id);
				if (genre != null)
				{
					genre.Name = upGenre.Name;
					_context.SaveChanges();
				}
			}
			else if (item.GetType() == typeof(SettingsModel))
			{
				SettingsModel upSettings = (SettingsModel)item;

				var setting = _context.Settings.FirstOrDefault(s => s.ID == upSettings.ID);
				if (setting != null)
				{
					setting.Setting = upSettings.Setting;
					setting.Comment = upSettings.Comment;
					setting.IMG = upSettings.IMG;
					_context.SaveChanges();
				}
			}
			else if (item.GetType() == typeof(WatchLaterAnimeModel))
			{
				WatchLaterAnimeModel upwatchLaterAnime = (WatchLaterAnimeModel)item;

				var watchLaterAnime = _context.WatchLaterAnimes.FirstOrDefault(s => s.AnimeID == upwatchLaterAnime.Id);
				if(watchLaterAnime != null)
				{
					watchLaterAnime.Comment = upwatchLaterAnime.Comment;
					_context.SaveChanges();
				}
			}
			else if (item.GetType() == typeof(WatchLaterMovieModel))
			{
				WatchLaterMovieModel upwatchLaterMovie = (WatchLaterMovieModel)item;

				var watchLaterMovie = _context.WatchLaterMovies.FirstOrDefault(s => s.MovieID == upwatchLaterMovie.Id);
				if (watchLaterMovie != null)
				{
					watchLaterMovie.Comment = upwatchLaterMovie.Comment;
					_context.SaveChanges();
				}
			}
		}

		public void ReadData(object item)
		{

		}

		public void DeletedData(object item) 
		{ 

		}
	}
}
