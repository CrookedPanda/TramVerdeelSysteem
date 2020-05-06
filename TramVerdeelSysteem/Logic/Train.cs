using Logic.Interfaces.Database;
using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    class Train
    {
        private IDatabaseTrain DatabaseTrain;

        public Train()
        {
            //implement default database class
        }
        public Train(IDatabaseTrain database)
        {
            DatabaseTrain = database;
        }

        public int Number { get; set; }
        public int Line { get; set; }
        public Status TrainStatus { get; set; }

        public void ChangeTrainStatus(Status pStatus)
        {
            TrainStatus = pStatus;
            ChangeTrainStatusDTO DTO = new ChangeTrainStatusDTO { TrainNumber = Number, TargetStatus = (int) pStatus};
            DatabaseTrain.ChangeTrainStatus(DTO);
        }

        //Clean? de clean functie in de train zelf van de classediagram staat raar. het is op het moment van chrijven niet duidelijk wat er precies in die functie moet gebeuren.
        // Servece? de serverce functie in de Classediaagram staat raaar.. op het moment van schrijven is het niet duidelijk wat deze functie presies moet doen.
        public enum Status
        {
            Defect,
            Cleaning,
            InService,
            InDepot
        }
    }
}
