using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

public partial class Adm_Pro : System.Web.UI.Page
{
    private CollegeBLL collegeBLL = new CollegeBLL();
    private ProfessBLL professBLL = new ProfessBLL();
    private StudentBLL studentBLL = new StudentBLL();
    private Profess profess = new Profess();
    private College college = new College();

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
            databind(college,profess);//表格数据绑定
            CollegeList(Ddl_col);
            CollegeList(Ddl_col_edit);
        }
    }

    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind(College college, Profess profess)
    {
        if (college.Col_names != null || profess.Pro_name != null)
            Gv_list.DataSource = professBLL.GetDataTableViewWhere(college,profess);
        else
            Gv_list.DataSource = professBLL.GetDataTableView();
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
        Session["col_name"] = Tb_col.Text.ToString();
        Session["pro_name"] = Tb_pro.Text.ToString();
    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到Student实体类中
    /// </summary>
    public void UseSession()
    {
        if (Session["col_name"] != null && Session["pro_name"] != null)
        {
            profess.Pro_name = Session["pro_name"].ToString();
            college.Col_names = Session["col_name"].ToString();
        }
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        college.Col_names = Tb_col.Text.ToString();
        profess.Pro_name = Tb_pro.Text.ToString();
        CreateSession();
        databind(college,profess);
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
            databind(college, profess);
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

    private void Lbtn_edit_Click(string id)
    {
        profess.Pro_id = int.Parse(id);
        professBLL.GetById(profess);
        Tb_name.Text = profess.Pro_name;
        Lb_id.Text = profess.Pro_id.ToString();
        Ddl_col_edit.SelectedValue = profess.Col_id.ToString();
    }

    /// <summary>
    /// 新建学生学籍事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_new_Click(object sender, EventArgs e)
    {
        profess.Pro_name = Request.Form["pro_name"];
        profess.Col_id = int.Parse(Ddl_col.SelectedValue);

        if (professBLL.Add(profess))
            Response.Write("<script>alert('添加成功!');location.href='Adm_Pro.aspx';</script>");
        else
            Response.Write("<script>alert('添加失败!');</script>");
    }


    /// <summary>
    /// 修改确认按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_edit_Click(object sender, EventArgs e)
    {
        profess.Pro_id = int.Parse(Lb_id.Text);
        profess.Pro_name = Tb_name.Text;
        profess.Col_id = int.Parse(Ddl_col_edit.SelectedValue);
        if (professBLL.Update(profess))
        {
            profess = new Profess();
            UseSession();
            databind(college, profess);
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
        //判断专业是否存在学生
        if (studentBLL.IsProCount(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败，该专业存在学生！');", true);
        else
        {
            //执行删除，并进行判断
            if (professBLL.DelById(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            {
                UseSession();//使用条件查询的session
                databind(college, profess);//刷新
                                           //不能两种同时使用
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功！');", true);
                //因为局部刷新原因，不能使用下列代码进行弹窗
                //Response.Write("<script language=javascript>alert('删除成功！');</script>");
            }
            else  //失败
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败！');", true);
        }
    }
}