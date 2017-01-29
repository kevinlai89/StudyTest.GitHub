function Login() {
    var name = $('#name').val();
    var pwd = $('#pwd').val();
    //做一层验证
    if (name == '') {
        alert('用户名不能为空!');
    }
    else {
        $.post("/account/DoLogin", { "name": name, "pwd": pwd }, //www.bamn.cn/dologin?name=admin&pwd=sadf
           function (data) {
               if (data == '-2') {
                   //alert('!');
                   $('#showInfo').html("用户名或者密码错误!");
               }
               else if (data == '-1') {
                   //alert('!');
                   $('#showInfo').html("用户名为空!");
               }
               else {
                   $('#showInfo').html("登录成功!");
                   window.location.href = "/home/index";
               }
           });
    }
   }

   function logoff() {
       $.messager.confirm('My Title', 'Are you confirm this?', function (r) {
           if (r) {
               $.post("/account/DoLogoff",
               function (data) {
                   if (data == '-1') {
                       alert("注销失败");
                   }
                   else {
                       alert("注销成功");
                       window.location.href = "/account/login";
                   }
               });
           }
       });

      
   }