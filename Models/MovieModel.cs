namespace WatchBook.Models
{
    public class MovieModel
    {
        public required int ID { get; set; }
        public required int FSK { get; set; }
        public required bool Favourite { get; set; }


        public required ItemRawModel Item { get; set; }
    }
}
