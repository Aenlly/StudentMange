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

        public List<Teacher> GetList()
        {
            return teacherDAL.GetList();
        }

        public DataTable GetDataTableView()
        {
            return teacherDAL.GetDataTableView();
        }

        public DataTable GetDataTableViewWhere(Teacher teacher)
        {
            return teacherDAL.GetDataTableViewWhere(teacher);
        }

        public void GetById(Teacher teacher)
        {
            teacherDAL.GetById(teacher);
        }

        public bool Add(Teacher teacher)
        {
            return teacherDAL.Add(teacher);
        }

        public bool Update(Teacher teacher)
        {
            return teacherDAL.Update(teacher);
        }

        public bool DelById(string id)
        {
            return teacherDAL.DelById(id);
        }
    }
}
