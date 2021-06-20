using System;

public partial class Admin_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //非登录页
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");//重定向至登录页
    }
}