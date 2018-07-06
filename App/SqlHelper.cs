using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class SqlHelper
    {
        private static readonly string conStr = string.Format("server=111.231.196.14,9911;database=FXTLServer;uid=sa;pwd=xingcheng0116,.;");//ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        //执行增删改的
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        //封装一个执行返回单个值的方法
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        //返回SqlDataReader对象的方法

        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        { 
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    //这里第二个参数代表在函数外部，如果掉了close()方法，则con会随之一起销毁
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        public static SqlDataReader ExecuteReader(string sql)
        {
            SqlConnection con = new SqlConnection(conStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        //封装一个返回DataTable的方法
        public static DataTable ExecuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }

            return dt;
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conStr))
            {
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
