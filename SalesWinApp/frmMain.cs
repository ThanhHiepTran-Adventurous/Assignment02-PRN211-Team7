﻿using BusinessObject.Models;
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
namespace SalesWinApp
{
    public partial class frmMain : Form
    {

        bool check;

        public Member user { get; set; }
        IOrderRepository order = new OrderRepository();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (user.RoleName == "member")
            {
               // createReportSalesToolStripMenuItem.Enabled = false;
                tlsManageProduct.Visible = false;
            //  tlsManageOrder.Visible = false;
                check = true;
                MessageBox.Show("Is member " + user.RoleName + " Member Name " + user.Email);
            }
            else
            {
                IsMdiContainer = true;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tlsManageMember_Click(object sender, EventArgs e)
        {
            // if(user.RoleName == "member")
            if (check == true)
            {
                // IsMdiContainer = true;
                frmMemberForUserSignUp childForm = new frmMemberForUserSignUp
                {
                    user = user,
                    mainForm = this,
                    InsertOrUpdate = true
                };
                //     childForm.MdiParent = this;
                //    childForm.Dock = DockStyle.Fill;
                childForm.Show();
            }
            else
            {
                frmMembers childFormMembers = new frmMembers();
                childFormMembers.MdiParent = this;
                childFormMembers.Dock = DockStyle.Fill;
                childFormMembers.Show();
            }
        }

        private void tlsManageProduct_Click(object sender, EventArgs e)
        {
            frmProduct childFormProducts = new frmProduct();
            childFormProducts.MdiParent = this;
            childFormProducts.Dock = DockStyle.Fill;
            childFormProducts.Show();
        }

        private void tlsManageOrder_Click(object sender, EventArgs e)
        {
            if (check == true)
            {
                //  IsMdiContainer = true;
                frmOrdersForUser childForm = new frmOrdersForUser
                {
                    user = user,
                    userOrder = order.GetOrderByMemberId(user.MemberId),
                    frmMain = this,
                    //InsertOrUpdate = true
                };
                //   childForm.MdiParent = this;
                // childForm.Dock = DockStyle.Fill;
                childForm.Show();
            }
            else
            {
                frmOrders childFormOrders = new frmOrders();
                childFormOrders.MdiParent = this;
                childFormOrders.Dock = DockStyle.Fill;
                childFormOrders.Show();
            }
        }
    }
}
