//using Microsoft.Data.Sqlite;
//using WatchBook.Models;

//namespace WatchBook.Data
//{
//	public class DatabaseManager
//	{
//		private string _connectionString = "Data Source=WatchBookDB.db";

//		private SqliteConnection GetConnection()
//		{
//			return new SqliteConnection(_connectionString);
//		}


//		public void CreateDatabase()
//		{
//			using (var connection = GetConnection())
//			{
//				connection.Open();

//				string createAnimeTable = @"
//                CREATE TABLE IF NOT EXISTS Anime (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    Name TEXT,
//                    OriginalName TEXT,
//                    Rank TINYINT,
//                    Text TEXT,
//                    Buy TINYINT,
//                    Img BLOB,
//                    AnimeID INTEGER,
//                    Link TEXT,
//                    SearchCount INTEGER,
//                    DateAired DATE
//                )";

//                string createWatchLaterAnimeTable = @"
//                CREATE TABLE IF NOT EXISTS WatchLaterAnime (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    AnimeID INTEGER,
//                    Comment TEXT,
//                    FOREIGN KEY (AnimeID) REFERENCES Anime (ID)
//                )";

//                string createGenreTable = @"
//                CREATE TABLE IF NOT EXISTS Genre (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    Name TEXT
//                )";

//                string createAnimeGenreTable = @"
//                CREATE TABLE IF NOT EXISTS AnimeGenre (
//                    AnimeID INTEGER,
//                    GenreID INTEGER,
//                    FOREIGN KEY (AnimeID) REFERENCES Anime (ID),
//                    FOREIGN KEY (GenreID) REFERENCES Genre (ID)
//                )";

//                string createMovieTable = @"
//                CREATE TABLE IF NOT EXISTS Movie (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    Name TEXT,
//                    Buy TINYINT,
//                    Text TEXT,
//                    Img BLOB,
//                    MovieID INTEGER,
//                    Age TINYINT,
//                    Favorit BOOLEAN,
//                    Link TEXT,
//                    DateAired DATE
//                )";

//                string createWatchLaterMovieTable = @"
//                CREATE TABLE IF NOT EXISTS WatchLaterMovie (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    MovieID INTEGER,
//                    Comment TEXT,
//                    FOREIGN KEY (MovieID) REFERENCES Movie (ID)
//                )";

//                string createMovieGenreTable = @"
//                CREATE TABLE IF NOT EXISTS MovieGenre (
//                    MovieID INTEGER,
//                    GenreID INTEGER,
//                    FOREIGN KEY (MovieID) REFERENCES Movie (ID),
//                    FOREIGN KEY (GenreID) REFERENCES Genre (ID)
//                )";

//                string createSettingsTable = @"
//                CREATE TABLE IF NOT EXISTS Settings (
//                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
//                    Setting TEXT,
//                    Comment TEXT,
//                    Img BLOB
//                )";

//                using (var command = new SqliteCommand(createAnimeTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createWatchLaterAnimeTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createGenreTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createAnimeGenreTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createMovieTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createWatchLaterMovieTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createMovieGenreTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }
//                using (var command = new SqliteCommand(createSettingsTable, connection))
//                {
//                    command.ExecuteNonQuery();
//                }

//				Console.WriteLine("Database and tables created successfully.");
//			}
//		}

//        private static string InsertGenre(List<int> Genres)
//        {
//			string genreInsert = "";
//			foreach (var genre in Genres)
//			{
//				genreInsert += $"(last_insert_rowid(), {genre}),";

//			}
//			genreInsert.Remove(genreInsert.Length - 1);
//			genreInsert += ";";

//            return genreInsert;
//		}

//        private static void UseSQLCommand(SqliteConnection connection, string sql)
//        {
//			connection.Open();

//            using (var command = new SqliteCommand(sql, connection))
//			{
//				command.ExecuteNonQuery();
//			}
//		}



//        public void DbInsertData(object item)
//		{
//            using (var connection = GetConnection())
//            {
//                string insert = "";

//				if (item.GetType() == typeof(AnimeModel))
//				{
//                    AnimeModel anime = (AnimeModel)item;

//                    string genreInserts = InsertGenre(anime.Item.Genres);

//					insert = 
//                        $"INSERT INTO Anime(Name, OriginalName, Rank, Text, Buy, Img, AnimeID, Link, DateAired)" +
//                        $"VALUES ({anime.Item.Name}, {anime.OriginalName}, {anime.Rank}, {anime.Item.Text}, {anime.Item.Buy}, {anime.Item.IMG}, {anime.Item.ParentID}, {anime.Item.Link}, {anime.Item.Date});" +
//                        $"INSERT INTO AnimeGenre (AnimeID, GenreID)" +
//                        $"VALUES " + genreInserts;                    

//				} else if (item.GetType() == typeof(MovieModel))
//				{
//                    MovieModel movie = (MovieModel)item;

//					string genreInserts = InsertGenre(movie.Item.Genres);

//                    insert =
//                        $"INSERT INTO Movie(Name, Buy, Text, Img, MovieID, Age, Favorit, Link, DateAired)" +
//                        $"VALUES ({movie.Item.Name}, {movie.Item.Buy}, {movie.Item.Text}, {movie.Item.IMG}, {movie.Item.ParentID}, {movie.FSK}, {movie.Favourite}, {movie.Item.Link}, {movie.Item.Date});" +
//                        $"INSERT INTO MovieGenre (MovieID, GenreID)" +
//                        $"VALUES " + genreInserts;


//				} else if (item.GetType() == typeof(GenreModel))
//                {
//                    GenreModel genre = (GenreModel)item;

//					insert =
//					    $"INSERT INTO Genre(Name)" +
//                        $"VALUES ({genre.Name})";


//                } else if (item.GetType() == typeof(SettingsModel))
//                {
//					SettingsModel settings = (SettingsModel)item;

//                    insert =
//                        $"INSERT INTO Settings(Setting, Comment, Img)" +
//                        $"VALUES ({settings.Setting}, {settings.Comment}, {settings.IMG})";

//				} else if (item.GetType() == typeof(WatchLaterAnimeModel))
//				{
//					WatchLaterAnimeModel watchLaterA = (WatchLaterAnimeModel)item;

//                    insert = 
//                        $"INSERT INTO WatchLaterAnime(AnimeID, Comment)" +
//                        $"VALUES ({watchLaterA.AnimeID}, {watchLaterA.Comment})";

//				} else if (item.GetType() == typeof(WatchLaterMovieModel))
//                {
//					WatchLaterMovieModel watchLaterM = (WatchLaterMovieModel)item;

//					insert =
//						$"INSERT INTO WatchLaterMovie(MovieID, Comment)" +
//						$"VALUES ({watchLaterM.MovieID}, {watchLaterM.Comment})";
//				}

//				if (!string.IsNullOrEmpty(insert))
//                {
//                    UseSQLCommand(connection, insert);

//					Console.WriteLine("Data inserted successfully.");
//				}
//			}
//		}

//        public void DbUpdateData(object item)
//		{
//            using (var connection = GetConnection())
//            {
//                string update = "";

//                if (item.GetType() == typeof(AnimeModel))
//                {
//					AnimeModel anime = (AnimeModel)item;

//					update =
//						$"UPDATE Anime " +
//						$"SET Name = {anime.Item.Name}, OriginalName = {anime.OriginalName}, Rank = {anime.Rank}, Text = {anime.Item.Text}, " +
//                        $"Buy = {anime.Item.Buy}, Img = {anime.Item.IMG}, AnimeID = {anime.Item.ParentID}, Link = {anime.Item.Link}," +
//                        $"DateAired = {anime.Item.Date} " +
//						$"WHERE ID = {anime.Item.ID}"; 

//				} else if (item.GetType() == typeof(MovieModel))
//                {
//					MovieModel movie = (MovieModel)item;

//					update =
//						$"UPDATE Movie " +
//						$"SET Name = {movie.Item.Name}, Buy = {movie.Item.Buy}, Text = {movie.Item.Text}, Img = {movie.Item.IMG}, " +
//                        $"MovieID = {movie.Item.ParentID}, Age = {movie.FSK}, Favorit = {movie.Favourite}, Link = {movie.Item.Link}, " +
//                        $"DateAired = {movie.Item.Date} "  +
//						$"WHERE ID = {movie.Item.ID}";

//				} else if (item.GetType() == typeof(SettingsModel))
//				{
//					SettingsModel setting = (SettingsModel)item;

//                    update =
//                        $"UPDATE Settings " +
//                        $"SET Setting = {setting.Setting}, Comment = {setting.Comment}, Img = {setting.IMG}" +
//                        $"WHERE ID = {setting.ID}";
//				}

//				if (!string.IsNullOrEmpty(update))
//				{
//                    UseSQLCommand(connection, update);

//					Console.WriteLine("Data update successfully.");
//				}

//			}
//        }

//		public void DbDeleteData(object item)
//        {
//            using (var connection = GetConnection())
//            {
//                string delete = "";

//                if (item.GetType() == typeof(AnimeModel))
//                {
//                    AnimeModel anime = (AnimeModel)item;

//					delete =
//						$"DELETE FROM Anime" +
//						$"WHERE ID = {anime.Item.ID};" +
//						$"DELETE FROM WatchLaterAnime" +
//						$"WHERE MovieID = {anime.Item.ID};" +
//						$"DELETE FROM AnimeGenre" +
//						$"WHERE MovieID = {anime.Item.ID};";

//				}
//				else if (item.GetType() == typeof(MovieModel))
//                {
//					MovieModel movie = (MovieModel)item;

//					delete =
//						$"DELETE FROM Movie" +
//						$"WHERE ID = {movie.Item.ID};" +
//                        $"DELETE FROM WatchLaterMovie" +
//                        $"WHERE MovieID = {movie.Item.ID};" +
//                        $"DELETE FROM MovieGenre" +
//                        $"WHERE MovieID = {movie.Item.ID};";

//				} else if (item.GetType() == typeof(WatchLaterAnimeModel))
//                {
//					WatchLaterAnimeModel watchLaterA = (WatchLaterAnimeModel)item;

//					delete =
//						$"DELETE FROM WatchLaterAnime" +
//						$"WHERE ID = {watchLaterA.Id}";

//				} else if (item.GetType() == typeof(WatchLaterMovieModel))
//                {
//					WatchLaterMovieModel watchLaterM = (WatchLaterMovieModel)item;

//                    delete = 
//                        $"DELETE FROM WatchLaterMovie" +
//                        $"WHERE ID = {watchLaterM.Id}";
//				}

//				if (!string.IsNullOrEmpty(delete))
//				{
//					UseSQLCommand(connection, delete);

//					Console.WriteLine("Data delete successfully.");
//				}

//			}
//		}

//		public void DbReadData(object item)
//		{
//			// TODO for WatchLater-Anime/Movies, Genre, Settings, Anime and Movie (with all Gernres)
//		}

//	}
//}
