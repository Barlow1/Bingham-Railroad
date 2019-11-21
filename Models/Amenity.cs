using System;
using System.ComponentModel.DataAnnotations;

namespace BinghamRailroad.Models {
    public class Amenity {
        [Key]
        public string Name { get; set ;}
    }
}