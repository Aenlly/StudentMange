using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Student.BLL;
using Student.Model;

public partial class Adm_Col : System.Web.UI.Page
{
    private CollegeBLL collegeBLL = new CollegeBLL();
    private College college = new College();
    private StudentBLL studentBLL = new StudentBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adm_id"] == null)
            Response.Redirect("Login.aspx");
        //第一次呈现
        if (!IsPostBack)
        {
            //清除之前所存储的session
            Session.Remove("col_name");
            databind(college);//表格数据绑定
        }
        if (Request.QueryString.Count > 0)
            if (Request.QueryString["op"].Equals("edit"))
                GetEditById(Request.QueryString["id"]);
    }


    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind(College college)
    {
        if (Session["col_name"] != null)
            Gv_list.DataSource = collegeBLL.GetDataTableWhere(college);
        else
            Gv_list.DataSource = collegeBLL.GetDataTable();
        Gv_list.DataBind();
    }

    /// <summary>
    /// 查询input文本框数据session绑定显示
    /// </summary>
    public void CreateSession()
    {
        Session["col_name"] = Tb_name.Text.ToString();
    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到实体类中
    /// </summary>
    public void UseSession()
    {
        if (Session["col_name"] != null)
            college.Col_names = Session["col_name"].ToString();
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        college.Col_names = Tb_name.Text.ToString();
        CreateSession();
        databind(college);
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
            databind(college);
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
    }

    /// <summary>
    /// 编辑按钮事件
    /// </summary>
    /// <param name="id">学院编号</param>
    public void GetEditById(string id)
    {
        //以下代码进行序列化json格式转变
        List<College> list = new List<College>();
        college.Col_id = int.Parse(id);
        list.Add(collegeBLL.GetById(college));
        string str = JsonUtils.GetJson(list);
        //以下代码是传输序列化json数据避免包含html代码内容，但是使用下列内容，就无法刷新控件的值
        Response.Clear();
        Response.Write(str);
        Response.End();
    }


    /// <summary>
    /// 添加数据事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_new_Click(object sender, EventArgs e)
    {
        college.Col_names = Tb_col.Text;

        if (collegeBLL.Add(college))
            Response.Write("<script>alert('添加成功!');location.href='Adm_Col.aspx';</script>");
        else
            Response.Write("<script>alert('添加失败!');location.href='Adm_Col.aspx';</script>");
    }


    /// <summary>
    /// 修改确认按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_edit_Click(object sender, EventArgs e)
    {
        college.Col_names = Request.Form["edit_name"];
        college.Col_id = int.Parse(Request.Form["edit_id"]);

        if (collegeBLL.Update(college))
            Response.Write("<script>alert('添加成功!');location.href='Adm_Col.aspx';</script>");
        else
            Response.Write("<script>alert('添加成功!');location.href='Adm_Col.aspx';</script>");
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Gv_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //判断该学院是否存在学生
        if (studentBLL.IsColCount(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败，该学院存在学生！');", true);
        else
        {
            //执行删除，并进行判断
            if (collegeBLL.DelById(Gv_list.Rows[e.RowIndex].Cells[0].Text))
            {
                UseSession();//使用条件查询的session
                databind(college);//刷新
                                  //不能两种同时使用
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除成功！');", true);
                //因为局部刷新原因，不能使用下列代码进行弹窗
                //Response.Write("<script language=javascript>alert('删除成功！');</script>");
            }
            else  //失败
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, typeof(UpdatePanel), "提示", "alert('删除失败！');", true);
        }
    }
}