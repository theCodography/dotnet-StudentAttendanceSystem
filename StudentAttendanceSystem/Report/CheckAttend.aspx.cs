using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentAttendanceSystem.App_Code.DAO;
namespace StudentAttendanceSystem.Report
{
    public partial class CheckAttend : System.Web.UI.Page
    {
        public Boolean isEdited;
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
            btnSubmitAttend.Visible = false;
            ddlDate.Visible = false;
            LoadSchedule();
        }

        private void LoadSchedule()
        {
            int teacherID = TeacherDAO.GetTeacherId(Session["AccountTeacher"].ToString());
            DataTable dtSchedule = TeacherDAO.GetTeacherSchedule(teacherID);
            DataView dv = dtSchedule.DefaultView;
            DataView dv1 = dtSchedule.DefaultView;
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
            if (Request.QueryString["classID"] != null)
            {
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
                dv.RowFilter = String.Format("subject_id = '{0}' and class_id = '{1}'", subCode, classCode);
                ddlDate.Visible = true;
                if (!IsPostBack)
                {
                    
                    DataTable dt = dv.ToTable(true, "teaching_date", "slot");
                    dt.Columns.Add("something", typeof(string), "teaching_date + '_' + slot");
                    ddlDate.DataSource = dt;
                    ddlDate.DataTextField = "something";
                    ddlDate.DataValueField = "something";
                    ddlDate.DataBind();
                    ddlDate.Items.Insert(0, new ListItem("Choose Date", "0"));
                    ddlDate.SelectedIndex = 0;
                }
                if (ddlDate.SelectedIndex != 0)
                {
                    string today = DateTime.Now.ToString("MM/dd/yyyy");
                    string date = ddlDate.SelectedValue.Split('_')[0].Split(' ')[0];
                    int comp = DateTime.Compare(Convert.ToDateTime(date), Convert.ToDateTime(today));
                    if (comp < 0 || comp > 0)
                    {
                        isEdited = false;
                    }
                    else if (comp == 0)
                    {
                        isEdited = true;
                    }
                    int slot = Convert.ToInt32(ddlDate.SelectedValue.Split('_')[1]);
                    dv1.RowFilter = String.Format("subject_id = '{0}' and class_id = '{1}' and slot = {2} and teaching_date ='{3}'", subCode, classCode, slot, date);
                    gvStudent.DataSource = dv1.ToTable();
                    gvStudent.DataBind();
                }else
                {
                    gvStudent.DataSource = null;
                    gvStudent.DataBind();
                    btnSubmitAttend.Visible = false;
                }

            }


        }

        protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSchedule();
        }

        protected void gvStudent_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lbRadio");
                RadioButton rdbAbsent = (RadioButton)e.Row.FindControl("rdAbsent");
                RadioButton rdbAttend = (RadioButton)e.Row.FindControl("rdAttend");
                
                if (isEdited)
                {
                    string status = ((DataTable)gvStudent.DataSource).Rows[e.Row.RowIndex]["status_description"].ToString();
                    if("Present".Equals(status))
                    {
                        rdbAttend.Checked = true;
                    }else
                    {
                        rdbAbsent.Checked = true;
                    }
                    lbl.Visible = false;
                    btnSubmitAttend.Visible = true;
                }
                else
                {
                    rdbAbsent.Visible = false;
                    rdbAttend.Visible = false;
                }
            }

        }

        protected void btnSubmitAttend_Click(object sender, EventArgs e)
        {
            string date = ddlDate.SelectedValue.Split('_')[0].Split(' ')[0];
            int slot = Convert.ToInt32(ddlDate.SelectedValue.Split('_')[1]);
            DataTable dt = (DataTable)gvStudent.DataSource;

            foreach (GridViewRow gvr in gvStudent.Rows)
            {
                RadioButton rdbAbsent = (RadioButton)gvr.FindControl("rdAbsent");
                RadioButton rdbAttend = (RadioButton)gvr.FindControl("rdAttend");
                
                int status = 0;
                if(rdbAbsent.Checked)
                {
                    status = 0;
                }else if (rdbAttend.Checked)
                {
                    status = 1;
                }
                int stuid = Convert.ToInt32(((DataTable)gvStudent.DataSource).Rows[gvr.RowIndex]["student_id"].ToString());

                CheckAttendDAO.UpdateAttend(status,Convert.ToDateTime(date),slot,stuid);
            }
            ddlDate.SelectedIndex = 0;
            LoadSchedule();
        }
    }
}