using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    
    public class Flight
    {
        private Aircraft aircraft;
        private DateTime departureScheduleTime;
        private DateTime departureActualTime;
        private DateTime arrivalScheduleTime;
        private DateTime arrivalActualTime;
        private Enum.FlightStatus status;
        private Airport departureAirport;
        private Airport arrivalAirport;
        private float speed;
        private string registration;
        private double latitude;
        private double longitude;
        private string icon;


        public Flight(Aircraft aircraft, DateTime departureScheduleTime, DateTime arrivalScheduleTime, Airport departureAirport, Airport arrivalAirport, string registration)
        {
            this.aircraft = aircraft;
            this.departureScheduleTime = departureScheduleTime;
            this.arrivalScheduleTime = arrivalScheduleTime;
            this.departureAirport = departureAirport;
            this.arrivalAirport = arrivalAirport;
            this.latitude = departureAirport.Latitude;
            this.longitude = departureAirport.Longitude;
            this.registration = registration;
        }
        

        public Aircraft Aircraft
        {
            get { return aircraft; }
            set { aircraft = value; }
        }
        

        public DateTime DepartureScheduleTime
        {
            get { return departureScheduleTime; }
            set { departureScheduleTime = value; }
        }

        

        public DateTime DepartureActualTime
        {
            get { return departureActualTime; }
            set { departureActualTime = value; }
        }

        

        public DateTime ArrivalScheduleTime
        {
            get { return arrivalScheduleTime; }
            set { arrivalScheduleTime = value; }
        }

        

        public DateTime ArrivalActualTime
        {
            get { return arrivalActualTime; }
            set { arrivalActualTime = value; }
        }

        

        public Enum.FlightStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        

        public Airport DepartureAirport
        {
            get { return departureAirport; }
            set { departureAirport = value; }
        }

        

        public Airport ArrivalAirport
        {
            get { return arrivalAirport; }
            set { arrivalAirport = value; }
        }

        

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        

        public string Registration
        {
            get { return registration; }
            set { registration = value; }
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
            get { return "/airplane.png"; }
        }
    }
}