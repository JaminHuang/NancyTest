using Nancy;

namespace NancyTest
{
    public class Home : NancyModule
    {
        public Home()
        {
            #region 跳转主登录界面

            Get["/"] = p => { return View["User/Login/Login.cshtml"]; };

            #endregion
        }
    }
}