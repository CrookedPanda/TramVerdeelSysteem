using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class CleaningHistoryMasterView
    {
        public List<CleaningHistoryView> cleanings { get; set; }
        public CleaningHistoryView cleaning { get; set; }
    }
}
