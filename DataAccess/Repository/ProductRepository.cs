using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> GetProduct() => ProductDAO.Instance.GetProductList();

        public void InsertProduct(Product product) => ProductDAO.Instance.AddProduct(product);

        public void UpdateProduct(Product product) => ProductDAO.Instance.UpdateProduct(product);

        public void DeleteProduct(int productId) => ProductDAO.Instance.DeleteProduct(productId);


    }
}
