using Model.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public int GetTramWithNumber(int tramNumber)
        {
            int line = 0;
            try
            {
                _connect.Con.Open();
                string query = "SELECT tram.Line FROM tram"
                    + " WHERE tram.Number = @idTram";

                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@idTram", tramNumber);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        line = dataReader.GetInt32("Line");
                    }
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                _connect.Con.Close();
            }
            return line;
        }

        public List<int> GetTramList()
        {
            List<int> iList = new List<int>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT DISTINCT Number FROM `tram`";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        iList.Add(dataReader.GetInt32("Number"));
                    }
                }
                dataReader.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                _connect.Con.Close();
            }
            return iList;
        }
    }
}
