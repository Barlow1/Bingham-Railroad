using System.ComponentModel.DataAnnotations;

namespace BinghamRailroad.Models {
    public class UserSignInViewModel {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}