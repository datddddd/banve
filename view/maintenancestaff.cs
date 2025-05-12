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
    public partial class maintenancestaff : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;
        public maintenancestaff()
        {
            InitializeComponent();
            displaystaff();
        }
        private int id;
        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            displaystaff();
        }
        public void displaystaff()
        {
            maintenancesdata mda = new maintenancesdata();
            List<maintenancesdata> list = mda.maintenadmin();

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
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lưu thông tin dòng được chọn vào biến (nếu cần sử dụng sau này)
                id = Convert.ToInt32(row.Cells["ID"].Value); // Giả sử bạn khai báo biến này ở cấp lớp
                
            }

        }

        private void mainten_report_Click(object sender, EventArgs e)
        {
            maintenancestaffform fo = new maintenancestaffform();
            fo.Show();
        }

        private void mainten_refresh_Click(object sender, EventArgs e)
        {
            displaystaff();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                maintenancestaffform fo = new maintenancestaffform();
                fo.ID = Convert.ToInt32(row.Cells["ID"].Value);
                fo.SetMaintenName(row.Cells["ename"].Value.ToString());
                fo.SetMaintenDate(Convert.ToDateTime(row.Cells["date"].Value));
                fo.SetMaintenDescribe(row.Cells["describe"].Value.ToString());
                fo.SetMaintenanImage(row.Cells["image"].Value.ToString());
                fo.Show();

            }
        }

        private void mainten_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                        

                        using (SqlConnection connect = new SqlConnection(conn))
                        {
                            connect.Open();
                            string query = "DELETE FROM maintenance WHERE ID = @id";
                            using (SqlCommand cmd = new SqlCommand(query, connect))
                            {
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        displaystaff();
                        MessageBox.Show("Đã được xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bt_search_KeyDown(object sender, KeyEventArgs e)
        {
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
                    string searchQuery = "SELECT * FROM maintenance " +
                                         "WHERE (id like @SearchValue OR ename LIKE @SearchValue or describe like @SearchValue) ";
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
                            displaystaff();
                        }
                    }
                }
            }
        }
    }
}
