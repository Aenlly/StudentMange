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

        string sql = "";

        /// <summary>
        /// 查询全部学生信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
             sql = "select * from V_Student";
            return SqlDbHelper.ExecuteQuery(sql);
        }

        public DataTable GetDataTableViewWhere(Model.Student student)
        {
             sql = "select * from V_Student where stu_id like @stu_id and stu_name like @stu_name and stu_tel like @stu_tel";

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
        public bool DelById(string stu_id)
        {
            sql = "delete from student where stu_id=@stu_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@stu_id", stu_id) };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据学号获得学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Model.Student GetById(Model.Student student)
        {
            sql = "select * from student where stu_id=@stu_id";
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
            if (data.Rows[0][11].ToString() != null && !data.Rows[0][11].ToString().Equals(""))
                student.Col_id = int.Parse(data.Rows[0][11].ToString());
            else
                student.Col_id = -1;
            if (data.Rows[0][12].ToString() != null && !data.Rows[0][12].ToString().Equals(""))
                student.Pro_id = int.Parse(data.Rows[0][12].ToString());
            else
                student.Pro_id = -1;
            if (data.Rows[0][13].ToString() != null && !data.Rows[0][13].ToString().Equals(""))
                student.Cla_id = int.Parse(data.Rows[0][13].ToString());
            else
                student.Cla_id = -1;

            return student;
        }

        /// <summary>
        /// 根据班级id与姓名获得学生班级展示视图
        /// </summary>
        /// <param name="id">班级id</param>
        /// <param name="name">学生姓名</param>
        /// <returns></returns>
        public DataTable GetStudentByProIdView(string id,string name)
        {
            sql = "select * from V_studentByPro where cla_id=@cla_id and stu_name like @stu_name";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cla_id",id),
                new SqlParameter("@stu_name","%"+name+"%")
              };
            return SqlDbHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// 无班级时显示的视图
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetStudentByStuIdView(string id)
        {
            sql = "select * from V_StudentByPro where stu_id=@stu_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stu_id",id)
            };
            return SqlDbHelper.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// 判断该学院是否有学生
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsColCount(string col)
        {
            sql = "select count(*) from student where  col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@col_id",col)
            };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql, parameters).ToString()) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 判断该专业是否有学生
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool IsProCount(string pro)
        {
            sql = "select count(*) from student where pro_id=@pro_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@pro_id",pro)
            };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql, parameters).ToString()) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 判断该班级是否有学生
        /// </summary>
        /// <param name="cla"></param>
        /// <returns></returns>
        public bool IsClaCount(string cla)
        {
            sql = "select count(*) from student where cla_id=@cla_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@cla_id",cla)
            };
            if (int.Parse(SqlDbHelper.ExecuteScalar(sql, parameters).ToString()) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 管理员更新学生信息
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns></returns>
        public bool Update(Model.Student student)
        {
            sql = "update student set stu_head=@stu_head,stu_name=@stu_name,stu_sex=@stu_sex," +
                "stu_birth=@stu_birth,stu_edu=@stu_edu,stu_tel=@stu_tel,stu_pwd=@stu_pwd,stu_address=@stu_address" +
                ",stu_origin=@stu_origin,stu_time=@stu_time,@col_id=@col_id,cla_id=@cla_id,pro_id=@pro_id where stu_id=@stu_id";
            SqlParameter[] parameters = new SqlParameter[]
            {
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
                new SqlParameter("@cla_id", student.Cla_id),
                new SqlParameter("@pro_id", student.Pro_id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 按班级更新学生信息
        /// </summary>
        /// <param name="student">学生信息</param>
        /// <returns></returns>
        public bool UpdateByClaId(Model.Student student,string cla_id)
        {
            sql = "update student set col_id=@col_id,pro_id=@pro_id,cla_id=@cla_id where cla_id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@col_id", student.Col_id),
                new SqlParameter("@pro_id", student.Pro_id),
                new SqlParameter("@cla_id", student.Cla_id),
                new SqlParameter("@id", cla_id)
            };

            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) !=-1)
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
            sql = "select count(*) from student where stu_id=@stu_id and stu_pwd=@stu_pwd";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@stu_id",student.Stu_id),
                new SqlParameter("@stu_pwd",student.Stu_pwd) };
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
            sql = "select count(*) from student where stu_id=@stu_id and stu_name=@stu_name and stu_tel=@stu_tel";
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
        public bool Add(Model.Student student)
        {
            sql = "insert into student([stu_head],[stu_name],[stu_sex],[stu_birth],[stu_edu],[stu_tel],[stu_address],[stu_origin],[stu_time],[col_id],[pro_id],[cla_id]) values " +
                "(@stu_head,@stu_name,@stu_sex,@stu_birth,@stu_edu,@stu_tel,@stu_address,@stu_origin,@stu_time,@col_id,@pro_id,@cla_id)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@stu_head",student.Stu_head),
                new SqlParameter("@stu_name", student.Stu_name),
                new SqlParameter("@stu_sex", student.Stu_sex),
                new SqlParameter("@stu_birth", student.Stu_birth),
                new SqlParameter("@stu_edu", student.Stu_edu),
                new SqlParameter("@stu_tel", student.Stu_tel),
                new SqlParameter("@stu_address", student.Stu_address),
                new SqlParameter("@stu_origin", student.Stu_origin),
                new SqlParameter("@stu_time", student.Stu_time),
                new SqlParameter("@col_id", student.Col_id),
                new SqlParameter("@pro_id", student.Pro_id),
                new SqlParameter("@cla_id", student.Cla_id)
            };
            if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 根据学号进行更新学生信息，学生自主更新使用
        /// </summary>
        /// <param name="tel">需要更新的手机号</param>
        /// <param name="pwd">需要更新的密码</param>
        /// <param name="address">需要更新的家庭地址</param>
        /// <param name="id">条件学号</param>
        /// <returns></returns>
        public int Update(string tel,string pwd,string address,string id)
        {
            string sql_tel = "";
            string sql_pwd = "";
            string sql_address = "";
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter("@stu_id",id)
            };
            if (tel!=null&&!tel.Equals(""))
            {
                sql_tel = "stu_tel=@stu_tel";
                list.Add(new SqlParameter("@stu_tel", tel));
            }
            if (pwd != null && !pwd.Equals(""))
            {
                sql_pwd = (sql_tel.Equals("")?"":",")+"stu_pwd=@stu_pwd";
                list.Add(new SqlParameter("@stu_pwd", pwd));
            }
            if (address != null && !address.Equals(""))
            {
                sql_address = (sql_pwd.Equals("") ? "" : ",")+"stu_address=@stu_address";
                list.Add(new SqlParameter("@stu_address", address));
            }
            sql = "update student set " + sql_tel + sql_pwd + sql_address + " where stu_id=@stu_id";
            if(tel != null && !tel.Equals("")&& pwd != null && !pwd.Equals("")&& address != null && !address.Equals(""))
            {
                SqlParameter[] parameters = list.ToArray();
                if (SqlDbHelper.ExecuteNonQuery(sql, parameters) > 0)
                    return 1;//更新成功
                 return -1;//更新失败
            }
            return 0;//全部为空
        }
    }
}