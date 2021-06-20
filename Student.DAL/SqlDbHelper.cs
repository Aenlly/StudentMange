using System;
using System.Data;
using System.Data.SqlClient;

namespace Student.DAL
{
    class SqlDbHelper
    {
        private static DButil dButil;
        private static SqlConnection con;//创建数据库连接对象

        static SqlDbHelper()
        {
            dButil = new DButil();

        }

        /// <summary>
        /// 数据库查询方法
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>返回DataTable类型</returns>
        public static DataTable ExecuteQuery(string sql)
        {
            return ExecuteQuery(sql, null);
        }

        /// <summary>
        /// 数据库查询方法，带参
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameters">参数数组</param>
        /// <returns>返回DataTable类型</returns>
        public static DataTable ExecuteQuery(string sql,SqlParameter[] parameters)
        {
            con = dButil.SqlOpen();//打开//储存需要执行的sql语句数据库
            SqlCommand cmd = new SqlCommand(sql,con);//储存sql语句
            cmd.CommandType = CommandType.Text;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                adapter.Fill(dt);
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        /// <summary>
        /// 数据库增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, null);
        }

        /// <summary>
        /// 数据库增删改操作，带参
        /// </summary>
        /// <param name="sql">执行语句</param>
        /// <param name="parameter">参数数组</param>
        /// <returns>返回成功行数</returns>
        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            int n = 0;
            con = dButil.SqlOpen();//打开//储存需要执行的sql语句数据库
            SqlCommand cmd = new SqlCommand(sql,con);//储存sql语句
            cmd.CommandType = CommandType.Text;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            try
            {
                n = cmd.ExecuteNonQuery();//执行sql语句   
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();//关闭数据库
            }
            return n;
        }

        /// <summary>
        /// 查询数据库首行首列
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <returns>返回首行首列值</returns>
        public static object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, null);
        }

        /// <summary>
        /// 查询数据库首行首列，带参
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="parameter">查询参数</param>
        /// <returns>返回首行首列值</returns>
        public static object ExecuteScalar(string sql, SqlParameter[] parameters)
        {
            object obj = 0;
            con = dButil.SqlOpen();//打开数据库
            SqlCommand cmd = new SqlCommand(sql, con);//储存需要执行的sql语句
            cmd.CommandType = CommandType.Text;
            if (parameters != null)
                cmd.Parameters.AddRange(parameters);
            try
            {
                obj = cmd.ExecuteScalar(); //赋值查询到的第一行第一列内容
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();//关闭数据库
            }
            return obj;
        }
    }
}
