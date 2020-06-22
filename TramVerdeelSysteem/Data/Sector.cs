using System;
using System.Collections.Generic;
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
                cmd.CommandText = "UPDATE sector SET idTram = @idTram WHERE Position = '@Position' AND idTrack = (SELECT idTrack FROM track WHERE TrackNumber = '@TrackNumber' AND idRemise = (SELECT idRemise FROM remise WHERE Name = '@DepotName'))";
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

        public bool AddTrain(SectorDTO sector)
        {
            try
            {
                _connect.Con.Open();

                MySqlCommand cmd = _connect.Con.CreateCommand();
                cmd.CommandText = "UPDATE sector SET idTram = '@idTram' WHERE Position = '@Position' AND idTrack = (SELECT idTrack FROM track WHERE TrackNumber = '@TrackNumber' AND idRemise = (SELECT idRemise FROM remise WHERE Name = '@DepotName'))";
                cmd.Parameters.AddWithValue("@idTram", sector.TramId);
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
    }
}
