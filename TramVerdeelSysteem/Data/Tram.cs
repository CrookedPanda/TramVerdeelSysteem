using Model.DTOs;
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
                cmd.CommandText = "INSERT INTO `tram` (`idTramStatus`, `idTramType`, `Line`, `Number`) VALUES (@Status, @Type, @Line, @Number)";
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

        public void AddSector(int idTrack, int Position)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `sector`(`idTrack`, `Position`) VALUES (@track,@pos)";
                cmd.Parameters.AddWithValue("@track", idTrack);
                cmd.Parameters.AddWithValue("@pos", Position);
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
