using System;

public partial class Student_RetPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_RetPwd_Click(object sender, EventArgs e)
    {
        Student.Model.Student student = new Student.Model.Student();
        student.Stu_id = Request.Form["stu_id"];
        student.Stu_name = Request.Form["stu_name"];
        student.Stu_tel = Request.Form["stu_tel"];
        Student.BLL.StudentBLL bLL = new Student.BLL.StudentBLL();
        if(bLL.RetPwd(student))
            Response.Write("<script language=javascript>alert('找回成功，默认密码为：123456');window.window.location.href='Login.aspx';</script>");
        else
            Response.Write("<script language=javascript>alert('找回信息错误！请重新输入');window.window.location.href='RetPwd.aspx';</script>");
    }
}