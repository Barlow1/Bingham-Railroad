using System;
using System.ComponentModel.DataAnnotations;

namespace BinghamRailroad.Models {
    public class Train {
        public int Id { get; set; }
        public int NumSeats { get; set; }
    }
}