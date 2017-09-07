using System.ComponentModel.DataAnnotations;

namespace Vinyl.UI.ViewModels
{
    public class EmailContact
    {
        [DataType(DataType.EmailAddress), Display(Name = "Your Email")]
        [Required]
        public string ToEmail { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public string EmailSubject { get; set; }

        [Display(Name = "Your Name")]
        public string ToName { get; set; }

        [Display(Name = "Message")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "CC")]
        public string EmailCC { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "BCC")]
        public string EmailBCC { get; set; }
    }
}