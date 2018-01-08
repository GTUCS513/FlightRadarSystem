using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{

    public class Airport : IEquatable<Airport>
    {

        private string airportName;
        private string country;
        private int weather;
        private int wind;
        private double latitude;
        private double longitude;
        public string city { get; set; }
        public string alias { get; set; }


        public Airport() : this("Esenboğa", "Turkey", 0, 0) { }
        public Airport(String name) : this(name, "Turkey", 0, 0) { }

        public Airport(string airportName, string country, double lat, double lon):this(airportName,"","",country, lat,lon)
        {}

        public Airport(string airportName, string alias, string city, string country, double lat, double lon)
        {
            this.airportName = airportName;
            this.alias = alias;
            this.city = city;
            this.country = country;
            this.latitude = lat;
            this.longitude = lon;
        }
             


        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }


        public bool Equals(Airport other)
        {
            return this.Equals((object)other);
        }


        public override bool Equals(object obj) {
            // STEP 1: Check for null if nullable (e.g., a reference type)
            if (obj == null)
            {
                return false;
            }
            // STEP 2: Check for ReferenceEquals if this is a reference type
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            // STEP 3: equivalent data types
            if (this.GetType() != obj.GetType())
            {
                return false;
            }            

            // STEP 6: Compare identifying fields for equality.
            return this.alias.Equals(((Airport)obj).alias) || this.airportName.Equals(((Airport)obj).airportName);
        }

        public string Country
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