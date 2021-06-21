using Student.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student.DAL
{
    public class ClassproDAL
    {

        string sql = "";

        /// <summary>
        /// 获得班级的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Classpro> GetList()
        {
            List<Classpro> list = new List<Classpro>();
            sql = "select * from classpro";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Classpro classpro = new Classpro
                {
                    Cla_id = int.Parse(data.Rows[i][0].ToString()),
                    Cla_name = data.Rows[i][1].ToString()
                };
                list.Add(classpro);
            }
            return list;
        }

        public DataTable GetDataTableViewWhere(Teacher teacher, College college, Profess profess,Classpro classpro)
        {
            sql = "select * from V_Classpro where cla_name like @cla_name and pro_name like @pro_name and col_names like @col_names and tea_name like @tea_name";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cla_name","%"+classpro.Cla_name+"%"),
                new SqlParameter("@col_names","%"+college.Col_names+"%"),
                new SqlParameter("@pro_name","%"+profess.Pro_name+"%"),
                new SqlParameter("@tea_name","%"+teacher.Tea_name+"%")
            };
            DataTable data = SqlDbHelper.ExecuteQuery(sql,parameters);
            return data;
        }

        public DataTable GetDataTableView()
        {
            sql = "select * from V_Classpro";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            return data;
        }

        /// <summary>
        /// 根据id获得班级信息
        /// </summary>
        /// <param name="classpro"></param>
        public void GetById(Classpro classpro)
        {
            sql = "select * from classpro where cla_id=@cla_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cla_id",classpro.Cla_id)
            };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            classpro.Cla_name =data.Rows[0][1].ToString();
            if (data.Rows[0][2].ToString() != null&&!data.Rows[0][3].ToString().Equals(""))
                classpro.Pro_id = int.Parse(data.Rows[0][2].ToString());
            else
                classpro.Pro_id = -1;
            if (data.Rows[0][3].ToString() != null&&!data.Rows[0][3].ToString().Equals(""))
                classpro.Tea_id = int.Parse(data.Rows[0][3].ToString());
            else
                classpro.Tea_id = -1;
        }

        public bool DelById(string id)
        {
            sql = "delete from classpro where cla_id=@cla_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cla_id",id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters)>0)
                return true;
            return false;
        }

        /// <summary>
        /// 添加班级数据
        /// </summary>
        /// <param name="classpro"></param>
        /// <returns></returns>
        public bool Add(Classpro classpro)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@cla_name",classpro.Cla_name),
                new SqlParameter("@pro_id",classpro.Pro_id)
            };
            string tea = "null";
            if (classpro.Tea_id != -1)
            {
                tea = "@tea_id";
                list.Add(new SqlParameter("@tea_id", classpro.Tea_id));
            }
            sql = "insert into classpro(cla_name,pro_id,tea_id) values(@cla_name,@pro_id,"+tea+")";
            SqlParameter[] parameters = list.ToArray();
            if (SqlDbHelper.ExecuteNonQuery(sql,parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 更新班级数据
        /// </summary>
        /// <param name="classpro"></param>
        /// <returns></returns>
        public bool Update(Classpro classpro)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@cla_name",classpro.Cla_name),
                new SqlParameter("@pro_id",classpro.Pro_id),
                new SqlParameter("@cla_id",classpro.Cla_id)
            };
            string tea = "";
            if (classpro.Tea_id != -1) { 
                tea = ",tea_id=@tea_id";
                list.Add(new SqlParameter("tea_id", classpro.Tea_id));
            }
            sql = "update classpro set cla_name=@cla_name,pro_id=@pro_id" + tea + " where cla_id=@cla_id";
            SqlParameter[] parameters = list.ToArray();
            if (SqlDbHelper.ExecuteNonQuery(sql,parameters)>0)
                return true;
            return false;
        }

        /// <summary>
        /// 按专业获得班级信息列表
        /// </summary>
        /// <param name="pro_id">专业id</param>
        /// <returns></returns>
        public List<Classpro> GetListWhere(int pro_id)
        {
            List<Classpro> list = new List<Classpro>();
            sql = "select * from classpro where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@pro_id", pro_id) };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Classpro classpro = new Classpro
                {
                    Cla_id = int.Parse(data.Rows[i][0].ToString()),
                    Cla_name = data.Rows[i][1].ToString(),
                    Pro_id = int.Parse(data.Rows[i][2].ToString())
                };
                list.Add(classpro);
            }
            return list;
        }
    }
}