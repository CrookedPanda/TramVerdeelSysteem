using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;
using Data.Interfaces;
using Model.DTOs;

namespace Logic
{
    public class Track
    {
        public int Line { get; set; }
        public int TrackNumber { get; set; }
        private List<Sector> sectors;
        private IDatabaseTrack databaseTrack;

        public Track()
        {
            // database track = default database class
        }
        public Track(IDatabaseTrack cDatabase)
        {
            databaseTrack = cDatabase;
        }


        public void ChangeLine(int pLine, string pRemeseName)
        {
            Line = pLine;
            TrackLineDTO trackLineDTO = new TrackLineDTO() { RemeseName = pRemeseName, TargetLine = pLine, TrackNummer = TrackNumber };
            databaseTrack.changeTrackLine(trackLineDTO);
        }

        public void AddSector(Sector pSector)
        {
            sectors.Add(pSector);
        }

        public void ChangeSectorStatus(Sector.Status pStatus, string pRemeseName, int pPosition)
        {
            try
            {
                sectors.Where(i => i.position == pPosition).FirstOrDefault().ChangeSectorStatus(pStatus, TrackNumber, pRemeseName);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool ReserveSector(Train pTrain, string pRemeseName, int pPosition)
        {
           return sectors.Where(i => i.position == pPosition).FirstOrDefault().ReserveForTrain(pTrain, pRemeseName, TrackNumber);
        }
    }
}
