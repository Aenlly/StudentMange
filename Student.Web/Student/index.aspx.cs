﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //非登录页
        if (Session["stu_id"] == null)
            Response.Redirect("Login.aspx");//重定向至登录页
    }
}