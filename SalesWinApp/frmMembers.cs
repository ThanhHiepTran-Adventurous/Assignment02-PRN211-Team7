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
    public partial class frmMembers : Form
    {
        IMemberRepository memberRepository = new MemberRepository();
        //Create a data source
        BindingSource source;
        public frmMembers()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void frmMembers_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvMemberList.CellDoubleClick += DgvCarList_CellDoubleClick;
        }

        private void DgvCarList_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmMembersDetail frmMemberDetails = new frmMembersDetail
            {
                Text = "Update member",
           //     InsertOrUpdate = true,
         //       MemberInfo = GetMemberObject(),
         //       MemberRepository = memberRepository

            };
            if (frmMemberDetails.ShowDialog() == DialogResult.OK)
            {
                LoadMemberList();
                //set focus member update
                source.Position = source.Count - 1;
            }
            LoadMemberList();
        }

        private void LoadMemberList()
        {
            
        }

        private Member GetMemberObject()
        {
            Member member = null;
            {
                try

                {
                    member = new Member
                    {
                        MemberId = int.Parse(txtMemberID.Text),
                        Email = txtEmail.Text,
                        CompanyName = txtCompanyName.Text,
                        City = txtCity.Text,
                        Country = txtCountry.Text,
                        Password = txtPassword.Text,
                        RoleName = txtRoleName.Text
                    };


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Get member");
                }
                return member;
            }
        }

        private void ClearText()
        {
            txtMemberID.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtRoleName.Text = string.Empty;
        }
    }
}
