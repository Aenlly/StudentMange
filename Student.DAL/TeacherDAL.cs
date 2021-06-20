using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Student.DAL
{

    public class TeacherDAL
    {
        public List<Model.Teacher> GetInstructorList()
        {
            List<Model.Teacher> list = new List<Model.Teacher>();
            string sql = "select * from teacher";
            DataTable data=SqlDbHelper.ExecuteQuery(sql);
            for(int i = 0; i < data.Rows.Count; i++)
            {
                Model.Teacher teacher = new Model.Teacher();
                teacher.Tea_id = int.Parse(data.Rows[i][0].ToString());
                teacher.Tea_name = data.Rows[i][1].ToString();
                teacher.Tea_tel = data.Rows[i][2].ToString();
                teacher.Tea_address = data.Rows[i][3].ToString();
                teacher.Col_id = int.Parse(data.Rows[i][4].ToString());
                list.Add(teacher);
            }
            return list;
        }
    }
}
