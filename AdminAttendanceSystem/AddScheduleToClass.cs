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
    public partial class AddScheduleToClass : Form
    {
        public int ClassID { get; set; }
        private string ClassCode;
        public AddScheduleToClass(int classID, string classCode)
        {
            ClassID = classID;
            ClassCode = classCode;
            InitializeComponent();
        }

        private void AddScheduleToClass_Load(object sender, EventArgs e)
        {
            tbClass.Text = ClassCode;
            cbSlot.SelectedIndex = 0;
            cbSubject.DisplayMember = "subject_name";
            cbSubject.ValueMember = "subject_id";
            cbSubject.DataSource = ScheduleDAO.GetSubject();
            cbTeacher.DisplayMember = "teacher_name";
            cbTeacher.ValueMember = "teacher_id";
            cbTeacher.DataSource = TeacherDAO.GetTeacher();
        }

        private void monthCalendar1_MouseDown(object sender, MouseEventArgs e)
        {
            MonthCalendar.HitTestInfo info = monthCalendar1.HitTest(e.Location);
            if (info.HitArea == MonthCalendar.HitArea.Date)
            {
                if (monthCalendar1.BoldedDates.Contains(info.Time))
                {
                    monthCalendar1.RemoveBoldedDate(info.Time);
                }
                else
                {
                    monthCalendar1.AddBoldedDate(info.Time);
                }
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int teacherID = Convert.ToInt32(cbTeacher.SelectedValue);
            int slot = Convert.ToInt32(cbSlot.Text);
            int subID = Convert.ToInt32(cbSubject.SelectedValue);
            if (monthCalendar1.BoldedDates.Length == 0)
            {
                MessageBox.Show("Please Choose Date");
            }
            for (int i = 0; i < monthCalendar1.BoldedDates.Length; i++)
            {
                if (monthCalendar1.BoldedDates[i].Date >= DateTime.Now.Date)
                {
                    MessageBox.Show(String.Format("Date: {0}, Teacher: {1}, Slot: {2}", monthCalendar1.BoldedDates[i], teacherID, slot));
                    if (ScheduleDAO.GetScheduleExist(teacherID, slot, monthCalendar1.BoldedDates[i]) == 0)
                    {
                        ScheduleDAO.InsertSchedule(ClassID, monthCalendar1.BoldedDates[i], slot, subID, teacherID);
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Teacher {0} is busy at {1} Slot {2}", teacherID, monthCalendar1.BoldedDates[i].ToString("dd/MM/yyyy"), slot));
                    }
                }
                else
                {
                    MessageBox.Show(String.Format("Can not add date {0}", monthCalendar1.BoldedDates[i].ToString("dd/MM/yyyy")));
                }
                

            }
            monthCalendar1.RemoveAllBoldedDates();
        }
    }
}
