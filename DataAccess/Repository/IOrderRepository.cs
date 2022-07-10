using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.Models;
namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrder();

        void InsertOrder(Order order);

        void UpdateOrder(Order order);


        Order GetOrderById(int orderId);

        void DeleteOrder(int orderId);

        Order GetOrderByMemberId(int memberId);
    }
}
