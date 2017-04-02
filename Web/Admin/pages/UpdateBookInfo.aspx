<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateBookInfo.aspx.cs" Inherits="Web.Admin.pages.UpdateBookInfo" %>

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
                                <asp:HyperLink ID="AdminName" runat="server"><i class="fa fa-user fa-fw"></i> User Profile</asp:HyperLink>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <asp:HyperLink ID="HyperLink1" runat="server">
                                    <i class="fa fa-user fa-fw"></i>
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </asp:HyperLink>
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
                        <h1 class="page-header">更新图书详细信息</h1>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <div class="text-right">
                    <asp:Button class="btn btn-success" ID="BtnUpdate" runat="server" Text="更新" OnClick="BtnUpdate_Click" />
                    <button type="reset" onclick="javascript:window.history.go(-1);" class="btn btn-default">返回</button>
                </div>
                <br />
                <!-- /.row -->
                <div class="panel panel-default">
                    <div class="panel-heading">
                        图书信息 <small><b>
                            <asp:Label ID="ResultInfo" runat="server" Text=""></asp:Label></b></small>
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="form-group">
                            <label>书名</label>
                            <asp:TextBox class="form-control" placeholder="书名" ID="TextName" runat="server"></asp:TextBox>
                            <p class="help-block">图书名称.</p>
                        </div>
                        <div class="form-group">
                            <label>作者</label>
                            <asp:TextBox class="form-control" placeholder="作者" ID="TextAuthor" runat="server"></asp:TextBox>
                            <p class="help-block">图书作者.</p>
                        </div>
                        <div class="form-group">
                            <label>图片</label>
                            <asp:TextBox class="form-control" placeholder="图片" ID="TextImage" runat="server"></asp:TextBox>
                            <p class="help-block">图片的地址.</p>
                        </div>
                        <div class="form-group">
                            <label>价格</label>
                            <asp:TextBox class="form-control" placeholder="价格" ID="TextPrice" runat="server"></asp:TextBox>
                            <p class="help-block">图书价格.</p>
                        </div>
                        <div class="form-group">
                            <label>描述</label>
                            <asp:TextBox TextMode="multiline" placeholder="图书简介" class="form-control" Rows="3" ID="TextDescription" runat="server"></asp:TextBox>
                            <p class="help-block">图书的介绍.</p>
                        </div>
                        <div class="form-group">
                            <label for="types">图书类别</label>
                            <asp:DropDownList class="form-control" ID="DropDownList" runat="server" DataSourceID="SqlDataSource1" DataTextField="typeName" DataValueField="id"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [bookType]"></asp:SqlDataSource>
                        </div>

                    </div>
                    <!-- /.panel-body -->
                </div>
                <br />
                <!-- /.row -->
            </div>
            <!-- /#page-wrapper -->
        </div>
        <!-- /#wrapper -->
    </form>
    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>
</body>
</html>

