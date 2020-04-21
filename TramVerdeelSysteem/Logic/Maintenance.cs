

namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data.Interfaces;
    using Model.DTOs;
    using Model.ViewModels;

    /// <summary>
    /// The maintenance.
    /// </summary>
    internal class Maintenance
    {
        private IDatabaseMaintenance DatabaseMaintenance;

        private List<MaintenanceDTO> Services;

        private List<CleaningDTO> Cleanings;

        public Maintenance(IDatabaseMaintenance iDatabaseMaintenance)
        {
            this.DatabaseMaintenance = iDatabaseMaintenance;
        }

        private bool AddCleaning(CleaningView cleaningView)
        {
            try
            {
                var cleaning = new CleaningDTO();
                cleaning.TramNumber = cleaningView.TargetNumber;
                cleaning.Annotation = cleaningView.TargetAnnotation;
                cleaning.AuthKey = cleaningView.Key;
                //TODO: add IsLarge bool to DTO 
                if (this.DatabaseMaintenance.AddCleaning(cleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool AddService(MaintenanceView maintenanceView)
        {
            try
            {
                var service = new MaintenanceDTO();
                service.TramNumber = maintenanceView.Target;
                service.Annotation = maintenanceView.Annotation;
                service.AuthKey = maintenanceView.Key;
                if (this.DatabaseMaintenance.AddService(service)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool RemoveCleaning(CleaningView cleaningView)
        {
            try
            {
                var cleaning = new CleaningDTO();
                cleaning.TramNumber = cleaningView.TargetNumber;
                cleaning.AuthKey = cleaningView.Key;
                if (this.DatabaseMaintenance.RemoveCleaning(cleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool RemoveService(MaintenanceView maintenanceView)
        {
            try
            {
                var service = new MaintenanceDTO();
                service.TramNumber = maintenanceView.Target;
                service.AuthKey = maintenanceView.Key;
                if (this.DatabaseMaintenance.RemoveService(service)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool IndicateCompleteCleaning(CleaningView cleaning)
        {
            try
            {
                CleaningDTO completedCleaning = new CleaningDTO();
                completedCleaning.TramNumber = cleaning.TargetNumber;
                completedCleaning.AuthKey = cleaning.Key;
                completedCleaning.Annotation = cleaning.TargetAnnotation;
                if (this.DatabaseMaintenance.IndicateCompleteCleaning(completedCleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool IndicateCompleteService(MaintenanceView maintenanceView)
        {
            try
            {
                MaintenanceDTO service = new MaintenanceDTO();
                service.TramNumber = maintenanceView.Target;
                service.AuthKey = maintenanceView.Key;
                service.Annotation = maintenanceView.Annotation;
                if (this.DatabaseMaintenance.IndicateCompleteService(service)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<MaintenanceDTO> GetServiceList()
        {


            try
            {
                var services = new List<MaintenanceDTO>();
                services = this.DatabaseMaintenance.GetServiceList();
                if (services.Any()) return services;
                else throw new Exception("No services");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private CleaningView GetCleaningList()
        {

            try
            {
                // var cleanings = new List<CleaningDTO>();
                var cleanings = this.DatabaseMaintenance.GetCleaningList();
                var cleaningsView = new CleaningView();
                cleaningsView.CleaningList = cleanings.CleaningList;
                if (cleanings.CleaningList.Any()) return cleaningsView;
                else throw new Exception("No cleanings");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void GetCleaningHistory()
        {
            try
            {
                Cleanings = this.DatabaseMaintenance.GetCleaningHistory();
                if (Cleanings.Any()) OrganiseCleaningHistory();
                else throw new Exception("No cleanings");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void GetServiceHistory()
        {
            try
            {
                var services = new List<MaintenanceDTO>();
                services = this.DatabaseMaintenance.GetServiceHistory();
                if (services.Any()) return services;
                else throw new Exception("No services");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void OrganiseCleaningList()
        {

        }
    }
}