<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Master/MasterPage.master" AutoEventWireup="true" CodeFile="main_member.aspx.cs" Inherits="Web_main_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <link href="css/main.css" rel="stylesheet" type="text/css" />
        
    <div id="main_member_list">
        <h2>我的忆书馆</h2>
              
        </div>

        <div id="main_member">
        <h2>会员功能</h2>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>        
        </div>
    
    <div id="main_member_order">
        <h2>我的订单</h2>
        <div id="main_member_order_obligations">
            <h3>待付款</h3>
            <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        </div>
        <div id="main_member_order_receive">
            <h3>待收货</h3>
        </div>
        <div id="main_member_order_evaluate">
            <h3>待评价</h3>
        </div>
        <div id="main_member_order_allorders">
            <h3>全部订单</h3>
        </div>
        
             
    </div>
        
</asp:Content>

