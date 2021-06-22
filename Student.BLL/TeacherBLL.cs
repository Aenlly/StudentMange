using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.BLL
{
    public class TeacherBLL
    {
        DAL.TeacherDAL teacherDAL = new DAL.TeacherDAL();

        /// <summary>
        /// 获得全部辅导员信息列表
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GetList()
        {
            return teacherDAL.GetList();
        }

        /// <summary>
        /// 获得全部辅导员信息的视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            return teacherDAL.GetDataTableView();
        }

        /// <summary>
        /// 根据条件获得辅导员信息视图
        /// </summary>
        /// <param name="teacher">辅导员条件</param>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(Teacher teacher)
        {
            return teacherDAL.GetDataTableViewWhere(teacher);
        }

        /// <summary>
        /// 根据辅导员id获得辅导员信息，并存储在传递过来的参数中
        /// </summary>
        /// <param name="teacher"></param>
        public void GetById(Teacher teacher)
        {
            teacherDAL.GetById(teacher);
        }

        /// <summary>
        /// 辅导员信息添加
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool Add(Teacher teacher)
        {
            return teacherDAL.Add(teacher);
        }

        /// <summary>
        /// 进行更新信息辅导员
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public bool Update(Teacher teacher)
        {
            return teacherDAL.Update(teacher);
        }

        /// <summary>
        /// 根据辅导员id进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            return teacherDAL.DelById(id);
        }
    }
}
