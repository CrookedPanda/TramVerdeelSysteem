using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class MaintenanceHistoryMasterView
    {
        public List<MaintenanceHistoryView> maintenances { get; set; }
        public MaintenanceHistoryView maintenance { get; set; }
    }
}
