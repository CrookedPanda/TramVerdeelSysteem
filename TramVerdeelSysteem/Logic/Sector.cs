using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Model.DTOs;

namespace Logic
{
    using Model.ViewModels;

    public class Sector
    {
        public int position { get; set; }
        public Status status { get; set; } = Status.Open;
        public Tram train { get; set; }
        private IDatabaseSector databaseSector;

        public Sector()
        {
            this.databaseSector = new Data.Sector();
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
                    SectorPosition = position,
                    TrainNumber = pTrain.Number
                });
                return true;
            }
            return false;
        }*/

        public bool AddTrain(AddTrainView addTrainView)
        {

            SectorDTO sectorDto = new SectorDTO
            {
                DepotName = "Remise Havenstraat",
                SectorPosition = addTrainView.SectorPosition,
                SectorStatus = addTrainView.SectorStatus,
                TrackNumber = addTrainView.TrackNumber,
                TramId = addTrainView.TramId
            };

            this.databaseSector.ClearSectorWithTramNumber(sectorDto.TramId);
            
            return this.databaseSector.AddTrain(sectorDto);
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
