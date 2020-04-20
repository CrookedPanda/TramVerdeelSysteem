using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Maintenance : IDatabaseMaintenance
    {
        private readonly ConnectionClass _connect;
        public Maintenance(ConnectionClass connect)
        {
            _connect = connect;
        }

        public Maintenance()
        {
            _connect = new ConnectionClass();
        }

        public bool AddService(MaintenanceDTO maintenance)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `service` (`idTram`, `Size`, `Priority`, `Description`) VALUES ((SELECT idTram FROM Tram WHERE Number = @TramNumber), @Size, @Priority, @Description)";
                cmd.Parameters.AddWithValue("@TramNumber", maintenance.TramNumber);
                cmd.Parameters.AddWithValue("@Size", "1");
                cmd.Parameters.AddWithValue("@Priority", "1");
                cmd.Parameters.AddWithValue("@Description", maintenance.Annotation);
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
            return true;
        }

        public bool IndicateCompleteService(MaintenanceDTO maintenance)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `servicehistory` (`idTram`, `idUser`, `ServiceDate`, `Description`) VALUES ((SELECT idTram FROM Tram WHERE Number = @TramNumber), (SELECT idUser FROM authorisationlist WHERE Name = @AuthKey), @Date, @Annotation)";
                cmd.Parameters.AddWithValue("@TramNumber", maintenance.TramNumber);
                cmd.Parameters.AddWithValue("@AuthKey", maintenance.AuthKey);
                cmd.Parameters.AddWithValue("@Description", maintenance.Annotation);
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

            return true;
        }

        public bool RemoveService(MaintenanceDTO maintenance)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM service WHERE idService = @MaintId";
                cmd.Parameters.AddWithValue("@MaintId", maintenance.TramNumber);
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
            return true;
        }

        public void RemoveServiceHistory(int maintenanceId)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM servicehistory WHERE idServiceHistory = @MaintId";
                cmd.Parameters.AddWithValue("@MaintId", maintenanceId);
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

        public List<MaintenanceDTO> GetServiceList()
        {
            List<MaintenanceDTO> maintenanceList = new List<MaintenanceDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT Tram.Number, service.Size, service.Priority, service.Description FROM service"
                    + " INNER JOIN Tram ON Tram.idTram = service.idTram";
                    
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MaintenanceDTO maintenance = new MaintenanceDTO
                        {
                            TramNumber = dataReader.GetInt32("idTram"),
                            Annotation = dataReader.GetString("Description")
                        };
                        maintenanceList.Add(maintenance);
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
            return maintenanceList;
        }

        public List<MaintenanceDTO> GetServiceHistory()
        {
            List<MaintenanceDTO> maintenanceList = new List<MaintenanceDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT user.Name, tram.Number, sh.ServiceDate, sh.Description FROM servicehistory AS sh"
                    + " INNER JOIN user ON user.idUser = sh.idUser"
                    + " INNER JOIN tram ON tram.idTram = sh.idTram";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        MaintenanceDTO maintenance = new MaintenanceDTO
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
            return maintenanceList;
        }

        public bool AddCleaning(CleaningDTO cleaning)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "INSERT INTO `cleaning` (`idTram`, `Size`, `Priority`, `Description`) VALUES ((SELECT idTram FROM Tram WHERE Number = @TramNumber), @Size, @Priority, @Desc)";
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
            return true;
        }

        public bool IndicateCompleteCleaning(CleaningDTO cleaning)
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
            return true;
        }

        public bool RemoveCleaning(CleaningDTO cleaning)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM cleaning WHERE idService = @CleanId";
                cmd.Parameters.AddWithValue("@CleanId", cleaning.TramNumber);
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
            return true;
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
                string query = "SELECT Tram.Number, cleaning.Size, cleaning.Priority, cleaning.Description FROM cleaning"
                    + " INNER JOIN Tram ON Tram.idTram = cleaning.idTram";
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
                string query = "SELECT user.Name, tram.Number, ch.CleaningDate, ch.Description FROM cleaninghistory AS ch"
                    + " INNER JOIN user ON user.idUser = ch.idUser"
                    + " INNER JOIN tram ON tram.idTram = ch.idTram";
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
