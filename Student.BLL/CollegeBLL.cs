using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.BLL
{
    public class CollegeBLL
    {
        private DAL.CollegeDAL collegeDAL = new DAL.CollegeDAL();

        /// <summary>
        /// 获得学院的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Model.College> GetCollegeList()
        {
            return collegeDAL.GetCollegeList();
        }
    }
}
