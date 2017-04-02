<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Web.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page_serarch" class="card">
        <table class="table table-hover text-center">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>封面</th>
                    <th>书名</th>
                    <th>作者</th>
                    <th>描述</th>
                    <th>价格</th>
                </tr>
            </thead>
            <tbody>
                <%=ResultList %>                
            </tbody>
        </table>
        <h1 class="text-center text-info">
            <asp:Label ID="EmptyInfo" runat="server" Text=""></asp:Label></h1>
        <br />
    </div>
</asp:Content>

