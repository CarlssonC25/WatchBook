namespace WatchBook.Models
{
	public class WatchLaterAnimeModel
	{
		public int Id { get; set; }
		public int AnimeID { get; set; }
		public string Comment { get; set; }
	}

	public class WatchLaterMovieModel
	{
		public int Id { get; set; }
		public int MovieID { get; set; }
		public string Comment { get; set; }
	}
}
