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
    public partial class frmProductDetail : Form
    {
        public frmProductDetail()
        {
            InitializeComponent();
        }

        public IProductRepository ProductRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Product ProductInfo { get; set; }

        private void frmProductsDetails_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            txtProductID.Enabled = false;
            if (InsertOrUpdate == true)
            {
                txtProductID.Text = ProductInfo.ProductId.ToString();
                txtCategoryID.Text = ProductInfo.CategoryId.ToString();
                txtProductName.Text = ProductInfo.ProductName;
                txtWeight.Text = ProductInfo.Weight;
                txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitStock.Text = ProductInfo.UnitslnStock.ToString();
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var pro = new Product
                {
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitslnStock = int.Parse(txtUnitStock.Text)
                };
                if (InsertOrUpdate == false)
                {

                    ProductRepository.InsertProduct(pro);
                    MessageBox.Show("Add product successfully!!");
                    this.Close();
                }
                else
                {
                    pro.ProductId = int.Parse(txtProductID.Text);
                    ProductRepository.UpdateProduct(pro);
                    MessageBox.Show("Update Successfully!!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Products" : "Update a Products");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                var pro = new Product
                {
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    UnitslnStock = int.Parse(txtUnitStock.Text)
                };
                if (InsertOrUpdate == false)
                {

                    ProductRepository.InsertProduct(pro);
                    MessageBox.Show("Add product successfully!!");
                    this.Close();
                }
                else
                {
                    pro.ProductId = int.Parse(txtProductID.Text);
                    ProductRepository.UpdateProduct(pro);
                    MessageBox.Show("Update Successfully!!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Products" : "Update a Products");
            }
        }
    }
}
