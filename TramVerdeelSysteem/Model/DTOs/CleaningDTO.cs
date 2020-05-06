using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class CleaningDTO
    {
        public int TramNumber { get; set; }
        public string Annotation { get; set; }
        public string AuthKey { get; set; }
        public bool Urgent { get; set; }
        public List<Logic.CleaningTramModel> CleaningList { get; set; }
    }
}
