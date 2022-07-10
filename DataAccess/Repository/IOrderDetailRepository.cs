using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> getOrderDetail(int orderId);

        OrderDetail getDetailById(int orderId);


        OrderDetail getDetailByProductId(int productId);

        void InsertOrderDetail(OrderDetail detail);


        void UpdateOrderDetail(OrderDetail detail);

        void DeleteDetail(int orderId, int productId);
    }
}
