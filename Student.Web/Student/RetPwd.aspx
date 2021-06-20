<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RetPwd.aspx.cs" Inherits="Student_RetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员登录页</title>
    <link type="text/css" rel="styleSheet" href="../css/main.css" />
    <link rel="stylesheet" type="text/css" href="../Style/Login.css" />
    <script type="text/javascript" src="../Script/jquery-1.10.1.js"></script>
</head>
<body>
    <div id="bg">
        <div id="login_wrap">
            <div id="login">
                <!-- 登录注册切换动画 -->
                <div id="status">
                    <i style="top: 0; font-size: 21px;">找回</i>
                    <i style="top: 35px"></i>
                    <i style="right: 5px; font-size: 21px;">密码</i>
                </div>
                <span>
                    <form  id="form" runat="server">
                        <p class="form">
                            <input type="text" maxlength="50" placeholder="学号" required name="stu_id" minlength="1"></p>
                        <p class="form">
                            <input type="text" maxlength="5" placeholder="姓名" required name="stu_name" minlength="1"></p>
                        <p class="form">
                            <input type="tel" maxlength="11" placeholder="手机号" required name="stu_tel" minlength="11"></p>
                        <asp:Button ID="btn_RetPwd" runat="server" Text="确认" CssClass="btn" OnClick="btn_RetPwd_Click"/>
                        <input type="button" value="返回" class="btn"
                            onclick="javascrtpt: window.location.href = 'Login.aspx'" id="btn">
                    </form>
                </span>
            </div>

            <div id="login_img">
                <!-- 图片绘制框 -->
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
                <p id="title">CLOUD</p>
            </div>
        </div>
    </div>
</body>
</html>
