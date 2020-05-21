using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces.Database
{
    public interface IDatabaseTrain
    {
        public bool ChangeTrainStatus(ChangeTrainStatusDTO pModel);
        
        //AddTrain? hoe kan een train zichzelf toevoegen?


    }
}
