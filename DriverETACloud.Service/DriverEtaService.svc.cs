using System;
using DriverETACloud.Entities.Models;
using DriverETACloud.Entities.Context;
using System.Linq;
using System.Collections.Generic;

namespace DriverETACloud.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DriverEtaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DriverEtaService.svc or DriverEtaService.svc.cs at the Solution Explorer and start debugging.
    public class DriverEtaService : IDriverEtaService
    {


        public Driver AddDriver(Driver driver)
        {
            using (DriverEtaContext context = new DriverEtaContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Drivers.Add(driver);
                context.SaveChanges();
            }
            return driver;
        }

        public Driver GetDriverID(string id)
        {
            int ID = Convert.ToInt16(id);           
            using (DriverEtaContext context = new DriverEtaContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                var temp = context.Drivers
                    .Select(t => new { t.DOB, t.DriverID, t.FirstName, t.LastName })
                    .Where(i => i.DriverID == ID)
                    .ToList();

                return temp
                    .Select(t => new Driver { DOB = t.DOB.Value,DriverID=t.DriverID,FirstName=t.FirstName.Trim(),LastName=t.LastName.Trim() })
                    .SingleOrDefault();
            }

        }

        public List<Driver> GetAllDrivers()
        {
            List<Driver> lstDrivers = new List<Driver>();
            using (DriverEtaContext context = new DriverEtaContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                lstDrivers = context.Drivers.ToList<Driver>();
            }
            return lstDrivers;         
        }
    }
}
