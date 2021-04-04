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
    public partial class AddStudentToClass : Form
    {
        public int ClassID { get; set; }
        private string ClassCode;
        public AddStudentToClass(int classID, string classCode)
        {
            ClassID = classID;
            ClassCode = classCode;
            InitializeComponent();
        }

        private void AddStudentToClass_Load(object sender, EventArgs e)
        {
            tbClass.Text = ClassCode;
            //===========DVSTUDENTCHECKBOX=============
            DataGridViewCheckBoxColumn checkboxcol = new DataGridViewCheckBoxColumn();
            checkboxcol.Name = "checkcol";
            checkboxcol.HeaderText = "Select";
            dvStudentNoClass.Columns.Add(checkboxcol);
            //===========DVSTUDENT=============
            dvStudentNoClass.AutoGenerateColumns = false;
            dvStudentNoClass.Columns.Add("stuCode", "Student Code");
            dvStudentNoClass.Columns["stuCode"].DataPropertyName = "student_code";
            dvStudentNoClass.Columns.Add("stuName", "Student Name");
            dvStudentNoClass.Columns["stuName"].DataPropertyName = "student_name";
            dvStudentNoClass.Columns.Add("stuEmail", "email");
            dvStudentNoClass.Columns["stuEmail"].DataPropertyName = "email";
            dvStudentNoClass.AllowUserToAddRows = false;
            LoadStudent();
        }

        private void LoadStudent()
        {
            DataTable dt = StudentDAO.GetStudentNoClass();
            DataView dv = dt.DefaultView;
            dvStudentNoClass.DataSource = dv.ToTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<int> isAdd = new List<int>();
            foreach (DataGridViewRow row in dvStudentNoClass.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkcol"].Value);
                if (isSelected)
                {
                    int stuid = Convert.ToInt32(((DataTable)dvStudentNoClass.DataSource).Rows[row.Index]["student_id"]);
                    isAdd.Add(stuid);
                }
            }

            if (isAdd.Count == 0)
            {
                MessageBox.Show("You must select one corporation at least");
            }
            else
            {
                for (int i = 0; i < isAdd.Count; i++)
                {
                    ClassDAO.InsertStudentToClass(ClassID,isAdd[i]);
                }
                MessageBox.Show(String.Format("Add {0} student(s) to {1}.", isAdd.Count, ClassCode));
            }

            LoadStudent();
        }
    }
}
