using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModels
{
    public class SchoonmaakDienstVieuwModel
    {
        public List<SchoonTeMakenTram> SchoonmaakList { get; set; }
        public int SchoonTeMakenTram { get; set; }

        public SchoonmaakDienstVieuwModel()
        {
            // tijdelijke test data
            SchoonmaakList = new List<SchoonTeMakenTram>() {
            new SchoonTeMakenTram(2002, 20, 2),
            new SchoonTeMakenTram(220, 14, 1),
            new SchoonTeMakenTram(302, 16, 1),
            new SchoonTeMakenTram(503, 20, 1),
            };
        }
    }
}
