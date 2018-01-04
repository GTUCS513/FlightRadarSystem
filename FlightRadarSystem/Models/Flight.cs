using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    
    public class Flight
    {
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
        private Aircraft aircraft;

        public Aircraft Aircraft
        {
            get { return aircraft; }
            set { aircraft = value; }
        }
        private DateTime departureScheduleTime;

        public DateTime DepartureScheduleTime
        {
            get { return departureScheduleTime; }
            set { departureScheduleTime = value; }
        }

        private DateTime departureActualTime;

        public DateTime DepartureActualTime
        {
            get { return departureActualTime; }
            set { departureActualTime = value; }
        }

        private DateTime arrivalScheduleTime;

        public DateTime ArrivalScheduleTime
        {
            get { return arrivalScheduleTime; }
            set { arrivalScheduleTime = value; }
        }

        private DateTime arrivalActualTime;

        public DateTime ArrivalActualTime
        {
            get { return arrivalActualTime; }
            set { arrivalActualTime = value; }
        }

        private Enum.FlightStatus status;

        public Enum.FlightStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        private Airport departureAirport;

        public Airport DepartureAirport
        {
            get { return departureAirport; }
            set { departureAirport = value; }
        }

        private Airport arrivalAirport;

        public Airport ArrivalAirport
        {
            get { return arrivalAirport; }
            set { arrivalAirport = value; }
        }

        private float speed;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        private string registration;

        public string Registration
        {
            get { return registration; }
            set { registration = value; }
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

        private string icon;

        public string Icon
        {
            get { return "/airplane.png"; }
        }
    }
}