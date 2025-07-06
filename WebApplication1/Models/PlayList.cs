namespace WebApplication1.Models
{
    public class PlayList
    {
        public string PlaylistName { get; set; }
        public string PlaylistDescription { get; set; }
        public string PlaylistImageUrl { get; set; }
        public int NumberOfSongs { get; set; }
        public List<Song> Songs { get; set; }
    }

    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
    }
}