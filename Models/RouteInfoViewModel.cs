using System;
using System.Collections.Generic;

namespace BinghamRailroad.Models {
    public class RouteInfoViewModel {
        public int RouteId { get; set; }
        public int TrainId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int OpenSeats { get; set; }
        public List<String> Amenities { get; set; }
    }
}