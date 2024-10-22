namespace WatchBook.Models
{
    public class MovieModel
    {
        public required byte FSK { get; set; }
        public required bool Favourite { get; set; }


        public required ItemRawModel Item { get; set; }
    }
}
