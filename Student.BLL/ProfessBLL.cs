using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.BLL
{
    public class ProfessBLL
    {
        private DAL.ProfessDAL professDAL = new DAL.ProfessDAL();

        public List<Model.Profess> GetProfessList()
        {
            return professDAL.GetProfessList();
        }

        public List<Model.Profess> GetProfessListWhere(int col_id)
        {
            return professDAL.GetProfessListWhere(col_id);
        }
    }
}
