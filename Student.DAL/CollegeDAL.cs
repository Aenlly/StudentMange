using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Student.DAL
{
    public class CollegeDAL
    {
        /// <summary>
        /// 获得学院的所有信息
        /// </summary>
        /// <returns></returns>
        public List<Model.College> GetCollegeList()
        {
            List<Model.College> list = new List<Model.College>();
            string sql = "select * from college";
            DataTable data=SqlDbHelper.ExecuteQuery(sql);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                Model.College college = new Model.College();
                college.Col_id=int.Parse(data.Rows[i][0].ToString());
                college.Col_names = data.Rows[i][1].ToString();
                list.Add(college);
            }
            return list;
        }
    }
}
