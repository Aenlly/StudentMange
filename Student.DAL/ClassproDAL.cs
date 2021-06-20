using Student.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Student.DAL
{
    public class ClassproDAL
    {
        /// <summary>
        /// 获得班级的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Model.Classpro> GetClassproList()
        {
            List<Model.Classpro> list = new List<Model.Classpro>();
            string sql = "select * from classpro";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Model.Classpro classpro = new Model.Classpro();
                classpro.Cla_id = int.Parse(data.Rows[i][0].ToString());
                classpro.Cla_name = data.Rows[i][1].ToString();
                list.Add(classpro);
            }
            return list;
        }

        /// <summary>
        /// 按专业获得班级信息列表
        /// </summary>
        /// <param name="pro_id">专业id</param>
        /// <returns></returns>
        public List<Classpro> GetClassproListWhere(int pro_id)
        {
            List<Classpro> list = new List<Classpro>();
            string sql = "select * from classpro where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@pro_id", pro_id) };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Classpro classpro = new Classpro();
                classpro.Cla_id = int.Parse(data.Rows[i][0].ToString());
                classpro.Cla_name = data.Rows[i][1].ToString();
                classpro.Pro_id = int.Parse(data.Rows[i][2].ToString());
                list.Add(classpro);
            }
            return list;
        }
    }
}