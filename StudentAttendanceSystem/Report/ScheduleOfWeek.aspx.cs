using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentAttendanceSystem.App_Code.DAO;

namespace StudentAttendanceSystem.Report
{
    public partial class ScheduleOfWeek : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountStudent"] != null)
            {
                lbAccount.Text = Session["AccountStudent"].ToString();
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
            
            if(!IsPostBack)
            {
                DateTime firstDate = FirstMonday(2021);
                for (int i =0; i < 52; i++)
                {
                    string week = String.Format("{0} to {1}", firstDate.ToString("dd/MM"), firstDate.AddDays(6).ToString("dd/MM"));
                    ddlWeek.Items.Insert(i, new ListItem(week, week));
                    firstDate = firstDate.AddDays(7);
                }
                int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                ddlWeek.SelectedIndex = weekOfYear - 2;
                
                LoadStudentSchedule();
            }
            
        }

        private void LoadStudentSchedule()
        {
            int week = ddlWeek.SelectedIndex + 2;
            LabelTest.Text = ddlWeek.SelectedValue;
            int studentID = StudentDAO.GetStudentId(Session["AccountStudent"].ToString());
            DataTable dtSchedule = StudentDAO.GetStudentScheduleByWeek(studentID, week);

            DataView dv = dtSchedule.DefaultView;
            
            string[,] arrMultiD = {
                    { "Slot 1", "-", "-", "-", "-", "-", "-", "-" },
                    { "Slot 2", "-" ,"-", "-", "-", "-", "-", "-"},
                    { "Slot 3", "-" ,"-", "-", "-", "-", "-", "-"},
                    { "Slot 4", "-", "-", "-", "-", "-", "-", "-"},
                    { "Slot 5","-" , "-", "-", "-", "-", "-", "-"},
                    { "Slot 6","-" , "-", "-", "-", "-", "-", "-"}
             };
            
            foreach(DataRowView drV in dv)
            {
                int row = Convert.ToInt32(drV["slot"]) - 1;
                int col = Convert.ToInt32( Convert.ToDateTime(drV["teaching_date"]).DayOfWeek);
                if(Convert.ToDateTime(drV["teaching_date"]).DayOfWeek == DayOfWeek.Sunday)
                {
                    col = 7;
                }
                string status = "";
                if(drV["status_description"].ToString() != "Present")
                {
                    status = "red";
                }else
                {
                    status = "green";
                }
                string something = String.Format(@"<p>{0}</p>(<span class='{1}'>{2}</span>)",
                    drV["subject_code"].ToString(),status, drV["status_description"].ToString());
                arrMultiD.SetValue(something, row, col);

            }
            DataTable dt = new DataTable();

            dt.Columns.Add("No", Type.GetType("System.String"));
            dt.Columns.Add("Monday", Type.GetType("System.String"));
            dt.Columns.Add("Tuesday", Type.GetType("System.String"));
            dt.Columns.Add("Wednesday", Type.GetType("System.String"));
            dt.Columns.Add("Thursday", Type.GetType("System.String"));
            dt.Columns.Add("Friday", Type.GetType("System.String"));
            dt.Columns.Add("Saturday", Type.GetType("System.String"));
            dt.Columns.Add("Sunday", Type.GetType("System.String"));
            for (int i = 0; i < 6; i++)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["No"] = arrMultiD[i, 0];
                dt.Rows[dt.Rows.Count - 1]["Monday"] = arrMultiD[i, 1];
                dt.Rows[dt.Rows.Count - 1]["Tuesday"] = arrMultiD[i, 2];
                dt.Rows[dt.Rows.Count - 1]["Wednesday"] = arrMultiD[i, 3];
                dt.Rows[dt.Rows.Count - 1]["Thursday"] = arrMultiD[i, 4];
                dt.Rows[dt.Rows.Count - 1]["Friday"] = arrMultiD[i, 5];
                dt.Rows[dt.Rows.Count - 1]["Saturday"] = arrMultiD[i, 6];
                dt.Rows[dt.Rows.Count - 1]["Sunday"] = arrMultiD[i, 7];
            }
            GridMultiD.DataSource = dt;
            GridMultiD.DataBind();
        }

        protected void gvTimeTable_DataBinding(object sender, EventArgs e)
        {

        }
        public DateTime FirstMonday(int year)
        {
            DateTime firstDay = new DateTime(year, 1, 1);

            return new DateTime(year, 1, (8 - (int)firstDay.DayOfWeek) % 7 + 1);
        }
        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentSchedule();
        }
    }
}