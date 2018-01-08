using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace FlightRadarSystem.Models
{
    public class Aircraft
    {
        private string name;
        private string type;
        private string code;
        private string imageName;

        public static String defaultImageName = "turkishairlines.jpg";

        public Aircraft()
            : this("Turkish Airlines", "TK / THY", "A319", defaultImageName)
        {
           
        }

        public Aircraft(String name)
            : this(name, "TK / THY", "A319", defaultImageName)
        {

        }

        public Aircraft(string name, string type, string code, string imageName)
        {
            this.name = name;
            this.type = type;
            this.code = code;
            this.imageName = imageName;
        }

        public Aircraft(int aircraftid)
        {
            String[] info = Database.getInstance().getAircraft(aircraftid);
            if (info == null || info.Length < 4)
            {
                this.name = "Turkish Airlines";
                this.type = "TK / THY";
                this.code = "A319";
                this.imageName = defaultImageName;
            }
            else
            {
                this.name = info[0];
                this.type = info[1];
                this.code = info[2];
                this.imageName = info[3];
            }

        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        

        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; }
        }
    }
}