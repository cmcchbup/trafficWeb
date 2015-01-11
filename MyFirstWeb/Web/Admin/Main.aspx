<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="NET.CLY.Admin.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>


    <%---------------------------------------------------------------------------%>
    <%--------------------------------CSS文件---------------start----------------%>
    <%---------------------------------------------------------------------------%>

    <%---------------------------------------------------------------------------%>
    <%--------------------------------CSS文件---------------end------------------%>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
    <%--------------------------------JS文件----------------start----------------%>
    <%---------------------------------------------------------------------------%>
    <script src="../JS/jquery-1.8.2.js"></script>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
    <%--------------------------------Js文件----------------end------------------%>
    <%---------------------------------------------------------------------------%>
    <%--------------------------------CSS代码---------------start----------------%>
    <%---------------------------------------------------------------------------%>
    <style>
        div {
            /*border: 1px solid red;*/
        }

        body {
            background-image: url('../Images/bg_body_column.png');
            background-repeat: repeat-x;
            margin: 0px;
        }

        #Header {
            width: 100%;
            height: 60px;
            background-image: url('../Images/bg_header.gif');
            background-repeat: repeat-x;
        }

        #Main {
            height: 800px;
            margin-left: 178px;
        }

        #LeftBar {
            float: left;
            width: 176px;
            height: 500px;
            border-right: 2px solid aquamarine;
        }

        #Footer {
            clear: both;
            width: 100%;
            height: 20px;
        }

        #logo {
            margin-top: 10px;
        }

        .Menu1 {
            background-image: url("../Images/bg_menu_one.png");
            width: 177px;
            display: block;
            height: 30px;
            color: black;
            font-size: 13.63636302947998px;
            /*padding: 2px 2px 2px 5px;*/
            text-align: center;
            font-size: 20px;
            text-decoration: none;
            cursor: default;
        }

        .Menu2 {
            background-image: url("../Images/bg_menu_one.png");
            width: 177px;
            display: block;
            height: 29px;
            color: white;
            font-size: 13.63636302947998px;
            /*padding: 2px 2px 2px 5px;*/
            text-align: center;
            font-size: 13px;
            text-decoration: none;
        }

        iframe {
            margin-left: 0px;
        }
    </style>
    <%---------------------------------------------------------------------------%>
    <%--------------------------------CSS代码---------------end------------------%>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
    <%--------------------------------Js代码----------------start----------------%>
    <%---------------------------------------------------------------------------%>
    <script type="text/javascript">
        $(function () {
            $(".Menu2").click(function () {//为超链接取消跳转，让iframe标签跳转
                $("#frmWork").attr("src", $(this).attr("href"));
                return false;
            });
            $(".Menu1").click(function() {
                return false;
            });
        });
    </script>
    <%--------------------------------Js代码----------------end------------------%>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
    <%---------------------------------------------------------------------------%>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="Header">
                <img id="logo" src="" />
            </div>
            <div id="LeftBar">
                <a class="Menu1" href="">&nbsp;&nbsp;&nbsp;接警记录</a>
                <a class="Menu2" href="AddCaseInfo.html">案件录入</a>
                <a class="Menu2" href="NewsList.aspx">案件修改</a>
                <a class="Menu2" href="NewsList.aspx">案件删除</a>
                <a class="Menu1" href="">&nbsp;&nbsp;&nbsp;肇事方信息管理</a>
                <a class="Menu2" href="NewsList.aspx">肇事方信息录入</a>
                <a class="Menu2" href="NewsList.aspx">肇事方信息修改</a>
                <a class="Menu2" href="NewsList.aspx">肇事方信息删除</a>
                <a class="Menu1" href="">&nbsp;&nbsp;&nbsp;受害方信息管理</a>
                <a class="Menu2" href="NewsList.aspx">受害方信息删除</a>
                <a class="Menu2" href="NewsList.aspx">受害方信息删除</a>
                <a class="Menu2" href="NewsList.aspx">受害方信息删除</a>
                <a class="Menu1" href="">&nbsp;&nbsp;&nbsp;信息查询</a>
                <a class="Menu2" href="NewsList.aspx">案件详情查询</a>
                <a class="Menu2" href="NewsList.aspx">受害者车辆信息查询</a>
                <a class="Menu2" href="NewsList.aspx">受害者信息查询</a>
                <a class="Menu2" href="NewsList.aspx">肇事者车辆信息查询</a>
                <a class="Menu2" href="NewsList.aspx">肇事者信息查询</a>
                <a class="Menu1" href="">&nbsp;&nbsp;&nbsp;系统设置</a>
                <a class="Menu2" href="AddUser.html">添加用户</a>
                <a class="Menu2" href="DeleteUser.html">注销用户</a>
                <a class="Menu2" href="EditPassword.html">修改密码</a>
                <a class="Menu2" href="LoginOut.html">退出登录</a>
            </div>
            <div id="Main">
                <iframe id="frmWork" width="100%" height="100%" frameborder="0" src="Welcome.html"></iframe>
            </div>

            <div id="Footer">
            </div>
        </div>
    </form>
</body>
</html>
