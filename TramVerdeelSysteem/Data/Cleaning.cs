using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Cleaning
    {
        private readonly ConnectionClass _connect;
        public Cleaning(ConnectionClass connect)
        {
            _connect = connect;
        }
        public Cleaning()
        {
            _connect = new ConnectionClass();
        }

        public void AddCleaning(CleaningDTO cleaning)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO 'cleaning' ('idTram', 'Size', 'Priority', 'Description') VALUES (@tramID, @Size, @Priority, @Desc)";
                cmd.Parameters.AddWithValue("@tramID", cleaning.Target);
                cmd.Parameters.AddWithValue("@Size", 1);
                cmd.Parameters.AddWithValue("@Priority", 1);
                cmd.Parameters.AddWithValue("@Desc", cleaning.Annotation);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
        }

        public void RemoveCleaning()
        {

        }
    }
}
