using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Student.DAL
{
    public class ProfessDAL
    {
        public  List<Model.Profess> GetProfessList()
        {
            List<Model.Profess> list = new List<Model.Profess>();
            string sql = "select * from profess";
            DataTable data = SqlDbHelper.ExecuteQuery(sql);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Model.Profess profess=new Model.Profess();
                profess.Pro_id = int.Parse(data.Rows[i][0].ToString());
                profess.Col_id = int.Parse(data.Rows[i][1].ToString());
                profess.Pro_name = data.Rows[i][2].ToString();
                list.Add(profess);
            }
            return list;
        }

        public List<Model.Profess> GetProfessListWhere(int col_id)
        {
            List<Model.Profess> list = new List<Model.Profess>();
            string sql = "select * from profess where col_id=@col_id";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@col_id", col_id) };
            DataTable data = SqlDbHelper.ExecuteQuery(sql,parameters);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                Model.Profess profess = new Model.Profess();
                profess.Pro_id = int.Parse(data.Rows[i][0].ToString());
                profess.Col_id = int.Parse(data.Rows[i][1].ToString());
                profess.Pro_name = data.Rows[i][2].ToString();
                list.Add(profess);
            }
            return list;
        }
    }
}
