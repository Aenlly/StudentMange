using System;
using Student.BLL;
using Student.Model;
using System.Web.UI;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void btn_Sign_Click(object sender, EventArgs e)
    {
        Admin admin = new Admin();
        admin.Adm_tel = Request.Form["adm_tel"];
        admin.Adm_pwd = Request.Form["adm_pwd"];
        AdminBLL bLL = new AdminBLL();
        if (bLL.Login(admin)) {
            bLL.GetAdminOne(admin);
            Session["adm_id"] = admin.Adm_id;
            Session["adm_name"] = admin.Adm_name;
            Response.Redirect("index.aspx");
        }
        else {
            Response.Write("<script language=javascript>alert('登录失败');window.window.location.href='Login.aspx';</script>");
        }
    }
}