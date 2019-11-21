using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinghamRailroad.Models {
    public class StationAmenity {
        public int Id { get; set; }
        [ForeignKey("Station")]
        public int StationId { get; set; }
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
    }
}