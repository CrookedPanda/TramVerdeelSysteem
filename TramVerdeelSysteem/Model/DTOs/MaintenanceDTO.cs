using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class MaintenanceDTO
    {
        public int TramNumber { get; set; }
        public string Annotation { get; set; }
        public string AuthKey { get; set; }
        public bool Urgent { get; set; }
        public int TargetRail { get; set; }
        public int TargetSector { get; set; }
    }
}
