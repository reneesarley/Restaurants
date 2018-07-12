using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DiningTracker.Models
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private int _cuisineId;
        private bool _allowsDogs;
        private bool _servesAlcohol;
        private string _streetAddress;
        private string _city;
        private string _state;
        private int _zip;

        public Restaurant(string name, int cuisineId, bool allowsDogs, bool servesAlcohol, string streetAddres, string city, string state, int zip, int id = 0)
        {
            _id = id;
            _name = name;
            _cuisineId = cuisineId;
            _allowsDogs = allowsDogs;
            _servesAlcohol = servesAlcohol;
            _streetAddress = streetAddres;
            _city = city;
            _state = state;
            _zip = zip;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetCuisineId()
        {
            return _cuisineId;
        }

        public bool GetAllowsDogs()
        {
            return _allowsDogs;
        }

        public bool GetServesAlcohol()
        {
            return _servesAlcohol;
        }

        public string GetStreetAddress()
        {
            return _streetAddress;
        }

        public string GetCity()
        {
            return _city;
        }

        public string GetState()
        {
            return _state;
        }
        public int GetZip()
        {
            return _zip;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restuarants (name, cuisine_id, allows_dogs, serves_alcohol, streetAddress, city, state, zip) VALUES (@RestuarantName, @cuisineId, @AllowsDogs, @ServesAlcohol, @Street, @City, @State, @Zip);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@RestuarantName";
            name.Value = _name;
            cmd.Parameters.Add(name);

            MySqlParameter cuisineId = new MySqlParameter();
            cuisineId.ParameterName = "@cuisineId";
            cuisineId.Value = _cuisineId;
            cmd.Parameters.Add(cuisineId);

            MySqlParameter allowsDogs = new MySqlParameter();
            allowsDogs.ParameterName = "@AllowsDogs";
            allowsDogs.Value = _allowsDogs;
            cmd.Parameters.Add(allowsDogs);

            MySqlParameter servesAlcohol = new MySqlParameter();
            servesAlcohol.ParameterName = "@ServesAlcohol";
            servesAlcohol.Value = _servesAlcohol;
            cmd.Parameters.Add(servesAlcohol);

            MySqlParameter streetAddress = new MySqlParameter();
            streetAddress.ParameterName = "@Street";
            streetAddress.Value = _streetAddress;
            cmd.Parameters.Add(streetAddress);

            MySqlParameter city = new MySqlParameter();
            city.ParameterName = "@City";
            city.Value = _city;
            cmd.Parameters.Add(city);

            MySqlParameter state = new MySqlParameter();
            state.ParameterName = "@State";
            state.Value = _state;
            cmd.Parameters.Add(state);

            MySqlParameter zip = new MySqlParameter();
            zip.ParameterName = "@Zip";
            zip.Value = _zip;
            cmd.Parameters.Add(zip);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            
        }

        public static List<Restaurant> GetAll()
        {
            List<Restaurant> allRestaurants = new List<Restaurant> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restuarants;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int cuisineId = rdr.GetInt32(2);
                bool allowsDogs = rdr.GetBoolean(3);
                bool servesAlcohol = rdr.GetBoolean(4);
                string streetAddress = rdr.GetString(5);
                string city = rdr.GetString(6);
                string state = rdr.GetString(7);
                int zip = rdr.GetInt32(8);

                Restaurant newRestaurant = new Restaurant(name, cuisineId, allowsDogs, servesAlcohol, streetAddress, city, state, zip, id);
                allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allRestaurants;
            
        }


        public static List<Restaurant> GetOneCuisine(int selectedId)
        {
            List<Restaurant> allOfOneCuisine = new List<Restaurant> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restuarants WHERE cuisine_id = @SelectedID;";


            MySqlParameter id = new MySqlParameter();
            id.ParameterName = "@SelectedID";
            id.Value = selectedId;
            cmd.Parameters.Add(id);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            //MySqlParameter name = new MySqlParameter();
            //name.ParameterName = "@RestuarantName";
            //name.Value = _name;
            //cmd.Parameters.Add(name);

            while (rdr.Read())
            {
                int restId = rdr.GetInt32(0);
                string name = rdr.GetString(1);
                int cuisineId = rdr.GetInt32(2);
                bool allowsDogs = rdr.GetBoolean(3);
                bool servesAlcohol = rdr.GetBoolean(3);
                string streetAddress = rdr.GetString(4);
                string city = rdr.GetString(5);
                string state = rdr.GetString(6);
                int zip = rdr.GetInt32(7);


                Restaurant newRestaurant = new Restaurant(name, cuisineId, allowsDogs, servesAlcohol, streetAddress, city, state, zip,  restId);
                allOfOneCuisine.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allOfOneCuisine;

        }


        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restuarants;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public override bool Equals(System.Object otherRestuarant)
        {
            if (!(otherRestuarant is Restaurant))
            {
                return false;
            }
            else
            {
                Restaurant newRestuarant = (Restaurant)otherRestuarant;
                bool nameEquality = this.GetName().Equals(newRestuarant.GetName());
                //bool idEquality = this.GetId().Equals(newRestuarant.GetId());
                bool cuisineIdEquality = this.GetCuisineId().Equals(newRestuarant.GetCuisineId());
                bool dogEquality = this.GetAllowsDogs().Equals(newRestuarant.GetAllowsDogs());
                bool alcoholEquality = this.GetServesAlcohol().Equals(newRestuarant.GetServesAlcohol());
                return (nameEquality && cuisineIdEquality && dogEquality && alcoholEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

   }
}