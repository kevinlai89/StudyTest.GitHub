/// <reference path="Login.js" />
function Login() {
    var name = $('#name').val();
    var pwd = $('#pwd').val();

    //做个验证
    if (name == '') {
        alert("用户名不能为空");
    }

    $.post("/account/DoLogin", { name: name, pwd: pwd },
   function (data) {
       if (data == '-2') {
           $('#showInfo').html("用户名或密码错误");
       }
       else if (data == '-1') {
           $('#showInfo').html("用户名为空");
       }
       else {
           $('#showInfo').html("登录成功");
           window.location.href = "/home/index";
       }







   });
}


function logoff() {
    $.messager.confirm('My Title', 'Are you confirm this?', function (r) {
        if (r) {
            alert('confirmed: ' + r);
        }
    });
}