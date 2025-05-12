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
    class buyticketsdata
    {
        string conn = DatabaseConfig.ConnectionString;

        public int id { get; set; }
        public string movie_id { get; set; }
        public string seat_number { get; set; }
        public string price { get; set; }
        public string amount { get; set; }
        public string charge { get; set; }
        public string status { get; set; }
        public string date { get; set; }

        public List<buyticketsdata> recieptListdata()
        {
            List<buyticketsdata> list = new List<buyticketsdata>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string selectdata = "SELECT * FROM buy_tickets";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        buyticketsdata mdata = new buyticketsdata();
                        mdata.id = Convert.ToInt32(reader["ID"]);
                        mdata.movie_id = reader["movie_id"].ToString();
                        mdata.seat_number = reader["seat_number"].ToString();
                        mdata.price = reader["price"].ToString();
                        mdata.amount = reader["amount"].ToString();
                        mdata.charge = reader["charge"].ToString();
                        mdata.status = reader["status"].ToString();
                        mdata.date = reader["create_at"].ToString();
                        list.Add(mdata);
                    }
                }
            }
            return list;

        }
    }
}
