using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BinghamRailroad.Models;
using BinghamRailroad.Data;
using System.Web.Helpers;

namespace BinghamRailroad.Controllers
{
    public class HomeController : Controller
    {
        private readonly BingRailContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BingRailContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allStations = (from Station in _context.Set<Station>()
            select Station).ToList();
            ViewData["Stations"] = allStations;
            return View();
        }

        // This is the method that should get called whenever the user
        // clicks search on the homepage.
        [HttpGet]
        public IActionResult Routes()
        {
            var OriginStationId = 141;
            var DestinationStationId = 88;
            DateTime DepartureDate = DateTime.MinValue;
            DateTime ArrivalDate =  DateTime.MinValue;
            
            // Get matching routes
            List<RouteInfoViewModel> routes = new List<RouteInfoViewModel>();

            if(DateTime.MinValue != DepartureDate)
            {
                if(0 != OriginStationId && 0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    && route.DestinationStation == DestinationStationId
                    && route.DepartureTime.Date == DepartureDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != OriginStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    && route.DepartureTime.Date == DepartureDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.DestinationStation == DestinationStationId
                    && route.DepartureTime.Date == DepartureDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
            }
            else if(DateTime.MinValue != ArrivalDate)
            {
                if(0 != OriginStationId && 0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    && route.DestinationStation == DestinationStationId
                    && route.ArrivalTime.Date == ArrivalDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != OriginStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    && route.ArrivalTime.Date == ArrivalDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.DestinationStation == DestinationStationId
                    && route.ArrivalTime.Date == ArrivalDate
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
            }
            else
            {
                if(0 != OriginStationId && 0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    && route.DestinationStation == DestinationStationId
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != OriginStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.OriginStation == OriginStationId
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
                else if(0 != DestinationStationId)
                {
                    routes = 
                    (from route in _context.Set<Route>()
                    where route.DestinationStation == DestinationStationId
                    select new RouteInfoViewModel {
                        RouteId = route.Id,
                        DepartureTime = route.DepartureTime,
                        ArrivalTime = route.ArrivalTime,
                        TrainId = route.TrainId,
                    }).ToList();
                }
            }

            // Get train amenities for each route
            foreach(var r in routes)
            {
                r.Amenities =
                (from trainAmenity in _context.Set<TrainAmenity>()
                join train in _context.Set<Train>() on trainAmenity.TrainId equals train.Id
                join amenity in _context.Set<Amenity>() on trainAmenity.AmenityId equals amenity.Id
                where train.Id == r.TrainId
                select amenity.Name).ToList();
            }

            // Get remaining seats for each route
            foreach(var r in routes)
            {
                r.OpenSeats =
                (from train in _context.Set<Train>()
                join route in _context.Set<Route>() on train.Id equals route.TrainId
                where route.Id == r.RouteId
                select train.NumSeats).First()
                -
                (from train in _context.Set<Train>()
                join route in _context.Set<Route>() on train.Id equals route.TrainId
                join ticket in _context.Set<Ticket>() on route.Id equals ticket.RouteId
                where route.Id == r.RouteId
                select ticket).Count();
            }

            Console.Write("Number of Routes: " + routes.Count());
            return View("Privacy", routes);
        }

        // This method gets called when user clicks Buy Ticket on search results
        // page.
        public IActionResult BuyTicket(int RiderId, int RouteId)
        {
            _context.Add(new Ticket{RiderId = RiderId, RouteId = RouteId});
            _context.SaveChanges();
            return View("Index");
        }

        // This method gets called when a logged in user views their previous 
        // "bought" rides.
        public IActionResult ViewRides(int RiderId)
        {
            var rides = 
            (from rider in _context.Set<Rider>()
            join ticket in _context.Set<Ticket>() on rider.Id equals ticket.RiderId
            join route in _context.Set<Route>() on ticket.RouteId equals route.Id
            join oStation in _context.Set<Station>() on route.OriginStation equals oStation.Id
            join dStation in _context.Set<Station>() on route.DestinationStation equals dStation.Id
            where rider.Id == RiderId
            select new YourRidesViewModel {
                OriginStation = oStation.Name,
                DestinationStation = dStation.Name,
                DepartureTime = route.DepartureTime,
                ArrivalTime = route.ArrivalTime
            }).ToList();

            return View("Index");
        }

        // This method gets all the data for the Station Information screen. 
        public IActionResult ViewStationInformation(int StationId)
        {
            StationInfoViewModel stationInfo = new StationInfoViewModel();

            stationInfo.Amenities = 
            (from station in _context.Set<Station>()
            join stationAmenity in _context.Set<StationAmenity>() on station.Id equals stationAmenity.StationId
            join amenity in _context.Set<Amenity>() on stationAmenity.AmenityId equals amenity.Id
            where station.Id == StationId
            select amenity.Name).ToList();

            stationInfo.IncomingConnections =
            (from oStation in _context.Set<Station>()
            join route in _context.Set<Route>() on oStation.Id equals route.OriginStation
            join dStation in _context.Set<Station>() on route.DestinationStation equals dStation.Id
            where dStation.Id == StationId
            select oStation.Name).ToList();

            stationInfo.OutgoingConnections = 
            (from oStation in _context.Set<Station>()
            join route in _context.Set<Route>() on oStation.Id equals route.OriginStation
            join dStation in _context.Set<Station>() on route.DestinationStation equals dStation.Id
            where oStation.Id == StationId
            select dStation.Name).ToList();

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        // public IActionResult CreateAccount()
        // {
        //     return View();
        // }

        // This method will be called when a user attempts to create an account.
        // [HttpPost]
        public IActionResult CreateAccount(int temp)
        {
            string lastName = "User";
            string firstName = "Sally";
            string username = "SalUser";
            string password = "password1";

            // Validate param presence.
            if(lastName == null ||
               firstName == null ||
               username == null || 
               password == null)
            {
                Console.WriteLine("Failed account creation due to missing parameters");
                return View("Create");
            }
            if(lastName == "" ||
               firstName == "" ||
               username == "" || 
               password == "")
            {
                Console.WriteLine("Failed account creation due to missing parameters");
                return View("Create");
            }

            // Make sure username is unique. DB checks this also but we can fail more 
            // gracefully if we catch it here.
            int unique = (from rider in _context.Set<Rider>()
                       where rider.UserName == username
                       select rider).Count();
            if(unique != 0)
            {
                Console.WriteLine("Falied account creation due to username already being in use");
                return View("Create");
            }

            _context.Add(new Rider {
                FName = firstName,
                LName = lastName,
                UserName = username,
                Password = Crypto.HashPassword(password)
            });
            _context.SaveChanges();

            return View();
        }
        public IActionResult AccountInfo()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
