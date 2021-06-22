using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.DAL
{

    public class TeacherDAL
    {
        string sql = "";

        /// <summary>
        /// 获得全部辅导员信息的视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            sql = "select * from V_Teacher";
            return SqlDbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 按条件获得辅导员视图
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(Teacher teacher)
        {
            sql = "select * from V_Teacher where tea_name like @tea_name ";
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@tea_name","%"+teacher.Tea_name+"%")
            };
            if (teacher.Col_id != -1) { 
                sql += " and col_id=@col_id";
                list.Add(new SqlParameter("@col_id", teacher.Col_id));
            }
            SqlParameter[] parameters = list.ToArray();
            return SqlDbHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// 根据id获得辅导员信息
        /// </summary>
        /// <param name="teacher"></param>
        public void GetById(Teacher teacher)
        {
            sql = "select * from teacher where tea_id=@tea_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tea_id",teacher.Tea_id)
            };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);
            teacher.Tea_name = data.Rows[0][1].ToString();
            teacher.Tea_tel = data.Rows[0][2].ToString();
            teacher.Tea_address = data.Rows[0][3].ToString();
            if (teacher.Col_id.Equals("") && teacher.Col_id.ToString() != null)
                teacher.Col_id = int.Parse(data.Rows[0][4].ToString());
            else
                teacher.Col_id = -1;
        }

        /// <summary>
        /// 添加辅导员信息
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool Add(Teacher teacher)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@tea_name",teacher.Tea_name),
                new SqlParameter("@tea_tel",teacher.Tea_tel),
                new SqlParameter("@tea_address",teacher.Tea_address)
            };
            string col = "null";
            if (teacher.Col_id != -1)
            {
                col = "@col_id";
                list.Add(new SqlParameter("@col_id", teacher.Col_id));
            }
            sql = "insert into teacher(tea_name,tea_tel,tea_address,col_id) values(@tea_name,@tea_tel,@tea_address," + col + ")";
            SqlParameter[] parameters = list.ToArray();
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 更新辅导员信息
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool Update(Teacher teacher)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@tea_name",teacher.Tea_name),
                new SqlParameter("@tea_tel",teacher.Tea_tel),
                 new SqlParameter("@tea_id",teacher.Tea_id),
                new SqlParameter("@tea_address",teacher.Tea_address)
            };
            string tea = "";
            if (teacher.Col_id != -1)
            {
                tea = ",col_id=@col_id";
                list.Add(new SqlParameter("@col_id", teacher.Col_id));
            }
            sql = "update teacher set tea_name=@tea_name,tea_tel=@tea_tel,tea_address=@tea_address" + tea + " where tea_id=@tea_id";
            SqlParameter[] parameters = list.ToArray();
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据id删除辅导员
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            sql = "delete from teacher where tea_id=@tea_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tea_id",id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获得全部辅导员信息列表
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetList()
        {
            List<Teacher> list = new List<Teacher>();//初始化列表
            sql = "select * from teacher";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Teacher teacher = new Teacher
                {
                    Tea_id = int.Parse(data.Rows[i][0].ToString()),
                    Tea_name = data.Rows[i][1].ToString()
                };
                list.Add(teacher);
            }
            return list;
        }
    }
}
