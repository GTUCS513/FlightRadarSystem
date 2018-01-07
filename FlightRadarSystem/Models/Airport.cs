using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{   

    public class Airport
    {

        private string airportName;
        private Enum.Country country;
        private int weather;
        private int wind;
        private double latitude;
        private double longitude;


        public Airport(string airportName, Enum.Country country, double lat, double log)
        {
            this.airportName = airportName;
            this.country = country;
            this.latitude = lat;
            this.longitude = log;
        }

        

        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }

        

        public Enum.Country Country
        {
            get { return country; }
            set { country = value; }
        }

        

        public int Weather
        {
            get { return weather; }
            set { weather = value; }
        }

        

        public int Wind
        {
            get { return wind; }
            set { wind = value; }
        }

        

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public string Icon
        {
            get { return "http://maps.google.com/mapfiles/kml/paddle/blu-blank.png"; }
        }
            
    }
}