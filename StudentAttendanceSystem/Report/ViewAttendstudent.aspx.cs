using System;
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
    public partial class ViewAttendstudent : System.Web.UI.Page
    {
        public int count = 1;
        public int total;
        public int absent = 0;
        public float percent;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["AccountStudent"] != null)
            {
                lbAccount.Text = Session["AccountStudent"].ToString();
            }
            else
            {
                Response.Redirect("../Default.aspx");
                return;
            }

            LoadStudentSchedule();
        }
        private void LoadStudentSchedule()
        {

            int studentID = StudentDAO.GetStudentId(Session["AccountStudent"].ToString());
            DataTable dtSchedule = StudentDAO.GetStudentSchedule(studentID);

            DataView dv = dtSchedule.DefaultView;
            gvSubject.DataSource = dv.ToTable(true, "subject_name", "subject_id");
            gvSubject.DataBind();
            gvSubject.SelectedIndex = 0;

            string subCode = "";
            if (Request.QueryString["subID"] == null)
                subCode = gvSubject.SelectedValue.ToString();
            else subCode = Request.QueryString["subID"];
            foreach (GridViewRow row in gvSubject.Rows)
            {
                //Access the hyperlink here and get its text
                HyperLink hplink = ((HyperLink)row.Cells[0].Controls[0]);
                if (hplink.NavigateUrl.Substring(hplink.NavigateUrl.IndexOf("=") + 1) == subCode)
                {
                    hplink.CssClass = "active";
                }
            }
            dv.RowFilter = String.Format("subject_id = '{0}'", subCode);
            foreach (DataRowView drV in dv)
            {
                if("Absent".Equals(drV["status_description"].ToString()) )
                {
                    ++absent;
                }
            }
            total = dv.Count;
            percent = (float)absent / total * 100;
            gvReport.DataSource = dv.ToTable();
            gvReport.DataBind();
        }

        protected void gvReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(e.Row.Cells[5].Text != "Present")
                    e.Row.Cells[5].CssClass = "red";
                else e.Row.Cells[5].CssClass = "green";
                e.Row.Cells[1].Text = Convert.ToDateTime(e.Row.Cells[1].Text).ToString("dddd,MM/dd/yyyy");
            }
        }
    }
}