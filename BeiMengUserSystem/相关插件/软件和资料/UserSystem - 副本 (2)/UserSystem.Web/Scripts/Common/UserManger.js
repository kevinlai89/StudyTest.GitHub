function AddUser() {
    //$.messager.alert('Warning', '你真的添加吗！');
    var name = $('#name').val();
    var pwd = $('#pwd').val();
    var tec = $('#tec').val();

    if (name == '' || pwd == '') {
        $.messager.alert('Warning', '用户名或者密码为空！');
    }
    else {
        $.post("/Account/AddUser", { name: name, pwd: pwd },
           function (data) {
               //alert("Data Loaded: " + data);
               if (data == '0') {
                   $.messager.alert('Warning', '添加失败！');
               }
               else {
                   $.messager.alert('Warning', '添加成功！');
                   $('#dg').datagrid('reload', {
                       code: '01',
                       name: 'name01'
                   });
               }
           });
    }
}