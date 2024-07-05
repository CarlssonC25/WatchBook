namespace WatchBook.Models
{
    public class ItemModel
    {
        public required string Name { get; set; }
        public required int Buy { get; set; } // 0 = TO Buy | 1 = HD | 2 = BluRay
        public required List<string> Genres { get; set; }
        public required string Text { get; set; } // text string ??
        public required string Link { get; set; }
        public required DateTime Date { get; set; }


        public AnimeRawModel? AnimeInfo { get; set; }
        public MovieRawModel? MovieInfo { get; set; }
    }
}
