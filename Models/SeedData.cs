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
                if(!context.Station.Any())
                {
                    context.AddRange(
                        new Station {
                            Name = "Union Station - KC"
                        },
                        new Station {
                            Name = "St. Louis Station"
                        }
                    );
                }
                // If the Train table is empty, seed it.
                if(!context.Train.Any())
                {
                    context.AddRange(
                        new Train {
                            NumSeats = 100
                        }
                    );
                }
                // If the Amenity table is empty, seed it.
                if(!context.Amenity.Any())
                {
                    context.AddRange(
                        new Amenity {
                            Name = "Wifi"
                        },
                        new Amenity {
                            Name = "Sports Bar"
                        }
                    );
                }
                // If the Rider table is empty, seed it.
                if(!context.Rider.Any())
                {
                    context.AddRange(
                      new Rider {
                          FName = "Ghost",
                          LName = "Rider",
                          UserName = "Ride_Angry",
                          Password = "password1"
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
                            TrainId = 1,
                            AmenityId = 1
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
                            StationId = 1,
                            AmenityId = 1
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}