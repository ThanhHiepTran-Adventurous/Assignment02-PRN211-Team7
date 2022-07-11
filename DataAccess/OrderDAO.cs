using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess
{
     public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        public OrderDAO()
        {
        }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                    return instance;
                }
            }
        }
        //--------------------------------------------------------
        public IEnumerable<Order> GetOrderList()
        {
            IEnumerable<Order> orders = null;
            SalesManagementDBContext dBContext = new SalesManagementDBContext();
            orders = dBContext.Orders.ToList();
            return orders;
        }

       public IEnumerable<Order> GetSaleReportList(DateTime orderDate, DateTime shippedDate)
        {
            var list = new List<Order>();
            try
            {
                using SalesManagementDBContext dBContext = new SalesManagementDBContext();
                list = dBContext.Orders.Where(o => o.OrderDate >= orderDate && o.ShippedDate <= shippedDate).ToList();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        //-----------------------------------------------------------------
        public void DeleteOrder(int orderId)
        {
            try
            {
                SalesManagementDBContext dbContext = new SalesManagementDBContext();
                var order = dbContext.Orders.SingleOrDefault(orders => orders.OrderId == orderId);
                if (order != null)
                {
                    dbContext.Orders.Remove(order);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //------------------------------------------------------------------

        public void AddOrder(Order order)
        {
            try
            {
                SalesManagementDBContext dBContext = new SalesManagementDBContext();
                dBContext.Orders.Add(order);
                dBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //-----------------------------------------------------------------

        public void UpdateOrder(Order order)
        {
            try
            {
                SalesManagementDBContext dBContext = new SalesManagementDBContext();
                dBContext.Entry<Order>(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                dBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //----------------------------------------------
        public Order GetOrderById(int orderId)
        {
            SalesManagementDBContext dBContext = new SalesManagementDBContext();
            Order order = dBContext.Orders.Where(order => order.OrderId == orderId).FirstOrDefault();
            return order;
        }

        // tìm orderId
        public Order GetOrderByMemberId(int memberId)
        {
            SalesManagementDBContext dBContext = new SalesManagementDBContext();
            Order? order = dBContext.Orders.Where(order => order.MemberId == memberId).FirstOrDefault();
            return order;
        }


        //Lấy list các order bằng memberId
        public IEnumerable<Order> GetOrderListByMemId(int memberId)
        {
            using SalesManagementDBContext dBContext = new SalesManagementDBContext();
            var order = dBContext.Orders.Where(order => order.MemberId == memberId).ToList();
            if(order.Count > 0)
            {
                return order;
            }
            return null;
        }

        //public IEnumerable<Order> GetSaleReport(DateTime orderDate, DateTime shippedDate)
        //{

        //} 

    }
}
