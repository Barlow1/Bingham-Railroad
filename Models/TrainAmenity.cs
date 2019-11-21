using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinghamRailroad.Models {
    public class TrainAmenity {
        public int Id { get; set; }
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        [ForeignKey("Amenity")]
        public int AmenityId { get; set; }
    }
}