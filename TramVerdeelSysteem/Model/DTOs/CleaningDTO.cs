using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class CleaningDTO
    {
        public int Target { get; set; }
        public string Annotation { get; set; }
        public List<Logic.CleaningTramModel> CleaningList { get; set; }
    }
}
