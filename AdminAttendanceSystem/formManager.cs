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
    public partial class formManager : Form
    {
        public formManager()
        {
            InitializeComponent();
        }

        private void formManager_Load(object sender, EventArgs e)
        {
            //===========DVCLASS=============
            dvClass.AutoGenerateColumns = false;
            dvClass.Columns.Add("classname", "Class");
            dvClass.Columns["classname"].DataPropertyName = "class_code";

            DataGridViewButtonColumn buttonAddSchedule = new DataGridViewButtonColumn();
            buttonAddSchedule.Name = "addSchedule";
            buttonAddSchedule.HeaderText = "Action";
            buttonAddSchedule.Text = "Add Schedule";
            buttonAddSchedule.UseColumnTextForButtonValue = true;
            dvClass.Columns.Add(buttonAddSchedule);

            DataGridViewButtonColumn buttonAddStudent = new DataGridViewButtonColumn();
            buttonAddStudent.Name = "addStudent";
            buttonAddStudent.HeaderText = "Action";
            buttonAddStudent.Text = "Add Student";
            buttonAddStudent.UseColumnTextForButtonValue = true;
            dvClass.Columns.Add(buttonAddStudent);
            //===========DVSTUDENT=============
            dvStudent.AutoGenerateColumns = false;
            dvStudent.Columns.Add("stuCode", "Student Code");
            dvStudent.Columns["stuCode"].DataPropertyName = "student_code";
            dvStudent.Columns.Add("stuName", "Student Name");
            dvStudent.Columns["stuName"].DataPropertyName = "student_name";
            dvStudent.Columns.Add("stuEmail", "email");
            dvStudent.Columns["stuEmail"].DataPropertyName = "email";
            //===========DVACCOUNT=============
            dvAccount.AutoGenerateColumns = false;
            dvAccount.Columns.Add("accountEmail", "Account Email");
            dvAccount.Columns["accountEmail"].DataPropertyName = "email";
            dvAccount.Columns.Add("accountRole", "Role");
            dvAccount.Columns["accountRole"].DataPropertyName = "role_description";

            DataGridViewButtonColumn buttonEditAccount = new DataGridViewButtonColumn();
            buttonEditAccount.Name = "addSchedule";
            buttonEditAccount.HeaderText = "Action";
            buttonEditAccount.Text = "Edit";
            buttonEditAccount.UseColumnTextForButtonValue = true;
            dvAccount.Columns.Add(buttonEditAccount);
            //===========DVACCOUNTCBB=============
            DataTable dt = new DataTable();
            dt = RoleDAO.GetRole();
            DataRow row = dt.NewRow();
            row[0] = 0;
            row[1] = "All Account";
            dt.Rows.InsertAt(row, 0);
            cbbRole.DisplayMember = "role_description";
            cbbRole.ValueMember = "role_id";
            cbbRole.DataSource = dt;
            cbbRole.SelectedIndex = 0;

            LoadClass();
            LoadAccountAll();
        }
        private void LoadAccountAll()
        {
            dvAccount.DataSource = AccountDAO.GetAccountRole();
        }
        private void LoadAccountByRole(int role)
        {
            dvAccount.DataSource = AccountDAO.GetAccountByRole(role);
        }
        private void LoadClass()
        {
            dvClass.DataSource = ClassDAO.GetClassList();
        }
        private void LoadStudent(int classID)
        {
            DataTable dt = StudentDAO.GetStudentByClass(classID);
            DataView dv = dt.DefaultView;
            dvStudent.DataSource = dv.ToTable(true, "student_code", "student_name", "email");
        }

        private void dvClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int ClassID = Convert.ToInt32(((DataTable)dvClass.DataSource).Rows[e.RowIndex]["class_id"]);
            string ClassCode = ((DataTable)dvClass.DataSource).Rows[e.RowIndex]["class_code"].ToString();
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            else
            {
                LoadStudent(ClassID);
            }

            if (dvClass.Columns[e.ColumnIndex].Name.Equals("addStudent"))
            {
                AddStudentToClass formAddStudent = new AddStudentToClass(ClassID, ClassCode);
                formAddStudent.FormClosed += frmAdd_Closed;
                formAddStudent.ShowDialog();
            }
        }

        private void btnCreateClass_Click(object sender, EventArgs e)
        {
            CreateClass formCreate = new CreateClass();
            formCreate.FormClosed += frmCreate_Closed;
            formCreate.ShowDialog();
        }

        private void frmCreate_Closed(object sender, EventArgs e)
        {
            LoadClass();
            LoadAccountAll();
        }
        private void frmAdd_Closed(object sender, EventArgs e)
        {
            AddStudentToClass formAdd = (AddStudentToClass)sender;
            LoadStudent(formAdd.ClassID);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            FormCreateAccount formCreate = new FormCreateAccount();
            formCreate.FormClosed += frmCreate_Closed;
            formCreate.ShowDialog();
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            int role = Convert.ToInt32(cbbRole.SelectedValue);
            if (role == 0)
            {
                LoadAccountAll();
            }
            else
            {
                LoadAccountByRole(role);
            }

        }
    }
}
