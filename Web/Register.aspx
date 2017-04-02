<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Web.WebRegister" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="UTF-8">
    <title>注册</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/register.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <script src="js/jQuery-1.11.3.js"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script>
        $(function () {
            // 注册按钮的条件
            var isOk = [0, 0, 0, 0, 0, 0];

            // 判断是否可以点击注册
            var enbaleBtnReg = function () {
                for (var i = 0; i < 6; i++) {
                    if (isOk[i] == 0) {
                        $("#btnRegister").attr("disabled", true);
                        return;
                    }
                }
                $("#btnRegister").removeAttr("disabled");
            };

            // 用户名验证
            $("#TextUsername").blur(function () {
                var nameReg = /^[a-zA-Z0-9_]{1,}$/;
                if (!$(this).val().match(nameReg)) {
                    $(this).popover('show');
                    isOk[0] = 0;
                } else {
                    isOk[0] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 密码验证
            $("#TextPassword").blur(function () {
                var pwdReg = /^[A-Za-z0-9_]+$/;
                if (!$(this).val().match(pwdReg)) {
                    isOk[1] = 0;
                    $(this).popover('show');
                } else {
                    isOk[1] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 重复密码验证
            $("#TextRepassword").blur(function () {
                if ($(this).val() == $("#TextPassword").val()) {
                    isOk[2] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[2] = 0;
                    $(this).popover('show');
                }
            });
            // 电子邮件验证
            $("#TextEmail").blur(function () {
                var emailReg = /^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$/;
                if (!$(this).val().match(emailReg)) {
                    isOk[3] = 0;
                    $(this).popover('show');
                } else {
                    isOk[3] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                }
            });
            // 问题验证
            $("#TextQuestion").blur(function () {
                if ($(this).val().length > 0) {
                    isOk[4] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[4] = 0;
                    $(this).popover('show');
                }
            });
            // 回答验证
            $("#TextAnswer").blur(function () {
                if ($(this).val().length > 0) {
                    isOk[5] = 1;
                    $(this).popover('hide');
                    $("#btnRegister").removeAttr("disabled");
                } else {
                    isOk[5] = 0;
                    $(this).popover('show');
                }
            });
            

            // 注册验证
            $("#btnRegister").mousemove(function () {
                $("#TextUsername").blur();
                $("#TextPassword").blur();
                $("#TextRepassword").blur();
                $("#TextEmail").blur();
                $("#TextQuestion").blur();
                $("#TextAnswer").blur();
                enbaleBtnReg();
            });

        });

        // 回车注册事件取消
        function EnterKeyFilter() {
            if (window.event.keyCode == 13) {
                event.returnValue = false;
                event.cancel = true;
            }
        }
    </script>
</head>

<body onkeydown="javascript:EnterKeyFilter();">
    <div class="text-center">
        <a href="./Main.aspx"><img src="images/header.png" /></a>
    </div>
    <div class="container">
        <div id="form">
            <h1>用户注册<small> --忆书馆 <asp:Label style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label></small></h1>
            <br />
            <form class="form-horizontal" role="form" runat="server">
                <div class="form-group">
                    <label class="col-sm-2 control-label">用&nbsp;&nbsp;户&nbsp;&nbsp;名：</label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control" ID="TextUsername" runat="server" placeholder="请输入用户名" data-placement="right" data-content="只可以是数字字母和下划线" MaxLength="20"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="password" class="form-control" ID="TextPassword" runat="server" placeholder="请输入密码" data-placement="right" data-content="由数字 字母和下划线组成" MaxLength="16"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">重复密码：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="password" class="form-control" ID="TextRepassword" runat="server" placeholder="再次输入密码" data-placement="right" data-content="再次输入上一次的密码" MaxLength="16"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="email" class="form-control" ID="TextEmail" runat="server" placeholder="请输入邮箱" data-placement="right" data-content="例：example@domain.com"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">问&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="text" class="form-control" ID="TextQuestion" runat="server" placeholder="请输入一个找回密码的问题" data-placement="right" data-content="找回密码的问题"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">回&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;答：</label>
                    <div class="col-sm-10">
                        <asp:TextBox type="text" class="form-control" ID="TextAnswer" runat="server" placeholder="请输入回答" data-placement="right" data-content="找回密码的回答"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-7">
                        <asp:Button ID="btnRegister" class="btn btn-default" runat="server" Text="注册" OnClick="btnRegister_Click" />
                        <asp:HyperLink class="btn btn-link" ID="HyperLink1" runat="server" NavigateUrl="~/Web/Login.aspx">已有账号？直接登录</asp:HyperLink>
                    </div>
                    <div class="col-sm-3">
                        <button type="reset" class="btn btn-default">重置</button>
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
