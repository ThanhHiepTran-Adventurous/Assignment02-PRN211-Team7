using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> getOrderDetail(int orderId) => OrderDetailDAO.Instance.GetOrderDetailList(orderId);


        public OrderDetail getDetailById(int orderId) => OrderDetailDAO.Instance.getDetailById(orderId);


        public OrderDetail getDetailByProductId(int productId) => OrderDetailDAO.Instance.getDetailByProductId(productId);



        public void InsertOrderDetail(OrderDetail detail) => OrderDetailDAO.Instance.AddOrderDetail(detail);

        public void UpdateOrderDetail(OrderDetail detail) => OrderDetailDAO.Instance.UpdateOrderDetail(detail);


        public void DeleteDetail(int orderId, int productId) => OrderDetailDAO.Instance.DeleteOrderDetail(orderId, productId);

    }
}
