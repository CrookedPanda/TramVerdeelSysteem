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
        public Sector(ConnectionClass connect)
        {
            _connect = connect;
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
                throw;
            }
            finally
            {
                _connect.Con.Close();
            }
            return true;
        }
    }
}
