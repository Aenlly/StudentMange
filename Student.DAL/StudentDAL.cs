using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Student.Model;
using System.Data;

namespace Student.DAL
{
    public class StudentDAL
    {
        /// <summary>
        /// 查询全部学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudentDataTableView()
        {
            string sql = "select * from V_Student";
            return SqlDbHelper.ExecuteQuery(sql);
        }


        public DataTable GetStudentDataTableViewWhere(Model.Student student)
        {
            string sql = "select * from V_Student where stu_id like @stu_id and stu_name like @stu_name and stu_tel like @stu_tel";

            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@stu_id", "%" + student.Stu_id + "%"),
            new SqlParameter("@stu_name", "%" + student.Stu_name + "%"),
                new SqlParameter("@stu_tel", "%" + student.Stu_tel + "%")
            };
            if (student.Col_id > 0)
            {
                sql = sql + " and col_id=@col_id";
                list.Add(new SqlParameter("@col_id", student.Col_id));
            }
            if (student.Pro_id > 0)
            {
                sql = sql + " and pro_id=@pro_id";
                list.Add(new SqlParameter("@pro_id", student.Pro_id));
            }
            SqlParameter[] parameters = list.ToArray();

            return SqlDbHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// 删除学生学籍信息
        /// </summary>
        /// <param name="stu_id">学生学号</param>
        /// <returns></returns>
        public bool DelStudent(string stu_id)
        {
            string sql = "delete from student where stu_id=@stu_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@stu_id", stu_id) };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        public Model.Student GetStudentById(Model.Student student)
        {
            string sql = "select * from student where stu_id=@stu_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@stu_id", student.Stu_id) };
            DataTable data = SqlDbHelper.ExecuteQuery(sql, parameters);

            student.Stu_id = data.Rows[0][0].ToString();
            student.Stu_head = data.Rows[0][1].ToString();
            student.Stu_name = data.Rows[0][2].ToString();
            student.Stu_sex = data.Rows[0][3].ToString();
            student.Stu_birth = data.Rows[0][4].ToString();
            student.Stu_edu = data.Rows[0][5].ToString();
            student.Stu_tel = data.Rows[0][6].ToString();
            student.Stu_pwd = data.Rows[0][7].ToString();
            student.Stu_address = data.Rows[0][8].ToString();
            student.Stu_origin = data.Rows[0][9].ToString();
            student.Stu_time = data.Rows[0][10].ToString();
            student.Col_id = int.Parse(data.Rows[0][11].ToString());
            student.Pro_id = int.Parse(data.Rows[0][12].ToString());
            student.Cla_id = int.Parse(data.Rows[0][13].ToString());

            return student;
        }

        public bool UpdateStudent(Model.Student student)
        {
            List<SqlParameter> list = new List<SqlParameter> {
                new SqlParameter("@stu_head",student.Stu_head),
                new SqlParameter("@stu_name", student.Stu_name),
                new SqlParameter("@stu_sex", student.Stu_sex),
                new SqlParameter("@stu_birth", student.Stu_birth),
                new SqlParameter("@stu_edu", student.Stu_edu),
                new SqlParameter("@stu_tel", student.Stu_tel),
                new SqlParameter("@stu_pwd", student.Stu_pwd),
                new SqlParameter("@stu_address", student.Stu_address),
                new SqlParameter("@stu_origin", student.Stu_origin),
                new SqlParameter("@stu_time", student.Stu_time),
                new SqlParameter("@col_id", student.Col_id),
                new SqlParameter("@stu_id", student.Stu_id),
            };
            string cla = "";
            string pro = "";
            if (student.Cla_id != -1)
            {
                list.Add(new SqlParameter("@cla_id", student.Cla_id));
                cla = ",*cla_id=@cla_id";
            }
            if (student.Pro_id != -1)
            {
                list.Add(new SqlParameter("@pro_id", student.Cla_id));
                pro =cla.Equals("")?"":","+"pro_id=@pro_id";
            }
            string sql = "update student set stu_head=@stu_head,stu_name=@stu_name,stu_sex=@stu_sex,stu_birth=@stu_birth,stu_edu=@stu_edu,stu_tel=@stu_tel,stu_pwd=@stu_pwd,stu_address=@stu_address,stu_origin=@stu_origin,stu_time=@stu_time,@col_id=@col_id"+cla+pro+" where stu_id=@stu_id";
            SqlParameter[] parameters = list.ToArray();

            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 学生登录判断
        /// </summary>
        /// <param name="admin">学生登录信息</param>
        /// <returns>成功true，失败false</returns>
        public bool Login(Model.Student student)
        {
            string sql = "select count(*) from student where stu_id=@stu_id and stu_pwd=@stu_pwd";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@stu_id",student.Stu_id),
                new SqlParameter("@stu_pwd",student.Stu_id) };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql, parameters).ToString()) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="student">学生信息参数</param>
        /// <returns></returns>
        public bool RetPwd(Model.Student student)
        {
            string sql = "select count(*) from student where stu_id=@stu_id and stu_name=@stu_name and stu_tel=@stu_tel";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@stu_id", student.Stu_id),
                new SqlParameter("@stu_name", student.Stu_name),
                new SqlParameter("@stu_tel", student.Stu_tel)
            };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql, parameters).ToString()) == 0)
                return false;
            else
            {
                sql = "update from student set stu_pwd='123456' where stu_id=@stu_id";
                if (int.Parse(SqlDbHelper.ExecuteNonQuery(sql).ToString()) <= 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student">所添加的学生信息</param>
        /// <returns></returns>
        public bool AddStudent(Model.Student student)
        {
            string pro_id = "null";
            string cla_id = "null";
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@stu_name", student.Stu_name),
                new SqlParameter("@stu_sex", student.Stu_sex),
                new SqlParameter("@stu_birth", student.Stu_birth),
                new SqlParameter("@stu_edu", student.Stu_edu),
                new SqlParameter("@stu_tel", student.Stu_tel),
                new SqlParameter("@stu_address", student.Stu_address),
                new SqlParameter("@stu_origin", student.Stu_origin),
                new SqlParameter("@stu_time", student.Stu_time),
                new SqlParameter("@col_id", student.Col_id)
            };

            if (student.Pro_id > 0)
            {
                pro_id = "@pro_id";
                list.Add(new SqlParameter("@pro_id", student.Pro_id));
            }
            if (student.Cla_id > 0)
            {
                cla_id = "@cla_id";
                list.Add(new SqlParameter("@cla_id", student.Cla_id));
            }
            string sql = "insert into student([stu_name],[stu_sex],[stu_birth],[stu_edu],[stu_tel],[stu_address],[stu_origin],[stu_time],[col_id],[pro_id],[cla_id]) values " +
                "(@stu_name,@stu_sex,@stu_birth,@stu_edu,@stu_tel,@stu_address,@stu_origin,@stu_time,@col_id," + pro_id + "," + cla_id + ")";
            SqlParameter[] parameters = list.ToArray();
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }
    }
}