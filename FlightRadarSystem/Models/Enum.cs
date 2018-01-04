using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    public class Enum
    {
        public enum Country
        {
            Turkey,
            USA,
            England,
            China
        }

        public enum FlightStatus
        {
            Scheduled,
            Landed,
            Estimated,
        }
    }
}