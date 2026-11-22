namespace MyWebApi
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lname { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
