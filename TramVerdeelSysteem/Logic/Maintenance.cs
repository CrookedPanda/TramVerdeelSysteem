using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces;
using Model.ViewModels;

namespace Logic
{
    class Maintenance
    {
        IDatabaseMaintenance DatabaseMaintenance;

        List<Service> Services;
        List<Cleaning> Cleanings;

        public Maintenance(IDatabaseMaintenance iDatabaseMaintenance)
        {
            DatabaseMaintenance = iDatabaseMaintenance;
        }


        void AddCleaning(CleaningView cleaningView)
        {

        }

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
