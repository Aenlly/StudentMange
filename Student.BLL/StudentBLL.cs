using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.BLL
{
    public class StudentBLL
    {
        DAL.StudentDAL studentDAL=new DAL.StudentDAL();

        /// <summary>
        /// 获得全部学生学籍信息视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudentDataTableView()
        {
            return studentDAL.GetStudentDataTableView();
        }

        /// <summary>
        /// 条件获得学生学籍信息视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetStudentDataTableViewWhere(Model.Student student)
        {
            return studentDAL.GetStudentDataTableViewWhere(student);
        }

        /// <summary>
        /// 学生登录判断
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public bool Login(Model.Student student)
        {
            return studentDAL.Login(student);
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool RetPwd(Model.Student student)
        {
            return studentDAL.RetPwd(student);
        }

        /// <summary>
        /// 添加学生学籍信息
        /// </summary>
        /// <param name="student">学生学籍信息</param>
        /// <returns>-1已存在，0未添加成功，1添加成功</returns>
        public bool AddStudent(Model.Student student)
        {
            return studentDAL.AddStudent(student);
        }

        /// <summary>
        /// 删除学籍信息
        /// </summary>
        /// <param name="stu_id"></param>
        /// <returns></returns>
        public bool DelStudent(string stu_id)
        {
            return studentDAL.DelStudent(stu_id);
        }

        /// <summary>
        /// 按Id获得学籍信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Model.Student GetStudentById(Model.Student student)
        {
            return studentDAL.GetStudentById(student);
        }

        public bool UpdateStudent(Model.Student student)
        {
            return studentDAL.UpdateStudent(student);
        }
    }
}
