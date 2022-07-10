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
    public partial class frmMembersDetail : Form
    {
        public frmMembersDetail()
        {
            InitializeComponent();
        }

        public IMemberRepository MemberRepository { get; set; }

        public bool InsertOrUpdate { get; set; }
        public Member MemberInfo { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMembersDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            txtMemberId.Enabled = false;
            if (InsertOrUpdate == true)
            {
                txtMemberId.Text = MemberInfo.MemberId.ToString();
                txtEmail.Text = MemberInfo.Email;
                txtCompanyName.Text = MemberInfo.CompanyName;
                txtCity.Text = MemberInfo.City;
                txtCountry.Text = MemberInfo.Country;
                txtPassword.Text = MemberInfo.Password;
                txtRoleName.Text = MemberInfo.RoleName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var mem = new Member
                {
                    //   MemberId = int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtCompanyName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                    RoleName = txtRoleName.Text
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(mem);
                    MessageBox.Show("Add successfully!!");

                    this.Close();
                }
                else
                {
                    mem.MemberId = int.Parse(txtMemberId.Text);
                    MemberRepository.UpdateMember(mem);
                    MessageBox.Show("Update Successfully!!");

                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Members" : "Update a Member");
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }
    }
}
