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
    }
}
