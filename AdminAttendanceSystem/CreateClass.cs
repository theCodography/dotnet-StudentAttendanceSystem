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
    public partial class CreateClass : Form
    {
        public CreateClass()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(tbCode.Text == "" || tbCode.Text == null)
            {
                MessageBox.Show("Please Field All Box");
                return;
            }
            string code = tbCode.Text;
            int count = ClassDAO.GetClassListByCode(code);
            if (count == 0)
            {
                if (ClassDAO.InsertClass(code) > 0)
                {
                    MessageBox.Show(String.Format("Create Class {0} Success", code));
                    this.Close();
                }
            }else
            {
                MessageBox.Show(String.Format("Class {0} Exist", code));
            }

        }
    }
}
