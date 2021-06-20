using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Upload_Stu_head : System.Web.UI.Page
{
    private Student.Model.Student student = new Student.Model.Student();
    private Student.BLL.CollegeBLL collegeBLL = new Student.BLL.CollegeBLL();
    private Student.BLL.ProfessBLL professBLL = new Student.BLL.ProfessBLL();
    private Student.BLL.StudentBLL studentBLL = new Student.BLL.StudentBLL();
    private Student.BLL.ClassproBLL classproBLL = new Student.BLL.ClassproBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");
        if (!IsPostBack)
        {
            student.Stu_id = Request.QueryString["id"];
            studentBLL.GetStudentById(student);
            Edit_id.Text = student.Stu_id;
            Edit_name.Text = student.Stu_name;
            Ddl_sex.SelectedValue = student.Stu_sex;
            
            Edit_birth.Text = student.Stu_birth.Substring(0, 10);
            Ddl_edu.SelectedValue = student.Stu_edu;
            Edit_tel.Text = student.Stu_tel;
            Edit_pwd.Text = student.Stu_pwd;
            Edit_address.Text = student.Stu_address;
            Edit_origin.Text = student.Stu_origin;
            Edit_time.Text = student.Stu_time;
            CollegeList(Ddl_col_edit);
            Ddl_col_edit.SelectedValue = student.Col_id.ToString();
            Ddl_col_edit_SelectedIndexChanged(null, null);
            Ddl_pro_edit.SelectedValue = student.Pro_id.ToString();
            Ddl_pro_edit_SelectedIndexChanged(null, null);
            Ddl_cla_edit.SelectedValue = student.Cla_id.ToString();
        }
    }

    public bool UpFileload(Student.Model.Student student)
    {
        string dt = DateTime.Now.ToString("yyyyMMddhhmmssffffff");
        string uploadDir = Path.Combine(Request.PhysicalApplicationPath, "Uploads");

        if (Fup_head.PostedFile.ContentLength > 204800)//不能超过200k{
            Lb_head.Text = "文件不能超过200k";
        else
        {
            string filetype = Path.GetExtension(Fup_head.PostedFile.FileName);
            switch (filetype.ToLower())
            {
                case ".bmp":
                case ".png":
                case ".jpg":
                    break;
                default:
                    Lb_head.Text = "文件扩展名必须是bmp、png或jpg!";
                    return false;
            }
            string fileName = Path.GetFileName(Fup_head.PostedFile.FileName);
            string saveFile = Path.Combine(uploadDir, dt.ToString() + filetype);
            try
            {
                Fup_head.SaveAs(saveFile);
                Lb_head.Text = "上传成功！";
                student.Stu_head = "/Uploads/" + dt.ToString() + filetype;
                return true;
            }
            catch
            {
                return false;
            }
        }
        return false;
    }

    /// <summary>
    /// 学院下拉框数据绑定
    /// </summary>
    public void CollegeList(DropDownList col)
    {
        if (col.Items.Count == 0)
        {
            List<Student.Model.College> list = collegeBLL.GetCollegeList();
            foreach (Student.Model.College college in list)//遍历添加学院进去
                col.Items.Add(new ListItem(college.Col_names, college.Col_id.ToString()));
            if(col.Items.Count!=0)
                col.SelectedIndex = 0;   //默认选择
        }
    }


    /// <summary>
    /// 班级下拉框数据绑定
    /// </summary>
    /// <param name="cla">班级下拉框控件</param>
    /// <param name="pro">专业下拉框控件</param>
    public void ClassproList(DropDownList cla, DropDownList pro)
    {
        cla.Items.Clear();//清除
        if (pro.Items.Count != 0)
        {
            List<Student.Model.Classpro> list;
            list = classproBLL.GetClassproListWhere(int.Parse(pro.SelectedValue));
            foreach (Student.Model.Classpro classpro in list)//遍历添加班级进去
                cla.Items.Add(new ListItem(classpro.Cla_name, classpro.Cla_id.ToString()));
            if (cla.Items.Count != 0)
                cla.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// 专业下拉框数据绑定
    /// </summary>
    /// <param name="pro">专业下拉框控件</param>
    /// <param name="col">学院下拉框控件</param>
    /// <param name="is_b">查询true/添加false</param>
    public void ProfessList(DropDownList pro, DropDownList col, bool is_b)
    {
        pro.Items.Clear();//清除

        List<Student.Model.Profess> list;
        list = professBLL.GetProfessListWhere(int.Parse(col.SelectedValue));
        foreach (Student.Model.Profess profess in list)//遍历添加学院进去
            pro.Items.Add(new ListItem(profess.Pro_name, profess.Pro_id.ToString()));
        if (pro.Items.Count != 0)
            pro.SelectedIndex = 0;   //默认选择
    }

    protected void Ddl_col_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProfessList(Ddl_pro_edit, Ddl_col_edit, false);
        ClassproList(Ddl_cla_edit, Ddl_pro_edit);
    }

    protected void Ddl_pro_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClassproList(Ddl_cla_edit, Ddl_pro_edit);
    }

    protected void Btn_edit_Click(object sender, EventArgs e)
    {
        student.Stu_id = Edit_id.Text;
        student.Stu_name = Edit_name.Text;
        student.Stu_sex = Ddl_sex.SelectedValue;
        student.Stu_birth = Edit_birth.Text;
        student.Stu_edu = Ddl_edu.SelectedValue;
        student.Stu_tel = Edit_tel.Text;
        student.Stu_pwd = Edit_pwd.Text;
        student.Stu_address = Edit_address.Text;
        student.Stu_origin = Edit_origin.Text;
        student.Stu_time = Edit_time.Text;
        if (Ddl_col_edit.Items.Count != 0)
            student.Col_id = int.Parse(Ddl_col_edit.SelectedValue);
        else
            student.Col_id = -1;
        if (Ddl_pro_edit.Items.Count != 0)
            student.Pro_id = int.Parse(Ddl_pro_edit.SelectedValue);
        else
            student.Pro_id = -1;
        if (Ddl_cla_edit.Items.Count != 0)
            student.Cla_id = int.Parse(Ddl_cla_edit.SelectedValue);
        else
            student.Cla_id = -1;

        if (Fup_head.HasFile)
        {
            if (!UpFileload(student))
                return;
            else
            {
                if(studentBLL.UpdateStudent(student))
                    Response.Write("<script>alert('修改成功!');location.href='Adm_StudentInfo.aspx';</script>");
                else
                    Response.Write("<script>alert('修改失败!');</script>");
            }
        }
        else
        {
            if (studentBLL.UpdateStudent(student))
                Response.Write("<script>alert('修改成功!');location.href='Adm_StudentInfo.aspx';</script>");
            else
                Response.Write("<script>alert('修改失败!');</script>");
        }
    }
}