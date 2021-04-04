using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentAttendanceSystem.App_Code.DAO;
namespace StudentAttendanceSystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["AccountTeacher"] != null)
            {
                Response.Redirect("Teacher.aspx");
            }
            if(Session["AccountStudent"]!=null)
            {
                Response.Redirect("Student.aspx");
            }
            if(!IsPostBack)
            {
                ddlRole.DataTextField = "role_description";
                ddlRole.DataValueField = "role_id";
                ddlRole.DataSource = RoleDAO.GetRole();

                ddlRole.DataBind();
                ddlRole.SelectedIndex = 0;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            int role_id = Convert.ToInt32(ddlRole.SelectedValue);
            DataTable account = AccountDAO.GetAccount(email,password,role_id);
            if(account.Rows.Count > 0)
            {
                if(role_id == 2)
                {
                    Session["AccountTeacher"] = tbEmail.Text;
                    Response.Redirect("Teacher.aspx");
                }else if(role_id == 3)
                {
                    Session["AccountStudent"] = tbEmail.Text;
                    Response.Redirect("Student.aspx");
                }
               
                
            }else
            {
                Label4.Text = "Email or Password incorrect!";
            }
        }
    }
}