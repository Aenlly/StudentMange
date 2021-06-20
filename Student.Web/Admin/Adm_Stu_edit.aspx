<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adm_Stu_edit.aspx.cs" MasterPageFile="~/MasterPageAdmin.master" Inherits="Admin_Upload_Stu_head" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ListInfo">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- 客户列表查询部分  start-->
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
                    <div class="col-sm-2"></div>
                    <div class="form-horizontal col-sm-10" role="form">
                        <asp:TextBox ID="Edit_id" runat="server" Visible="False"></asp:TextBox>
                            <div class="form-group col-sm-12">
                                <label for="edit_head" class="col-sm-4 control-label">
                                    学籍照片
                                </label>
                                <div class="col-sm-8">
                                    <asp:Image ID="Img_head" CssClass="form-control" ImageUrl="~/Student_image/rightbg.jpg" runat="server" Height="50px" Width="50px" />
                                    <asp:FileUpload ID="Fup_head" runat="server" />
                                    <asp:Label ID="Lb_head" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                        </div>
                 
                            <div class="form-group col-sm-12">
                                <label for="edit_name" class="col-sm-4 control-label">
                                    学生姓名
                                </label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_name" runat="server" CssClass="form-control" CausesValidation="True" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空！" ControlToValidate="Edit_name"></asp:RequiredFieldValidator>
                                </div>
                        
                        </div>
    
                            <div class="form-group col-sm-12">
                                <label for="edit_sex" class="col-sm-4 control-label">学生性别</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Ddl_sex" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="男">男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
               
                        </div>
 
                            <div class="form-group col-sm-12">
                                <label for="edit_birth" class="col-sm-4 control-label">出生日期</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_birth" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" Type="Date" MinimumValue="1990-01-01" MaximumValue="9999-12-31" ErrorMessage="格式错误！" ControlToValidate="Edit_birth" Display="Dynamic"></asp:RangeValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="不能为空！" ControlToValidate="Edit_birth" EnableViewState="True" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
              
                        </div>
 
                            <div class="form-group col-sm-12">
                                <label for="edit_edu" class="col-sm-4 control-label">学生学历</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Ddl_edu" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="本科">本科</asp:ListItem>
                                        <asp:ListItem>专科</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_tel" class="col-sm-4 control-label">联系方式</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_tel" runat="server" EnableViewState="True" CssClass="form-control" MaxLength="11"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错误！" ControlToValidate="Edit_tel" ValidationExpression="^1[3|4|5|7|8][0-9]{9}$"></asp:RegularExpressionValidator>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_pwd" class="col-sm-4 control-label">登录密码</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_pwd" runat="server" MaxLength="16" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                         
                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_address" class="col-sm-4 control-label">家庭地址</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_address" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                 
                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_origin" class="col-sm-4 control-label">生源地</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_origin" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="不能为空！" EnableClientScript="True" ControlToValidate="Edit_origin"></asp:RequiredFieldValidator>
                                </div>

                        </div>

                            <div class="form-group col-sm-12">
                                <label for="edit_time" class="col-sm-4 control-label">入学年份</label>
                                <div class="col-sm-8">
                                    <asp:TextBox ID="Edit_time" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator" ControlToValidate="Edit_time" Type="Integer" MaximumValue="9999" MinimumValue="1990"></asp:RangeValidator>
                                </div>
                            </div>
      

                            <div class="form-group col-sm-12">
                                <label for="new_col_id" class="col-sm-4 control-label">所属学院</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Ddl_col_edit" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_col_edit_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
              
                            <div class="form-group col-sm-12">
                                <label for="new_pro_id" class="col-sm-4 control-label">所属专业</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Ddl_pro_edit" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_pro_edit_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                                   <div class="form-group col-sm-12">
                                <label for="new_cla_id" class="col-sm-4 control-label">所属班级</label>
                                <div class="col-sm-8">
                                    <asp:DropDownList ID="Ddl_cla_edit" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        <br />
                        <br />
                        <div class="form-group col-sm-12">
                            <div class="col-sm-5"></div>
                            <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                            <asp:Button ID="Lbtn_edit_ok" runat="server" CssClass="btn btn-primary" OnClick="Btn_edit_Click" Text="确认"></asp:Button>
                        </div>
                    </div>
                        </div>
                </div>
            </div>
        </div>
</asp:Content>

