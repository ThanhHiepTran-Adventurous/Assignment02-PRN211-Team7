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
    public partial class frmOrderProduct : Form
    {


        IOrderDetailRepository OrderDetailRepository = new OrderDetailRepository();

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public OrderDetail orderDetailInfo { get; set; }

        public frmOrderProduct()
        {
            InitializeComponent();
        }

        private void frmOrderProduct_Load(object sender, EventArgs e)
        {
            var orderDetails = OrderDetailRepository.getOrderDetail(this.OrderId);
            LoadOrderDetailList(orderDetails);
        }

        private void LoadOrderDetailList(IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                if (orderDetails.Count() > 0)
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Order ID", typeof(int));

                    dataTable.Columns.Add("Product ID", typeof(int));

                    dataTable.Columns.Add("Unit Price", typeof(decimal));

                    dataTable.Columns.Add("Quantity", typeof(int));

                    dataTable.Columns.Add("Discount", typeof(float));

                    foreach (var orderDetail in orderDetails)
                    {
                        dataTable.Rows.Add(orderDetail.OrderId, orderDetail.ProductId,
                            orderDetail.UnitPrice, orderDetail.Quantity, orderDetail.Discount);
                    }

                    dgvOrderDetailList.DataSource = dataTable;

                    txtOrderId.Text = dataTable.Rows[0][0].ToString();
                    txtProductId.Text = dataTable.Rows[0][1].ToString();
                    txtUnitPrice.Text = dataTable.Rows[0][2].ToString();
                    txtQuantity.Text = dataTable.Rows[0][3].ToString();
                    txtDiscount.Text = dataTable.Rows[0][4].ToString();
                }
                else
                {
                    try
                    {
                        dgvOrderDetailList.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Order Detail list");
            }
        }

        private void btnAddOrderDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private OrderDetail GetDetailObject()
        {
            OrderDetail orderDetail = null;
            try
            {
                //    int productId = ProductId;
                int orderId = OrderId;
                orderDetail = OrderDetailRepository.getDetailById(orderId);
                //    orderDetail = OrderDetailRepository.getDetailByProductId(productId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Order"); ;
            }
            return orderDetail;
        }


        private void dgvOrderDetailList_DataSourceChanged(object sender, EventArgs e)
        {
            // Set your desired AutoSize Mode:
            dgvOrderDetailList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrderDetailList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvOrderDetailList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= dgvOrderDetailList.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dgvOrderDetailList.Columns[i].Width;

                // Remove AutoSizing:
                dgvOrderDetailList.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dgvOrderDetailList.Columns[i].Width = colw;
            }
        }
    }
}
