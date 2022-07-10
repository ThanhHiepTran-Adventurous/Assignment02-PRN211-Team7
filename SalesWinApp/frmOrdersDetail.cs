using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using BusinessObject.Models;
using DataAccess.Repository;
namespace SalesWinApp
{
    public partial class frmOrdersDetail : Form
    {
        public frmOrdersDetail()
        {
            InitializeComponent();
        }

        public IOrderRepository OrderRepository { get; set; }

        public bool InsertOrUpdate { get; set; }

        public Order OrderInfo { get; set; }

        private void frmOrdersDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            txtOrderId.Enabled = false;
            if (InsertOrUpdate == true)
            {
                txtOrderId.Text = OrderInfo.OrderId.ToString();
                txtMemberId.Text = OrderInfo.MemberId.ToString();
                txtOrderDate.Text = OrderInfo.OrderDate.ToString("dd/MM/yyyy");
                txtRequiredDate.Text = OrderInfo.RequiredDate.ToString("dd/MM/yyyy");
                txtShippedDate.Text = OrderInfo.ShippedDate.ToString("dd/MM/yyyy");
                txtFreight.Text = OrderInfo.Freight.ToString();
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

                if (String.IsNullOrEmpty(txtMemberId.Text) || String.IsNullOrEmpty(txtFreight.Text)
                    || String.IsNullOrEmpty(txtOrderDate.Text) || String.IsNullOrEmpty(txtRequiredDate.Text)
                    || String.IsNullOrEmpty(txtShippedDate.Text))
                {
                    throw new Exception("Invalid input");
                }
                DateTime orderDate = DateTime.ParseExact(
                        txtOrderDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime requiredDate = DateTime.ParseExact(
                        txtRequiredDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime shippedDate = DateTime.ParseExact(
                        txtShippedDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                if (DateTime.Compare(orderDate, requiredDate) > 0
                    || DateTime.Compare(orderDate, shippedDate) > 0)
                {
                    throw new Exception("Invalid date time input");
                }


                var order = new Order
                {
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = orderDate,
                    RequiredDate = requiredDate,
                    ShippedDate = shippedDate,
                    Freight = decimal.Parse(txtFreight.Text)
                };
                if (InsertOrUpdate == false)
                {
                    OrderRepository.InsertOrder(order);
                    MessageBox.Show("Add order Succccessfully");
                    this.Close();
                }
                else
                {
                    order.OrderId = int.Parse(txtOrderId.Text);
                    OrderRepository.UpdateOrder(order);
                    MessageBox.Show("Update Order succesfully");
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

       
    }
}
