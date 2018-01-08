using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using MySql.Data.MySqlClient;
using System.Configuration;

namespace FlightRadarSystem.Models
{
    public class Database
    {
        public static bool connection_open{get;set;}
        private static MySqlConnection connection;
        private static Database db;
        private static List<Models.Airport> airports;

        //Singleton pattern
        private Database()
        {
            Get_Connection();
        }

        ~Database() {
            Close_Local_Connection();
            db = null;
        }


        public static Database getInstance()
        {
            if (db == null)
                db = new Database();

            return db;
        }

        private static void Get_Connection()
        {
            connection_open = false;

            try
            {
                connection = new MySqlConnection();
                //connection = DB_Connect.Make_Connnection(ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString);
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

                //            if (db_manage_connnection.DB_Connect.OpenTheConnection(connection))
                if (Open_Local_Connection())
                {
                    connection_open = true;
                }
                else
                {
                    //					MessageBox::Show("No database connection connection made...\n Exiting now", "Database Connection Error");
                    //					 Application::Exit();
                }
            }
            catch (System.ArgumentException se)
            {
                string MessageString = "The following error occurred loading the Column details: " + se.Message;

            }

        }

        private static bool Open_Local_Connection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static bool Close_Local_Connection() {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //airport list is retrieved from https://openflights.org/data.html and stored into airports table of mysql flightradar schema
        public List<Models.Airport> getAirports()
        {
            if (airports == null)
                airports = new List<Models.Airport>();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("select idairports, name, iata, city, country, lat, lon from airports");                

                MySqlDataReader reader = cmd.ExecuteReader();

                String[] cols = new String[7];
                Models.Airport ap;

                try
                {
                    
                    int count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            cols[i] = reader.GetString(i);
                        }

                        //todo: check if there exists an airport with the same id already. use contains and implement  new IEqualityComparer for Airport object
                        ap = new Airport(cols[1], cols[2], cols[3], cols[4], Double.Parse(cols[5]), Double.Parse(cols[6]));
                        airports.Add(ap);
                    }
                    
                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                    Console.WriteLine(MessageString);

                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                Console.WriteLine(MessageString);
            }

            return airports;
        }

        public String[] getAircraft(int aircraftid) {

            String []aircraftInfo = new String[4];

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("select idaircraft, name, type, code, imagename from aircraft where idaircraft = " + aircraftid);

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    aircraftInfo[0] = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    aircraftInfo[1] = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    aircraftInfo[2] = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    aircraftInfo[3] = reader.IsDBNull(3) ? "" : reader.GetString(3);


                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                    aircraftInfo[0] = MessageString;

                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                aircraftInfo[0] = MessageString;
            }

            return aircraftInfo;
            
        }

        
            

    }

    
}