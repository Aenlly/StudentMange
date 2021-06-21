using Student.Model;
using Student.BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Stu_Cla : System.Web.UI.Page
{
    private StudentBLL studentBLL = new StudentBLL();
    private Student.Model.Student student = new Student.Model.Student();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["stu_id"] == null)
            Response.Redirect("Login.aspx");
        //第一次呈现
        if (!IsPostBack)
        {
            //清除之前所存储的session
            Session.Remove("s_name");
            student.Stu_id = Session["stu_id"].ToString();
            studentBLL.GetById(student);
            Lb_cla.Text = student.Cla_id.ToString();
            CreateSession();
            databind(student.Cla_id.ToString(), null);//表格数据绑定

        }
    }

    /// <summary>
    /// GridView列表数据绑定
    /// </summary>
    public void databind(string cla_id, string s_name)
    {
        if (!cla_id.Equals("-1") && s_name != null)
            Gv_list.DataSource = studentBLL.GetStudentByProIdView(cla_id, s_name);
        else if (cla_id.Equals("-1"))
            Gv_list.DataSource = studentBLL.GetStudentByStuIdView(Session["stu_id"].ToString());
        else
            Gv_list.DataSource = studentBLL.GetStudentByProIdView(cla_id, null);
        Gv_list.DataBind();
    }

    /// <summary>
    /// 查询input文本框数据session绑定显示
    /// </summary>
    public void CreateSession()
    {
        Session["s_name"] = Tb_name.Text;
        Session["col_id"] = Lb_cla.Text;

    }

    /// <summary>
    /// 查询的Session如果存在，则使用Session，并且进行赋值到实体类中
    /// </summary>
    public void UseSession()
    {
        if (Session["s_name"] != null)
            student.Stu_name = Session["s_name"].ToString();
    }

    /// <summary>
    /// 查询按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Lbtn_select_Click(object sender, EventArgs e)
    {
        student.Stu_name = Tb_name.Text.ToString();
        CreateSession();
        UseSession();
        databind(Session["col_id"].ToString(), Session["s_name"].ToString());
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
            databind(Session["col_id"].ToString(), Session["s_name"].ToString());
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
}