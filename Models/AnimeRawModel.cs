namespace WatchBook.Models
{
    public class AnimeRawModel
    {
        public required string OriginalName { get; set; }
        public required bool Country { get; set; } // true = Japan | false = China
        public required int Rank { get; set; } // 1-10 and 11 = S
        public int? Episodes { get; set; }
    }
}
