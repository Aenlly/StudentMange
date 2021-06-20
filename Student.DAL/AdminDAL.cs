using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Student.DAL
{
    public class AdminDAL
    {
        /// <summary>
        /// 管理员登录判断
        /// </summary>
        /// <param name="admin">管理员登录信息</param>
        /// <returns>成功true，失败false</returns>
        public bool Login(Model.Admin admin)
        {
            string sql = "select count(*) from admin where adm_tel=@adm_tel and adm_pwd=@adm_pwd";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@adm_tel",admin.Adm_tel),
                new SqlParameter("@adm_pwd",admin.Adm_pwd) };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql,parameters).ToString()) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 利用手机号查询一条管理员信息
        /// </summary>
        /// <param name="admin">管理员信息</param>
        /// <returns>查询到的管理员信息</returns>
        public Model.Admin GetAdminOne(Model.Admin admin)
        {
            string sql = "select * from admin where adm_tel=@adm_tel";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@adm_tel",admin.Adm_tel)
            };
            DataTable dt=SqlDbHelper.ExecuteQuery(sql, parameters);
            admin.Adm_id=dt.Rows[0][0].ToString();
            admin.Adm_name = dt.Rows[0][1].ToString();
            admin.Adm_tel = dt.Rows[0][3].ToString();
            return admin;
        }

    }
}
