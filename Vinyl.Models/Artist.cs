using System.Collections.Generic;

namespace Vinyl.Models
{
    public class Artist : Person
    {
        public Artist()
        {
            this.Records = new HashSet<Record>();
        }
        public string AboutLink { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<Record> Records { get; set; }
    }
}
