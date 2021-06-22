using Student.Model;
using Student.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Adm_Cla : System.Web.UI.Page
{
    private CollegeBLL collegeBLL = new CollegeBLL();
    private ProfessBLL professBLL = new ProfessBLL();
    private TeacherBLL teacherBLL = new TeacherBLL();
    private ClassproBLL classproBLL = new ClassproBLL();
    private StudentBLL studentBLL = new StudentBLL();
    private Profess profess = new Profess();
    private College college = new College();
    private Teacher teacher = new Teacher();
    private Classpro classpro = new Classpro();
    private Student.Model.Student student = new Student.Model.Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");
        //第一次呈现
        if (!IsPostBack)
        {
            //清除之前所存储的session
            Session.Remove("col_name");
            Session.Remove("pro_name");
            Session.Remove("tea_name");
            Session.Remove("cla_name");
            databind(teacher, college, profess,classpro);//表格数据绑定

            //初始化下拉框数据
            CollegeList(Ddl_col);
            CollegeList(Ddl_col_edit);
            CollegeList(Ddl_col_stu);
            ProfessList(Ddl_pro, Ddl_col);
            ProfessList(Ddl_pro_edit, Ddl_col_edit);
            TeacherList(Ddl_tea);
            TeacherList(Ddl_tea_edit);
        }
    }

    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind(Teacher teacher, College college, Profess profess,Classpro classpro)
    {
        if (college.Col_names != null || profess.Pro_name != null|| classpro.Cla_name!=null)
            Gv_list.DataSource = classproBLL.GetDataTableViewWhere(teacher, college, profess, classpro);
        else
            Gv_list.DataSource = classproBLL.GetDataTableView();
        Gv_list.DataBind();
    }

    /// <summary>
    /// 学院下拉框数据绑定
    /// </summary>
    public void CollegeList(DropDownList col)
    {
        if (col.Items.Count == 0)
        {
            List<College> list = collegeBLL.GetList();
            foreach (College college in list)//遍历添加学院进去
                col.Items.Add(new ListItem(college.Col_names, college.Col_id.ToString()));
            col.SelectedIndex = 0;   //默认选择
        }
    }

    /// <summary>
    /// 专业下拉框数据绑定
    /// </summary>
    /// <param name="pro"></param>
    /// <param name="col"></param>
    public void ProfessList(DropDownList pro, DropDownList col)
    {
        pro.Items.Clear();
        if (col.Items.Count != 0)
        {
            List<Profess> list = professBLL.GetListWhere(int.Parse(col.SelectedValue));
            foreach (Profess profess in list)//遍历添加专业进去
                pro.Items.Add(new ListItem(profess.Pro_name, profess.Pro_id.ToString()));
            if(pro.Items.Count!=0)
                pro.SelectedIndex = 0;   //默认选择
        }
    }

    /// <summary>
    /// 班级下拉框数据绑定
    /// </summary>
    /// <param name="cla"></param>
    /// <param name="pro_id"></param>
    public void ClassproList(DropDownList cla,int pro_id)
    {
        cla.Items.Clear();
        List<Classpro> list = classproBLL.GetListWhere(pro_id);
        foreach (Classpro classpro in list)//遍历添加专业进去
            cla.Items.Add(new ListItem(classpro.Cla_name, classpro.Cla_id.ToString()));
        if(cla.Items.Count!=0)
            cla.SelectedIndex = 0;   //默认选择
    }

    /// <summary>
    /// 教师下拉框数据绑定
    /// </summary>
    /// <param name="tea"></param>
    public void TeacherList(DropDownList tea)
    {
        List<Teacher> list = teacherBLL.GetList();
        foreach (Teacher teacher in list)//遍历添加老师进去
            tea.Items.Add(new ListItem(teacher.Tea_name, teacher.Tea_id.ToString()));
        tea.SelectedIndex = 0;   //默认选择

    }

    /// <summary>
    /// 查询input文本框数据session绑定显示
    /// </summary>
    public void CreateSession()
    {
        //创建所有session
        Session["tea_name"] = Tb_tea.Text.ToString();
        Session["col_name"] = Tb_col.Text.ToString();
        Session["pro_name"] = Tb_pro.Text.ToString();
        Session["cla_name"] = Tb_pro.Text.ToString();
    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到实体类中
    /// </summary>
    public void UseSession()
    {
        //所有session都不为空才使用
        if (Session["tea_name"] != null && Session["col_name"] != null && Session["pro_name"] != null && Session["cla_name"] != null)
        {
            teacher.Tea_name = Session["tea_name"].ToString();
            profess.Pro_name = Session["pro_name"].ToString();
            college.Col_names = Session["col_name"].ToString();
            classpro.Cla_name = Session["cla_name"].ToString();
        }
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        teacher.Tea_name = Tb_tea.Text.ToString();//获得查询老师姓名
        college.Col_names = Tb_col.Text.ToString();//获得查询学院名称
        profess.Pro_name = Tb_pro.Text.ToString();//获得查询专业名称
        classpro.Cla_name = Tb_cla.Text.ToString();//获得查询班级名称
        CreateSession();//创建session或者更新
        UseSession();//使用session
        databind(teacher, college, profess,classpro);//数据绑定
    }

    /// <summary>
    /// GridView表格索引变动事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">行单击的控件</param>
    protected void Gv_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            Gv_list.PageIndex = e.NewPageIndex;
            UseSession();
            databind(teacher, college, profess, classpro);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// GridView动态生成控件事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">行单击的控件</param>
    protected void Gv_list_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //判断名称是否是lbtn_page，即跳转页确认按钮
        if (e.CommandName == "lbtn_page")
        {
            try
            {
                //需要进行IsPostBack判断是否第一次，否则获取不到TextBox中的值
                TextBox tb = (TextBox)Gv_list.BottomPagerRow.FindControl("inPageNum");
                if (!tb.Text.Equals(""))
                {
                    int num = 0;
                    bool is_num = int.TryParse(tb.Text, out num);//转换
                    if (is_num)//如果输入的非数字，则什么都不执行
                    {
                        if (num <= 0)
                            num = 1;
                        GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);//创建页索引实例
                        Gv_list_PageIndexChanging(null, ea);//执行索引变动事件
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        if (e.CommandName == "Edit_show")
            Lbtn_edit_Click(e.CommandArgument.ToString());
        if (e.CommandName == "Stu_show")
            Lbtn_stu_Click(e.CommandArgument.ToString());
    }

    /// <summary>
    /// 点击编辑按钮事件
    /// </summary>
    /// <param name="id"></param>
    private void Lbtn_edit_Click(string id)
    {
        classpro.Cla_id = int.Parse(id);
        classproBLL.GetById(classpro);
        Tb_name.Text = classpro.Cla_name;
        Lb_id.Text = classpro.Cla_id.ToString();//班级编号
        if (classpro.Pro_id != -1)
        {
            profess.Pro_id = classpro.Pro_id;
            professBLL.GetById(profess);//利用专业id获得当前选择的专业信息
            Ddl_col_edit.SelectedValue = profess.Col_id.ToString();//选中学院id
            ProfessList(Ddl_pro_edit, Ddl_col_edit);

            Ddl_pro_edit.SelectedValue = classpro.Pro_id.ToString();//专业编号
        }
        if(classpro.Tea_id!=-1)
            Ddl_tea_edit.SelectedValue = classpro.Tea_id.ToString();//选中辅导员
    }

    /// <summary>
    /// 学生转移事件
    /// </summary>
    /// <param name="id"></param>
    private void Lbtn_stu_Click(string id)
    {
        Ddl_cla_this.Items.Clear();//清空下拉框
        classpro.Cla_id = int.Parse(id);//存储班级编号
        classproBLL.GetById(classpro);//利用id获得班级信息
        Ddl_cla_this.Items.Add(new ListItem(classpro.Cla_name, classpro.Cla_id.ToString()));//存储选项
        Ddl_cla_this.SelectedIndex = 0;//设置默认选项

        ClassproList(Ddl_cla_stu, classpro.Pro_id);
        int n = Ddl_cla_stu.Items.Count;
        Ddl_cla_stu.SelectedValue = classpro.Cla_id.ToString();
        if (classpro.Pro_id != -1)//判断是否为-1，信息不存在
        {
            profess.Pro_id = classpro.Pro_id;//存储专业id
            professBLL.GetById(profess);//利用专业id获得当前选择的专业信息
            Ddl_col_stu.SelectedValue = profess.Col_id.ToString();//选中学院id
            ProfessList(Ddl_pro_stu, Ddl_col_stu);

            Ddl_pro_stu.SelectedValue = classpro.Pro_id.ToString();//选择专业编号

        }
    }

    /// <summary>
    /// 创建班级事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_new_Click(object sender, EventArgs e)
    {
        classpro.Cla_name = Request.Form["cla_name"];
        if (Ddl_pro.Items.Count != 0) {
            classpro.Pro_id = int.Parse(Ddl_pro.SelectedValue);
            classpro.Tea_id = int.Parse(Ddl_tea.SelectedValue);


            if (classproBLL.Add(classpro))
                Response.Write("<script>alert('添加成功!');location.href='Adm_Cla.aspx';</script>");
            else
                Response.Write("<script>alert('添加失败!');location.href='Adm_Cla.aspx';</script>");
        }
        else
        {
            Response.Write("<script>alert('添加失败，请选择专业!');location.href='Adm_Cla.aspx';</script>");
        }
        
    }


    /// <summary>
    /// 修改确认事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_edit_Click(object sender, EventArgs e)
    {
        classpro.Cla_id = int.Parse(Lb_id.Text);
        classpro.Cla_name = Tb_name.Text;
        classpro.Pro_id = int.Parse(Ddl_pro_edit.SelectedValue);
        classpro.Tea_id = int.Parse(Ddl_tea_edit.SelectedValue);
        if (classproBLL.Update(classpro))
        {
            teacher = new Teacher();
            college = new College();
            profess = new Profess();
            classpro = new Classpro();
            UseSession();
            databind(teacher, college, profess, classpro);
            //不能两种同时使用
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('修改成功！');", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('修改失败！');", true);

    }


    /// <summary>
    /// 删除按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Gv_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //判断班级是否存在学生
        if (studentBLL.IsClaCount(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('该班存在学生，无法删除！');", true);
        else {
            //利用id删除班级，并且获得返回值
            if (classproBLL.DelById(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            {
                UseSession();//使用条件查询的session
                databind(teacher, college, profess, classpro);//刷新
                                                              //不能两种同时使用
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功！');", true);
                //因为局部刷新原因，不能使用下列代码进行弹窗
                //Response.Write("<script language=javascript>alert('删除成功！');</script>");
            }
            else  //失败
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败！');", true);
        }
    }

    /// <summary>
    /// 编辑时选项变动
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ddl_col_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProfessList(Ddl_pro_edit, Ddl_col_edit);
    }


    /// <summary>
    /// 新建学院选择索引变更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ddl_col_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProfessList(Ddl_pro, Ddl_col);
    }

    /// <summary>
    /// 转移专业索引变更
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Ddl_pro_stu_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClassproList(Ddl_cla_stu,int.Parse(Ddl_pro_stu.SelectedValue));
    }

    protected void Ddl_col_stu_SelectedIndexChanged(object sender, EventArgs e)
    {
        ProfessList(Ddl_pro_stu, Ddl_col_stu);
        ClassproList(Ddl_cla_stu,int.Parse(Ddl_col_stu.SelectedValue));
    }

    /// <summary>
    /// 转移学生确认事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_stu_Click1(object sender, EventArgs e)
    {
        if (Ddl_col_stu.Items.Count == 0)
            Response.Write("< script > alert('转移失败，请选择学院!'); location.href = 'Adm_Cla.aspx';</ script > ");
        else if (Ddl_pro_stu.Items.Count == 0)
            Response.Write("<script>alert('转移失败，请选择专业!');location.href='Adm_Cla.aspx';</script>");
        else if (Ddl_cla_stu.Items.Count == 0)
            Response.Write("<script>alert('转移失败，请选择班级!');location.href='Adm_Cla.aspx';</script>");
        else
        {
            string cla_id = Ddl_cla_this.SelectedValue;
            student.Col_id = int.Parse(Ddl_col_stu.SelectedValue);
            student.Pro_id = int.Parse(Ddl_pro_stu.SelectedValue);
            student.Cla_id = int.Parse(Ddl_cla_stu.SelectedValue);

            if(studentBLL.UpdateByClaId(student,cla_id))
                Response.Write("<script>alert('转移成功!');location.href='Adm_Cla.aspx';</script>");
            else
                Response.Write("<script>alert('转移失败!');location.href='Adm_Cla.aspx';</script>");
        }
    }
}