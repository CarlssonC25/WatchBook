
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

		private void ConnectGenre(List<GenreModel> genres, int itemID, string type)
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
					var errorMesseag = $"Error: Connect Genre {genre.Name} to {type} ID-{itemID} don't work!";
					// TODO return messeag(Exists) in consol ----------------------------------------------------
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
		private GenreModel CreateGenreModel(Genre genre)
		{
			GenreModel modelGenre = new GenreModel
			{
				Name = genre.Name,
				Id = genre.ID
			};

			return modelGenre;
		}
		private WatchLaterAnimeModel CreateWatchLaterAnimeModel (WatchLaterAnime rawLater)
		{
			WatchLaterAnimeModel later = new WatchLaterAnimeModel
			{
				Id = rawLater.ID,
				AnimeID = rawLater.AnimeID,
				Comment = rawLater.Comment
			};

			return later;
		}
		private WatchLaterMovieModel CreateWatchLaterMovieModel(WatchLaterMovie rawLater)
		{
			WatchLaterMovieModel later = new WatchLaterMovieModel
			{
				Id = rawLater.ID,
				MovieID = rawLater.MovieID,
				Comment = rawLater.Comment
			};

			return later;
		}


		// DB Insert Date ------		
		public void DbInsertAnime(AnimeModel rawAnime)
		{
			if (!ExistsItem(rawAnime))
			{
				Anime anime = new Anime
				{
					Rank = rawAnime.Rank,
					Name = rawAnime.Item.Name,
					OrginalName = rawAnime.OriginalName,
					Text = rawAnime.Item.Text,
					Country = rawAnime.Country,
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
				ConnectGenre(rawAnime.Item.Genres, rawAnime.Item.ID, "anime");
			}
			else
			{
				var errorMesseag = $"Error: Save new Anime {rawAnime.Item.Name} alredy exists!";
				// TODO return messeag(Exists) in consol ----------------------------------------------------
			}
		}
		public void DbInsertMovie(MovieModel rawMovie)
		{
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
				ConnectGenre(rawMovie.Item.Genres, rawMovie.Item.ID, "movie");
			}
			else
			{
				var errorMesseag = $"Error: Save new Movie {rawMovie.Item.Name} alredy exists!";
				// TODO return messeag(Exists) in consol ----------------------------------------------------
			}
		}
		public void DbInsertGenre(GenreModel rawGenre)
		{
			if (!ExistsItem(rawGenre))
			{
				Genre genre = new Genre
				{
					Name = rawGenre.Name
				};

				_context.Genres.Add(genre);
				_context.SaveChanges();

			}
			else
			{
				var errorMesseag = $"Error: Save new Genre {rawGenre.Name} alredy exists!";
				// TODO return messeag(Exists) in consol ----------------------------------------------------
			}
		}
		public void DbInsertSetting(SettingsModel rawSettings)
		{
			if (!ExistsItem(rawSettings))
			{
				Settings settings = new Settings
				{
					Setting = rawSettings.Setting,
					Comment = rawSettings.Comment,
					IMG = rawSettings.IMG
				};

				_context.Settings.Add(settings);
				_context.SaveChanges();
			}
			else
			{
				var errorMesseag = $"Error: Save new Setting {rawSettings.Setting} alredy exists!";
				// TODO return messeag(Exists) in consol ----------------------------------------------------
			}
		}
		public void DbInsertWatchLaterAnime(WatchLaterAnimeModel rawWatchLaterAnime)
		{
			WatchLaterAnime watchLaterAnime = new WatchLaterAnime
			{
				AnimeID = rawWatchLaterAnime.AnimeID,
				Comment = rawWatchLaterAnime.Comment
			};

			_context.WatchLaterAnimes.Add(watchLaterAnime);
			_context.SaveChanges();
		}
		public void DbInsertWatchLaterMovie(WatchLaterMovieModel RawWatchLaterMovie)
		{
			WatchLaterMovie watchLaterMovie = new WatchLaterMovie
			{
				MovieID = RawWatchLaterMovie.MovieID,
				Comment = RawWatchLaterMovie.Comment
			};

			_context.WatchLaterMovies.Add(watchLaterMovie);
			_context.SaveChanges();
		}

		// DB Update Date ------		
		public void DbUpdateAnime(AnimeModel upAnime)
		{
			var anime = _context.Animes.FirstOrDefault(a => a.ID == upAnime.Item.ID);
			if (anime != null)
			{
				anime.Name = upAnime.Item.Name;
				anime.OrginalName = upAnime.OriginalName;
				anime.Text = upAnime.Item.Text;
				anime.Rank = upAnime.Rank;
				anime.IMG = upAnime.Item.IMG;
				anime.Buy = upAnime.Item.Buy;
				anime.DateAired = upAnime.Item.Date;
				anime.Episodes = upAnime.Episodes;
				anime.Link = upAnime.Item.Link;

				_context.SaveChanges();
			}
		}
		public void DbUpdateMovie(MovieModel upMovie)
		{
			var movie = _context.Movies.FirstOrDefault(m => m.ID == upMovie.Item.ID);
			if (movie != null)
			{
				movie.Name = upMovie.Item.Name;
				movie.Buy = upMovie.Item.Buy;
				movie.Text = upMovie.Item.Text;
				movie.IMG = upMovie.Item.IMG;
				movie.Age = upMovie.FSK;
				movie.Favorit = upMovie.Favourite;
				movie.DateAired = upMovie.Item.Date;
				movie.Link = upMovie.Item.Link;

				_context.SaveChanges();
			}
		}
		public void DbUpdateGenre(GenreModel upGenre)
		{
			var genre = _context.Genres.FirstOrDefault(g => g.ID == upGenre.Id);
			if (genre != null)
			{
				genre.Name = upGenre.Name;
				_context.SaveChanges();
			}
		}
		public void DbUpdateSetting(SettingsModel upSettings)
		{
			var setting = _context.Settings.FirstOrDefault(s => s.ID == upSettings.ID);
			if (setting != null)
			{
				setting.Setting = upSettings.Setting;
				setting.Comment = upSettings.Comment;
				setting.IMG = upSettings.IMG;
				_context.SaveChanges();
			}
		}
		public void DbUpdateWatchLaterAnime(WatchLaterAnimeModel upwatchLaterAnime)
		{
			var watchLaterAnime = _context.WatchLaterAnimes.FirstOrDefault(s => s.AnimeID == upwatchLaterAnime.Id);
			if (watchLaterAnime != null)
			{
				watchLaterAnime.Comment = upwatchLaterAnime.Comment;
				_context.SaveChanges();
			}
		}
		public void DbUpdateWatchLaterMovie(WatchLaterMovieModel upwatchLaterMovie)
		{
			var watchLaterMovie = _context.WatchLaterMovies.FirstOrDefault(s => s.MovieID == upwatchLaterMovie.Id);
			if (watchLaterMovie != null)
			{
				watchLaterMovie.Comment = upwatchLaterMovie.Comment;
				_context.SaveChanges();
			}
		}

		// DB Read Date --------
		public AnimeModel DbReadAnime(AnimeModel getAnime)
		{
			var rawanime = _context.Animes
										.Include(g => g.AnimeGenres)
										.ThenInclude(ag => ag.Genre)
										.FirstOrDefault(a => a.ID == getAnime.Item.ID);

			if (rawanime != null)
			{
				List<GenreModel> genres = null;
				foreach(var rawGenre in rawanime.AnimeGenres)
				{
					genres.Add(CreateGenreModel(rawGenre.Genre));
				}

				ItemRawModel itemRawModel = new ItemRawModel
				{
					Name = rawanime.Name,
					Buy = rawanime.Buy,
					Date = rawanime.DateAired,
					IMG = rawanime.IMG,
					Link = rawanime.Link,
					ParentID = rawanime.AnimeID,
					Text = rawanime.Text,
					Genres = genres,
				};

				AnimeModel anime = new AnimeModel
				{ 
					Episodes = rawanime.Episodes,
					Country = rawanime.Country,
					OriginalName = rawanime.OrginalName,
					Rank = rawanime.Rank,
					Item = itemRawModel
				};

				return anime;
			}

			var error = $"Error: Read Anime- {getAnime.Item.Name} don't work!";
			return null;
		}
		public MovieModel DbReadMovie(MovieModel getMovie)
		{
			var rawMovie = _context.Movies
										.Include(g => g.MovieGenres)
										.ThenInclude(gm => gm.Genre)
										.FirstOrDefault(m => m.ID == getMovie.Item.ID);

			if (rawMovie == null)
			{
				List<GenreModel> genres = null;
				foreach(var rawGenre in rawMovie.MovieGenres)
				{
					genres.Add(CreateGenreModel(rawGenre.Genre));
				}

				ItemRawModel itemRawModel = new ItemRawModel
				{
					Name = rawMovie.Name,
					Buy = rawMovie.Buy,
					Date = rawMovie.DateAired,
					IMG = rawMovie.IMG,
					Link = rawMovie.Link,
					ParentID = rawMovie.MovieID,
					Text = rawMovie.Text,
					Genres = genres,
				};

				MovieModel movie = new MovieModel
				{
					Favourite = rawMovie.Favorit,
					FSK = rawMovie.Age,
					Item = itemRawModel
				};

				return movie;
			}

			var error = $"Error: Read Anime- {getMovie.Item.Name} don't work!";
			return null;
		}
		public GenreModel DbReadGenre(GenreModel getGenre)
		{
			var rawGenre = _context.Genres.FirstOrDefault(g => g.ID == getGenre.Id);
			return CreateGenreModel(rawGenre);
		}
		public List<GenreModel> DbReadGenres()
		{
			var rawGenres = _context.Genres.ToList();
			
			if (rawGenres != null)
			{
				List<GenreModel> modelGenre = null;

				foreach (var genre in rawGenres)
				{
					modelGenre.Add(CreateGenreModel(genre));
				}

				return modelGenre;
			}

			return null;
		}
		public SettingsModel DbReadSetting(SettingsModel getSettings)
		{
			var rawSetting = _context.Settings.FirstOrDefault(s => s.Setting == getSettings.Setting);

			SettingsModel settings = new SettingsModel
			{
				ID = rawSetting.ID,
				Setting = rawSetting.Setting,
				Comment = rawSetting.Comment,
				IMG = rawSetting.IMG
			};

			return settings;
		}
		public WatchLaterAnimeModel DbReadWatchLaterAnime(WatchLaterAnimeModel getwatchLaterAnime)
		{
			var rawLater = _context.WatchLaterAnimes.FirstOrDefault(w => w.ID == getwatchLaterAnime.Id);

			return CreateWatchLaterAnimeModel(rawLater);
		}
		public List<WatchLaterAnimeModel> DbReadWatchLaterAnimes()
		{
			var rawLaters = _context.WatchLaterAnimes.ToList();

			List<WatchLaterAnimeModel> laters = null;
			foreach (var later in rawLaters)
			{
				laters.Add(CreateWatchLaterAnimeModel(later));
			}

			return laters;
		}
		public WatchLaterMovieModel DbReadWatchLaterMovie(WatchLaterMovieModel getwatchLaterMovie)
		{
			var rawLater = _context.WatchLaterMovies.FirstOrDefault(w => w.ID == getwatchLaterMovie.Id);
			
			return CreateWatchLaterMovieModel(rawLater);

		}
		public List<WatchLaterMovieModel> DbReadWatchLaterMovies()
		{
			var rawLaters = _context.WatchLaterMovies.ToList();

			List<WatchLaterMovieModel> laters = null;
			foreach (var later in rawLaters)
			{
				laters.Add(CreateWatchLaterMovieModel(later));
			}
			return laters;

		}

		// DB Delete Date -----
		public void DbDeleteAnime(AnimeModel delAnime)
		{
			var animeToDel = _context.Animes
									.Include(g => g.AnimeGenres)
									.FirstOrDefault(a => a.ID == delAnime.Item.ID);

			if (animeToDel != null) 
			{
				var animesToDel = _context.Animes
											.Where(a => a.AnimeID == delAnime.Item.ID)
											.Include(a => a.AnimeGenres)
											.ToList();

				animesToDel.Add(animeToDel);

				foreach (var anime in animesToDel)
				{
					_context.AnimeGenres.RemoveRange(anime.AnimeGenres);
				}

				_context.Animes.RemoveRange(animesToDel);
				_context.SaveChanges();
			}
		}
		public void DbDeleteMovie(MovieModel delMovie) 
		{
			var movieToDel = _context.Movies
										.Include(g => g.MovieGenres)
										.FirstOrDefault(m => m.ID == delMovie.Item.ID);

			if(movieToDel != null)
			{
				var moviesToDel = _context.Movies
											.Where(m => m.MovieID == delMovie.Item.ID)
											.Include(a => a.MovieGenres)
											.ToList();

				moviesToDel.Add(movieToDel);

				foreach(var movie in moviesToDel)
				{
					_context.MovieGenres.RemoveRange(movie.MovieGenres);
				}

				_context.Movies.RemoveRange(moviesToDel);
				_context.SaveChanges();
			}
		}
		public void DbDeleteGenre(GenreModel delGenre)
		{
			var genreToDel = _context.Genres.FirstOrDefault(g => g.ID == delGenre.Id);

			if(genreToDel != null)
			{
				_context.Genres.Remove(genreToDel);
				_context.SaveChanges();
			}
		}
		public void DbDeleteWatchLaterAnime(WatchLaterAnimeModel delWLAnime)
		{
			var WLAnimeToDel = _context.WatchLaterAnimes.FirstOrDefault(w => w.ID == delWLAnime.Id);

			if (WLAnimeToDel != null)
			{
				_context.WatchLaterAnimes.Remove(WLAnimeToDel);
				_context.SaveChanges();
			}
		}
		public void DbDeleteWatchLaterMovie(WatchLaterMovieModel delWLMovie)
		{
			var WLMovieToDel = _context.WatchLaterMovies.FirstOrDefault(w => w.ID == delWLMovie.Id);

			if (WLMovieToDel != null)
			{
				_context.WatchLaterMovies.Remove(WLMovieToDel);
				_context.SaveChanges();
			}
		}
	}
}
