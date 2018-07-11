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

        public Restaurant(string name, int cuisineId, int id = 0)
        {
            _id = id;
            _name = name;
            _cuisineId = cuisineId;
            
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

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restuarants (name, cuisine_id) VALUES (@RestuarantName, @cuisineId);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@RestuarantName";
            name.Value = _name;
            cmd.Parameters.Add(name);

            MySqlParameter cuisineId = new MySqlParameter();
            cuisineId.ParameterName = "@cuisineId";
            cuisineId.Value = _cuisineId;
            cmd.Parameters.Add(cuisineId);

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
                Restaurant newRestaurant = new Restaurant(name, cuisineId, id);
                allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allRestaurants;
            
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
                bool cuisineIdEquility = this.GetCuisineId().Equals(newRestuarant.GetCuisineId());
                return (nameEquality && cuisineIdEquility);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

   }
}