using movie.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace movie.view
{
    public partial class maintenanceadmin : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;
        public maintenanceadmin()
        {
            InitializeComponent();
            display();
        }
        private int id;
        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            display();
        }
        public void display()
        {
            maintenancesdata mda = new maintenancesdata();
            List<maintenancesdata> list = mda.maintenadminform();

            // Chuyển đổi ngày thành chỉ ngày (loại bỏ giờ)
            foreach (var item in list)
            {
                if (DateTime.TryParse(item.date, out DateTime dateValue))
                {
                    item.date = dateValue.Date.ToString("yyyy-MM-dd"); // Chỉ lấy ngày và chuyển thành string
                }
            }

            dataGridView1.DataSource = list;

            // Định dạng cột date để chỉ hiển thị ngày (yyyy-MM-dd)
            if (dataGridView1.Columns.Contains("date"))
            {
                dataGridView1.Columns["date"].DefaultCellStyle.Format = "yyyy-MM-dd";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                mainten_name.Text = row.Cells[1].Value.ToString();
                mainten_Date.Text = row.Cells[2].Value.ToString();
                mainten_des.Text = row.Cells[3].Value.ToString();
                maintenan_p.ImageLocation = row.Cells[4].Value.ToString();
            }    
        }

        private void mainten_accept_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn chấp thuận yêu cầu với ID: {id}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        // Cập nhật dữ liệu
                        string updatedata = $"UPDATE MAINTENANCE SET [CURRENT] = @current WHERE ID = {id}";
                        using (SqlCommand cmd = new SqlCommand(updatedata, connection))
                        {
                            cmd.Parameters.AddWithValue("@current", "Accepted");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            display();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainten_reject_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn từ chối yêu cầu với ID: {id}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        // Cập nhật dữ liệu
                        string updatedata = $"UPDATE MAINTENANCE SET [CURRENT] = @current WHERE ID = {id}";
                        using (SqlCommand cmd = new SqlCommand(updatedata, connection))
                        {
                            cmd.Parameters.AddWithValue("@current", "Rejected");
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            display();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void receipt_searchbtn_Click(object sender, EventArgs e)
        {
            string searchValue = mainten_search.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string searchQuery = "SELECT * FROM maintenance " +
                                     "WHERE ((id like @SearchValue OR ename LIKE @SearchValue or describe like @SearchValue) and [current] != 'REJECTED') ";
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
                        display();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            display();
        }

        private void mainten_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                receipt_searchbtn_Click(null, null);
            }
        }
    }
}
