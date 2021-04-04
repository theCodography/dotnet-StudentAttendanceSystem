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
    public partial class FormCreateAccount : Form
    {
        public FormCreateAccount()
        {
            InitializeComponent();
        }

        private void FormCreateAccount_Load(object sender, EventArgs e)
        {
            cbbRole.DisplayMember = "role_description";
            cbbRole.ValueMember = "role_id";
            cbbRole.DataSource = RoleDAO.GetRole();
            cbbRole.SelectedIndex = 0;

        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ("Teacher".Equals(cbbRole.Text))
            {
                tbCode.Enabled = false;
            }
            else
            {
                tbCode.Enabled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            int role = Convert.ToInt32(cbbRole.SelectedValue);
            string email = tbEmail.Text;
            string pass = tbPass.Text;
            string code = tbCode.Text;
            string name = tbName.Text;
            if (email == "" || pass == "" || email == "")
            {
                MessageBox.Show("Please Field All Box");
                return;
            }
            int count = AccountDAO.GetAccountListByEmail(email);
            if (count == 0)
            {
                if (role == 2)
                {
                    if (TeacherDAO.InsertTeacher(email, pass, 2, name) > 0)
                    {
                        MessageBox.Show(String.Format("Create Teacher {0} Success", email));
                    }
                }
                else if (role == 3)
                {
                    if (StudentDAO.GetStudentByCode(code) != 0)
                    {
                        MessageBox.Show(String.Format("Code {0} Exist", code));
                        tbCode.Text = "";
                        return;
                    }
                    if (StudentDAO.InsertStudent(email, pass, 3, code, name) > 0)
                    {
                        MessageBox.Show(String.Format("Create Student {0} Success", email));
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show(String.Format("Email {0} Exist", email));
            }

        }
    }
}
