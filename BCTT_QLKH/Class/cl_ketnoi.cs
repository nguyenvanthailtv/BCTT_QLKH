using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BCTT_QLKH.Class
{
    class cl_ketnoi
    {
        public static SqlConnection sqlcon;
        public static void ketnoi()
        {
            if(sqlcon == null)
            {
                sqlcon = new SqlConnection(@"Data Source=DESKTOP-Q2BQVLO\SQLEXPRESS;Initial Catalog=BCTT_QLKH;Integrated Security=True");
            }
            if(sqlcon.State == System.Data.ConnectionState.Closed)
            {
                sqlcon.Open();
            }
            
        }
    }
}
