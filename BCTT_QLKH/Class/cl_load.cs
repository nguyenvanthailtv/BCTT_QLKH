using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BCTT_QLKH.Class
{
    class cl_load
    {
        public static DataTable loaddl(string sql)
        {
            cl_ketnoi.ketnoi();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd = cl_ketnoi.sqlcon.CreateCommand();
            sqlcmd.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter(sqlcmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        public static int insert_update_delete(string sql)
        {
            cl_ketnoi.ketnoi();
            SqlCommand sqlcmd = new SqlCommand(sql, cl_ketnoi.sqlcon);
            return sqlcmd.ExecuteNonQuery();
        }
    }
}
