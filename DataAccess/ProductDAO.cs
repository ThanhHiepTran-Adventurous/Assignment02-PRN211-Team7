using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        public ProductDAO()
        {

        }

        //----------------------------------------------------
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Product> SearchProducts(string searchBy, string keyword)
        {
            using (SalesManagementDBContext dbContext = new SalesManagementDBContext())
            {

                switch (searchBy)
                {
                    case "Product Name":
                        return dbContext.Products.Where(p => p.ProductName.Contains(keyword)).ToList();
                        break;
                    case "Product ID":
                        return dbContext.Products.Where(p => p.ProductId == int.Parse(keyword)).ToList();
                        break;
                    case "Unit In Stock":
                        return dbContext.Products.Where(p => p.UnitslnStock == int.Parse(keyword)).ToList();
                        break;
                    case "Unit Price":
                        return dbContext.Products.Where(p => p.UnitPrice == decimal.Parse(keyword)).ToList();
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        //--------------------------------------

        public void AddProduct(Product product)
        {
            try
            {
                SalesManagementDBContext productDBContext = new SalesManagementDBContext();
                productDBContext.Products.Add(product);
                productDBContext.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                SalesManagementDBContext productDBContext = new SalesManagementDBContext();
                productDBContext.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                productDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int productId)
        {
            try
            {
                SalesManagementDBContext productDBContext = new SalesManagementDBContext();

                var product = productDBContext.Products.SingleOrDefault(products => products.ProductId == productId);
                if (product != null)
                {
                    productDBContext.Remove(product);
                    productDBContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Product> GetProductList()
        {
            SalesManagementDBContext context = new SalesManagementDBContext();
            var producs = context.Products.ToList();
            return producs;
        }


    }
}
