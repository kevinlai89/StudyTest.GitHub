<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>UserManger</title>
    
</head>
<body>
<script src="../../Scripts/Common/UserManger.js" type="text/javascript"></script>
    <table id="dg" class="easyui-datagrid" style="width:700px;height:250px" data-options="
                            rownumbers:true,
                            singleSelect:true,
                            url:'/account/LoadUser',
                            toolbar:'#tb',
                            fit:true,
                            pagination:true,
				            pageSize:10">
		<thead>
			<tr>
				<th data-options="field:'ID',width:120">用户ID</th>
				<th data-options="field:'Name',width:160">用户名</th>
				<th data-options="field:'Pwd',width:180,align:'right'">用户密码</th>
				<th data-options="field:'AddTime',width:180,align:'right'">添加日期</th>
			</tr>
		</thead>
	</table>

	<div id="tb" style="padding:5px;height:auto">

		<div style="margin-bottom:5px">
			<a href="#" class="easyui-linkbutton" iconCls="icon-add" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-edit" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-save" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-cut" plain="true"></a>
			<a href="#" class="easyui-linkbutton" iconCls="icon-remove" plain="true"></a>
		</div>

		<div>
			用户名: <input type="text" id="name" style="width:80px">
			密　码: <input type="text" id="pwd" style="width:80px">
			技　术: 
			<select id="tec" class="easyui-combobox" panelHeight="auto" style="width:100px">
				<option value="java">Java</option>
				<option value="c">C</option>
				<option value="basic">Basic</option>
				<option value="perl">Perl</option>
				<option value="python">Python</option>
			</select>
			<a href="#" class="easyui-linkbutton" iconCls="icon-search" onclick="AddUser();">添加</a>
		</div>

	</div>

</body>
</html>
