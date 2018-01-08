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
        private static Models.MainModel mm;
        public static System.Timers.Timer timer;

        public HomeController()
        {
            mm = new Models.MainModel(this);
            timer = new System.Timers.Timer(15*60*1000); // call every 15 min.
            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            mm.flights = Models.DataRetriever.RetrieveFlights(mm.airports);
        }

        public ActionResult Index()
        {
            InitializeData();
            ViewData["Flights"] = mm.flights;
            ViewData["Airports"] = mm.airports;
            ViewData["Aircrafts"] = mm.aircrafts;
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
            //airports.Add(new Models.Airport("Adana Sakirpasa Airport", "Turkey", 36.97582943, 35.274832234));
            //airports.Add(new Models.Airport("Ankara Esenboga International Airport", "Turkey", 40.1244, 32.9917));
            //airports.Add(new Models.Airport("JFK Airport", "USA", 40.64416666, -73.78222));

            mm.aircrafts.Add(new Models.Aircraft("Turkish Airlines","TK / THY","A319","anadolujet.jpg"));
            mm.aircrafts.Add(new Models.Aircraft("Pegasus Airlines", "PC / PGT", "A320","turkishairlines.jpg"));
            
            //mm.flights.Add(new Models.Flight(mm.aircrafts[0],new DateTime(2017,12,7,23,22,38),new DateTime(2017,12,7,1,10,0),mm.airports[0],mm.airports[1],"ABCDE"));
            //mm.flights.Add(new Models.Flight(mm.aircrafts[0], new DateTime(2017, 12, 30, 12, 22, 45), new DateTime(2017, 12, 30, 14, 0, 0), mm.airports[1], mm.airports[2], "ADE"));
            //mm.flights.Add(new Models.Flight(mm.aircrafts[1], new DateTime(2017, 12, 10, 1, 50, 0), new DateTime(2017, 12, 11, 10, 10, 0), mm.airports[0], mm.airports[2], "CDE"));

            //mm.flights[0].Longitude = 55.5698;
            //mm.flights[1].Longitude = -25.5698;
            //mm.flights[2].Longitude = 85.5698;
                        
            
            mm.airports.AddRange(Models.Database.getInstance().getAirports());
            mm.flights.AddRange(Models.DataRetriever.RetrieveFlights(mm.airports));
            
        }
    }
}