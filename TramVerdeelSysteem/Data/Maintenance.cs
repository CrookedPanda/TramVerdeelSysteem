using System;
using System.Collections.Generic;
using System.Text;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Maintenance
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

        public bool AddMaintenance(MaintenanceDTO maintenance)
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
            return false;
        }

        private void AddMaintenanceHistory(MaintenanceDTO maintenance)
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
        }

        public bool RemoveMaintenance(int maintenanceId)
        {
            try
            {
                _connect.Con.Open();
                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "DELETE FROM service WHERE idService = @MaintId";
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
            return false;
        }

        public void RemoveMaintenanceHistory(int maintenanceId)
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

        public List<MaintenanceDTO> GetMaintenanceList()
        {
            List<MaintenanceDTO> maintenanceList = new List<MaintenanceDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT service.idTram, service.Size, service.Priority, service.Description FROM service";
                    
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

        public List<MaintenanceDTO> GetMaintenanceHistory()
        {
            List<MaintenanceDTO> maintenanceList = new List<MaintenanceDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT user.Name, sh.idTram, sh.ServiceDate, sh.Description FROM servicehistory AS sh"
                    + " INNER JOIN user ON user.idUser = sh.idUser";
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
    }
}
