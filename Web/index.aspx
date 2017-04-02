<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>忆书馆</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="css/index.css"
            rel="stylesheet" type="text/css" />
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header" >
        <div class="row">
            <div class="col-md-4 col-md-offset-1">
                <img src="images/header.png" />
            </div>
            <div class="col-md-2 col-md-offset-4"><div class="btn-group">
              <button type="button" class="btn btn-warning">登陆</button>
              <button type="button" class="btn btn-warning">注册</button>
              <button type="button" class="btn btn-warning">帮助</button>
            </div>                                              
            </div>
        </div>
        
    </div>
    <div id="search">
        <link href="css/search.css" rel="stylesheet" type="text/css" />
    搜索图书：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1"
        runat="server" Text=" 搜 索 " BackColor="#DEA774" BorderColor="#666666" />
&nbsp;</div>
    <div id="navigation">
        <ul id="navBar">
        <li>
            <a href="http://www.baidu.com/">网站首页</a>
        </li>
        <li>
            <a href="http://www.baidu.com/">畅销图书</a>
        </li>
        <li>
            <a href="http://www.baidu.com/">新品图书</a>
        </li> 
        <li>
            <a href="http://www.baidu.com/">会员功能</a>
        </li>
        <li>
            <a href="http://www.baidu.com/">购物车</a>
        </li>
        <div class="clean">
        </div>
        </ul>
    </div>

    <div id="main" class="container">
        <link href="css/main.css" rel="stylesheet" type="text/css" />
        <div id="main_search">

        </div>
        <div id="main_hot">
        <h2>热搜图书</h2>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>        
        </div>
        <div id="main_new">
        <h2>新书上架</h2>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        </div>
        <div id="recommend">
        <h2>推荐图书</h2>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        <a href="#"><img class="recommend" src="images/education/english/english_sparkenglish.jpg" height="200px" /></a>
        </div>
        
        
    </div>

    <div id="footer">
        <link href="css/footer.css" rel="stylesheet" type="text/css" />
        <br />制作班级：14软件工程（转本）<br /><br />
&nbsp;© 2016 赵冬晋 王倩 赵牧宇 版权所有<br /><br />
    </div>
    </form>
</body>
</html>
