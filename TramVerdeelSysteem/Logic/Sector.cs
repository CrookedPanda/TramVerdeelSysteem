using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Model.DTOs;

namespace Logic
{
    public class Sector
    {
        public int position { get; set; }
        public Status status { get; set; } = Status.Open;
        public Train train { get; set; }
        private IDatabaseSector databaseSector;

        public Sector()
        {
            //implemetn standard datasorce
        }
        public Sector(IDatabaseSector cDatabase)
        {
            databaseSector = cDatabase;
        }


        public void ChangeSectorStatus(Status pStatus, int pTracknumber, string pRemeseName)
        {
            status = pStatus;
            SectorStatusChangeDTO sectorStatusDTO = new SectorStatusChangeDTO()
            {
                DepotName = pRemeseName,
                TrackNumber = pTracknumber,
                SectorPosition = position,
                SectorStatus = (int)status
            };

            databaseSector.SectorStatusChange(sectorStatusDTO);
        }
        public void ClearSector(string pRemese, int pTrackNumber)
        {
            status = Status.Open;
            train = null;
            databaseSector.ClearSector(new SectorDTO() {DepotName = pRemese, TrackNumber = pTrackNumber, SectorPosition = position });
        }

        /*public bool ReserveForTrain(Train pTrain, string pRemese, int pTrackNumber)
        {
            if(status == Status.Open)
            {
                // database
                databaseSector.ReserveSector(new ReserveSectorDTO
                {
                    RemeseName = pRemese,
                    Tracknumber = pTrackNumber,
                    SectorPosiotion = position,
                    TrainNumber = pTrain.Number
                });
                return true;
            }
            return false;
        }*/

        public bool AddTrain(Train pTrain, string pRemese, int pTrackNumber)
        {
            switch(status)
            {
                case Status.Open:
                    train = pTrain;
                    status = Status.occupied;
                    return true;
                case Status.Reserved:
                    if (pTrain == train)
                    {
                        ChangeSectorStatus(Status.occupied, pTrackNumber, pRemese);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return false;             
            }                
        }

        public enum Status
        {
            Open,
            Blocked,
            Reserved,
            occupied
        }
    }
}
