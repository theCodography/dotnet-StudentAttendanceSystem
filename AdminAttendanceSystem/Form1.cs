using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentAttendanceSystem.App_Code.DAO;
namespace AdminAttendanceSystem
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            
            InitializeComponent();
        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;
            int role = 1;
            DataTable account = AccountDAO.GetAccount(username, password, role);
            if (account.Rows.Count > 0)
            {
                MessageBox.Show("Login Success");
                formManager f = new formManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Email or Password incorrect!");
            }
        }
    }
}
