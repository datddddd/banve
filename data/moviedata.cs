using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using movie.data;

namespace movie
{
     class moviedata
    {
        string conn = DatabaseConfig.ConnectionString;

        public int id {  get; set; }
        public string movieid { get; set; }
        public string moviename { get; set; }
        public string gener { get; set; }
        public string price { get; set; }
        public string capacity { get; set; }
        public string status { get; set; }
        public string image { get; set; }
        public string date { get; set; }
        
        public List<moviedata> movieListdata()
        { 
            List<moviedata> list = new List<moviedata>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string selectdata = "SELECT * FROM MOVIES WHERE DELETE_DATE IS NULL";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        moviedata mdata = new moviedata();
                        mdata.id = Convert.ToInt32(reader["ID"]);
                        mdata.movieid = reader["movie_id"].ToString();
                        mdata.moviename = reader["movie_name"].ToString();
                        mdata.gener = reader["gener"].ToString();
                        mdata.price = reader["price"].ToString();
                        mdata.capacity = reader["capacity"].ToString();
                        mdata.status = reader["status"].ToString();
                        mdata.image = reader["movie_image"].ToString();
                        mdata.date = reader["create_at"].ToString();
                        list.Add(mdata);
                    }
                }
            }
            return list;
        }
        public List<moviedata> movieavaiListdata()
        {
            List<moviedata> list = new List<moviedata>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();
                string selectdata = "SELECT * FROM MOVIES WHERE status = 'Available' and DELETE_DATE IS NULL";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        moviedata mdata = new moviedata();
                        mdata.id = Convert.ToInt32(reader["ID"]);
                        mdata.movieid = reader["movie_id"].ToString();
                        mdata.moviename = reader["movie_name"].ToString();
                        mdata.gener = reader["gener"].ToString();
                        mdata.price = reader["price"].ToString();
                        mdata.capacity = reader["capacity"].ToString();
                        mdata.status = reader["status"].ToString();
                        mdata.image = reader["movie_image"].ToString();
                        mdata.date = reader["create_at"].ToString();
                        list.Add(mdata);
                    }
                }
            }
            return list;
        }

    }
}
