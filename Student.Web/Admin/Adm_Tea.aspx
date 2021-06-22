﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adm_Tea.aspx.cs" Inherits="Adm_Tea" MasterPageFile="~/MasterPageAdmin.master" %>

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
                <h1 class="page-header">辅导员管理</h1>
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
                                <label for="stu_name">辅导员姓名</label>
                                <asp:TextBox ID="Tb_name" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="stu_tel">所属学院</label>
                                <asp:DropDownList ID="Ddl_col_select" CssClass="form-control" runat="server"></asp:DropDownList>
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
                            <div class="panel-heading">辅导员信息列表</div>
                            <!-- /.panel-heading -->

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Gv_list" runat="server" CssClass="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" OnPageIndexChanging="Gv_list_PageIndexChanging" OnRowCommand="Gv_list_RowCommand" OnRowDeleting="Gv_list_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="tea_id" HeaderText="辅导员编号"></asp:BoundField>
                                            <asp:BoundField DataField="tea_name" HeaderText="辅导员姓名"></asp:BoundField>
                                            <asp:BoundField DataField="tea_tel" HeaderText="联系方式"></asp:BoundField>
                                            <asp:BoundField DataField="tea_address" HeaderText="通讯地址"></asp:BoundField>
                                            <asp:BoundField DataField="col_names" HeaderText="所属学院"></asp:BoundField>
                                            <asp:BoundField DataField="cla_num" HeaderText="管理班级总数"></asp:BoundField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="操作">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-primary btn-sm" Text="编辑" CommandName="Edit_show" CausesValidation="false" OnClientClick="edit_show()" ID="Lbtn_Edit_show" CommandArgument='<%# Eval("tea_id") %>'></asp:LinkButton>
                                                    &nbsp;
                                                    <asp:LinkButton runat="server" Text="删除" CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('确认要删除吗？')" CommandName="Delete" CausesValidation="False" CommandArgument='<%# Eval("tea_id") %>' ID="Lbtn_delete"></asp:LinkButton>
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
                <!-- 列表查询部分  end-->
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
                    <h4 class="modal-title" id="myModalLabel">新建辅导员信息</h4>
                </div>
                        <div class="modal-body">

                            <div class="form-horizontal">
                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_name" class="col-sm-4 control-label">
                                            辅导员姓名
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_new_name" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="姓名不能为空！" ControlToValidate="Tb_new_name" ForeColor="Red" ValidationGroup="new"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_tel" class="col-sm-4 control-label">
                                            联系方式
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_new_tel" MaxLength="11" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="联系方式不能为空！" ControlToValidate="Tb_new_tel" Display="Dynamic" ForeColor="Red" ValidationGroup="new"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="格式错误！" Display="Dynamic" Font-Italic="False" ForeColor="Red" ControlToValidate="Tb_new_tel" ValidationExpression="^1[3|4|5|7|8][0-9]{9}$" ValidationGroup="new"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group col-sm-12">
                                        <label for="new_address" class="col-sm-4 control-label">
                                            通讯地址
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_new_address" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="通讯地址不能为空！" ControlToValidate="Tb_new_address" ForeColor="Red" ValidationGroup="new"></asp:RequiredFieldValidator>
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
                            </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                                <asp:LinkButton ID="Lbtn_new" runat="server" CssClass="btn btn-primary" Text="创建" OnClick="Lbtn_new_Click" ValidationGroup="new" />
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
                    <h4 class="modal-title" id="myModalLabel">修改辅导员信息</h4>
                </div>
               
                <div class="modal-body">
             
                    <div class="form-horizontal">
                          <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                        <asp:Label ID="Lb_id" runat="server" Visible="False"></asp:Label>

                        <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="edit_name" class="col-sm-4 control-label">
                                            辅导员姓名
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_edit_name" MaxLength="20" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="姓名不能为空！" ControlToValidate="Tb_edit_name" ForeColor="Red" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                        <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="edit_name" class="col-sm-4 control-label">
                                            联系方式
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_edit_tel" MaxLength="11" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="联系方式不能为空！" ControlToValidate="Tb_edit_tel" Display="Dynamic" ForeColor="Red" ValidationGroup="edit"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="格式错误！" Display="Dynamic" Font-Italic="False" ForeColor="Red" ValidationGroup="edit" ControlToValidate="Tb_edit_tel" ValidationExpression="^1[3|4|5|7|8][0-9]{9}$"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                </div>
                                
                        <div class="row">
                                    <div class="form-group col-sm-12">

                                        <label for="edit_name" class="col-sm-4 control-label">
                                            通讯地址
                                        </label>
                                        <div class="col-sm-8 col-sm-12">
                                            <asp:TextBox ID="Tb_edit_address" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="通讯地址不能为空！" ControlToValidate="Tb_edit_address" ForeColor="Red" ValidationGroup="edit"></asp:RequiredFieldValidator>
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
                                 </ContentTemplate>
                        </asp:UpdatePanel>
                      </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <asp:LinkButton ID="Lbtn_edit" runat="server" CssClass="btn btn-primary" OnClick="Lbtn_edit_Click" Text="确认" ValidationGroup="edit"></asp:LinkButton>
                    </div>
        </div>
    </div>
     </div>
</asp:Content>

