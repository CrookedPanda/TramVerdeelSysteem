using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class MaintenanceMasterView
    {
        public List<MaintenanceView> maintenances { get; set; }
        public MaintenanceView maintenance { get; set; }
    }
}
