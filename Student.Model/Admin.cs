using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Model
{
    /// <summary>
    /// 管理员实体类
    /// </summary>
    public class Admin
    {
        private string adm_id;      //管理员编号
        private string adm_name;    //管理员姓名
        private string adm_tel;     //手机号
        private string adm_pwd;     //密码

        public string Adm_id { get => adm_id; set => adm_id = value; }
        public string Adm_name { get => adm_name; set => adm_name = value; }
        public string Adm_tel { get => adm_tel; set => adm_tel = value; }
        public string Adm_pwd { get => adm_pwd; set => adm_pwd = value; }
    }
}
