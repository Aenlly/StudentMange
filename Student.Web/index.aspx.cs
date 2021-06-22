using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["stu_id"] != null || Session["adm_id"] != null) { 
            if (Session["stu_id"] != null)
                Response.Redirect("Student/index.aspx");
            else
                Response.Redirect("Admin/index.aspx");
        }
        else
                Response.Redirect("Student/Login.aspx");
    }
}