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
        public string Key { get; set; }

        public CleaningView()
        {

        }
        public CleaningView(string test)
        {
            Target = 0;
            Annotation = "annotation";
            CleaningList = new List<Logic.CleaningTramModel>() { 
                new Logic.CleaningTramModel(false, 202, 64, 1), 
                new Logic.CleaningTramModel(false, 302, 64, 2), 
                new Logic.CleaningTramModel(false, 2020, 65, 1), 
                new Logic.CleaningTramModel(false, 410, 66, 1), 
                new Logic.CleaningTramModel(false, 2001, 65, 2) 
            };
        }
    }
}
