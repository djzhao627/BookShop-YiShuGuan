<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登录</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/login.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <script src="js/jQuery-1.11.3.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            // 激活注册按钮的条件
            var isOk = [0, 0];

            // 判断是否可以点击登录
            var enableBtnLogin = function () {
                for (var i = 0; i < 2; i++) {
                    if (!isOk[i]) {
                        $("#btnLogin").attr("disabled", true);
                        return;
                    }
                }
                $("#btnLogin").removeAttr("disabled");
            };

            

            // 用户名验证
            var nameCheck = function ($name) {
                var nameReg = /^[a-zA-Z0-9_]{1,}$/;
                if (!$name.val().match(nameReg)) {
                    $name.popover('show');
                    isOk[0] = 0;
                } else {
                    isOk[0] = 1;
                    $name.popover('hide');
                }
            };
            // 失去焦点
            $("#TextUsername").keyup(function () {
                nameCheck($(this));
                $("#btnLogin").removeAttr("disabled");
            });

            // 密码验证
            var pwdCheck = function($pwd) {
                var pwdReg = /^[A-Za-z0-9_]+$/;
                if (!$pwd.val().match(pwdReg)) {
                    isOk[1] = 0;
                    $pwd.popover('show');
                } else {
                    isOk[1] = 1;
                    $pwd.popover('hide');
                }
            }
            // 失去焦点
            $("#TextPassword").keyup(function () {
                pwdCheck($(this));
                $("#btnLogin").removeAttr("disabled");
            });          


            // 登录验证
            var loginCkeck = function() {
                nameCheck($("#TextUsername"));
                pwdCheck($("#TextPassword"));
            }

            // 鼠标移上操作            
            $("#btnLogin").mousemove(function () {
                loginCkeck();
                enableBtnLogin();
            });


        });
    </script>
</head>
<body>
    <div class="text-center">
        <a href="./Main.aspx">
            <img src="images/header.png" /></a>
    </div>
    <div class="container">
        <div id="form">
            <h1>用户登录<small> --忆书馆
                <asp:Label Style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label></small>
            </h1>
            <br />
            <form class="form-horizontal" role="form" runat="server">
                <div class="form-group">
                    <label class="col-sm-2 control-label">用户名：</label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control" ID="TextUsername" runat="server" placeholder="请输入用户名" data-placement="top" data-content="输入您的用户名" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">密&nbsp;&nbsp;&nbsp;&nbsp;码：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="password" class="form-control" ID="TextPassword" runat="server" placeholder="请输入密码" data-placement="bottom" data-content="输入您的的密码" MaxLength="16"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="CheckBoxRemind" runat="server" />请记住我
                            </label>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-10">
                        <asp:Button class="btn btn-default" ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
                        <asp:HyperLink class="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Web/Register.aspx">没有账号？去注册</asp:HyperLink>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <div id="footer">
        <span>制作班级：14软件工程（转本）</span><br />
        <span>&copy; 2016 赵冬晋 王倩 赵牧宇 版权所有</span>
    </div>
</body>
</html>
