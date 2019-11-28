using System;
using System.Collections.Generic;

namespace BinghamRailroad.Models {
    public class StationInfoViewModel {
        public List<String> Amenities { get; set; }
        public List<String> IncomingConnections { get; set; }
        public List<String> OutgoingConnections { get; set; }
    }
}