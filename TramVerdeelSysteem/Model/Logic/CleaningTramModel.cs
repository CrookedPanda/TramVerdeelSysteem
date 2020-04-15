using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Logic
{
    public class CleaningTramModel : TramModel
    {
        public bool IsLarge { get; set; }


        public CleaningTramModel()
        {

        }
        //constructor voor test data
        public CleaningTramModel(bool cIsLarge, int cNumber, int cRails, int cSector)
        {
            IsLarge = cIsLarge;
            Number = cNumber;
            Rails = cRails;
            Sector = cSector;

            Status = new StatusModel("Vies", "heeft een kleine schoonmaak nodig");
        }
    }
}
