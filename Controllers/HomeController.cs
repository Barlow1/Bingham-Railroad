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
        [HttpPost]
        public IActionResult Routes(Route searchRoute)
        {
            var OriginStationId = searchRoute.OriginStation;
            var DestinationStationId = searchRoute.DestinationStation;
            DateTime DepartureDate = searchRoute.DepartureTime;
            DateTime ArrivalDate = searchRoute.ArrivalTime;

            ViewData["OriginStationName"] = (from station in _context.Set<Station>()
                                          where station.Id == searchRoute.OriginStation
                                          select station.Name).Single();

            ViewData["DestinationStationName"] = (from station in _context.Set<Station>()
                                               where station.Id == searchRoute.DestinationStation
                                               select station.Name).Single();

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

            return View("Routes", routes);
        }

        // This method gets called when user clicks Buy Ticket on search results
        // page. Redirects to sign in page if user is not signed in.
        public IActionResult BuyTicket(int RouteId)
        {
            int riderId = AuthenticateUser();
            _context.Add(new Ticket{RiderId = riderId, RouteId = RouteId});
            _context.SaveChanges();
            return View("Index");
        }

        // This method gets called when a logged in user views their previously
        // "bought" rides. Redirects to sign in page if user is not signed in.
        public IActionResult ViewRides()
        {
            int riderId = AuthenticateUser();

            var rides =
            (from rider in _context.Set<Rider>()
            join ticket in _context.Set<Ticket>() on rider.Id equals ticket.RiderId
            join route in _context.Set<Route>() on ticket.RouteId equals route.Id
            join oStation in _context.Set<Station>() on route.OriginStation equals oStation.Id
            join dStation in _context.Set<Station>() on route.DestinationStation equals dStation.Id
            where rider.Id == riderId
            select new YourRidesViewModel {
                OriginStation = oStation.Name,
                DestinationStation = dStation.Name,
                DepartureTime = route.DepartureTime,
                ArrivalTime = route.ArrivalTime
            }).ToList();

            var displayName =
            from rider in _context.Set<Rider>()
            where rider.Id == riderId
            select new {
                First = rider.FName,
                Last = rider.LName
            };

            ViewData["DisplayName"] = displayName.First().ToString();
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

            ViewData["DisplayStation"] =
            (from station in _context.Set<Station>()
            where station.Id == StationId
            select station.Name).First().ToString();

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // This method is called when the user navigates to the page where they
        // enter their info to sign in.
        public IActionResult SignIn()
        {
            return View();
        }

        // This method is called when the user clicks the sign in button on
        // the sign in page.
        [HttpPost]
        public IActionResult SignIn(UserSignInViewModel userInfo)
        {
            if(userInfo.Username == null || userInfo.Username == "")
            {
                ViewData["Error"] = "Username must be provided";
                return View();
            }
            else if(userInfo.Password == null || userInfo.Password == "")
            {
                ViewData["Error"] = "Password must be provided";
                return View();
            }

            string username = userInfo.Username;
            string password = userInfo.Password;

            var user =
            from rider in _context.Set<Rider>()
            where rider.UserName == username
            select rider;

            if(user.Count() == 0)
            {
                ViewData["Error"] = "Failed to sign in due to invalid username";
                return View();
            }

            var hashedPassword = user.First().Password;

            if(!Crypto.VerifyHashedPassword(hashedPassword, password))
            {
                ViewData["Error"] = "Failed to sign in due to wrong password";
                return View();
            }
            else
            {
                HttpContext.Response.Cookies.Append("AuthUserId", user.First().Id.ToString());
                return RedirectToAction("Index");
            }
        }

        // This method is called when the user navigates to the page where they
        // enter their info to create an account.
        public IActionResult CreateAccount()
        {
            return View();
        }

        // This method will be called when a user attempts to create an account.
        [HttpPost]
        public IActionResult CreateAccount(Rider newRider)
        {
            string lastName = newRider.FName;
            string firstName = newRider.LName;
            string username = newRider.UserName;
            string password = newRider.Password;

            // Make sure username is unique. DB checks this also but we can fail more
            // gracefully if we catch it here.
            int unique = (from rider in _context.Set<Rider>()
                       where rider.UserName == username
                       select rider).Count();
            if(unique != 0)
            {
                ViewData["Error"] = "Account creation failed. Username " +
                                    username + " is already in use.";
                return View("CreateAccount");
            }

            _context.Add(new Rider {
                FName = firstName,
                LName = lastName,
                UserName = username,
                Password = Crypto.HashPassword(password)
            });
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult AccountInfo()
        {
            int riderId = AuthenticateUser();

            var riderInfo =
            from rider in _context.Set<Rider>()
            where rider.Id == riderId
            select rider;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Returns the user id if the user has been authenticated, otherwise redirects to
        // sign in page and returns -1.
        private int AuthenticateUser()
        {
            if(HttpContext.Request.Cookies.ContainsKey("AuthUserId"))
            {
                return Int32.Parse(HttpContext.Request.Cookies["AuthUserId"]);
            }
            else
            {
                RedirectToAction("SignIn");
                return -1;
            }
        }
    }
}
