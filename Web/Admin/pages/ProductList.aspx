<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Web.Admin.pages.ProductList" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="../../images/favicon.ico" />
    <title>忆书馆-后台管理</title>
    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet">
    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form runat="server">
        <div id="wrapper">
            <!-- Navigation -->
            <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">忆书馆-后台管理</a>
                </div>
                <!-- /.navbar-header -->
                <ul class="nav navbar-top-links navbar-right">
                    <!-- /.dropdown -->
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                            <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li>
                                <asp:HyperLink ID="HyperLink2" runat="server">
                                    <i class="fa fa-user fa-fw"></i><asp:Label ID="AdminName" runat="server" Text=""></asp:Label>
                                </asp:HyperLink>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <asp:HyperLink NavigateUrl="~/Web/Admin/pages/LogOut.ashx" ID="HyperLink1" runat="server"><i class="fa fa-sign-out fa-fw"></i> Logout</asp:HyperLink>
                            </li>
                        </ul>
                        <!-- /.dropdown-user -->
                    </li>
                    <!-- /.dropdown -->
                </ul>
                <!-- /.navbar-top-links -->
                <div class="navbar-default sidebar" role="navigation">
                    <div class="sidebar-nav navbar-collapse">
                        <ul class="nav" id="side-menu">

                            <li>
                                <a href="./UserList.aspx"><i class="fa fa-dashboard fa-fw"></i>用户列表</a>
                            </li>
                            <li>
                                <a href="./ProductList.aspx"><i class="fa fa-table fa-fw"></i>商品列表</a>
                            </li>
                            <li>
                                <a href="./BookTypeManager.aspx"><i class="fa fa-list-alt fa-fw"></i>分类管理</a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.sidebar-collapse -->
                </div>
                <!-- /.navbar-static-side -->
            </nav>
            <div id="page-wrapper">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">图书详细信息</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <!-- /.row -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        图书信息列表
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <table width="100%" class="table table-striped table-bordered table-hover" id="dataTables-example">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>封面图片</th>
                                    <th>书名</th>
                                    <th>作者</th>
                                    <th>描述</th>
                                    <th>价格</th>
                                    <th>类别</th>
                                    <th>操作</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="odd gradeX">
                                    <td disable="true">-</td>
                                    <td><asp:TextBox class="form-control" placeholder="图片路径" ID="TextBookImage" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="书名" ID="TextBookName" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="作者" ID="TextBookAuthor" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox class="form-control" placeholder="描述" ID="TextBookDescription" runat="server"></asp:TextBox></td>                                    
                                    <td style="width: 8%;"><asp:TextBox class="form-control" placeholder="价格" ID="TextBookPrice" runat="server"></asp:TextBox></td>
                                    <td style="width: 10%;">
                                        <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="typeName" DataValueField="id"></asp:DropDownList>

                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [bookType]"></asp:SqlDataSource>

                                    </td>
                                    <td>
                                        <asp:Button class="btn btn-success"  ID="BtnAddBook" runat="server" Text="添加" OnClick="BtnAddBook_Click" />
                                    </td>
                                </tr>
                                <%=ProductsList %>

                            </tbody>
                        </table>
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /#page-wrapper -->
        </div>
        <!-- /#wrapper -->
        <div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="text-danger">您确定要删除这条记录吗？</h3>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                        <asp:TextBox Style="display: none;" ID="BookId" runat="server"></asp:TextBox>
                        <asp:Button class="btn btn-danger btn-ok" ID="BtnDeleteBook" runat="server" Text="删除" OnClick="BtnDeleteBook_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>
    <script>
        $(function () {
            $(".btn_delete").click(function () {
                console.log($(this).parent().attr("bookId"));
                $("#BookId").val($(this).parent().attr("bookId"));
            });
            $(".btn_update").click(function() {
                window.location.href = "UpdateBookInfo.aspx?bookId=" + $(this).parent().attr("bookId");
            });
        });
    </script>
</body>
</html>