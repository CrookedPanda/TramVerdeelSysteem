using System;
using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Logic.Interfaces.Database;
using Model.DTOs;
using Model.ViewModels;


namespace Logic
{
    public class conductor
    {
        public IDatabaseMaintenance DataBase { get; set; }

        public conductor(IDatabaseMaintenance cDataBase)
        {
            DataBase = cDataBase;
        }

        public conductor()
        {
            DataBase = new Data.Maintenance();

        }

        public void AddTramToCleaning(ConductorView Train)
        {
            if(Train.Cleaning == true)
            {
                CleaningDTO cleaning = new CleaningDTO() {TramNumber = Train.TramNumber,  Annotation = "de tram licht vol met bierblikjes van carnaval."};
                DataBase.AddCleaning(cleaning);
            }            
        }
    }
}
