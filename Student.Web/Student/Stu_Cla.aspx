<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stu_Cla.aspx.cs" Inherits="Stu_Cla"  MasterPageFile="~/MasterPageStudent.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ListInfo">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <!-- 列表查询部分  start-->
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">班级信息</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-inline">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="Lb_cla" runat="server" Visible="False"></asp:Label>
                            <div class="form-group">
                                <label for="stu_name">学生姓名</label>
                                <asp:TextBox ID="Tb_name" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <asp:LinkButton CausesValidation="false" ID="Lbtn_select" runat="server" CssClass="btn btn-primary" OnClick="Lbtn_select_Click">查询</asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">

                        <div class="panel panel-default">
                            <div class="panel-heading">班级学生信息列表</div>
                            <!-- /.panel-heading -->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="Gv_list" runat="server" CssClass="table table-bordered table-striped" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="暂无数据" OnPageIndexChanging="Gv_list_PageIndexChanging" OnRowCommand="Gv_list_RowCommand">
                                        <Columns>
                                            <asp:BoundField DataField="stu_name" HeaderText="学生姓名"></asp:BoundField>
                                            <asp:BoundField DataField="stu_sex" HeaderText="学生性别"></asp:BoundField>
                                            <asp:BoundField DataField="stu_time" HeaderText="入学日期"></asp:BoundField>
                                            <asp:BoundField DataField="col_names" HeaderText="所属学院"></asp:BoundField>
                                            <asp:BoundField DataField="pro_name" HeaderText="所属专业"></asp:BoundField>
                                            <asp:BoundField DataField="cla_name" HeaderText="所属班级"></asp:BoundField>
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
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="EditInfo">

</asp:Content>

