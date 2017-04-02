<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Web.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        $(function () {
            $(".delete_book").click(function () {
                $("#delete_book_name").text($(this).attr("bookName"));
                $("#ContentPlaceHolder1_BookId").val($(this).attr("bookId"));
            });
        });
    </script>
    <div class="modal fade" id="confirm-delete" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    您确定要删除此条订单吗？
                </div>
                <div class="modal-body">
                    <span class="text-primary" id="delete_book_name"></span>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>
                    <asp:TextBox style="display: none;" ID="BookId" runat="server"></asp:TextBox>
                    <asp:Button class="btn btn-danger btn-ok" ID="BtnDeleteBook" runat="server" Text="删除" OnClick="BtnDeleteBook_Click" />
                </div>
            </div>
        </div>
    </div>
    <h2>
        <strong style="margin: 2%;"><asp:Label class="text-primary" ID="AccountName" runat="server" Text=""></asp:Label></strong>的购物车

    </h2>
    <div id="page_cart" class="card">
        <table class="table table-hover text-center">
            <thead>
                <tr>
                    <th>序号</th>
                    <th>封面</th>
                    <th>书名</th>
                    <th>价格</th>
                    <th>数量</th>
                    <th>下单时间</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody>
                <%=OrderList %>
            </tbody>
        </table>
        <h1 class="text-center text-info">
            <asp:Label ID="EmptyInfo" runat="server" Text=""></asp:Label></h1>
        <br />
    </div>
</asp:Content>

