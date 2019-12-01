using System;
using System.ComponentModel.DataAnnotations;

namespace BinghamRailroad.Models {
    public class Rider {
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters.")]
        [RegularExpression("((?=.*/d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%?=*&]))",
                            ErrorMessage="Password must contain upper and lower case letters as at least one digit and at least one special character.")]
        public string Password { get; set; }
    }
}