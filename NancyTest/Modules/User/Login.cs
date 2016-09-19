using System.Data;
using System.IO;
using Nancy;
using Nancy.Data;
using Nancy.ModelBinding;

namespace NancyTest.Module
{
    public class Login : NancyModule
    {
        private SysUserService userService = new SysUserService();
        public Login()
        {
            #region 登录——表单验证,成功跳转至主页面

            Post["/Home"] = p =>
            {
                //获取表单
                var user = SqlHelperServer.ToDBValue(Request.Form);
                //验证用户名是否存在
                if (!userService.isUserId(user.userId))
                {
                    return "<script>alert('用户名不存在！');location.href='/'</script>";
                }
                //验证密码输入是否正确
                if (userService.GetUserPwd(user.userId) != user.userPwd)
                {
                    return "<script>alert('密码错误！');location.href='/'</script>";
                }
                if (user.verifity != Session["Code"].ToString())
                {
                    return "<script>alert('验证码错误！');location.href='/'</script>";
                }
                ViewBag.UserId = user.userId;
                DataTable dt = userService.GetUser();
                return View["User/Home.cshtml", dt.Rows];
            };

            #endregion

            #region 获取验证码

            Get["/CreateCode"] = p =>
            {
                var Code = new CreatCode();
                string verifity = Code.CreateValidateCode(5);
                Session["Code"] = verifity;
                byte[] bytes = Code.CreateValidateGraphic(verifity);
                var ms = new MemoryStream(bytes);
                ms.Flush();
                ms.Position = 0;
                return Response.FromStream(ms, @"images/jpg");
            };

            #endregion

            #region 密码还原

            Get["/Options/{userId}"] = p =>
            {
                if (userService.ReBackPwd(p.userId))
                {
                    DataTable dt = userService.GetUser();
                    return View["User/Home.cshtml", dt.Rows];
                }
                return "<script>alert('密码错误！');location.href='/Home'</script>";
            };

            #endregion

            #region 删除用户

            Get["/Delete/{userId}"] = p =>
            {
                if (userService.DeleteUser(p.userId))
                {
                    DataTable dt = userService.GetUser();
                    return View["User/Home.cshtml", dt.Rows];
                }
                return "<script>alert('操作失败！');location.href='/Home'</script>";
            };

            #endregion

            #region 新增用户

            Post["/AddUser"] = p =>
            {
                var user = this.Bind<SysUser>();
                if (userService.AddUser(user))
                {
                    return "<script>alert('用户新增成功！');location.href='/Home'</script>";
                }
                return View["User/Home.cshtml"];
            };

            #endregion

            #region 修改用户

            Post["/AddUser/{userId}"] = p =>
            {
                DataTable dt = new DataTable();
                dt = userService.GetUserByUserId(p.userId);
                return View["User/UserManagent.cshtml",dt.Rows];
            };

            #endregion
        }
    }
}