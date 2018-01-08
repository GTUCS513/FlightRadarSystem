﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Globalization;

namespace FlightRadarSystem.Models
{
    public class DataRetriever
    {

        public static List<Models.Flight> RetrieveFlights() {
            List<Models.Flight> flights = new List<Models.Flight>(); 

            flights.AddRange(RetrieveAirportFlights("http://www.esenbogaairport.com/en-EN/flightinfo/Pages/Arrival.aspx", false, false)); // international arrival
            flights.AddRange(RetrieveAirportFlights("http://www.esenbogaairport.com/en-en/flightinfo/pages/arrival1.aspx", false, true)); // domestic arrival
            flights.AddRange(RetrieveAirportFlights("http://www.esenbogaairport.com/en-en/flightinfo/pages/Departure.aspx", true, false));  //international departure
            flights.AddRange(RetrieveAirportFlights("http://www.esenbogaairport.com/en-en/flightinfo/pages/departure.aspx", true, true)); // domestic departure

            return flights;

        }

        public static List<Models.Flight> RetrieveAirportFlights(String url, bool isDeparture, bool isDomestic) {

            List<Models.Flight> flights = new List<Models.Flight>();

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            HtmlNode node = document.DocumentNode.SelectNodes("//div[@id='ucus_bilgileri_ucuslar']").First();

            HtmlNode[] trNodes = node.SelectNodes(".//tr").ToArray();

            String innerhtml = "";

            for (int i = 0; i < trNodes.Length; i++)
            {                

                HtmlNode[] tdNodes = trNodes[i].SelectNodes(".//td").ToArray();

                int size =tdNodes.Length;

                String[] flightInfo = new String[size];
               
                for (int j = 0; tdNodes != null &&  j < size; j++)
                {
                    innerhtml = tdNodes[j].InnerHtml;
                    if (innerhtml.Contains("span"))
                    {
                        int sspan = innerhtml.IndexOf(">");
                        int espan = innerhtml.IndexOf("</span>");

                        innerhtml = innerhtml.Substring(sspan + 1, espan - sspan - 1);

                    }

                    if (innerhtml.Contains("img"))
                    {
                        int simg = innerhtml.IndexOf("\"");
                        int eimg = innerhtml.IndexOf("\"", simg + 1);

                        innerhtml = innerhtml.Substring(simg + 1, eimg - simg - 1);
                    }

                    flightInfo[j] = innerhtml == null ? null : innerhtml.Trim();


                }

                //Date	Schedule	Estimated	Actual	Airline	Flight Number	Arrival	Remark	Carousel

                DateTime date = flightInfo[0].Equals("") ? new DateTime() : DateTime.ParseExact(flightInfo[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);

                DateTime schedule = flightInfo[1].Equals("") ? new DateTime() : DateTime.ParseExact(flightInfo[0] + " " + flightInfo[1], "dd.MM.yyyy h:mm tt", CultureInfo.InvariantCulture);
                DateTime estimated = flightInfo[2].Equals("") ? new DateTime() : DateTime.ParseExact(flightInfo[0] + " " + flightInfo[2], "dd.MM.yyyy h:mm tt", CultureInfo.InvariantCulture);
                DateTime actual = flightInfo[3].Equals("") ? new DateTime() : DateTime.ParseExact(flightInfo[0] + " " + flightInfo[3], "dd.MM.yyyy h:mm tt", CultureInfo.InvariantCulture);

                String iconurl = flightInfo[4];
                String flightNo = flightInfo[5];
                String destination = flightInfo[6];
                String status = flightInfo[7];
                int gate = flightInfo[8].Equals("") ? -1 : Int32.Parse(flightInfo[8]);

                Models.Flight flight;
                if (isDeparture)
                    flight = new Flight(new Aircraft(), schedule, estimated, new Airport("Esenboğa"), new Airport(destination), null);
                else
                    flight = new Flight(new Aircraft() , schedule, estimated, new Airport(destination), new Airport("Esenboğa"), null);

                flights.Add(flight);
            }

            return flights;
        } 


        public static String getWebSiteContent(String url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream data = response.GetResponseStream();
                string html = String.Empty;
                using (StreamReader sr = new StreamReader(data))
                {
                    html = sr.ReadToEnd();
                }

                return html;

                //WebClient client = new WebClient();
                //String downloadedString = client.DownloadString("http://www.havalimani.com/havalimanlari/ataturk-havalimani-domarr.php");
                //ViewBag.Message = downloadedString.Substring(1,100);
            }
            catch (System.Net.WebException we)
            {
                return we.Message;
            }

        }

    }

     
}