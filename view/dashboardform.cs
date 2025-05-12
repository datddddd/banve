using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using movie.data;

namespace movie
{
    public partial class dashboardform : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;
        public dashboardform()
        {
            InitializeComponent();
            displayavaibmovie();
            displaytotalstaff();
            displaytotalbuy();
            displaytotalincome();
            displayavailmovie();
        }

        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            displayavaibmovie();
            displaytotalstaff();
            displaytotalbuy();
            displaytotalincome();
            displayavailmovie();
        }

        public void displayavaibmovie()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string selectdata = "SELECT count(id) as avaim FROM MOVIES WHERE status = 'Available' ";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["avaim"] != null)
                        {
                            decimal totalavaim = Convert.ToDecimal(reader["avaim"]);
                            dashboard_avaim.Text = totalavaim.ToString();
                        }
                    }
                }
            }
        }
        public void displaytotalstaff()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string selectdata = "SELECT count(MATAIKHOAN) as totalstaff FROM TAIKHOAN WHERE LOAITAIKHOAN = 'STAFF' AND TRANGTHAI = 'ACTIVE' ";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["totalstaff"] != null)
                        {
                            decimal totalavaim = Convert.ToDecimal(reader["totalstaff"]);
                            dashboard_ts.Text = totalavaim.ToString();
                        }
                    }
                }
            }
        }
        public void displaytotalbuy()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string selectdata = "SELECT COUNT(ID) AS TOTALBUY FROM buy_tickets WHERE STATUS = 'paid'";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["TOTALBUY"] != null)
                        {
                            decimal totalavaim = Convert.ToDecimal(reader["TOTALBUY"]);
                            dashboard_totalbuy.Text = totalavaim.ToString();
                        }
                    }
                }
            }
        }
            public void displaytotalincome()
        {
            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string selectdata = "SELECT sum(price) AS totalincome FROM buy_tickets WHERE STATUS = 'paid'";
                using (SqlCommand command = new SqlCommand(selectdata, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        if (reader["totalincome"] != null)
                        {
                            decimal totalavaim = Convert.ToDecimal(reader["totalincome"]);
                            dashboard_totalincome.Text = "$"+totalavaim.ToString("0.00");
                        }
                    }
                }
            }
        }
        public void displayavailmovie()
        {
            moviedata mda = new moviedata();
            List<moviedata> list = mda.movieavaiListdata();

            dataGridView1.DataSource = list;
        }
    }
}
