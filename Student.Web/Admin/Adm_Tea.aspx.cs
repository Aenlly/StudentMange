using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

public partial class Adm_Tea : System.Web.UI.Page
{
    private CollegeBLL collegeBLL = new CollegeBLL();
    private TeacherBLL teacherBLL = new TeacherBLL();
    private Teacher teacher = new Teacher();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");
        //第一次呈现
        if (!IsPostBack)
        {
            //清除之前所存储的session
            Session.Remove("col_id");
            Session.Remove("tea_name");
            databind(teacher);//表格数据绑定
            CollegeList(Ddl_col_select);
            CollegeList(Ddl_col);
            CollegeList(Ddl_col_edit);
        }
    }

    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind( Teacher teacher)
    {
        if (teacher.Col_id >0 || teacher.Tea_name != null)
            Gv_list.DataSource = teacherBLL.GetDataTableViewWhere(teacher);
        else
            Gv_list.DataSource = teacherBLL.GetDataTableView();
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
    /// 查询input文本框数据session绑定显示
    /// </summary>
    public void CreateSession()
    {
        Session["tea_name"] = Tb_name.Text.ToString();
        Session["col_id"] = Ddl_col_select.SelectedValue;
    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到实体类中
    /// </summary>
    public void UseSession()
    {
        if (Session["tea_name"] != null && Session["col_id"] != null)
        {
            teacher.Tea_name = Session["tea_name"].ToString();
            teacher.Col_id = int.Parse(Session["col_id"].ToString());
        }
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        teacher.Tea_name = Tb_name.Text.ToString();
        teacher.Col_id =int.Parse(Ddl_col_select.SelectedValue);
        CreateSession();
        databind(teacher);
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
            databind(teacher);
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
    }
    
    /// <summary>
    /// 编辑按钮获得数据事件
    /// </summary>
    /// <param name="id"></param>
    private void Lbtn_edit_Click(string id)
    {
        teacher.Tea_id = int.Parse(id);
        teacherBLL.GetById(teacher);
        Tb_edit_name.Text = teacher.Tea_name;
        Tb_edit_tel.Text = teacher.Tea_tel;
        Tb_edit_address.Text= teacher.Tea_address;
        Lb_id.Text = id;
        if(teacher.Col_id!=-1)
            Ddl_col_edit.SelectedValue = teacher.Col_id.ToString();
    }


    /// <summary>
    /// 修改确认按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_edit_Click(object sender, EventArgs e)
    {
        teacher.Tea_id = int.Parse(Lb_id.Text);
        teacher.Tea_name = Tb_edit_name.Text;
        teacher.Tea_tel = Tb_edit_tel.Text;
        teacher.Tea_address =Tb_edit_address.Text;
        teacher.Col_id = int.Parse(Ddl_col_edit.SelectedValue);
        if (teacherBLL.Update(teacher))
        {
            teacher = new Teacher();
            UseSession();
            databind(teacher);
            //ajax中弹窗
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('修改成功！');", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('修改失败！');", true);

    }

    /// <summary>
    /// 删除前事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Gv_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //执行删除，并进行判断
        if (teacherBLL.DelById(Gv_list.Rows[e.RowIndex].Cells[0].Text))
        {
            UseSession();//使用条件查询的session
            databind(teacher);//刷新
                                       //不能两种同时使用
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功！');", true);
            //因为局部刷新原因，不能使用下列代码进行弹窗
            //Response.Write("<script language=javascript>alert('删除成功！');</script>");
        }
        else  //失败
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败！');", true);

    }

    /// <summary>
    /// 新建数据事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_new_Click(object sender, EventArgs e)
    {
        teacher.Tea_name =Tb_new_name.Text;
        teacher.Tea_tel = Tb_new_tel.Text;
        teacher.Tea_address = Tb_new_address.Text;
        teacher.Col_id = int.Parse(Ddl_col.SelectedValue);
        if (teacherBLL.Add(teacher))
            Response.Write("<script>alert('添加成功!');location.href='Adm_Tea.aspx';</script>");
        else
            Response.Write("<script>alert('添加失败!');location.href='Adm_Tea.aspx';</script>");
    }
}