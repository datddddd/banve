using movie.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movie
{
    public partial class receip : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;

        public receip()
        {
            InitializeComponent();
            displayreceipt();
        }

        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            displayreceipt();
        }

        public void displayreceipt()
        {
            buyticketsdata mda = new buyticketsdata();
            List<buyticketsdata> list = mda.recieptListdata();

            dataGridView1.DataSource = list;
        }
        private int id = 0;
        
        private void RefreshReceipts()
        {
            using (SqlConnection connect = new SqlConnection(conn))
            {
                connect.Open();
                string query = "SELECT * FROM BUY_TICKETS";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connect))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                        MessageBox.Show($"ID được chọn: {id}", "Thông báo");

                        using (SqlConnection connect = new SqlConnection(conn))
                        {
                            connect.Open();
                            string query = "DELETE FROM BUY_TICKETS WHERE ID = @id";
                            using (SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        RefreshReceipts();
                        MessageBox.Show("Hóa đơn đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearfield();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hóa đơn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void clearfield()
        {
            id = 0;
            receipt_movieid.Text = "....";
            receipt_seat.Text = "....";
            receipt_amount.Text = "....";
            receipt_charge.Text = "....";
            receipt_price.Text = "....";
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                id = (int)row.Cells[0].Value;
                receipt_movieid.Text = row.Cells[1].Value.ToString();
                receipt_seat.Text = row.Cells[2].Value.ToString();
                receipt_price.Text = row.Cells[3].Value.ToString();
                receipt_amount.Text = row.Cells[4].Value.ToString();
                receipt_charge.Text = row.Cells[5].Value.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearfield();
        }

        private void receipt_searchbtn_Click(object sender, EventArgs e)
        { 
                string searchValue = receipt_searchtxt.Text.Trim();
                if (string.IsNullOrEmpty(searchValue))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                string searchQuery = "SELECT * FROM buy_tickets " +
                                     "WHERE (movie_id LIKE @SearchValue OR id LIKE @SearchValue) ";
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
                            RefreshReceipts();
                    }
                    }
                }
            
        }

        private void receipt_searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                receipt_searchbtn_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshReceipts();
        }
    }
}
