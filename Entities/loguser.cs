using System.ComponentModel.DataAnnotations;


    public class loguser
    {
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }

