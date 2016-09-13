/*提交表单验证*/
var checkLogin = function() {
    var userId = document.getElementById("user");
    var userPwd = document.getElementById("password");
    var code = document.getElementById("code");
    //验证用户名
    if (userId == null || userId.value == "") {
        error_userId.innerHTML = "<font color='red'>用户名不能为空！</font>";
        userId.focus();
        return false;
    } else {
        var pattern = "^[a-zA-Z][a-zA-Z0-9_@]{4,20}$";
        var check = new RegExp(pattern);
        if (!check.test(userId.value)) {
            error_userId.innerHTML = "<font color='red'>用户名只能为数字，字母和下划线_以及@符号，并且只能以英文开头！</font>";
            userId.focus();
            return false;
        }
    }
    //验证密码
    if (userPwd == null || userPwd.value == "") {
        error_userPwd.innerHTML = "<font color='red'>密码不能为空！</font>";
        userPwd.focus();
        return false;
    }
    //验证码判断
    if (code == null || code.value == "") {
        error_code.innerHTML = "<font color='red'>验证码不能为空！</font>";
        error_code.focus();
        return false;
    }
}

//点击“修改”按钮
function showUpdateDiv() {
    document.getElementById("fade").style.display = 'block';
    document.getElementById("newPwd").value = "";
    document.getElementById("newPwd2").value = "";
    $("#show").fadeIn();
}
//取消修改
function CancelSubmitComment() {
    $("#show").hide();
    $("fade").hide();
}