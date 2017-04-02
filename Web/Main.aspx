<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Web.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="page_main">
        <div class="row">
            <div class="col-md-2">
                <div id="main_type">
                    <br />
                    <div class="panel panel-warning">
                        <div class="panel-heading text-center">
                            <i class="fa fa-bell fa-fw"></i>图书分类
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="list-group">
                                <%=BookType %>
                            </div>
                            <!-- /.list-group -->
                            <a href="Main.aspx" class="btn btn-default btn-block">全部分类</a>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                </div>
            </div>
            <div class="col-md-10">
                <div id="main_hot">

                    <h2 class="text-success">热搜图书</h2>
                    <%=HotSearch %>
                </div>
                <div id="main_new">
                    <h2 class="text-success">新书上架</h2>
                    <%=NewComing %>
                </div>
                <div id="recommend">
                    <h2 class="text-success">推荐图书</h2>
                    <%=RecommendBooks %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

