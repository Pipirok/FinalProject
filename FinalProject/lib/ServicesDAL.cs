using FinalProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class ServicesDAL
    {
        private static LaundryDBEntities db = DALC.dbEntryPoint;
        public static List<Service> GetAllServices()
        {
            return db.Services.ToList();
        }

        public static Service GetServiceByID(int ServiceID)
        {
            return db.Services.Find(ServiceID);
        }

        public static bool DoesServiceExist(string displayName)
        {
            return db.Services.Where(s => s.DisplayName == displayName).ToList().Count() != 0;
        }

        public static Service GetServiceByDisplayName(string DisplayName)
        {
            return db.Services.Where(s => s.DisplayName == DisplayName).ToList()[0];
        }

        public static void UpdateService(int ServiceID, string displayName, int fee, int duration)
        {
            Service service = db.Services.Find(ServiceID);
            service.DisplayName = displayName;
            service.Fee = fee;
            service.Duration = duration;
            db.SaveChanges();
        }

        public static List<OrderService> GetOrderServices(int OrderID)
        {
            return db.OrderServices.Where(o => o.OrderID == OrderID).ToList();
        }

        public static void AddService(string displayName, int fee, int duration)
        {
            db.AddService(displayName, fee, duration);
        }

        public static void DeleteService(int ID)
        {
            db.DeleteService(ID);
        }
    }
}