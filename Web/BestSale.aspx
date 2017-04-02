<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="BestSale.aspx.cs" Inherits="Web.BestSale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="page_main">
        <div class="row">
            <div >
                <div id="main_hot" class="text-center">
                    <h2 class="text-success">畅销图书</h2>
                    <%=BestSaleBook %>
                </div>               
            </div>
        </div>
    </div>
</asp:Content>

