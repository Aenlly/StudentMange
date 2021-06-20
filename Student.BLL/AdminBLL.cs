using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.BLL
{
    /// <summary>
    /// 管理员操作
    /// </summary>
    public class AdminBLL
    {
        DAL.AdminDAL adminDAL = new DAL.AdminDAL();

        /// <summary>
        /// 管理员登录判断
        /// </summary>
        /// <param name="admin">管理员登录信息</param>
        /// <returns>true成功，false失败</returns>
        public bool Login(Model.Admin admin)
        {
            return adminDAL.Login(admin);
        }

        /// <summary>
        /// 利用手机号查询一条管理员信息
        /// </summary>
        /// <param name="admin">管理员信息</param>
        /// <returns>查询到的管理员信息</returns>
        public Model.Admin GetAdminOne(Model.Admin admin)
        {
            return adminDAL.GetAdminOne(admin);
        }
    }
}
