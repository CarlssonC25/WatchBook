using System;
using Microsoft.Data.Sqlite;

namespace WatchBook.Data
{
    public class MyDbContext
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=WatchBookDB.db";

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Erstellen Sie die Tabellen
                string createAnimeTable = @"
                CREATE TABLE IF NOT EXISTS Anime (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Rank TINYINT,
                    Name TEXT,
                    OriginalName TEXT,
                    Text TEXT,
                    Buy TINYINT,
                    Img BLOB,
                    AnimeID INTEGER,
                    Link TEXT,
                    SearchCount INTEGER,
                    DateAired DATE
                )";

                string createWatchLaterAnimeTable = @"
                CREATE TABLE IF NOT EXISTS WatchLaterAnime (
                    AnimeID INTEGER,
                    Comment TEXT,
                    FOREIGN KEY (AnimeID) REFERENCES Anime (ID)
                )";

                string createGenreTable = @"
                CREATE TABLE IF NOT EXISTS Genre (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT
                )";

                string createAnimeGenreTable = @"
                CREATE TABLE IF NOT EXISTS AnimeGenre (
                    AnimeID INTEGER,
                    GenreID INTEGER,
                    FOREIGN KEY (AnimeID) REFERENCES Anime (ID),
                    FOREIGN KEY (GenreID) REFERENCES Genre (ID)
                )";

                string createMovieTable = @"
                CREATE TABLE IF NOT EXISTS Movie (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT,
                    Buy TINYINT,
                    Text TEXT,
                    Img BLOB,
                    MovieID INTEGER,
                    Episodes INTEGER,
                    Age TINYINT,
                    Favorit BOOLEAN,
                    DateAired DATE
                )";

                string createWatchLaterMovieTable = @"
                CREATE TABLE IF NOT EXISTS WatchLaterMovie (
                    MovieID INTEGER,
                    Comment TEXT,
                    FOREIGN KEY (MovieID) REFERENCES Movie (ID)
                )";

                string createMovieGenreTable = @"
                CREATE TABLE IF NOT EXISTS MovieGenre (
                    MovieID INTEGER,
                    GenreID INTEGER,
                    FOREIGN KEY (MovieID) REFERENCES Movie (ID),
                    FOREIGN KEY (GenreID) REFERENCES Genre (ID)
                )";

                string createSettingsTable = @"
                CREATE TABLE IF NOT EXISTS Settings (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Comment TEXT,
                    Img BLOB
                )";

                // Führen Sie die SQL-Befehle aus
                using (var command = new SqliteCommand(createAnimeTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createWatchLaterAnimeTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createGenreTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createAnimeGenreTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createMovieTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createWatchLaterMovieTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createMovieGenreTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SqliteCommand(createSettingsTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Beispiel für das Einfügen von Daten
                string insertAnime = @"
                INSERT INTO Anime (Rank, Name, OriginalName, Text, Buy, Img, AnimeID, Link, SearchCount, DateAired)
                VALUES (1, 'My Anime', 'Original Name', 'Some text', 1, NULL, 1, '', 100, '2023-07-23')";

                using (var command = new SqliteCommand(insertAnime, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Beispiel für das Abrufen von Daten
                string selectAnime = "SELECT * FROM Anime";
                using (var command = new SqliteCommand(selectAnime, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}");
                    }
                }
            }
        }
    }
}
