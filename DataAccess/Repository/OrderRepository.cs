using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> GetOrder() => OrderDAO.Instance.GetOrderList();


        public void InsertOrder(Order order) => OrderDAO.Instance.AddOrder(order);

        public void UpdateOrder(Order order) => OrderDAO.Instance.UpdateOrder(order);

        public void DeleteOrder(int orderId) => OrderDAO.Instance.DeleteOrder(orderId);



        public Order GetOrderById(int orderId) => OrderDAO.Instance.GetOrderById(orderId);

        public Order GetOrderByMemberId(int memberId)
        {
            return OrderDAO.Instance.GetOrderByMemberId(memberId);
        }


        public IEnumerable<Order>? getOrderDetail(int memberId) => OrderDAO.Instance.GetOrderListByMemId(memberId);
    }
}
