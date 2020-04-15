using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Tram
    {
        private readonly ConnectionClass _connect;
        public Tram(ConnectionClass connect)
        {
            _connect = connect;
        }

        public Tram()
        {
            _connect = new ConnectionClass();
        }

        public void AddTram(int idTramStatus, int idTramType, int Line, int Number)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `service` (`idTramStatus`, `idTramType`, `Line`, `Number`) VALUES (@idTram, @Size, @Priority, @Description)";
                cmd.Parameters.AddWithValue("@Status", idTramStatus);
                cmd.Parameters.AddWithValue("@Type", idTramType);
                cmd.Parameters.AddWithValue("@Line", Line);
                cmd.Parameters.AddWithValue("@Number", Number);
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
    }
}
