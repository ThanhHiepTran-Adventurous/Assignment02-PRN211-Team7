using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesWinApp
{
    public partial class frmProduct : Form
    {
        IProductRepository productRepository = new ProductRepository();
        BindingSource source;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvProduct.CellDoubleClick += DgvProducList_CellDoubleClick;
        }

        private void DgvProducList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductsDetails = new frmProductDetail
            {
                Text = "Update  product",
                InsertOrUpdate = true,
                ProductInfo = GetProductObject(),
                ProductRepository = productRepository
            };
            if (frmProductsDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductsList();
                source.Position = source.Count - 1;
            }
            LoadProductsList();
        }

        private Product GetProductObject()
        {
            Product product = null;
            try
            {
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitslnStock = int.Parse(txtUnitStock.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get producs");
            }
            return product;
        }

        public void LoadProductsList()
        {
            var products = productRepository.GetProduct();
            try
            {

                BindingSource source = new BindingSource();
                source.DataSource = products;

                txtProductID.DataBindings.Clear();
                txtCategoryID.DataBindings.Clear();
                txtProductName.DataBindings.Clear();
                txtWeight.DataBindings.Clear();
                txtUnitPrice.DataBindings.Clear();
                txtUnitStock.DataBindings.Clear();

                txtProductID.DataBindings.Add("Text", source, "ProductId");
                txtCategoryID.DataBindings.Add("Text", source, "CategoryId");
                txtProductName.DataBindings.Add("Text", source, "ProductName");
                txtWeight.DataBindings.Add("Text", source, "Weight");
                txtUnitPrice.DataBindings.Add("Text", source, "UnitPrice");
                txtUnitStock.DataBindings.Add("Text", source, "UnitslnStock");

                dgvProduct.DataSource = null;
                dgvProduct.DataSource = source;
                this.dgvProduct.Columns["OrderDetails"].Visible = false;
                this.dgvProduct.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                if (products.Count() == 0)
                {
                    ClearTextProduct();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Products List");
            }

        }

        private void ClearTextProduct()
        {
            txtProductID.Text = string.Empty;
            txtCategoryID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtUnitPrice.Text = string.Empty;
            txtUnitStock.Text = string.Empty;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadProductsList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductDetail frmProductsDetails = new frmProductDetail
            {
                Text = "Add a new Products",
                InsertOrUpdate = false,
                ProductRepository = productRepository
            };
            if (frmProductsDetails.ShowDialog() == DialogResult.OK)
            {
                LoadProductsList();
                source.Position = source.Count - 1;
            }
            LoadProductsList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var pro = GetProductObject();
                productRepository.DeleteProduct(pro.ProductId);
                MessageBox.Show("Delete successfuly");
                LoadProductsList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a product!");
            }
        }
    }
}
