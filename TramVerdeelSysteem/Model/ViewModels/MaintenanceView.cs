using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class MaintenanceView
    {
        public int Target { get; set; }
        public string Annotation { get; set; }
        public List<Logic.MaintenanceTramModel> MaintenanceList { get; set; }

        
    }
}
