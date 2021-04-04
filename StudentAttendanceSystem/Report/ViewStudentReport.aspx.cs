using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}