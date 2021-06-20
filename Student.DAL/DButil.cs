using System.Data.SqlClient;
using System.Configuration;

namespace Student.DAL
{

    class DButil
    {
        SqlConnection con;
        public SqlConnection SqlOpen()
        {
            string conn = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; //链接数据库
            con = new SqlConnection(conn);
            try{
                con.Open();
            }
            catch
            {
                con.Close();
            }
            return con;
        }
    }
}
