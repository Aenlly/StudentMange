using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Student.Model;

namespace Student.BLL
{
    public class ProfessBLL
    {
        private DAL.ProfessDAL professDAL = new DAL.ProfessDAL();

        /// <summary>
        /// 获得专业信息列表
        /// </summary>
        /// <returns></returns>
        public List<Profess> GetList()
        {
            return professDAL.GetProfessList();
        }

        /// <summary>
        /// 根据学院id获得专业信息列表
        /// </summary>
        /// <param name="col_id"></param>
        /// <returns></returns>
        public List<Profess> GetListWhere(int col_id)
        {
            return professDAL.GetProfessListWhere(col_id);
        }

        /// <summary>
        /// 添加专业信息
        /// </summary>
        /// <param name="profess">专业信息</param>
        /// <returns></returns>
        public bool Add(Profess profess)
        {
            return professDAL.Add(profess);
        }

        /// <summary>
        /// 根据id删除专业信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DelById(string id)
        {
            return professDAL.DelById(id);
        }

        /// <summary>
        /// 更新专业信息
        /// </summary>
        /// <param name="profess"></param>
        /// <returns></returns>
        public bool Update(Profess profess)
        {
            return professDAL.Update(profess);
        }

        /// <summary>
        /// 根据学院，专业信息条件获得专业信息视图
        /// </summary>
        /// <param name="college"></param>
        /// <param name="profess"></param>
        /// <returns></returns>
        public DataTable GetDataTableViewWhere(College college, Profess profess)
        {
            return professDAL.GetDataTableViewWhere(college, profess);
        }

        /// <summary>
        /// 获得专业全部信息的视图
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableView()
        {
            return professDAL.GetDataTableView();
        }

        /// <summary>
        /// 根据专业编号获得专业信息
        /// </summary>
        /// <param name="profess"></param>
        public void GetById(Profess profess)
        {
            professDAL.GetById(profess);
        }
    }
}
