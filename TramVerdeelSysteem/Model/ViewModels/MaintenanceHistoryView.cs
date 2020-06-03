using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class MaintenanceHistoryView
    {
        public int TramNumber { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public DateTime Datetime { get; set; }
    }
}
