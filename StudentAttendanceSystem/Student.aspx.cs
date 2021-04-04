using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentAttendanceSystem
{
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountStudent"] != null)
            {
                lbAccount.Text = Session["AccountStudent"].ToString();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }


    }
}