using FinalProject.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FinalProject.lib
{
    public class OrdersDAL
    {
        private static LaundryDBEntities db = DALC.dbEntryPoint;

        public static List<OrdersAndStatus> GetRecentOrdersAndStatus()
        {
            // List is reversed so that recent orders are at the top
            List<OrdersAndStatus> oas = db.OrdersAndStatuses.ToList().Reverse<OrdersAndStatus>().ToList();
            if (oas.Count > 10) return oas.GetRange(0, 10);
            return oas;
        }

        public static Order GetOrderByID(int OrderID)
        {
            return db.Orders.Find(OrderID);
        }

        public static List<OrdersAndStatus> GetAllOrders()
        {
            return db.OrdersAndStatuses.ToList();
        }

        public static string GetTotalOrders()
        {
            return db.Orders.Count().ToString();
        }

        public static string GetCancelledOrders()
        {
            return db.Orders.Where(m => m.OrderStatus == 4).ToList().Count().ToString();
        }

        public static string GetCompletedOrders()
        {
            return db.Orders.Where(m => m.OrderStatus == 3).ToList().Count().ToString();

        }

        public static string GetPendingOrders()
        {
            return db.Orders.Where(m => m.OrderStatus == 1).ToList().Count().ToString();
        }

        public static void DeleteOrder(int ID)
        {
            db.DeleteOrder(ID);
        }

        public static void AddOrder(string FirstName, string LastName, int LaundryWeight, DateTime OrderDate, List<DB.Service> Services)
        {
            int totalFee = 0;
            db.AddOrder(FirstName, LastName, LaundryWeight, OrderDate, 0);
            Order addedOrder = db.Orders.ToList().Last();
            foreach (DB.Service s in Services)
            {
                totalFee += s.Fee.Value;
                db.AddOrderService(addedOrder.OrderID, s.ServiceID);
            }
            addedOrder.TotalCost = totalFee;
            db.SaveChanges();
        }
        public static void UpdateOrder(int OrderID, string FirstName, string LastName, int Status, int LaundryWeight, DateTime OrderDate, List<DB.Service> Services)
        {
            Order orderToUpdate = db.Orders.Find(OrderID);
            int totalFee = 0;
            orderToUpdate.CustomerName = FirstName;
            orderToUpdate.CustomerSurname = LastName;
            orderToUpdate.LaundryWeight = LaundryWeight;
            orderToUpdate.OrderDate = OrderDate;
            orderToUpdate.OrderStatus = Status;
            db.DeleteOrderServices(OrderID);
            foreach (DB.Service s in Services)
            {
                totalFee += s.Fee.Value;
                db.AddOrderService(OrderID, s.ServiceID);
            }
            orderToUpdate.TotalCost = totalFee;
            db.SaveChanges();
        }
    }
}