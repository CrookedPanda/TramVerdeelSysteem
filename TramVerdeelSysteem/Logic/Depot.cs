using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Logic
{
    class Depot
    {
        public Depot()
        {

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
