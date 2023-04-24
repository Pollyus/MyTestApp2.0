using System.ComponentModel.DataAnnotations;

namespace ReactApp.ViewModels
{
    public class IdentityViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
