

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

        private List<Service> Services;

        private List<Cleaning> Cleanings;

        public Maintenance(IDatabaseMaintenance iDatabaseMaintenance)
        {
            this.DatabaseMaintenance = iDatabaseMaintenance;
        }

        private bool AddCleaning(CleaningView cleaningView)
        {
            try
            {
                var cleaning = new CleaningDTO();

                if (this.DatabaseMaintenance.AddCleaning(cleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool AddService()
        {
            try
            {
                var service = new MaintenanceDTO();

                if (this.DatabaseMaintenance.AddService(service)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool RemoveCleaning()
        {
            try
            {
                var cleaning = new CleaningDTO();

                if (this.DatabaseMaintenance.RemoveCleaning(cleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool RemoveService()
        {
            try
            {
                var service = new MaintenanceDTO();

                if (this.DatabaseMaintenance.RemoveService(service)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool IndicateCompleteCleaning(CleaningDTO cleaning)
        {
            try
            {
                if (this.DatabaseMaintenance.IndicateCompleteCleaning(cleaning)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private bool IndicateCompleteService(MaintenanceDTO service)
        {
            try
            {
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

        private List<CleaningDTO> GetCleaningList()
        {
            try
            {
                var cleanings = new List<CleaningDTO>();
                cleanings = this.DatabaseMaintenance.GetCleaningList();
                if (cleanings.Any()) return cleanings;
                else throw new Exception("No cleanings");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<CleaningDTO> GetCleaningHistory()
        {
            try
            {
                var cleanings = new List<CleaningDTO>();
                cleanings = this.DatabaseMaintenance.GetCleaningHistory();
                if (cleanings.Any()) return cleanings;
                else throw new Exception("No cleanings");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<MaintenanceDTO> GetServiceHistory()
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
    }
}