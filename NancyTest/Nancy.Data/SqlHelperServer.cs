using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Nancy.Data
{
    public static class SqlHelperServer
    {
        private static SqlConnection _Conn;
        /// <summary>
        /// 获取一个SQL连接
        /// </summary>
        private static void GetConn()
        {
            if (_Conn == null)
                _Conn = new SqlConnection();//如果是null,则新建一个连接
            //判断链接是否打开
            if (_Conn.State != ConnectionState.Open)
            {
                _Conn.ConnectionString = ConfigurationManager.AppSettings["MvcTest"];//建立数据库连接
                _Conn.Open();//打开链接
            }
        }

        public static object ToDBValue(this object value)
        {
            return value == null ? DBNull.Value : value;
        }
        /// <summary>
        /// 执行SQL查询类语句
        /// </summary>
        /// <param name="sql">参数：查询语句</param>
        /// <returns>返回查询结果</returns>
        public static DataTable ExecuteQuery(string sql)
        {
            GetConn();
            SqlDataAdapter sda = new SqlDataAdapter(sql,_Conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds.Tables[0];
        }
        /// <summary>
        /// 执行SQL非查询类语句
        /// </summary>
        /// <param name="sql">参数：非查询语句</param>
        /// <returns>返回受影响的行数</returns>
        public static int ExecuteNonQuery(string sql)
        {
            GetConn();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _Conn;
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }
        public static SqlDataReader ExecuteQueryToReader(string sql)
        {
            GetConn();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _Conn;
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }
    }
}
