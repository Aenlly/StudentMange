<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stu_info.aspx.cs" MasterPageFile="~/MasterPageStudent.master" Inherits="Stu_info" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ListInfo">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">修改学籍信息</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                    <div class="form-horizontal col-sm-10" role="form">
                        <asp:TextBox ID="Edit_id" runat="server" Visible="False"></asp:TextBox>
                            <div class="form-group col-sm-12">
                                <label for="edit_head" class="col-sm-4 control-label">
                                    学籍照片
                                </label>
                                <div class="col-sm-8">
                                    <asp:Image ID="Img_head" CssClass="form-control" ImageUrl="~/Student_image/rightbg.jpg" runat="server" Height="100px" Width="100px" />
                                </div>
                        </div>
                 
                            <div class="form-group col-sm-12">
                                <label for="edit_name" class="col-sm-4 control-label">
                                    学生姓名
                                </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_name" runat="server" CssClass="form-control" CausesValidation="True" MaxLength="10" Enabled="False"></asp:TextBox>
                                </div>
                        
                        </div>
    
                            <div class="form-group col-sm-12">
                                <label for="edit_sex" class="col-sm-4 control-label">学生性别</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_sex" runat="server" CssClass="form-control" CausesValidation="True" MaxLength="10" Enabled="False"></asp:TextBox>
                                    </div>
               
                        </div>
 
                            <div class="form-group col-sm-12">
                                <label for="edit_birth" class="col-sm-4 control-label">出生日期</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_birth" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
              
                        </div>
 
                            <div class="form-group col-sm-12">
                                <label for="edit_edu" class="col-sm-4 control-label">学生学历</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_edu" runat="server" CssClass="form-control" CausesValidation="True" MaxLength="10" Enabled="False"></asp:TextBox>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_tel" class="col-sm-4 control-label">联系方式</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_tel" runat="server" EnableViewState="True" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错误！" ControlToValidate="Tb_tel" ValidationExpression="^1[3|4|5|7|8][0-9]{9}$" ForeColor="Red"></asp:RegularExpressionValidator>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_pwd" class="col-sm-4 control-label">登录密码</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_pwd" runat="server" MaxLength="16" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Rfv_pwd" runat="server" ErrorMessage="密码不能与初值相同！" ControlToValidate="Tb_pwd" ForeColor="Red"></asp:RequiredFieldValidator>
                                     
                                </div>
                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_address" class="col-sm-4 control-label">家庭地址</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_address" runat="server" CssClass="form-control" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="地址不能为空！" ControlToValidate="Tb_address" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                 
                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_origin" class="col-sm-4 control-label">生源地</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_origin" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_time" class="col-sm-4 control-label">入学年份</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_time" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
      

                            <div class="form-group col-sm-12">
                                <label for="new_col_id" class="col-sm-4 control-label">所属学院</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_col" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
              
                            <div class="form-group col-sm-12">
                                <label for="new_pro_id" class="col-sm-4 control-label">所属专业</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_pro" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                                   <div class="form-group col-sm-12">
                                <label for="new_cla_id" class="col-sm-4 control-label">所属班级</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Tb_cla" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                </div>
                            </div>
                        <br />
                        <br />
                        <div class="form-group col-sm-12">
                            <div class="col-sm-6"></div>

                            <asp:Button ID="Btn_Ok" runat="server" Width="200px" CssClass="btn btn-primary btn-lg" OnClick="Btn_Ok_Click" Text="确认"></asp:Button>
                        </div>
                    </div>
                        </div>
                </div>
            </div>
        </div>
</asp:Content>

