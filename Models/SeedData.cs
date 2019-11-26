using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BinghamRailroad.Data;
using System;
using System.Linq;

namespace BinghamRailroad.Models {
    public static class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new BingRailContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BingRailContext>>()))
            {
                // If the Station table is empty, seed it.
                if (!context.Station.Any())
                {
                    context.AddRange(
                        new Station {
                            Id = 20,
                            Name = "Union Station - KC"
                        },
                        new Station {
                            Id = 41,
                            Name = "St. Louis Station"
                        },
                        new Station
                        {
                            Id = 1,
                            Name = "Amtrak Train Station"
                        },
                        new Station
                        {
                            Id = 45,
                            Name = "30th Street Station"
                        },
                        new Station
                        {
                            Id = 38,
                            Name = "Cincinnati Union Terminal"
                        },
                        new Station
                        {
                            Id = 99,
                            Name = "Buffalo Central Terminal"
                        },
                        new Station
                        {
                            Id = 2,
                            Name = "Grand Central Terminal"
                        },
                        new Station
                        {
                            Id = 53,
                            Name = "Hoboken Terminal"
                        },
                        new Station
                        {
                            Id = 112,
                            Name = "Los Angeles Union Station"
                        },
                        new Station
                        {
                            Id = 129,
                            Name = "Mount Royal Station"
                        },
                        new Station
                        {
                            Id = 39,
                            Name = "Pennsylvania Station"
                        },
                        new Station
                        {
                            Id = 86,
                            Name = "Reading Terminal"
                        },
                        new Station
                        {
                            Id = 143,
                            Name = "Central Station"
                        },
                        new Station
                        {
                            Id = 17,
                            Name = "Dearborn Station"
                        },
                        new Station
                        {
                            Id = 30,
                            Name = "Denver Union Station"
                        },
                        new Station
                        {
                            Id = 49,
                            Name = "St.Paul Union Depot"
                        },
                        new Station
                        {
                            Id = 141,
                            Name = "Grande Central Station"
                        },
                        new Station
                        {
                            Id = 65,
                            Name = "Chicago Union Station"
                        },
                        new Station
                        {
                            Id = 88,
                            Name = "King Street Station"
                        },
                        new Station
                        {
                            Id = 10,
                            Name= "Settle Union Station"
                        }
                      
                    );
                }

                // If the Train table is empty, seed it.
                if(!context.Train.Any())
                {
                    context.AddRange(
                        new Train {
                            Id = 1,
                            NumSeats = 100
                        },
                        new Train
                        {
                            Id = 211,
                            NumSeats = 160
                        },
                        new Train
                        {
                            Id = 264,
                            NumSeats = 196
                        },
                        new Train
                        {
                            Id = 316,
                            NumSeats = 150
                        },
                        new Train
                        {
                            Id = 494,
                            NumSeats = 200
                        },
                        new Train
                        {
                            Id = 347,
                            NumSeats = 170
                       
                        },
                        new Train
                        {
                            Id = 246,
                            NumSeats = 140
                        },
                        new Train
                        {
                            Id = 238,
                            NumSeats = 120
                           
                        },
                        new Train
                        {
                            Id = 332,
                            NumSeats = 230
                        },
                        new Train
                        {
                            Id = 451,
                            NumSeats = 250
                        },
                        new Train
                        {
                            Id = 486,
                            NumSeats = 270
                        }
                        
                    );
                }

                // If the Amenity table is empty, seed it.
                if(!context.Amenity.Any())
                {
                    context.AddRange(
                        new Amenity {
                            Id = 1,
                            Name = "Wifi"
                        },
                        new Amenity {
                            Id = 5,
                            Name = "Sports Bar"
                        },
                        new Amenity
                        {
                            Id = 35,
                            Name = "Power Outlets"
                        },
                        new Amenity
                        {
                            Id = 15,
                            Name = "Drinking Water"
                        },
                        new Amenity
                        {
                            Id = 4,
                            Name = "Tables"
                        },
                        new Amenity
                        {
                            Id = 24,
                            Name = "Restrooms"
                        },
                        new Amenity
                        {
                            Id = 13,
                            Name = "Onboard Dinning"
                        }
                    );
                }

                // If the Rider table is empty, seed it.
                if(!context.Rider.Any())
                {
                    context.AddRange(
                      new Rider {
                          Id = 611,
                          FName = "Ghost",
                          LName = "Rider",
                          UserName = "Ride_Angry",
                          Password = "password1"
                      },  
                      new Rider
                      {
                          Id = 746,
                          FName = "Johnnie",
                          LName = "Pena",
                          UserName = "picnicore",
                          Password  = "x5yJRfP2"
                      },
                      new Rider
                      {
                          Id = 931,
                          FName = "Luz",
                          LName = "Keller",
                          UserName = "koaladolls",
                          Password = "M37fdWg6"
                      },
                      new Rider
                      {
                          Id = 951,
                          FName = "Angelica",
                          LName = "Sanders",
                          UserName = "rabbitauthor",
                          Password = "j4yhPa4B"
                      },
                      new Rider
                      {
                          Id = 899,
                          FName = "Roxanne",
                          LName = "Moreno",
                          UserName = "chunkymethods",
                          Password = "y8ptSwUF"
                      },
                      new Rider
                      {
                          Id = 660,
                          FName = "Joyce",
                          LName = "Williamson",
                          UserName = "faxcuddly",
                          Password = "AQM4epVM"
                      }
                    );
                }

                // If the TrainAmenity table is empty, seed it.
                // NOTE: referential integrity is not gauranteed
                // for entries in this file.
                if(!context.TrainAmenity.Any())
                {
                    context.AddRange(
                        new TrainAmenity {
                            Id = 50,
                            TrainId = 1,
                            AmenityId = 1
                        },
                        new TrainAmenity
                        {
                            Id = 40,
                            TrainId = 211,
                            AmenityId = 24
                        },
                        new TrainAmenity
                        {
                            Id= 20,
                            TrainId = 264,
                            AmenityId = 5

                        },
                        new TrainAmenity
                        {
                            Id = 30,
                            TrainId = 316,
                            AmenityId = 15

                        },
                        new TrainAmenity
                        {
                            TrainId =  494,
                            AmenityId = 35

                        },
                        new TrainAmenity
                        {
                            Id = 25,
                            TrainId = 347,
                            AmenityId = 4

                        },
                        new TrainAmenity
                        {
                            Id = 80,
                            TrainId = 332,
                            AmenityId = 13
                        }
                    );
                }

                // If the StationAmenity table is empty, seed it.
                // NOTE: referential integrity is not gauranteed
                // for entries in this file.
                if(!context.StationAmenity.Any())
                {
                    context.AddRange(
                        new StationAmenity {
                            Id = 12,
                            StationId = 1,
                            AmenityId = 1
                        },
                        new StationAmenity
                        {
                            Id = 27,
                            StationId = 20,
                            AmenityId = 5
                        },
                        new StationAmenity
                        {
                            Id = 16,
                            StationId = 45,
                            AmenityId = 35
                        },
                        new StationAmenity
                        {
                            Id = 89,
                            StationId = 38,
                            AmenityId = 15
                        },
                        new StationAmenity
                        {
                            Id = 22,
                            StationId = 41,
                            AmenityId = 4
                        },
                        new StationAmenity
                        {
                            Id = 39,
                            StationId = 99,
                            AmenityId = 24
                        },
                        new StationAmenity
                        {
                            Id = 54,
                            StationId = 2,
                            AmenityId = 13
                        }
                    );
                }

                // If the Route table is empty, seed it.
                // NOTE: referential integrity is not gauranteed
                // for entries in this file.
                if(!context.Route.Any())
                {
                    context.AddRange(
                        new Route {
                            Id = 120,
                            TrainId = 1,
                            OriginStation = 141,
                            DestinationStation = 88,
                            DepartureTime = new DateTime(2019, 11, 25, 12, 15, 00),
                            ArrivalTime = new DateTime(2019, 12, 15, 14, 30, 00)
                        },
                        new Route
                        {
                           Id = 450,
                           TrainId = 211,
                           OriginStation = 20,
                           DestinationStation = 41,
                           DepartureTime = new DateTime(2019, 10, 20, 10, 15, 10),
                           ArrivalTime = new DateTime(2019, 10, 20, 12, 30, 00)
                        },
                        new Route
                        {
                           Id = 505,
                           TrainId = 264,
                           OriginStation = 39,
                           DestinationStation = 86,
                           DepartureTime = new DateTime(2019, 09, 25, 09, 25, 00),
                           ArrivalTime = new DateTime(2019, 09, 30, 22, 35, 10)
                        },
                        new Route
                        {
                           Id = 670,
                           TrainId = 316,
                           OriginStation = 143,
                           DestinationStation = 17,
                           DepartureTime = new DateTime(2019, 08, 20, 12, 15, 00),
                           ArrivalTime = new DateTime(2019, 09, 15, 14, 30, 00)
                        },
                        new Route
                        {
                           Id = 666,
                           TrainId = 347,
                           OriginStation = 30,
                           DestinationStation = 49,
                           DepartureTime = new DateTime(2019, 02, 04, 02, 15, 00),
                           ArrivalTime = new DateTime(2019, 02, 20, 14, 30, 00)
                        }
                    );
                }

                // If the Ticket table is empty, seed it.
                // NOTE: referential integrity is not gauranteed
                // for entries in this file.
                if(!context.Ticket.Any())
                {
                    context.AddRange(
                        new Ticket {
                            Id = 70,
                            RiderId = 611,
                            RouteId = 120
                        },
                        new Ticket
                        {
                            Id = 555,
                            RiderId = 746,
                            RouteId = 450
                        },
                        new Ticket
                        {
                           Id = 09,
                           RiderId = 931,
                           RouteId = 505
                        },
                        new Ticket
                        {
                           Id = 55,
                           RiderId = 951,
                           RouteId = 670
                        },
                        new Ticket
                        {
                           Id = 14,
                           RiderId = 899,
                           RouteId = 666
                        },
                        new Ticket
                        {
                            Id = 33,
                            RiderId = 660,
                            RouteId = 666
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}