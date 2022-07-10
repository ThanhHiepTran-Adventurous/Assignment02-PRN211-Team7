using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using BusinessObject.Models;
using DataAccess.Repository;


namespace SalesWinApp
{
    public partial class frmOrdersForUser : Form
    {

        public Member? user { get; set; }

        public Order userOrder { get; set; }

        public frmMain? frmMain { get; set; }

        IOrderRepository orderRepository = new OrderRepository();
        public frmOrdersForUser()
        {
            InitializeComponent();
        }

        private void GetOrderMemberInfo()
        {
            txtOrderId.Text = userOrder.OrderId.ToString();
            txtMemberId.Text = userOrder.MemberId.ToString();
            txtOrderDate.Text = userOrder.OrderDate.ToString();
            txtRequiredDate.Text = userOrder.RequiredDate.ToString();
            txtShippedDate.Text = userOrder.ShippedDate.ToString();
            txtFreight.Text = userOrder.Freight.ToString();
        }

        private void frmOrdersForUser_Load(object sender, EventArgs e)
        {
            IEnumerable<Order>? orders = null;
            orders = orderRepository.getOrderDetail(this.userOrder.MemberId);
            // var orders =   orderRepository.GetOrder();
            if (orders == null)
            {
                MessageBox.Show("No Order you want to see!");
            }else
            {
                loadOrderListOnDgv(orders);
                GetOrderMemberInfo();
            }
            
        }


        private void loadOrderListOnDgv(IEnumerable<Order> orders)
        {
            try
            {
                if (orders.Count() > 0)
                {
                    DataTable dataTb = new DataTable();
                    dataTb.Columns.Add("Order ID", typeof(int));
                    dataTb.Columns.Add("Member ID", typeof(int));
                    dataTb.Columns.Add("Order Date", typeof(string));
                    dataTb.Columns.Add("Required Date", typeof(string));
                    dataTb.Columns.Add("Shipped Date", typeof(string));
                    dataTb.Columns.Add("Freight", typeof(decimal));
                    foreach (var orderItem in orders)
                    {
                        dataTb.Rows.Add(orderItem.OrderId, orderItem.MemberId,
                            orderItem.OrderDate, orderItem.RequiredDate, orderItem.ShippedDate,
                            orderItem.Freight);
                    }
                    dgvOrderListForUs.DataSource = dataTb;

                    txtOrderId.Text = dataTb.Rows[0][0].ToString();
                    txtMemberId.Text = dataTb.Rows[0][1].ToString();
                    txtOrderDate.Text = dataTb.Rows[0][2].ToString();
                    txtRequiredDate.Text = dataTb.Rows[0][3].ToString();
                    txtShippedDate.Text = dataTb.Rows[0][4].ToString();
                    txtFreight.Text = dataTb.Rows[0][5].ToString();
                }
                else
                {
                    try
                    {
                        dgvOrderListForUs.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "List null");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order List");
            }
        }

        private void dgvOrderListForUs_DataSourceChanged(object sender, EventArgs e)
        {
            dgvOrderListForUs.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrderListForUs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrderListForUs.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i <= dgvOrderListForUs.Columns.Count - 1; i++)
            {
                int colums = dgvOrderListForUs.Columns[i].Width;

                dgvOrderListForUs.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvOrderListForUs.Columns[i].Width = colums;
            }
        }
    }
}
