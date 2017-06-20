<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CMSWebForms.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html>    
<html>
<head>
    <title>test</title>
    <%--<link rel="stylesheet" type="text/css" href="Scripts/jquery-1.10.2.min.js" />  --%>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-combined.min.css" rel="stylesheet" />  
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="Content/test.css"/>
    

</head>
<body>
    <ul id="sidebar" class="dropdown-menu text-right" role="menu" aria-labelledby="dropdownMenu" style="display: block;  position: fixed; top: 0; left: 0;">
        <li><h1 class="text-center"><a tabindex="-1" href="#">CMS</a></h1></li>
        <li class="divider"></li>
        <li class="dropdown-submenu pull-right">
            <a tabindex="-1" href="#" id="myId">Sales</a>
            <ul class="dropdown-menu text-right">
                <li><a tabindex="-1" href="#">Customers</a></li>
                <li class="dropdown-submenu pull-right">
                    <a tabindex="-1" href="#" id="myId">Pricing</a>
                    <ul class="dropdown-menu text-center">
                        <li><a tabindex="-1" href="#">A</a></li>
                        <li><a tabindex="-1" href="#">B</a></li>
                        <li><a tabindex="-1" href="#">C</a></li>
                        <li><a tabindex="-1" href="#">D</a></li>
                        <li><a tabindex="-1" href="#">E</a></li>
                    </ul>
                </li>
                <li><a tabindex="-1" href="#">Quotes</a></li>
                <li><a tabindex="-1" href="#">Orders</a></li>
                <li><a tabindex="-1" href="#">Pricing</a></li>
                <li><a tabindex="-1" href="#">Reports</a></li>
            </ul>
            </li>
        <p>&nbsp;</p>
        <!--<p>&nbsp;</p>-->
        <li class="dropdown-submenu pull-right">
            <a tabindex="-1" href="#" id="myId">Manufacturing</a>
            <ul class="dropdown-menu text-center">
                <li><a tabindex="-1" href="#">One</a></li>
                <li><a tabindex="-1" href="#">Two</a></li>
                <li><a tabindex="-1" href="#">Three</a></li>
                <li><a tabindex="-1" href="#">Four</a></li>
                <li><a tabindex="-1" href="#">Five</a></li>
            </ul>
        </li>
    </ul>
    <!--</div>-->
    <!--<div id="wrapper">-->
    <%--<div id="page-content-wrapper">
        <nav class="navbar navbar-inverse">
            <div class="container-fluid">
                <ul class="nav navbar-nav navbar-left">
                    <li>
                        <asp:Button ID="sidebarToggle" Runat=Server OnClientClick="myFunction(); return false;"/>
                        <button id="sidebarToggle" class="btn btn-primary btn-lg">
                            <i class="fa fa-angle-left"></i>
                        </button>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="#" class="btn btn-sm btn-info">
                         <i class="fa fa-sign-in"></i>&nbsp;&nbsp;Log in
                        </a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="content-header container-fluid text-center">
            <h1 id="home" class="">
                CMS
            </h1>
        </div>
        <div class="page-content inset container-fluid">
            <div class="row">
                <div class="jumbotron text-center">
                    <h1 class="">Hello Beautiful!</h1>
                    <p class="">
                        
                    </p>
                    Name:
                    <asp:TextBox ID="TextBox1" runat="server" Width="248px"></asp:TextBox>
                    Address:
                     <asp:TextBox ID="TextBox2" runat="server" Width="248px"></asp:TextBox>
                </div>
            </div>
        </div>
        <div id="footer"  class="container-fluid">
            <div class="navbar navbar-inverse navbar-fixed-bottom">
                <h4 class="text-center text-primary">&copy;2016 Apiron Technologies, Inc.</h4>
            </div>
        </div>
    </div>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>--%>
   <%-- <script type="text/javascript" src="js/test.js"></script>--%>
    <%--<script src="Scripts/site.js"></script>--%>
</body>
</html>
</asp:Content>
