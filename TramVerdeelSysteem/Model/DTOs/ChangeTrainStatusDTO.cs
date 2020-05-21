using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class ChangeTrainStatusDTO
    {
        public int TrainNumber { get; set; }
        public int TargetStatus { get; set; }
    }
}
