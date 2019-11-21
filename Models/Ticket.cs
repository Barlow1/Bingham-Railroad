using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinghamRailroad.Models {
    public class Ticket {
        public int Id { get; set; }
        [ForeignKey("Rider")]
        public int RiderId { get; set; }
        [ForeignKey("Route")]
        public int RouteId { get; set; }
    }
}