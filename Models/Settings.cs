namespace WatchBook.Models
{
    public class Settings
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public byte[] IMG { get; set; } // Assuming img is stored as byte array
    }
}
