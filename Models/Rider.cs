using System;
using System.ComponentModel.DataAnnotations;

namespace BinghamRailroad.Models {
    public class Rider {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}