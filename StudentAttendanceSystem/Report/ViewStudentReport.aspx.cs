using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentAttendanceSystem.App_Code.DAO;

namespace StudentAttendanceSystem.Report
{
    public partial class ViewStudentReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountTeacher"] != null)
            {
                lbAccount.Text = Session["AccountTeacher"].ToString();
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
            LoadReport();
        }
        private void LoadReport()
        {
            int teacherID = TeacherDAO.GetTeacherId(Session["AccountTeacher"].ToString());
            DataTable dtSchedule = TeacherDAO.GetTeacherSchedule(teacherID);
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
            gvClass.DataSource = dv.ToTable(true, "class_id", "class_code", "subject_id");
            gvClass.DataBind();
            gvClass.SelectedIndex = 0;

            string classCode = Request.QueryString["classID"];
            foreach (GridViewRow row in gvClass.Rows)
            {
                //Access the hyperlink here and get its text
                HyperLink hplink1 = ((HyperLink)row.Cells[0].Controls[0]);
                if (hplink1.NavigateUrl.Substring(hplink1.NavigateUrl.LastIndexOf("=") + 1) == classCode)
                {
                    hplink1.CssClass = "active";
                }
            }
        }
    }
}