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
using System.Threading;
using movie.data;


namespace movie
{
    public partial class buyticket : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;

        public buyticket()
        {
            InitializeComponent();
            displayavailmovie();
            //displayavaimovie();
        }

        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            displayavailmovie();
        }

        public void displayavailmovie()
        {
            moviedata mda = new moviedata();
            List<moviedata> list = mda.movieavaiListdata();

            dataGridView1.DataSource = list;
        }
        private int id = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id = (int)row.Cells[0].Value;
                buyticket_movieid.Text = row.Cells[1].Value.ToString();
                buyticket_movien.Text = row.Cells[2].Value.ToString();
                buyticket_gener.Text = row.Cells[3].Value.ToString();
                buyticket_reprice.Text = row.Cells[4].Value.ToString();
                //buyticket_avaiseat.Text = row.Cells[1].Value.ToString();
                staff_p.ImageLocation = row.Cells[7].Value.ToString();
            }
        }
        string movie_id;

        public void displayavaimovie()
        {

            using (SqlConnection connection = new SqlConnection(conn))
            {
                connection.Open();

                string selectavaiseat = "SELECT capacity FROM MOVIES WHERE DELETE_DATE IS NULL AND STATUS != 'Deleted' AND movie_id = @movie_id";
                int setavaible = 0;

                using (SqlCommand command = new SqlCommand(selectavaiseat, connection))
                {
                    command.Parameters.AddWithValue("@movie_id", movie_id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            setavaible = (int)reader["capacity"];
                        }
                        reader.Close();
                    }
                }

                if (setavaible > 0)
                {
                    string getseat = "SELECT SEAT_NUMBER FROM BUY_TICKETS WHERE MOVIE_ID = @movie_id;";
                    List<int> bookseat = new List<int>();

                    using (SqlCommand cmd = new SqlCommand(getseat, connection))
                    {
                        cmd.Parameters.AddWithValue("@movie_id", movie_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bookseat.Add((int)reader["seat_number"]);
                            }
                            reader.Close();
                        }
                    }

                    List<int> allseat = Enumerable.Range(1, setavaible).ToList();
                    List<int> avaiableseats = allseat.Except(bookseat).ToList();

                    DataTable table = new DataTable();
                    table.Columns.Add("seat_number", typeof(int));
                    foreach (int seat in avaiableseats)
                    {
                        table.Rows.Add(seat);
                    }
                    if (table.Rows.Count > 0)
                    {
                        buyticket_avaichair.DataSource = table;
                        buyticket_avaichair.DisplayMember = "seat_number";
                        buyticket_avaichair.ValueMember = "seat_number";
                    }
                    else
                    {
                        MessageBox.Show("Không còn ghế trống cho phim này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        buyticket_avaichair.DataSource = null;
                    }

                }
                else
                {
                    MessageBox.Show("Không còn ghế trống cho phim này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    buyticket_avaichair.DataSource = null;

                }
            }
        }

        private void buyticket_selectmoviebtn_Click(object sender, EventArgs e)
        {
            movie_id = buyticket_movieid.Text.Trim();
            try
            {
                displayavaimovie();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi lấy danh sách ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        double total = 0;
        private void buyticket_calcubtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string selectprice = "SELECT MOVIE_ID ,PRICE FROM MOVIES WHERE MOVIE_ID = '" + movie_id + "'";
                double getprice = 0;
                using (SqlCommand cmd = new SqlCommand(selectprice, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        getprice = Convert.ToDouble(reader["price"].Equals(null) ? 0 : reader["price"]);
                    }

                    reader.Close();

                }

                double getfoodproce = (buyticket_food.SelectedIndex == -1) ? 0 : 100;
                double getdrink = (buyticket_drinks.SelectedIndex == -1) ? 0 : 50;

                total = (getfoodproce + getdrink + getprice);

                buyticket_total.Text = "$" + total.ToString("0.00");

            }
        }
        public void clearfield()
        {
            id = 0;
            buyticket_movieid.Text = "";
            buyticket_movien.Text = "";
            buyticket_gener.Text = "";
            buyticket_reprice.Text = "";
            staff_p.Image = null;
        }
        private void buyticket_clear1_Click(object sender, EventArgs e)
        {
            clearfield();
        }
        double charge = 0;
        double getamount = 0;
        private void CalculateCharge()
        {
            if (id == 0 || total == 0)
            {
                MessageBox.Show("Vui lòng chọn phim và tính tổng trước khi nhập số tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                double amountEntered = Convert.ToDouble(buyticket_amount.Text);
                if (amountEntered >= total)
                {
                    charge = amountEntered - total;
                    getamount = amountEntered;
                }
                else
                {
                    MessageBox.Show("Số tiền không đủ để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    charge = 0;
                  
                }
                buyticket_charge.Text = "$"+charge.ToString("0.00");
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập số hợp lệ vào ô thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                buyticket_amount.Text = "";
                getamount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void buyticket_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Nếu nhấn Enter để xác nhận
            {
                CalculateCharge();
            }
        }

        private void buyticket_buybtn_Click(object sender, EventArgs e)
        {
            if(movie_id == null || total == 0)
            {
                MessageBox.Show("Vui lòng chọn phim trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    string insertdata = "INSERT INTO BUY_TICKETS (MOVIE_ID,SEAT_NUMBER,PRICE,AMOUNT,CHARGE , STATUS , CREATE_AT)" +
                        "VALUES (@movie_id,@seatn,@price,@amount,@charge , @status, @date)";
                    using (SqlCommand cmd = new SqlCommand(insertdata, connect))
                    {
                        cmd.Parameters.AddWithValue("@movie_id", movie_id);
                        cmd.Parameters.AddWithValue("@seatn", buyticket_avaichair.Text);
                        cmd.Parameters.AddWithValue("@price", total);
                        cmd.Parameters.AddWithValue("@amount", getamount);
                        cmd.Parameters.AddWithValue("@charge", charge);
                        cmd.Parameters.AddWithValue("@status", "PAID");
                        DateTime today = DateTime.Now;
                        cmd.Parameters.AddWithValue("@date", today);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show($"Thanh toán thành công ghế :{buyticket_avaichair.Text} !"
                            , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //clearfield2();
                        //clearfield();
                    }    
                }    

            }
        }
        public void clearfield2()
        {
            buyticket_avaichair.SelectedIndex = -1;
            buyticket_food.SelectedIndex = -1;
            buyticket_drinks.SelectedIndex = -1;
            buyticket_amount.Text = "";
            buyticket_total.Text = "$0.00";
            buyticket_charge.Text = "$0.00";
        }
        private void buyticket_clear2_Click(object sender, EventArgs e)
        {
            clearfield2();


        }

        private void buyticket_receipbtn_Click(object sender, EventArgs e)
        {
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(printDocument1_BeginPrint);

            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private int rowIndex = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float y = 0;
            int cout = 0;
            int colwith = 100;
            int headermargin = 10;
            int tablemargin = 10;

            Font font = new Font("Arial", 12);
            Font bold = new Font("Arial", 12, FontStyle.Bold);
            Font headerforn = new Font("Arial", 16, FontStyle.Bold);
            Font labelfont = new Font("Arial", 14, FontStyle.Bold);

            float margin = e.MarginBounds.Top;

            StringFormat aligncenter = new StringFormat();
            aligncenter.Alignment = StringAlignment.Center;
            aligncenter.LineAlignment = StringAlignment.Center;

            // Header
            string headertext = "MY CINEMA";
            y = (margin + cout * headerforn.GetHeight(e.Graphics) + headermargin);
            e.Graphics.DrawString(headertext, headerforn, Brushes.Black, e.MarginBounds.Left
                + (dataGridView1.Columns.Count / 6) * colwith, y, aligncenter);

            cout++;
            y += tablemargin;

            // Movie Info
            string movieInfo = $"Movie ID: {movie_id}\n" +
                               $"Movie Name: {buyticket_movien.Text}\n" +
                               $"Genre: {buyticket_gener.Text}";
            y += 20;
            e.Graphics.DrawString(movieInfo, font, Brushes.Black, margin, y);

            y += font.GetHeight(e.Graphics) * 3;

            // Food and Drinks Info
            string food = (buyticket_food.SelectedIndex != -1) ? buyticket_food.Text : "None";
            string drinks = (buyticket_drinks.SelectedIndex != -1) ? buyticket_drinks.Text : "None";

            string foodDrinksInfo = $"Food: {food}\nDrinks: {drinks}";
            e.Graphics.DrawString(foodDrinksInfo, font, Brushes.Black, margin, y);

            y += font.GetHeight(e.Graphics) * 2;

            // Pricing Info
            DateTime today = DateTime.Now;
            string pricingInfo = $"Chair : {buyticket_avaichair.Text}\n" +
                                 $"Total Price: ${total:0.00}\n" +
                                 $"Amount Paid: ${buyticket_amount.Text}\n" +
                                 $"Change: {buyticket_charge.Text}\n" +
                                 $"Date: {today:dd/MM/yyyy HH:mm}";
            e.Graphics.DrawString(pricingInfo, font, Brushes.Black, margin, y);

            y += font.GetHeight(e.Graphics) * 5;
        }


        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            rowIndex = 0;

        }

        private void bt_search_KeyDown(object sender, KeyEventArgs e)
        {
            // Chỉ thực hiện tìm kiếm khi nhấn phím Enter
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = bt_search.Text.Trim();
                if (string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    string searchQuery = "SELECT * FROM MOVIES " +
                                         "WHERE (MOVIE_NAME LIKE @SearchValue OR MOVIE_ID LIKE @SearchValue) " +
                                         "AND STATUS = 'AVAILABLE' " +
                                         "AND DELETE_DATE IS NULL";
                    using (SqlCommand cmd = new SqlCommand(searchQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy kết quả nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayavailmovie();
                        }
                    }
                }
            }

        }
    }
}
    
