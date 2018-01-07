using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace FlightRadarSystem.Models
{
    public class Aircraft
    {
        private string name;
        private string type;
        private string code;
        private string imageName;

        private bool connection_open;
        private MySqlConnection connection;

        public static String defaultImageName = "turkishairlines.jpg";

        public Aircraft()
            : this("", "", "", defaultImageName)
        {
           
        }

        public Aircraft(string name, string type, string code, string imageName)
        {
            

            try
            {
                Get_Connection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = string.Format("select idaircraft, name, type, code, imagename from aircraft where idaircraft = 1");

                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    reader.Read();

                    this.name = reader.IsDBNull(1) ? name : reader.GetString(1);
                    this.type = reader.IsDBNull(2) ? type : reader.GetString(2);
                    this.code = reader.IsDBNull(3) ? code : reader.GetString(3);
                    this.imageName = reader.IsDBNull(3) ? imageName : reader.GetString(3);
                    

                    reader.Close();

                }
                catch (MySqlException e)
                {
                    string MessageString = "Read error occurred  / entry not found loading the Column details: "
                        + e.ErrorCode + " - " + e.Message + "; \n\nPlease Continue";
                    //MessageBox.Show(MessageString, "SQL Read Error");
                    reader.Close();
                    Name = MessageString;
               
                }
            }
            catch (MySqlException e)
            {
                string MessageString = "The following error occurred loading the Column details: "
                    + e.ErrorCode + " - " + e.Message;
                Name = MessageString;
            }


            connection.Close();

            //this.name = name;
            //this.type = type;
            //this.code = code;
            //this.imageName = imageName;
        }
        private void Get_Connection() 
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
            catch (System.ArgumentException se) {
                string MessageString = "The following error occurred loading the Column details: " + se.Message;
                
            }

        }

        private bool Open_Local_Connection()
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