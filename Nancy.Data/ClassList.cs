using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Data;

namespace Nancy.Data
{
    /// <summary>
    /// 用户类
    /// </summary>
     public class SysUser
    {
         /// <summary>
         /// 编号
         /// </summary>
         public string Id { get; set; }
         /// <summary>
         /// 用户Id
         /// </summary>
         public string userId { get; set; }
         /// <summary>
         /// 用户密码
         /// </summary>
         public string userPwd { get; set; }
    }
}
