using System;
using System.Collections.Generic;
using System.Text;
using Model.DTOs;

namespace Data.Interfaces
{
    public interface IDatabaseMaintenance
    {
        bool AddCleaning(CleaningDTO cleaning);
        bool AddService(MaintenanceDTO service);
        bool RemoveCleaning(CleaningDTO cleaning);
        bool RemoveService(MaintenanceDTO service);
        bool IndicateCompleteCleaning(CleaningDTO cleaning);
        bool IndicateCompleteService(MaintenanceDTO service);
        MaintenanceDTO GetServiceList();
        CleaningDTO GetCleaningList();
        CleaningDTO GetCleaningHistory();
        MaintenanceDTO GetServiceHistory();



    }
}
