using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class CleaningView
    {
        public int Target { get; set; }
        public string Annotation { get; set; }
        public List<Logic.CleaningTramModel> CleaningList { get; set; }
    }
}
