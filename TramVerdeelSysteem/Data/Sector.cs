using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Data.Interfaces;
using Logic.Interfaces;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Sector:IDatabaseSector
    {
        private readonly ConnectionClass _connect;
        public Sector()
        {
            _connect = new ConnectionClass(); 
        }
        
        public bool GetSector(SectorDTO sector)
        {
            bool hasSector = false;
            try
            {
                _connect.Con.Open();
                string query = "SELECT track.TrackNumber, sector.idSectorStatus, sector.Position FROM sector"
                    + " INNER JOIN Tram ON Tram.idTram = sector.idTram"
                    + " INNER JOIN track ON track.idTrack = sector.idTrack"
                    + " WHERE tram.Number = @idTram";

                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@idTram", sector.TramId);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        hasSector = true;
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
            return hasSector;
        }

        public bool IsSectorFree(int trackNumber)
        {
            //SELECT MAX(Position), idTram FROM `sector`
            //INNER JOIN track ON track.idTrack = sector.idTrack
            //WHERE track.TrackNumber = 40
            bool hasSector = false;
            try
            {
                _connect.Con.Open();
                string query = "SELECT Position, idTram FROM `sector`"
                    + " INNER JOIN track ON track.idTrack = sector.idTrack"
                    + " WHERE track.TrackNumber = @trackNumber ORDER BY sector.Position DESC LIMIT 0,1";

                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@trackNumber", trackNumber);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while(dataReader.Read())
                    {
                        hasSector = dataReader.IsDBNull(dataReader.GetOrdinal("idTram")) ? true : false;
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
            return hasSector;
        }

        public bool SectorStatusChange(SectorStatusChangeDTO sectorStatusChange)
        {
            try
            {
                _connect.Con.Open();

                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "UPDATE sector SET idSectorStatus = '@StatusNumber' WHERE Position = '@Position' AND idTrack = (SELECT idTrack FROM track WHERE TrackNumber = '@TrackNumber' AND idRemise = (SELECT idRemise FROM remise WHERE Name = '@DepotName'))";
                cmd.Parameters.AddWithValue("@StatusNumber", sectorStatusChange.SectorStatus);
                cmd.Parameters.AddWithValue("@Position", sectorStatusChange.SectorPosition);
                cmd.Parameters.AddWithValue("@TrackNumber", sectorStatusChange.TrackNumber);
                cmd.Parameters.AddWithValue("@DepotName", sectorStatusChange.DepotName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connect.Con.Close();
            }
            return true;
        }

        public bool ClearSector(SectorDTO sector)
        {
            try
            {
                _connect.Con.Open();

                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "UPDATE sector SET idTram = @idTram WHERE Position = @Position AND idTrack = (SELECT idTrack FROM track WHERE TrackNumber = @TrackNumber AND idRemise = (SELECT idRemise FROM remise WHERE Name = @DepotName))";
                cmd.Parameters.AddWithValue("@idTram", null);
                cmd.Parameters.AddWithValue("@Position", sector.SectorPosition);
                cmd.Parameters.AddWithValue("@TrackNumber", sector.TrackNumber);
                cmd.Parameters.AddWithValue("@DepotName", sector.DepotName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _connect.Con.Close();
            }
            return true;
        }

        public bool ClearSectorWithTramNumber(int tramNumber)
        {
            try
            {
                _connect.Con.Open();

                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "UPDATE sector INNER JOIN Tram ON sector.idTram = Tram.idTram"
                    + " SET sector.idTram = @idTram"
                    + " WHERE Tram.Number = @tramNumber";
                cmd.Parameters.AddWithValue("@idTram", null);
                cmd.Parameters.AddWithValue("@tramNumber", tramNumber);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.Write(e);
                return false;
            }
            finally
            {
                _connect.Con.Close();
            }
            return true;
        }

        public bool AddTrain(SectorDTO sector)
        {
            try
            {
                _connect.Con.Open();

                string query = "UPDATE sector SET idTram = (SELECT idTram FROM tram WHERE tram.Number = @idTram) WHERE Position = @Position AND idTrack = (SELECT idTrack FROM track WHERE TrackNumber = @TrackNumber AND idRemise = (SELECT idRemise FROM remise WHERE Name = @DepotName))";

                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@idTram", sector.TramId);
                cmd.Parameters.AddWithValue("@Position", sector.SectorPosition);
                cmd.Parameters.AddWithValue("@TrackNumber", sector.TrackNumber);
                cmd.Parameters.AddWithValue("@DepotName", sector.DepotName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
            finally
            {
                _connect.Con.Close();
            }
            return true;
        }


    }
}
