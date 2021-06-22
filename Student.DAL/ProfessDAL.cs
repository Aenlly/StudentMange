using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Student.Model;

namespace Student.DAL
{
    public class ProfessDAL
    {
        /// <summary>
        /// 获得专业信息列表
        /// </summary>
        /// <returns></returns>
        public  List<Profess> GetProfessList()
        {
            List<Profess> list = new List<Profess>();
            string sql = "select * from profess";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Profess profess = new Profess
                {
                    Pro_id = int.Parse(data.Rows[i][0].ToString()),
                    Col_id = int.Parse(data.Rows[i][1].ToString()),
                    Pro_name = data.Rows[i][2].ToString()
                };
                list.Add(profess);
            }
            return list;
        }

        /// <summary>
        /// 添加专业信息
        /// </summary>
        /// <param name="profess">专业信息</param>
        /// <returns></returns>
        public bool Add(Profess profess)
        {
            string sql = "insert into profess(pro_name,col_id) values(@pro_name,@col_id)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_name",profess.Pro_name),
                new SqlParameter("@col_id",profess.Col_id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据id删除专业信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            string sql = "delete from profess where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_id",id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 更新专业信息
        /// </summary>
        /// <param name="profess"></param>
        /// <returns></returns>
        public bool Update(Profess profess)
        {
            string sql = "update profess set pro_name=@pro_name,col_id=@col_id where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_name",profess.Pro_name),
                new SqlParameter("@pro_id",profess.Pro_id),
                new SqlParameter("@col_id",profess.Col_id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据学院id获得专业信息列表
        /// </summary>
        /// <param name="col_id"></param>
        /// <returns></returns>
        public List<Profess> GetProfessListWhere(int col_id)
        {
            List<Profess> list = new List<Profess>();
            string sql = "select * from profess where col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@col_id", col_id) };
            DataTable data = SqlDbHelper.ExecuteQuery(sql,parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Profess profess = new Profess
                {
                    Pro_id = int.Parse(data.Rows[i][0].ToString()),
                    Col_id = int.Parse(data.Rows[i][1].ToString()),
                    Pro_name = data.Rows[i][2].ToString()
                };
                list.Add(profess);
            }
            return list;
        }

        /// <summary>
        /// 根据学院，专业信息条件获得专业信息视图
        /// </summary>
        /// <param name="college"></param>
        /// <param name="profess"></param>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(College college, Profess profess)
        {
            string sql = "select * from V_Profess where pro_name like @pro_name and col_names like @col_names";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_name","%"+profess.Pro_name+"%"),
                new SqlParameter("@col_names","%"+college.Col_names+"%")
            };
            return SqlDbHelper.ExecuteQuery(sql,parameters);
        }

        /// <summary>
        /// 根据专业编号获得专业信息
        /// </summary>
        /// <param name="profess"></param>
        public void GetById(Profess profess)
        {
            string sql = "select * from profess where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_id",profess.Pro_id)
            };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            profess.Col_id = int.Parse(data.Rows[0][1].ToString());
            profess.Pro_name = data.Rows[0][2].ToString();
        }

        /// <summary>
        /// 获得专业全部信息的视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            string sql = "select * from V_Profess";
            return SqlDbHelper.ExecuteQuery(sql);
        }
    }
}
