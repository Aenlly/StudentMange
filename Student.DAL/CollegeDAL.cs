using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.DAL
{
    public class CollegeDAL
    {

        string sql = "";

        /// <summary>
        /// 获得学院的所有信息
        /// </summary>
        /// <returns></returns>
        public List<College> GetList()
        {
            List<College> list = new List<College>();
            sql = "select * from college";
            DataTable data=SqlDbHelper.ExecuteQuery(sql);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                College college = new College();
                college.Col_id=int.Parse(data.Rows[i][0].ToString());
                college.Col_names = data.Rows[i][1].ToString();
                list.Add(college);
            }
            return list;
        }

        /// <summary>
        /// 获得学院所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            sql = "select c.col_id,col_names,count(s.stu_id) as col_num from college c left join student s on c.col_id=s.col_id group by c.col_id,col_names";
            return SqlDbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 按条件获得学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public DataTable GetDataTableWhere(College college)
        {
            sql = "select c.col_id,col_names,count(s.stu_id) as col_num from college c left join student s on c.col_id=s.col_id where col_names like @col_names group by c.col_id,col_names ";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@col_names","%"+college.Col_names+"%")
            };
            return SqlDbHelper.ExecuteQuery(sql,parameters);
        }

        /// <summary>
        /// 删除学院信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            sql = "delete from college where col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@col_id",id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 添加学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public bool Add(College college)
        {
            sql = "insert into college(col_names) values(@col_names)";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@col_names",college.Col_names)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 更新学院信息2
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public bool Update(College college)
        {
             sql = "update college set col_names=@col_names where col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@col_id",college.Col_id),
                new SqlParameter("@col_names",college.Col_names)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据学院id获得学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public College GetById(College college)
        {
             sql = "select * from college where col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@col_id",college.Col_id)
            };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            college.Col_names = data.Rows[0][1].ToString();
            return college;
        }

    }
}
