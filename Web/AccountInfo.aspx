<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="AccountInfo.aspx.cs" Inherits="Web.AccountInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page_account" class="card">
            <br/>
        <div class="row">
            <div class="text-center">
                <h1>用户信息<small> --忆书馆 <asp:Label style="color: #FF0000" ID="ErrorInfo" runat="server" Text=""></asp:Label></small></h1>
            </div>
        </div>
            <br />
            <div class="form-horizontal" role="form">
                <div class="form-group">
                    <label class="col-sm-2 control-label">用&nbsp;&nbsp;户&nbsp;&nbsp;名：</label>
                    <div class="col-sm-9">
                        <asp:TextBox disabled="true" class="form-control" ID="TextUsername" runat="server" placeholder="请输入用户名"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="password" class="form-control" ID="TextPassword" runat="server" placeholder="请输入密码"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;箱：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="email" class="form-control" ID="TextEmail" runat="server" placeholder="请输入邮箱"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">问&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="text" class="form-control" ID="TextQuestion" runat="server" placeholder="请输入一个找回密码的问题"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-2 control-label">回&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;答：</label>
                    <div class="col-sm-9">
                        <asp:TextBox type="text" class="form-control" ID="TextAnswer" runat="server" placeholder="请输入回答"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-sm-offset-2 col-sm-6">
                        <asp:Button ID="BtnUpdate" class="btn btn-default" runat="server" Text="更新" OnClick="BtnUpdate_Click" />
                        <asp:Label class="text-success" ID="ResultInfo" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-sm-3">
                        <button type="button" onclick="javascript:history.go(-1);" class="btn btn-default">返回</button>
                    </div>
                </div>
            </div>
        <br/>
    </div>
</asp:Content>

