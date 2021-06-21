using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.BLL
{
    public class CollegeBLL
    {
        private DAL.CollegeDAL collegeDAL = new DAL.CollegeDAL();

        /// <summary>
        /// 获得学院的所有信息
        /// </summary>
        /// <returns></returns>
        public List<College> GetList()
        {
            return collegeDAL.GetList();
        }


        /// <summary>
        /// 获得学院
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return collegeDAL.GetDataTable();
        }

        /// <summary>
        /// 按条件获得学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public DataTable GetDataTableWhere(College college)
        {
            return collegeDAL.GetDataTableWhere(college);
        }
       
        /// <summary>
        /// 删除学院信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            return collegeDAL.DelById(id);
        }

        /// <summary>
        /// 添加学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public bool Add(College college)
        {
            return collegeDAL.Add(college);
        }

        /// <summary>
        /// 更新学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public bool Update(College college)
        {
            return collegeDAL.Update(college);
        }

        /// <summary>
        /// 按条件查找学院信息
        /// </summary>
        /// <param name="college"></param>
        /// <returns></returns>
        public College GetById(College college)
        {
            return collegeDAL.GetById(college);
        }
    }
}
