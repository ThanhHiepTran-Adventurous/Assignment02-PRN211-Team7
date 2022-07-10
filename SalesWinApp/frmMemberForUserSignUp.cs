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
    public partial class frmMemberForUserSignUp : Form
    {

        public Member? user { get; set; }



        public frmMain? mainForm { get; set; }

        public bool InsertOrUpdate { get; set; }

        IMemberRepository memberRepository = new MemberRepository();


        public frmMemberForUserSignUp()
        {
            InitializeComponent();
        }



        private void getMemberInfo()
        {
            txtMemberId.Text = user.MemberId.ToString();
            txtEmail.Text = user.Email.ToString();
            txtCompanyName.Text = user.CompanyName.ToString();
            txtCity.Text = user.City.ToString();
            txtCountry.Text = user.Country.ToString();
            txtPassword.Text = user.Password.ToString();
            txtRoleName.Text = user.RoleName.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim().Length > 0 && txtCompanyName.Text.Trim().Length > 0
                    && txtCity.Text.Trim().Length > 0 && txtCountry.Text.Trim().Length > 0
                    && txtPassword.Text.Trim().Length > 0 && txtRoleName.Text.Trim().Length > 0)
                {
                    Member mem = new Member()
                    {
                        Email = txtEmail.Text,
                        CompanyName = txtCompanyName.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Text,
                        RoleName = txtRoleName.Text,

                    };
                    if (InsertOrUpdate == true)
                    {
                        mem.MemberId = int.Parse(txtMemberId.Text);
                        memberRepository.UpdateMember(mem);
                        user = mem;
                        mainForm.user = this.user;
                        getMemberInfo();
                        MessageBox.Show("Update successfully");

                    }
                    else
                    {
                        memberRepository.InsertMember(mem);
                        MessageBox.Show("SignUp successfully");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Input Fail!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update account");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMemberForUserSignUp_Load(object sender, EventArgs e)
        {
            if (InsertOrUpdate == true)
            {
                getMemberInfo();
            }
        }
    }
}
