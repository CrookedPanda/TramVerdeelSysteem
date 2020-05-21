using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class MaintenanceView
    {
        //public int Target { get; set; }
        //public string Annotation { get; set; }
        //public List<Logic.MaintenanceTramModel> MaintenanceList { get; set; }
        //public string Key { get; set; }

        public int TargetNumber { get; set; }
        public int TargetRail { get; set; }
        public int TargetSector { get; set; }
        public bool TargetIsLarge { get; set; }
        public string TargetAnnotation { get; set; }
        public string Key { get; set; }
    }
}
