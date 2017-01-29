<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Login</title>
    <script src="../../Content/Easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Content/Easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Content/Easyui/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../../Content/Easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/Easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Common/Login.js" type="text/javascript"></script>
</head>
<body>
    <div id="win" class="easyui-window" title="登录系统" style="width:260px;height:180px;"  data-options="iconCls:'icon-save',modal:true,closable:false,minimizable:false,maximizable:false,collapsible:false,draggable:false,resizable:false">   
        <table style=" padding-top:10px; padding-left:15px;">
            <tr>
                <td>用户名：</td><td><input id="name" type="text" value="admin" /></td>
            </tr>
            <tr>
                <td></td><td></td>
            </tr>
            <tr>
                <td>密　码：</td><td><input id="pwd" type="text" value="123321" /></td>
            </tr>
            <tr>
                <td></td><td></td>
            </tr>
            <tr>
                <td></td><td><input type="button" onclick="Login();" value="登录" /></td>
            </tr>
            <tr>
                <td></td><td><label id="showInfo" style=" color:Red"></label></td>
            </tr>
        </table>
    </div> 
    <%--<input type="button" value="有种点我" /> --%>
</body>
</html>
