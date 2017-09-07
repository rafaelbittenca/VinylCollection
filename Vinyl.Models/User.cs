namespace Vinyl.Models
{
    public class User : Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Avatar { get; set; }
    }
}
