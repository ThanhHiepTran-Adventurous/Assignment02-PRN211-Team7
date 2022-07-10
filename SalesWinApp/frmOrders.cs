using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataAccess.Repository;
using BusinessObject.Models;


namespace SalesWinApp
{
    public partial class frmOrders : Form
    {

        IOrderRepository orderRepository = new OrderRepository();
        BindingSource source;
        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            LoadOrdersList();
            // btnDelete.Enabled = false;
            dgvOrderList.CellDoubleClick += DgvOrderList_CellDoubleClick;
        }

        //-----------------------------------
        private void DgvOrderList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmOrdersDetail details = new frmOrdersDetail
            {
                Text = "Update order",
                InsertOrUpdate = true,
                OrderInfo = GetOrderObject(),
                OrderRepository = orderRepository
            };
            if (details.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
                source.Position = source.Count - 1;

            }
            LoadOrdersList();
        }
        //------------------------------------------------------
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmOrdersDetail ordersDetails = new frmOrdersDetail
            {
                Text = "Add a new Orders",
                InsertOrUpdate = false,
                OrderRepository = orderRepository
            };
            if (ordersDetails.ShowDialog() == DialogResult.OK)
            {
                LoadOrdersList();
                source.Position = source.Count - 1;
            }
            LoadOrdersList();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadOrdersList();
        }
        //-------------------------------------------------------------
        public void LoadOrdersList()
        {
            var orders = orderRepository.GetOrder();
            try
            {
                BindingSource source = new BindingSource();
                source.DataSource = orders;

                txtOrderId.DataBindings.Clear();
                txtMemberId.DataBindings.Clear();
                txtOrderDate.DataBindings.Clear();
                txtRequiredDate.DataBindings.Clear();
                txtShippedDate.DataBindings.Clear();
                txtFreight.DataBindings.Clear();

                txtOrderId.DataBindings.Add("Text", source, "OrderId");
                txtMemberId.DataBindings.Add("Text", source, "MemberId");
                txtOrderDate.DataBindings.Add("Text", source, "OrderDate");
                txtRequiredDate.DataBindings.Add("Text", source, "RequiredDate");
                txtShippedDate.DataBindings.Add("Text", source, "ShippedDate");
                txtFreight.DataBindings.Add("Text", source, "Freight");

                dgvOrderList.DataSource = null;
                dgvOrderList.DataSource = source;

                this.dgvOrderList.Columns["Member"].Visible = false;
                this.dgvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                this.dgvOrderList.Columns["OrderDetails"].Visible = false;
                this.dgvOrderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

                if (orders.Count() == 0)
                {
                    ClearTextOrder();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Orders List");

            }
        }

        private void ClearTextOrder()
        {
            txtOrderId.Text = string.Empty;
            txtMemberId.Text = string.Empty;
            txtOrderDate.Text = string.Empty;
            txtRequiredDate.Text = string.Empty;
            txtShippedDate.Text = string.Empty;
            txtFreight.Text = string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                var order = GetOrderObject();
                orderRepository.DeleteOrder(order.OrderId);
                MessageBox.Show("Delete order successfull");
                LoadOrdersList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a Order!");
            }
        }
        //--------------------------------------------------------
        private Order GetOrderObject()
        {
            Order order = null;
            try
            {
                // int orderId = int.Parse(txtOrderId.Text);
                // order = orderRepository.GetOrderById(orderId);


                order = new Order
                {
                    OrderId = int.Parse(txtOrderId.Text),
                    MemberId = int.Parse(txtMemberId.Text),
                    OrderDate = DateTime.Parse(txtOrderDate.Text),
                    RequiredDate = DateTime.Parse(txtRequiredDate.Text),
                    ShippedDate = DateTime.Parse(txtShippedDate.Text),
                    Freight = decimal.Parse(txtFreight.Text)
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Orders");


            }
            return order;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewOrderDetail_Click(object sender, EventArgs e)
        {
            frmOrderProduct frmOrderProduct = new frmOrderProduct()
            {
                OrderId = int.Parse(txtOrderId.Text)
            };
            frmOrderProduct.ShowDialog();
        }
    }
}
