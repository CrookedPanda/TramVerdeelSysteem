using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class CleaningMasterView
    {
        public List<CleaningView> cleanings { get; set; }
        public CleaningView cleaning { get; set; }
    }
}
