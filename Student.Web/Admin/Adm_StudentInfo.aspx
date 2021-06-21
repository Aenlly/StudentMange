<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adm_StudentInfo.aspx.cs" Inherits="Admin_Adm_StudentInfo" MasterPageFile="~/MasterPageAdmin.master" %>
<%@ Register Assembly="AjaxControlToolkit"Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ListInfo">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Ajax/Admin_Student_info.js" />
        </Scripts>
    </asp:ScriptManager>
    <!-- 列表查询部分  start-->
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">学籍管理</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-inline">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="stu_id">学号</label>
                                <asp:TextBox ID="Tb_id" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_name">姓名</label>
                                <asp:TextBox ID="Tb_name" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_tel">手机号</label>
                                <asp:TextBox ID="Tb_tel" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="col_id">学院</label>
                                <asp:DropDownList ID="DdCol_select" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdCol_select_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="pro_id">专业</label>
                                <asp:DropDownList ID="DdPro_select" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                            <asp:LinkButton CausesValidation="false" ID="Lbtn_select" runat="server" CssClass="btn btn-primary" OnClick="Lbtn_select_Click">查询</asp:LinkButton>
                            <a href="#" class="btn btn-success " data-toggle="modal"
                                data-target="#newDialog" style="margin-left: 50px;" onclick="clear()">新建</a>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">

                        <div class="panel panel-default">
                            <div class="panel-heading">客户信息列表</div>
                            <!-- /.panel-heading -->

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Gv_stu" runat="server" CssClass="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" OnPageIndexChanging="Gv_stu_PageIndexChanging" OnRowCommand="Gv_stu_RowCommand" OnRowDeleting="Gv_stu_RowDeleting">

                                        <Columns>

                                            <asp:BoundField DataField="stu_id" HeaderText="学号"></asp:BoundField>
                                            <asp:BoundField DataField="stu_name" HeaderText="姓名"></asp:BoundField>
                                            <asp:BoundField DataField="stu_sex" HeaderText="性别"></asp:BoundField>
                                            <asp:BoundField DataField="stu_edu" HeaderText="学历"></asp:BoundField>
                                            <asp:BoundField DataField="stu_tel" HeaderText="手机号"></asp:BoundField>
                                            <asp:BoundField DataField="stu_origin" HeaderText="生源地"></asp:BoundField>
                                            <asp:BoundField DataField="col_names" HeaderText="学院"></asp:BoundField>
                                            <asp:BoundField DataField="pro_name" HeaderText="专业"></asp:BoundField>
                                            <asp:BoundField DataField="cla_name" HeaderText="班级"></asp:BoundField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="编辑" CommandName="Edit_show" CausesValidation="false" ID="Lbtn_Edit_show" CommandArgument='<%# Eval("stu_id") %>'></asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton runat="server" Text="删除" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('确认要删除吗？')" CommandName="Delete" CausesValidation="False" CommandArgument='<%# Eval("stu_id") %>' ID="Lbtn_delete"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <PagerTemplate>
                                            <span style="float: right;">
                                                <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
                                                <asp:LinkButton CausesValidation="false" ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                                <asp:LinkButton CausesValidation="false" ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                                <asp:LinkButton CausesValidation="false" ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                                <asp:LinkButton CausesValidation="false" ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                                到第<asp:TextBox runat="server" ID="inPageNum"></asp:TextBox>页
                                            <asp:LinkButton CausesValidation="false" ID="lbtn_page" runat="server" CommandName="lbtn_page" CssClass="btn btn-default btn-sm" Text="确定" />
                                            </span>
                                        </PagerTemplate>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:GridView>

                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <!--
                        使用Repeater，可以没有GridView控件外面的自动生成的div，避免样式变动
                    < asp:Repeater ID="Rt_stu">
                        HeaderTemplate中的内容只出现一次
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped">
                                <thead>
                                    <tr>
                                        <th>学历</th>
                                        <th>姓名</th>
                                        <th>性别</th>
                                        <th>学历</th>
                                        <th>手机号</th>
                                        <th>生源地</th>
                                        <th>学院</th>
                                        <th>专业</th>
                                        <th>班级</th>
                                        <th>操作</th>
                                    </tr>
                                </thead>
                                <tbody style="text-align:center; font-size:16px;">
                        </HeaderTemplate>
                        <!--ItemTemplate中的内容可以出现无数次，进行迭代输出，DataBinder.Eval(Container.DataItem, "stu_id") 中，后面是数据库中的列名-->
                            <!--
                        <ItemTemplate>
                            <tr>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_id") %></span> </td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_name") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_sex") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_edu") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_tel") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "stu_origin") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "col_name") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "pro_name") %></span></td>
                                <td class="td"><span class="span">< %# DataBinder.Eval(Container.DataItem, "cla_name") %></span></td>
                                <td>
                                    <span class="span">
                                    <asp:LinkButton ID="Lbtn_edit" CssClass="btn btn-primary btn-sm" runat="server">编辑</asp:LinkButton>
                                    <asp:LinkButton ID="Lbtn_del" CssClass="btn btn-danger btn-sm" runat="server">删除</asp:LinkButton>
                                    </span>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <!--FooterTemplate中的内容只出现一次中的-->
                            <!--    
                    <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    -->
                            <!-- /.panel-body -->
                        </div>
                        <!-- /.panel -->
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- 客户列表查询部分  end-->
                </div>
            </div>
        </div>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="NewInfo">
    <!-- 创建模态框 -->
    <div class="modal fade" id="newDialog" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel">新建学籍信息</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                                <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="new_name" class="col-sm-4 control-label">
                                            学籍照片
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:FileUpload ID="Fup_head" runat="server" />
                                            <asp:Label ID="Lb_head" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="new_name" class="col-sm-4 control-label">
                                            学生姓名
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <input type="text" required class="form-control" pattern=".{2,10}" maxlength="10" id="new_name" placeholder="学生姓名"
                                                name="stu_name" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_sex" class="col-sm-4 control-label">学生性别</label>
                                        <div class="col-sm-8">
                                            <select class="form-control" id="new_sex" name="stu_sex">
                                                <option value="男" selected>男</option>
                                                <option value="女">女</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_birth" class="col-sm-4 control-label">出生日期</label>
                                        <div class="col-sm-8">
                                            <input type="date" min="1990-01-01" required class="form-control" max="9999-12-31" id="new_birth" placeholder="出生日期"
                                                name="stu_birth" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_edu" class="col-sm-4 control-label">学生学历</label>
                                        <div class="col-sm-8">
                                            <select class="form-control" id="new_edu" name="stu_edu">
                                                <option value="本科" selected>本科</option>
                                                <option value="专科">专科</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_tel" class="col-sm-4 control-label">联系方式</label>
                                        <div class="col-sm-8">
                                            <input type="tel" pattern=".{11}" maxlength="11" class="form-control" id="new_tel" placeholder="联系方式" name="stu_tel" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_address" class="col-sm-4 control-label">家庭地址</label>
                                        <div class="col-sm-8">
                                            <input type="text" pattern=".{3,50}" class="form-control" id="new_address" placeholder="家庭地址" name="stu_address" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_origin" class="col-sm-4 control-label">生源地</label>
                                        <div class="col-sm-8">
                                            <input type="text" pattern=".{3,50}" required class="form-control" id="new_origin" placeholder="生源地"
                                                name="stu_origin" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_time" class="col-sm-4 control-label">入学年份</label>
                                        <div class="col-sm-8">
                                            <input type="text" pattern="[0-9]{4}" min="1999" required class="form-control" maxlength="4" id="new_time" placeholder="入学年份"
                                                name="stu_time" />
                                        </div>
                                    </div>
                                </div>
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">所属学院</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_col" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_col_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_pro_id" class="col-sm-4 control-label">所属专业</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_pro" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_pro_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_cla_id" class="col-sm-4 control-label">所属班级</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_cla" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>

                    <asp:Button ID="Btn_new" runat="server" CssClass="btn btn-primary" Text="创建" OnClick="Btn_new_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="EditInfo">

</asp:Content>

