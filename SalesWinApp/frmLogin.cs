using Microsoft.Extensions.Configuration;
using DataAccess;
using DataAccess.Repository;
using BusinessObject.Models;

namespace SalesWinApp
{
    public partial class frmLogin : Form
    {       
        
        public frmLogin()
        {
            InitializeComponent();
        }
        MemberRepository mem = new MemberRepository();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var adminLogin = Program.Configuration.GetSection("AdminAccount").Get<Member>();

            string Email = adminLogin.Email;
            string Password = adminLogin.Password;

            string _Email, _Password;
            _Email = txtEmail.Text;
            _Password = txtPassword.Text;

            Member check = mem.GetMailAndPassword(_Email, _Password);   

            if (Email.Equals(_Email) && Password.Equals(_Password))
            {

                MessageBox.Show("Wellcome to admin!");
                frmMain frmMain = new frmMain();
                frmMain.user = adminLogin;
                frmMain.Show();
                this.Hide();
            }
            else if (check == null)
            {
                MessageBox.Show("Invalid");
            }
            else
            {
                frmMain mainForm = new frmMain();
                mainForm.user = check;
                mainForm.Show();
                this.Hide();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            frmMemberForUserSignUp signUpFrm = new frmMemberForUserSignUp
            {
                user = null,
                mainForm = null,
                InsertOrUpdate = false
            };
            signUpFrm.ShowDialog();
        }
    }
}