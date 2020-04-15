using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class Train
    {
        public int Number { get; set; }
        public int Line { get; set; }
        public Status TrainStatus { get; set; }

        public enum Status
        {
            Defect,
            Cleaning,
            InService,
            InDepot
        }
    }
}
