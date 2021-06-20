using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Adm_StudentInfo : System.Web.UI.Page
{
    private Student.BLL.CollegeBLL collegeBLL = new Student.BLL.CollegeBLL();
    private Student.BLL.ProfessBLL professBLL = new Student.BLL.ProfessBLL();
    private Student.BLL.StudentBLL studentBLL = new Student.BLL.StudentBLL();
    private Student.BLL.ClassproBLL classproBLL = new Student.BLL.ClassproBLL();
    private Student.Model.Student student = new Student.Model.Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");
        //第一次呈现
        if (!IsPostBack)
        {
            //清除之前所存储的session
            Session.Remove("s_id");
            Session.Remove("s_name");
            Session.Remove("s_tel");
            Session.Remove("c_id");
            Session.Remove("p_id");
            databind(student);//表格数据绑定
            CollegeList(DdCol_select,true);//学院下拉框数据绑定
            ProfessList(DdPro_select,DdCol_select,true);//专业下拉框数据绑定
            CollegeList(Ddl_col, false);
            ProfessList(Ddl_pro, Ddl_col, false);
            ClassproList(Ddl_cla, Ddl_pro);
          /*  CollegeList(Ddl_col_edit, false);
            ProfessList(Ddl_pro_edit, Ddl_col_edit, false);
            ClassproList(Ddl_cla_edit, Ddl_pro_edit);*/
        }
    }


    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind(Student.Model.Student student)
    {
        if(student.Stu_id!=null||student.Stu_name!=null || student.Stu_tel!=null || student.Col_id != 0 || student.Pro_id != 0)
            Gv_stu.DataSource = studentBLL.GetStudentDataTableViewWhere(student);
        else
            Gv_stu.DataSource = studentBLL.GetStudentDataTableView();
        Gv_stu.DataBind();
    }

    /// <summary>
    /// 学院下拉框数据绑定
    /// </summary>
    public void CollegeList(DropDownList col,bool is_b)
    {
        if (col.Items.Count == 0) {
            if(is_b)
                col.Items.Add(new ListItem("全部", "-1"));
            List<Student.Model.College> list = collegeBLL.GetCollegeList();
            foreach (Student.Model.College college in list)//遍历添加学院进去
                col.Items.Add(new ListItem(college.Col_names, college.Col_id.ToString()));
            if (is_b)
                col.SelectedValue = "-1";   //默认选择"请选择"
            else
                col.SelectedIndex = 0;   //默认选择
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
        if (is_b)
            pro.Items.Add(new ListItem("全部", "-1"));
        if (!col.SelectedValue.Equals("-1"))
            list = professBLL.GetProfessListWhere(int.Parse(col.SelectedValue));
        else
            list = professBLL.GetProfessList();
        foreach (Student.Model.Profess profess in list)//遍历添加学院进去
            pro.Items.Add(new ListItem(profess.Pro_name, profess.Pro_id.ToString()));
        if (is_b)
            pro.SelectedValue = "-1";   //默认选择"请选择"
        else
            if (pro.Items.Count != 0)
                pro.SelectedIndex = 0;   //默认选择
    }

    /// <summary>
    /// 班级下拉框数据绑定
    /// </summary>
    /// <param name="cla">班级下拉框控件</param>
    /// <param name="pro">专业下拉框控件</param>
    public void ClassproList(DropDownList cla, DropDownList pro)
    {
        cla.Items.Clear();//清除
        if (pro.Items.Count!=0)
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
    /// 查询input文本框数据session绑定显示
    /// </summary>
    public void CreateSession()
    {
        Session["s_id"]= Tb_id.Text.ToString();
        Session["s_name"] = Tb_name.Text.ToString();
        Session["s_tel"] = Tb_tel.Text.ToString();
        Session["c_id"] = DdCol_select.SelectedValue;
        Session["p_id"] = DdPro_select.SelectedValue;
    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到Student实体类中
    /// </summary>
    public void UseSession()
    {
        if (Session["s_id"] != null && Session["s_name"] != null && Session["s_tel"] != null && Session["c_id"] != null && Session["p_id"] != null)
        {
            student.Stu_id = Session["s_id"].ToString();
            student.Stu_name = Session["s_name"].ToString();
            student.Stu_tel = Session["s_tel"].ToString();
            student.Col_id = int.Parse(Session["c_id"].ToString());
            student.Pro_id = int.Parse(Session["p_id"].ToString());
        }
    }

    /// <summary>
    /// 学院下拉框索引变动事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DdCol_select_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Remove("p_id");//学院信息变动时，专业信息的session清除
        ProfessList(DdPro_select,DdCol_select,true);//查询专业
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        student.Stu_id = Tb_id.Text.ToString();
        student.Stu_name = Tb_name.Text.ToString();
        student.Stu_tel =Tb_tel.Text.ToString();
        student.Col_id = int.Parse(DdCol_select.SelectedValue);
        student.Pro_id = int.Parse(DdPro_select.SelectedValue);
        CreateSession();
        databind(student);
    }

    /// <summary>
    /// GridView表格索引变动事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">行单击的控件</param>
    protected void Gv_stu_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try {
            Gv_stu.PageIndex = e.NewPageIndex;
            UseSession();
            databind(student);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// GridView动态生成控件事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">行单击的控件</param>
    protected void Gv_stu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //判断名称是否是lbtn_page，即跳转页确认按钮
        if (e.CommandName == "lbtn_page")
        {
            try
            {
                //需要进行IsPostBack判断是否第一次，否则获取不到TextBox中的值
                TextBox tb = (TextBox)Gv_stu.BottomPagerRow.FindControl("inPageNum");
                if (!tb.Text.Equals(""))
                {
                    int num = 0;
                    bool is_num = int.TryParse(tb.Text, out num);//转换
                    if (is_num)//如果输入的非数字，则什么都不执行
                    { 
                        if (num <= 0)
                            num = 1;
                        GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);//创建页索引实例
                        Gv_stu_PageIndexChanging(null, ea);//执行索引变动事件
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        if (e.CommandName == "Edit_show")
            Response.Redirect("Adm_Stu_edit.aspx?id=" + e.CommandArgument.ToString());
             /*Lbtn_edit_Click(e.CommandArgument.ToString());*/
        if (e.CommandName == "Delete")
            Lbtn_delete_Click(e.CommandArgument.ToString());
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="id">学号</param>
    protected void Lbtn_delete_Click(string id)
    {
        //执行删除，并进行判断
        if (studentBLL.DelStudent(id))
        {
            UseSession();//使用条件查询的session
            databind(student);//刷新
            //不能两种同时使用
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功！');", true);
            //因为局部刷新原因，不能使用下列代码进行弹窗
            //Response.Write("<script language=javascript>alert('删除成功！');</script>");
        }
        else  //失败
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败！');", true);
    }

    /*
    /// <summary>
    /// 编辑按钮事件
    /// </summary>
    /// <param name="id">学号</param>
    public void Lbtn_edit_Click(string id)
    {
        /*以下代码进行序列化json格式转变
        List<Student.Model.Student> list = new List<Student.Model.Student>();
        student.Stu_id = Gv_stu.Rows[e.NewEditIndex].Cells[0].Text.ToString();
        list.Add(studentBLL.GetStudentById(student));
        string str = JsonUtils.GetJson(list);*/
    /*以下代码是传输序列化json数据避免包含html代码内容，但是使用下列内容，就无法刷新控件的值
    Response.Clear();
    Response.Write(str);
    Response.End();
}*/

        /// <summary>
        /// 添加学籍的学院下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_col_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfessList(Ddl_pro, Ddl_col, false);
            ClassproList(Ddl_cla, Ddl_pro);
        }

        /// <summary>
        /// 添加学籍的专业下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_pro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassproList(Ddl_cla, Ddl_pro);
        }
    
    
        /// <summary>
        /// 创建学生学籍事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_new_Click(object sender, EventArgs e)
        {

            student.Stu_name=Request.Form["stu_name"];//姓名
            student.Stu_sex = Request.Form["stu_sex"];//性别
            student.Stu_birth = Request.Form["stu_birth"];//出生日期
            student.Stu_edu = Request.Form["stu_edu"];//学历
            student.Stu_tel = Request.Form["stu_tel"];//手机号
            student.Stu_address = Request.Form["stu_address"];//家庭地址
            student.Stu_origin = Request.Form["stu_origin"];//生源地
            student.Stu_time = Request.Form["stu_time"];//入学年份
            if(Ddl_col.Items.Count != 0)
                student.Col_id=int.Parse(Ddl_col.SelectedValue);
            if(Ddl_pro.Items.Count!=0)
                student.Pro_id = int.Parse(Ddl_pro.SelectedValue);
            if(Ddl_cla.Items.Count!=0)
                student.Cla_id = int.Parse(Ddl_cla.SelectedValue);
            if (studentBLL.AddStudent(student))
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(UpdatePanel), "提示", "alert('创建成功！');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, typeof(UpdatePanel), "提示", "alert('创建失败！');", true);
        }
        
    /*
    protected void Ddl_col_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void Ddl_pro_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }*/
    /*
    /// <summary>
    /// 编辑确认事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_edit_Click(object sender, EventArgs e)
    {
        */
    /*
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
    student.Col_id = int.Parse(Ddl_col_edit.SelectedValue);
    student.Pro_id = int.Parse(Ddl_pro_edit.SelectedValue);
    student.Cla_id = int.Parse(Ddl_cla_edit.SelectedValue);

    if(studentBLL.UpdateStudent(student))
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, typeof(UpdatePanel), "提示", "alert('保存成功！');", true);
    else
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, typeof(UpdatePanel), "提示", "alert('保存失败！');", true);

}*/

}