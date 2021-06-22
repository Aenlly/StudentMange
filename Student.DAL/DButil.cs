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
            con = new SqlConnection(conn);//实例化连接
            try{
                con.Open();//打开链接
            }
            catch
            {
                con.Close();//错误则关闭链接
            }
            return con;
        }
    }
}
