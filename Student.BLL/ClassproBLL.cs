using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.BLL
{
    public class ClassproBLL
    {
        private DAL.ClassproDAL classproDAL = new DAL.ClassproDAL();

        /// <summary>
        /// 获得班级的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Model.Classpro> GetClassproList()
        {
            return classproDAL.GetClassproList();
        }

        /// <summary>
        /// 按专业获得班级信息列表
        /// </summary>
        /// <param name="pro_id">专业id</param>
        /// <returns></returns>
        public List<Model.Classpro> GetClassproListWhere(int pro_id)
        {
            return classproDAL.GetClassproListWhere(pro_id);
        }
    }
}
