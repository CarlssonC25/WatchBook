namespace WatchBook.Models
{
    public class ItemRawModel
    {
        public string Name { get; set; }
        public int Buy { get; set; } // 0 = TO Buy | 1 = HD | 2 = BluRay
        public List<string> Genres { get; set; }
        public byte[] IMG { get; set; } // Assuming img is stored as byte array
        public string Text { get; set; } // text string ??
        public string Link { get; set; }
        public DateTime Date { get; set; }
    }
}
