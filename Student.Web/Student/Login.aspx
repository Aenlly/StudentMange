<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理员登录页</title>
    <link type="text/css" rel="styleSheet"  href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../Style/Login.css"/>
    <script type="text/javascript" src="../Script/jquery-1.10.1.js"></script>
</head>
<body>
<div id="bg">
    <div id="login_wrap">
        <div id="login"><!-- 登录注册切换动画 -->
            <div id="status">
                <i style="top: 0;font-size: 30px; right: 59px;">登</i>
                <i style="top: 35px"></i>
                <i style="right: 5px;font-size: 30px; top: 0px; width: 31px;">录</i>
            </div>
            <span>
                    <form id="Login_From" runat="server">
                        <p class="form"><input type="text" id="user" placeholder="学号" name="stu_id"></p>
                        <p class="form"><input type="password" id="passwd" placeholder="密码" name="stu_pwd"/></p>
                        <asp:Button ID="btn_Sign" runat="server" Text="登录" CssClass="btn" Style="margin-right: 20px;" OnClick="btn_Sign_Click" />
                        <input type="button" value="忘记密码" class="btn" onclick="javascrtpt:window.location.href='RetPwd.aspx'" id="btn" />
                    </form>
                </span>
        </div>

        <div id="login_img"><!-- 图片绘制框 -->
            <span class="circle">
                    <span></span>
                    <span></span>
                </span>
            <span class="star">
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                    <span></span>
                </span>
            <span class="fly_star">
                    <span></span>
                    <span></span>
                </span>
            <p id="title">Hello</p>
        </div>
    </div>
</div>
</body>
</html>
