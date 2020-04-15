using System;
using System.Collections.Generic;
using System.Text;
using Model.DTOs;

namespace Data.Interfaces
{
    public interface IDatabaseMaintenance
    {
        void AddCleaning();
        void AddService();
        void RemoveCleaning();
        void RemoveService();
        void IndicateCompleteCleaning(CleaningDTO cleaning);
        void IndicateCompleteService(MaintenanceDTO service);
        void GetServiceList();
        void GetCleaningList();
        void GetCleaningHistory();
        void GetServiceHistory();



    }
}
