using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DiningTracker.Models
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private int _cusineId;


        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }


        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurants;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

   }
}