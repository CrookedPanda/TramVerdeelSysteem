using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class CleaningHistoryDTO
    {
        public int TramNumber { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public DateTime Datetime { get; set; }
    }
}
