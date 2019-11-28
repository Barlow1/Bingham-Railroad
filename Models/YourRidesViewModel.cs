using System;
using System.Collections.Generic;

namespace BinghamRailroad.Models {
    public class YourRidesViewModel {
        public string OriginStation { get; set; }
        public string DestinationStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}