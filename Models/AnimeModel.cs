namespace WatchBook.Models
{
    public class AnimeModel
    {
        public required string OriginalName { get; set; }
        public required bool Country { get; set; } // true = Japan | false = China
        public required int Rank { get; set; } // 1-10 and 11 = S
        public required int Episodes { get; set; } // if only 1 is a Anime Movie

        public required ItemRawModel Item { get; set; }
    }
}
