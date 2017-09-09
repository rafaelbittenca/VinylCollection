namespace Vinyl.Models
{
    public class Record : AuditableEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rate { get; set; }
        public byte[] Cover { get; set; }

        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
