using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Model;
using Data;

namespace Logic
{
    class Depot
    {
        public Depot()
        {

        }

        public Model.ViewModels.DepotView GetDepotView()
        {
            
            Model.ViewModels.DepotView depotView = new Model.ViewModels.DepotView();
        }

        public void AddTrain()
        {

        }

        public void ClearSector(/*Track*/ track, int position)
        {
            track.ClearSector(position);
        }

        public void ReserveSector(/*Track*/ track, int position, Train train)
        {
            track.ReserveSector(position, train);
        }

        public void ChangeSectorStatus(/*Track*/ track, int position, Enum status)
        {
            track.ChangeSectorStatus(position, status);
        }
    }
}
