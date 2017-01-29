<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
    <script src="../../Content/Easyui/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../Content/Easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Content/Easyui/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <link href="../../Content/Easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/Easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Common/Login.js" type="text/javascript"></script>
</head>
<body class="easyui-layout">
<%
    UserSystem.Model.UserManager user = Session["user"] as UserSystem.Model.UserManager;
     %>
	<div data-options="region:'north',border:false" style="height:50px;background:#0099C8;padding:10px">
    
           <div style=" float:left;">logo</div> 
           <div style="padding:5px;border:0px solid #ddd; float:right">
		        <a href="#" class="easyui-linkbutton" data-options="plain:true">Home</a>
		        <a href="#" class="easyui-menubutton" data-options="iconCls:'icon-edit'" onclick="logoff();">注销</a>
		        <a href="#" class="easyui-menubutton" data-options="menu:'#mm2',iconCls:'icon-help'">Help</a>
		        <a href="#" class="easyui-menubutton" data-options="menu:'#mm3'">About</a>
	        </div>
    </div>
	<div data-options="region:'west',split:true,title:'菜单栏'" style="width:150px;">
        <div class="easyui-accordion" data-options="fit:true">
            <div title="用户管理" data-options="iconCls:'icon-save'" style="overflow:auto;padding:10px;">
                <ul id="tt"></ul>  
            </div>
            <div title="系统设计" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            </div>
            <div title="帮助" data-options="iconCls:'icon-ok'" style="overflow:auto;padding:10px;">
            </div>
        </div>
    </div>
	<div data-options="region:'south',border:false" style="height:20px;background:#ccc;padding:1px;">北盟学习社区 当前登录人： <%=user.Name %></div>
	<div data-options="region:'center'">
        <div id="tabs" class="easyui-tabs" style="width:500px;height:250px;" data-options="fit:true">   
            <div title="Tab1" style="padding:20px;display:none;">   
                tab1   
            </div>   
            <div title="Tab2" data-options="closable:true" style="overflow:auto;padding:20px;display:none;">   
                tab2   
            </div>   
            <div title="Tab3" data-options="iconCls:'icon-reload',closable:true" style="padding:20px;display:none;">   
                tab3   
            </div>   
        </div> 
    </div>
    <script type="text/javascript">
        $('#tt').tree({
            url: '/Prim/Index',
            checkbox: true
        });

        $('#tt').tree({
            onClick: function (node) {//菜单树 的点击事件
                //alert(node.attributes.url);  // alert node text property when clicked
                //接下来是添加一个tab
                $('#tabs').tabs('add', {
                    title: node.text,
                    iconCls:'icon-ok',
                    //content: 'asdfsdfsdfsdfsd',
                    href:'/home/usermanger',
                    closable: true
                }); 
            }
        });

//        $('#tabs').tabs('add', { title: 'New Tab', content: 'Tab Body' }); //easyui 的控件的 方法使用
//        $('#tabs').tabs({onBeforeClose: function (title) {return confirm('Are you sure you want to close ' + title); }});//easyui 事件调用
//        $('#tt').tabs({tools: '#tab-tools'});//easyui 修改属性

    </script>
</body>
</html>
