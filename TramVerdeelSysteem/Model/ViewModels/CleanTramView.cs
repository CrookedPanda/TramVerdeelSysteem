using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    class CleanTramView
    {
        public int TrainNumber { get; set; }
        public int Rail { get; set; }
        public int Sector { get; set; }
        public bool IsLarge { get; set; }
        public string Annotation { get; set; }

        public CleanTramView()
        {

        }
        public CleanTramView(CleaningView Model)
        {
            TrainNumber = Model.TargetNumber;
            Rail = Model.TargetRail;
            Sector = Model.TargetSector;
            IsLarge = Model.TargetIsLarge;
            Annotation = Model.TargetAnnotation;
        }
    }
}
