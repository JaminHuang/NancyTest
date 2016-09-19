using System.Data;

namespace Nancy.Data
{
    public class SysUserService
    {
        /// <summary>
        ///     验证UserId是否存在
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>True/False</returns>
        public bool isUserId(string userId)
        {
            string sql = string.Format("SELECT * FROM SysUser WHERE UserId='{0}'", userId);
            DataTable dt = SqlHelperServer.ExecuteQuery(sql);
            if (dt.Rows.Count <= 0)
                return false;
            return true;
        }

        /// <summary>
        ///     获取UserPwd
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>密码信息</returns>
        public string GetUserPwd(string userId)
        {
            string sql = string.Format("SELECT UserPwd FROM SysUser WHERE UserId='{0}'", userId);
            DataTable dt = SqlHelperServer.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["UserPwd"].ToString();
            }
            return null;
        }

        /// <summary>
        ///     获取用户列表信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetUser()
        {
            string sql = string.Format("SELECT * FROM SysUser ");
            DataTable dt = SqlHelperServer.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public DataTable GetUserByUserId(string userId)
        {
            string sql = string.Format("SELECT * FROM SysUser WHERE UserId='{0}'",userId);
            DataTable dt = SqlHelperServer.ExecuteQuery(sql);
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        ///     重置密码
        /// </summary>
        /// <param name="UserId">用户ID</param>
        /// <returns></returns>
        public bool ReBackPwd(string UserId)
        {
            string sql = string.Format("UPDATE SysUser SET UserPwd='123456' WHERE UserId='{0}'", UserId);
            int k = SqlHelperServer.ExecuteNonQuery(sql);
            if (k > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     修改密码
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="userPwd">用户Pwd</param>
        /// <returns></returns>
        public bool UpdateUser(string userId, string userPwd)
        {
            string sql = string.Format("UPDATE SysUser SET UserPwd='{1}' WHERE UserId='{0}'", userId, userPwd);
            int k = SqlHelperServer.ExecuteNonQuery(sql);
            if (k > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     删除用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            string sql = string.Format("DELETE SysUser WHERE  UserId='{0}'", userId);
            int k = SqlHelperServer.ExecuteNonQuery(sql);
            if (k > 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户类型</param>
        /// <returns></returns>
        public bool AddUser(SysUser user)
        {
            string sql = string.Format("INSERT INTO SysUser(UserId,UserPwd) VALUES('{0}','{1}')",user.userId,user.userPwd);
            int k = SqlHelperServer.ExecuteNonQuery(sql);
            if (k > 0)
            {
                return true;
            }
            return false;
        }
    }
}