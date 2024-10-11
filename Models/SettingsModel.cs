namespace WatchBook.Models
{
    public class SettingsModel
    {
        public int ID { get; set; }
        public required string Setting { get; set; }
        public string Comment { get; set; }
        public byte[] IMG { get; set; } // Assuming img is stored as byte array
    }
}
