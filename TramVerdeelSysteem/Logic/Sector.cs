using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Sector
    {
        public int position { get; set; }
        public Status status { get; set; } = Status.Open;
        public Train train { get; set; }

        public void ChangeSectorStatus(Status pStatus)
        {
            status = pStatus;
            // roep de database aan voor de aanpassingen
        }

        public void ClearSector()
        {
            status = Status.Open;
            train = null;
            // roep de database aan voor de aanpassingen
        }

        public bool ReserveForTrain(Train pTrain)
        {
            if(status == Status.Blocked)
            {
                return false;
            }
            else
            {
                train = pTrain;
                status = Status.Reserved;

                // roep de database aan voor de aanpassingen
                return true;
            }
        }

        public bool AddTrain(Train pTrain)
        {
            switch(status)
            {
                case Status.Open:
                    train = pTrain;
                    // pas de verandering aan in de database
                    return true;
                case Status.Reserved:
                    if (pTrain == train)
                    {
                        status = Status.occupied;
                        // pas de verandering aan in de database
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
