using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Sign_Click(object sender, EventArgs e)
    {
        Student.Model.Student student = new Student.Model.Student();
        student.Stu_id = Request.Form["stu_id"];
        student.Stu_pwd = Request.Form["stu_pwd"];
        Student.BLL.StudentBLL bLL = new Student.BLL.StudentBLL();
        if (bLL.Login(student)) { 
            Session["stu_id"] = student.Stu_id;
            Session["stu_name"] = student.Stu_name;
            Response.Redirect("index.aspx");
        }
        else {
            Response.Write("<script language=javascript>alert('登录失败');window.window.location.href='Login.aspx';</script>");
        }
    }
}