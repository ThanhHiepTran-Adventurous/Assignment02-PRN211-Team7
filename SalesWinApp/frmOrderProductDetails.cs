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
    public partial class frmOrderProductDetails : Form
    {

        public int orderId { get; set; }

        public OrderDetail OrderDetailInfo = new OrderDetail();

        public Product productInfo = new Product();

        public bool InsertOrUpdate { get; set; }

        public IOrderDetailRepository OrderDetailRepository { get; set; }

        public frmOrderProductDetails()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(txtQuantity.Text)
                    || String.IsNullOrEmpty(txtDiscount.Text)
                    || String.IsNullOrEmpty(txtUnitPrice.Text))
                {
                    throw new Exception("Invalid input");
                }
                if (float.Parse(txtDiscount.Text) > 100)
                {
                    throw new Exception("Discount must smaller than 100");
                }
                Product choice = (Product)cbxProductChoice.SelectedItem;
                var detail = new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = choice.ProductId,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Discount = float.Parse(txtDiscount.Text)
                };
                if(InsertOrUpdate == false)
                {
                    OrderDetailRepository.InsertOrderDetail(detail);
                }else
                {
                    OrderDetailRepository.UpdateOrderDetail(detail);
                }
                Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Insert");
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Close form");
            }
        }

        private void frmOrderProductDetails_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            ProductRepository productRepository = new ProductRepository();
            var products = productRepository.GetProduct();
            txtOrderId.Text = orderId.ToString();

            foreach (Product product in products)
            {

                cbxProductChoice.Items.Add(product);
            }
            txtOrderId.Enabled = false;

            if (InsertOrUpdate == true)
            {
                cbxProductChoice.Enabled = false;

                int numberOfItem = cbxProductChoice.Items.Count;
                for (int i = 0; i < numberOfItem; i++)
                {
                    Product product = (Product)cbxProductChoice.Items[i];
                    if (product.ProductId == OrderDetailInfo.ProductId)
                    {
                        cbxProductChoice.SelectedIndex = i;
                    }
                }
                txtUnitPrice.Text = OrderDetailInfo.UnitPrice.ToString();
                txtQuantity.Text = OrderDetailInfo.Quantity.ToString();
                txtDiscount.Text = OrderDetailInfo.Discount.ToString();
            }
        }
    }
}
