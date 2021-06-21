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

        public List<Profess> GetList()
        {
            return professDAL.GetProfessList();
        }

        public List<Profess> GetListWhere(int col_id)
        {
            return professDAL.GetProfessListWhere(col_id);
        }

        public bool Add(Profess profess)
        {
            return professDAL.Add(profess);
        }

        public bool DelById(string id)
        {
            return professDAL.DelById(id);
        }

        public bool Update(Profess profess)
        {
            return professDAL.Update(profess);
        }

        public DataTable GetDataTableViewWhere(College college, Profess profess)
        {
            return professDAL.GetDataTableViewWhere(college, profess);
        }

        public DataTable GetDataTableView()
        {
            return professDAL.GetDataTableView();
        }

        public void GetById(Profess profess)
        {
            professDAL.GetById(profess);
        }
    }
}
