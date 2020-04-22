using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Logic
{
    public class StatusModel
    {
        public string Status { get; set; }
        public string Description { get; set; }

        public StatusModel()
        {

        }
        public StatusModel(string cStatus, string cDescription)
        {
            Status = cStatus;
            Description = cDescription;
        }
    }
}
