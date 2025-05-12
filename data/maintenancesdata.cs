using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace movie.data
{
    class maintenancesdata
    {
        string conn = DatabaseConfig.ConnectionString;
        public int id { get; set; }
        public string ename { get; set; }
        public string date { get; set; }
        public string describe { get; set; }
        public string image { get; set; }
        public string current { get; set; }

        public List<maintenancesdata> maintenadmin()
        {
            List<maintenancesdata> list = new List<maintenancesdata>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string selectdata = "SELECT * FROM maintenance";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenancesdata mdata = new maintenancesdata();
                        mdata.id = Convert.ToInt32(reader["ID"]);
                        mdata.ename = reader["ename"].ToString();
                        mdata.date = reader["date"].ToString();
                        mdata.describe = reader["describe"].ToString();
                        mdata.image = reader["movie_image"].ToString();
                        mdata.current = reader["current"].ToString();

                        list.Add(mdata);
                    }
                }
            }
            return list;
        }
        public List<maintenancesdata> maintenadminform()
        {
            List<maintenancesdata> list = new List<maintenancesdata>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string selectdata = "SELECT * FROM MAINTENANCE WHERE [CURRENT] = 'wait' or [CURRENT] = 'ACCEPTED'";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenancesdata mdata = new maintenancesdata();
                        mdata.id = Convert.ToInt32(reader["ID"]);
                        mdata.ename = reader["ename"].ToString();
                        mdata.date = reader["date"].ToString();
                        mdata.describe = reader["describe"].ToString();
                        mdata.image = reader["movie_image"].ToString();
                        mdata.current = reader["current"].ToString();

                        list.Add(mdata);
                    }
                }
            }
            return list;
        }
    }
}
