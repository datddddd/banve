using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using movie.data;
namespace movie
{
    class staffdata
    {
        string conn = DatabaseConfig.ConnectionString;
        public int ID { get; set; }//0
        public string username { get; set; }//1
        public string password { get; set; } //2
        public string role { get; set; }//3
        public string status { get; set; }//4
        public List<staffdata> staffdatalist()
        {
            List<staffdata> listdata = new List<staffdata>();
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string selectData = "SELECT * FROM TAIKHOAN WHERE LOAITAIKHOAN = 'STAFF' and trangthai != 'DELETED'";
                using (SqlCommand cmd = new SqlCommand(selectData, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) 
                    {
                        staffdata sdata = new staffdata();
                        sdata.ID = (int)reader[0];
                        sdata.username = reader[1].ToString();
                        sdata.password = reader[2].ToString();
                        sdata.role = reader[3].ToString();
                        sdata.status = reader[4].ToString();
                        listdata.Add(sdata);
                        
                    }
                }
            }
            return listdata;
        }
    }
}
