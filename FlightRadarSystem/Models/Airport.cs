using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    public class Airport
    {
        public Airport(string airportName, Enum.Country country, double lat, double log)
        {
            this.airportName = airportName;
            this.country = country;
            this.latitude = lat;
            this.longitude = log;
        }

        private string airportName;

        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }

        private Enum.Country country;

        public Enum.Country Country
        {
            get { return country; }
            set { country = value; }
        }

        private int weather;

        public int Weather
        {
            get { return weather; }
            set { weather = value; }
        }

        private int wind;

        public int Wind
        {
            get { return wind; }
            set { wind = value; }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        private double longitude;

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