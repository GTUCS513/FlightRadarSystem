using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

namespace FlightRadarSystem.Controllers
{
    public class HomeController : Controller
    {
        List<Models.Flight> flights = new List<Models.Flight>();
        List<Models.Airport> airports = new List<Models.Airport>();
        List<Models.Aircraft> aircrafts = new List<Models.Aircraft>();

        public ActionResult Index()
        {
            InitializeData();
            ViewData["Flights"] = flights;
            ViewData["Airports"] = airports;
            ViewData["Aircrafts"] = aircrafts;
            return View();
        }

        public ActionResult GotoMainPage()
        {
            return View("MainPage");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void InitializeData()
        {
            airports.Add(new Models.Airport("Adana Sakirpasa Airport", Models.Enum.Country.Turkey, 36.97582943, 35.274832234));
            airports.Add(new Models.Airport("Ankara Esenboga International Airport", Models.Enum.Country.Turkey, 40.1244, 32.9917));
            airports.Add(new Models.Airport("JFK Airport", Models.Enum.Country.USA, 40.64416666, -73.78222));

            aircrafts.Add(new Models.Aircraft("Turkish Airlines","TK / THY","A319","anadolujet.jpg"));
            aircrafts.Add(new Models.Aircraft("Pegasus Airlines", "PC / PGT", "A320","turkishairlines.jpg"));
            
            flights.Add(new Models.Flight(aircrafts[0],new DateTime(2017,12,7,23,22,38),new DateTime(2017,12,7,1,10,0),airports[0],airports[1],"ABCDE"));
            flights.Add(new Models.Flight(aircrafts[0], new DateTime(2017, 12, 30, 12, 22, 45), new DateTime(2017, 12, 30, 14, 0, 0), airports[1], airports[2], "ADE"));
            flights.Add(new Models.Flight(aircrafts[1], new DateTime(2017, 12, 10, 1, 50, 0), new DateTime(2017, 12, 11, 10, 10, 0), airports[0], airports[2], "CDE"));

            flights[0].Longitude = 55.5698;
            flights[1].Longitude = -25.5698;
            flights[2].Longitude = 85.5698;

            flights.AddRange(Models.DataRetriever.RetrieveFlights());
            
        }
    }
}