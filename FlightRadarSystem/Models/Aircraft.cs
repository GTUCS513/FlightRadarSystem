using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightRadarSystem.Models
{
    public class Aircraft
    {
        public Aircraft(string name, string type, string code, string imageName)
        {
            this.name = name;
            this.type = type;
            this.code = code;
            this.imageName = imageName;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string imageName;

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
    }
}