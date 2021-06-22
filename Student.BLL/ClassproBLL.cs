using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.BLL
{
    public class ClassproBLL
    {
        private DAL.ClassproDAL classproDAL = new DAL.ClassproDAL();

        /// <summary>
        /// 获得班级的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Classpro> GetList()
        {
            return classproDAL.GetList();
        }

        /// <summary>
        /// 按专业获得班级信息列表
        /// </summary>
        /// <param name="pro_id">专业id</param>
        /// <returns></returns>
        public List<Classpro> GetListWhere(int pro_id)
        {
            return classproDAL.GetListWhere(pro_id);
        }

        /// <summary>
        /// 获得班级的条件显示视图
        /// </summary>
        /// <param name="teacher">老师</param>
        /// <param name="college">学院</param>
        /// <param name="profess">专业</param>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(Teacher teacher, College college, Profess profess,Classpro classpro)
        {
            return classproDAL.GetDataTableViewWhere(teacher, college, profess, classpro);
        }

        /// <summary>
        /// 获得班级的显示视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            return classproDAL.GetDataTableView();
        }

        /// <summary>
        /// 获得指定id的班级信息
        /// </summary>
        /// <param name="classpro"></param>
        public void GetById(Classpro classpro)
        {
            classproDAL.GetById(classpro);
        }

        /// <summary>
        /// 添加班级方法
        /// </summary>
        /// <param name="classpro"></param>
        /// <returns></returns>
        public bool Add(Classpro classpro)
        {
            return classproDAL.Add(classpro);
        }

        /// <summary>
        /// 修改班级方法
        /// </summary>
        /// <param name="classpro"></param>
        /// <returns></returns>
        public bool Update(Classpro classpro)
        {
            return classproDAL.Update(classpro);
        }


        /// <summary>
        /// 根据班级id删除班级信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            return classproDAL.DelById(id);
        }
    }
}
