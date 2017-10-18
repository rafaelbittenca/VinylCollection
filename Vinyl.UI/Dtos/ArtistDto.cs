using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinyl.UI.Dtos
{
    public class ArtistDto
    {
		public long? Id { get; set; }

		[Required]
		[StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		public DateTime BirthDate { get; set; }

		public string AboutLink { get; set; }

		public byte[] Picture { get; set; }
	}
}
