<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adm_Cla.aspx.cs" Inherits="Adm_Cla" MasterPageFile="~/MasterPageAdmin.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ListInfo">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
        <asp:ScriptReference Path="~/Ajax/Admin.js" />
    </Scripts>
    </asp:ScriptManager>
    <!-- 列表查询部分  start-->
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">班级管理</h1>
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
                                <label for="stu_name">辅导员</label>
                                <asp:TextBox ID="Tb_tea" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_name">学院名称</label>
                                <asp:TextBox ID="Tb_col" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_tel">专业名称</label>
                                <asp:TextBox ID="Tb_pro" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_name">班级名称</label>
                                <asp:TextBox ID="Tb_cla" CssClass="form-control" runat="server"></asp:TextBox>
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
                            <div class="panel-heading">班级信息列表</div>
                            <!-- /.panel-heading -->

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Gv_list" runat="server" CssClass="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" OnPageIndexChanging="Gv_list_PageIndexChanging" OnRowCommand="Gv_list_RowCommand" OnRowDeleting="Gv_list_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="cla_id" HeaderText="班级编号"></asp:BoundField>
                                            <asp:BoundField DataField="cla_name" HeaderText="班级名称"></asp:BoundField>
                                            <asp:BoundField DataField="tea_name" HeaderText="辅导员"></asp:BoundField>
                                            <asp:BoundField DataField="pro_name" HeaderText="所属专业"></asp:BoundField>
                                            <asp:BoundField DataField="col_names" HeaderText="所属学院"></asp:BoundField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="编辑" CommandName="Edit_show" CausesValidation="false" OnClientClick="edit_show()" ID="Lbtn_Edit_show" CommandArgument='<%# Eval("cla_id") %>'></asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton runat="server" Text="删除" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('确认要删除吗？')" CommandName="Delete" CausesValidation="False" CommandArgument='<%# Eval("cla_id") %>' ID="Lbtn_delete"></asp:LinkButton>
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
                    <h4 class="modal-title" id="myModalLabel">新建班级信息</h4>
                </div>
                        <div class="modal-body">

                            <div class="form-horizontal">


                                <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="new_name" class="col-sm-4 control-label">
                                            班级名称
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <input type="text" required class="form-control" pattern=".{2,50}" maxlength="50" id="new_name" placeholder="班级名称"
                                                name="cla_name" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">辅导员</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_tea" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">所属学院</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_col" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">所属专业</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_pro" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                                <asp:Button ID="Lbtn_new" runat="server" CssClass="btn btn-primary" Text="创建" OnClick="Lbtn_new_Click" ></asp:Button>
                            </div>

                        </div>
            </div>
        </div>
        </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="EditInfo">

     <!-- 编辑模态框 -->
    <div class="modal fade" id="editDialog" tabindex="-1" role="dialog"
        aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h4 class="modal-title" id="myModalLabel">修改班级信息</h4>
                </div>

                <div class="modal-body">
              
                    <div class="form-horizontal">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                        <asp:Label ID="Lb_id" runat="server" Visible="False"></asp:Label>

                        <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="edit_name" class="col-sm-4 control-label">
                                            班级名称
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_name" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Tb_name" ValidationGroup="edit" ForeColor="Red" runat="server" ErrorMessage="不能为空！"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">辅导员</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_tea_edit" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">所属学院</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_col_edit" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_col_id" class="col-sm-4 control-label">所属专业</label>
                                        <div class="col-sm-8">
                                            <asp:DropDownList ID="Ddl_pro_edit" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <asp:LinkButton ID="Lbtn_edit" ValidationGroup="edit" runat="server" CssClass="btn btn-primary" OnClick="Lbtn_edit_Click" Text="确认"></asp:LinkButton>
                    </div>
              

            </div>
        </div>
    </div>
     </div>
</asp:Content>

