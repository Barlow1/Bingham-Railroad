using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinghamRailroad.Models {
    public class Route {
        public int Id { get; set; }
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        [ForeignKey("Station")]
        public int OriginStation { get; set; }
        [ForeignKey("Station")]
        public int DestinationStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}