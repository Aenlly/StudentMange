using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;
using Student.DAL;

namespace Student.BLL
{
    public class StudentBLL
    {
        StudentDAL studentDAL = new StudentDAL();

        /// <summary>
        /// 获得全部学生学籍信息视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            return studentDAL.GetDataTableView();
        }

        /// <summary>
        /// 条件获得学生学籍信息视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(Model.Student student)
        {
            return studentDAL.GetDataTableViewWhere(student);
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
        /// <returns></returns>
        public bool Add(Model.Student student)
        {
            return studentDAL.Add(student);
        }

        /// <summary>
        /// 删除学籍信息
        /// </summary>
        /// <param name="stu_id"></param>
        /// <returns></returns>
        public bool DelById(string stu_id)
        {
            return studentDAL.DelById(stu_id);
        }

        /// <summary>
        /// 按Id获得学籍信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Model.Student GetById(Model.Student student)
        {
            return studentDAL.GetById(student);
        }

        /// <summary>
        /// 更新学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public bool Update(Model.Student student)
        {
            return studentDAL.Update(student);
        }

        /// <summary>
        /// 按班级进行更新学院、专业、班级的转移
        /// </summary>
        /// <param name="student"></param>
        /// <param name="cla_id">班级编号</param>
        /// <returns></returns>
        public bool UpdateByClaId(Model.Student student,string cla_id)
        {
            return studentDAL.UpdateByClaId(student,cla_id);
        }

        /// <summary>
        /// 判断该学院是否有学生
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsColCount(string col)
        {
            return studentDAL.IsColCount(col);
        }

        /// <summary>
        /// 判断该专业是否有学生
        /// </summary>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool IsProCount(string pro)
        {
            return studentDAL.IsProCount(pro);
        }

        /// <summary>
        /// 判断该班级是否有学生
        /// </summary>
        /// <param name="cla"></param>
        /// <returns></returns>
        public bool IsClaCount(string cla)
        {
            return studentDAL.IsClaCount(cla);
        }

        /// <summary>
        /// 根据学号进行更新学生信息，学生自主更新使用
        /// </summary>
        /// <param name="tel">需要更新的手机号</param>
        /// <param name="pwd">需要更新的密码</param>
        /// <param name="address">需要更新的家庭地址</param>
        /// <param name="id">条件学号</param>
        /// <returns></returns>
        public int Update(string tel, string pwd, string address, string id)
        {
            return studentDAL.Update(tel, pwd, address, id);
        }

        /// <summary>
        /// 获得某个班的所有学生的信息视图
        /// </summary>
        /// <param name="id">班级编号</param>
        /// <param name="name">学生姓名</param>
        /// <returns></returns>
        public DataTable GetStudentByProIdView(string id,string name)
        {
            return studentDAL.GetStudentByProIdView(id,name);
        }

        /// <summary>
        /// 班级不存在，则只显示登录者一个学生信息
        /// </summary>
        /// <param name="id">学号</param>
        /// <returns></returns>
        public DataTable GetStudentByStuIdView(string id)
        {
            return studentDAL.GetStudentByStuIdView(id);
        }
    }
}
