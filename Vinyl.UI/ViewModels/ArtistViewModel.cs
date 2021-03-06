﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vinyl.UI.ViewModels
{
    public class ArtistViewModel
    {
        public long? Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // Globalization
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime BirthDate { get; set; }

        [Display(Name = "About Link (E.g. Wikipedia, Artist WebPage)")]
        public string AboutLink { get; set; }

		//[DataType(DataType.Upload)]
		public byte[] Picture { get; set; }

    }
}