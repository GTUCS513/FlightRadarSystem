using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    public class MainModel
    {
        public List<Models.Flight> flights {get; set;}
        public List<Models.Airport> airports { get; set; }
        public List<Models.Aircraft> aircrafts {get; set;}

        private Controllers.HomeController hc;
        private Models.Database db;
        private Models.DataRetriever dr;

        public MainModel(Controllers.HomeController hc)
        {
            this.hc = hc;
            db = Database.getInstance();
            dr = new DataRetriever();

            flights = new List<Models.Flight>();
            airports = new List<Models.Airport>();
            aircrafts = new List<Models.Aircraft>();
        }

        public Airport findAirport(string name) {

            Airport ap = airports.Find(x => x.alias.Contains(name));
            ap = ap == null ? airports.Find(x => x.AirportName.Contains(name)) : ap;
    
            return ap;

        }

    }
}