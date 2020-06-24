using Model.DTOs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Data
{
    public class Track
    {
        private readonly ConnectionClass _connect;
        public Track(ConnectionClass connect)
        {
            _connect = connect;
        }

        public Track()
        {
            _connect = new ConnectionClass();
        }


        //SELECT * FROM `sector` INNER JOIN track ON sector.idTrack = track.idTrack WHERE track.TrackNumber = "40"

        public List<SectorDTO> GetTrack(int trackNumber)
        {
            List<SectorDTO> sectorList = new List<SectorDTO>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT track.TrackNumber, sector.idTram, sector.idSectorStatus, sector.Position, track.Line FROM `sector`"
                    + " INNER JOIN track ON sector.idTrack = track.idTrack WHERE track.TrackNumber = @trackNumber";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@trackNumber", trackNumber);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        SectorDTO sector = new SectorDTO
                        {
                            TrackNumber = dataReader.GetInt32("TrackNumber"),
                            TramId = dataReader.IsDBNull(dataReader.GetOrdinal("idTram")) ? 0 : dataReader.GetInt32("idTram"),
                            SectorStatus = dataReader.GetInt32("idSectorStatus"),
                            SectorPosition = dataReader.GetInt32("Position"),
                            Line = dataReader.GetInt32("Line"),
                        };
                        sectorList.Add(sector);
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
            return sectorList;
        }

        public List<int> GetTrackWithLine(int lineNumber)
        {
            List<int> trackList = new List<int>();
            try
            {
                _connect.Con.Open();
                string query = "SELECT DISTINCT track.TrackNumber FROM `sector`"
                    + " INNER JOIN track ON sector.idTrack = track.idTrack WHERE track.Line = @lineNumber";
                MySqlCommand cmd = new MySqlCommand(query, _connect.Con);
                cmd.Parameters.AddWithValue("@lineNumber", lineNumber);
                var dataReader = cmd.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        trackList.Add(dataReader.GetInt32("TrackNumber"));
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
            return trackList;
        }
    }
}
