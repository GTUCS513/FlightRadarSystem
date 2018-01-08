using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FlightRadarSystem.Models
{
    public class FileReader
    {
        public string[] readAirportsFromFile(String filename)
        {
            StreamReader objInput = new StreamReader(filename, System.Text.Encoding.Default);

            string contents = objInput.ReadToEnd().Trim();           
            string[] split = Regex.Split(contents, ",", RegexOptions.None);

            return split;

        }

    }
}