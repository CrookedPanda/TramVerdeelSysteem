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
                cmd.CommandText = "INSERT INTO 'cleaning' ('idTram', 'Size', 'Priority', 'Description') VALUES ((SELECT idTram FROM Tram WHERE Number = @TramNumber), @Size, @Priority, @Desc)";
                cmd.Parameters.AddWithValue("@TramNumber", cleaning.TramNumber);
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

        private void AddCleaningHistory(CleaningDTO cleaning)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `cleaninghistory` (`idTram`, `idUser`, `ServiceDate`, `Description`) VALUES ((SELECT idTram FROM Tram WHERE Number = @TramNumber), (SELECT idUser FROM authorisationlist WHERE Name = @AuthKey), @Date, @Annotation)";
                cmd.Parameters.AddWithValue("@TramNumber", cleaning.TramNumber);
                cmd.Parameters.AddWithValue("@AuthKey", cleaning.AuthKey);
                cmd.Parameters.AddWithValue("@Description", cleaning.Annotation);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
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

        public bool RemoveCleaning(int cleaningId)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM cleaning WHERE idService = @CleanId";
                cmd.Parameters.AddWithValue("@CleanId", cleaningId);
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
            return false;
        }

        public void RemoveCleaningHistory(int cleaningId)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM cleaninghistory WHERE idServiceHistory = @CleanId";
                cmd.Parameters.AddWithValue("@CleanId", cleaningId);
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

        public List<CleaningDTO> GetCleaningList()
        {
            List<CleaningDTO> cleaningList = new List<CleaningDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT cleaning.idTram, cleaning.Size, cleaning.Priority, cleaning.Description FROM cleaning";

                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CleaningDTO cleaning = new CleaningDTO
                        {
                            TramNumber = dataReader.GetInt32("idTram"),
                            Annotation = dataReader.GetString("Description")
                        };
                        cleaningList.Add(cleaning);
                    }
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
            return cleaningList;
        }

        public List<CleaningDTO> GetCleaningHistory()
        {
            List<CleaningDTO> cleaningList = new List<CleaningDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT user.Name, ch.idTram, ch.ServiceDate, ch.Description FROM cleaninghistory AS ch"
                    + " INNER JOIN user ON user.idUser = ch.idUser";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CleaningDTO cleaning = new CleaningDTO
                        {
                            TramNumber = dataReader.GetInt32("idTram"),
                            Annotation = dataReader.GetString("Description")
                        };
                    }
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
            return cleaningList;
        }
    }
}
