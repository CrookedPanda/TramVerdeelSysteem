using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModels
{
    public class ReparatieDienstViewModel
    {
        public List<TeReparairenTram> teReparairenTrams { get; set; }
        public int TargetTramIndex { get; set; }

        public ReparatieDienstViewModel()
        {
            // tijdelijke test data
            teReparairenTrams = new List<TeReparairenTram>() {
            new TeReparairenTram(2002, 20, 2),
            new TeReparairenTram(220, 14, 1),
            new TeReparairenTram(302, 16, 1),
            new TeReparairenTram(503, 20, 1),
            };

            TargetTramIndex = 0;
        }
    }
}
