using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BinghamRailroad.Models
{
    public class Search
    {
     
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Station OriginStation { get; set; }
        public Station DestinationStation { get; set; }
    }
}