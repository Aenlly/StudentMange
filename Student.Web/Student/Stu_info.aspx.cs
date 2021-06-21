using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

public partial class Stu_info : System.Web.UI.Page
{
    private Student.Model.Student student = new Student.Model.Student();
    private CollegeBLL collegeBLL = new CollegeBLL();
    private ProfessBLL professBLL = new ProfessBLL();
    private StudentBLL studentBLL = new StudentBLL();
    private ClassproBLL classproBLL = new ClassproBLL();

    protected void Page_Load(object sender, EventArgs e)
    {

        //非登录页
        if (Session["stu_id"] == null)
            Response.Redirect("Login.aspx");//重定向至登录页
        if (!IsPostBack)
        {

            student.Stu_id = Session["stu_id"].ToString();
            studentBLL.GetById(student);
            Edit_id.Text = student.Stu_id;
            Tb_name.Text = student.Stu_name;
            Tb_sex.Text = student.Stu_sex;

            Rfv_pwd.InitialValue = student.Stu_pwd;

            Tb_birth.Text = student.Stu_birth.Substring(0, 10);
            Tb_edu.Text = student.Stu_edu;
            Tb_tel.Text = student.Stu_tel;
            Tb_pwd.Text = student.Stu_pwd;
            Tb_address.Text = student.Stu_address;
            Tb_origin.Text = student.Stu_origin;
            Tb_time.Text = student.Stu_time;
            College college = new College();
            college.Col_id = int.Parse(student.Col_id.ToString());
            collegeBLL.GetById(college);

            Profess profess = new Profess();
            profess.Pro_id = int.Parse(student.Pro_id.ToString());
            collegeBLL.GetById(college);

            Classpro classpro = new Classpro();
            classpro.Cla_id = int.Parse(student.Cla_id.ToString());
            collegeBLL.GetById(college);
            Tb_col.Text = college.Col_names;
            Tb_pro.Text = profess.Pro_name;
            Tb_cla.Text = classpro.Cla_name;
            Img_head.ImageUrl="~"+student.Stu_head;
        }
    }

    protected void Btn_Ok_Click(object sender, EventArgs e)
    {
        string id = Edit_id.Text;
        
        string tel = Tb_tel.Text;
        string pwd = Tb_pwd.Text;
        string address = Tb_address.Text;
        int n = studentBLL.Update(tel, pwd, address, id);
        if(n==1)
            Response.Write("<script>alert('修改成功!');location.href='Stu_info.aspx';</script>");
        else if(n==-1)
            Response.Write("<script>alert('修改失败!');location.href='Stu_info.aspx';</script>");

    }
}