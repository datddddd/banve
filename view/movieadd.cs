using movie.data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace movie
{
    public partial class movieadd : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;

        public movieadd()
        {
            InitializeComponent();
            displaydata();
        }
        public void refreshdata()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshdata));
                return;
            }
            displaydata();
        }

        public void displaydata()
        {
            try
            {
                moviedata mdata = new moviedata();
                List<moviedata> list = mdata.movieListdata();
                if (list != null && list.Count > 0)
                {
                    dataGridView1.DataSource = list;
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addmovie_btnimport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    addmovie_pic.ImageLocation = ofd.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int id = 0;
        private void addmovie_btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string checkid = "SELECT COUNT(*) FROM MOVIES WHERE MOVIE_ID = @MOVIEID";
                    using (SqlCommand cid = new SqlCommand(checkid, connection))
                    {
                        cid.Parameters.AddWithValue("@MOVIEID", addmovie_id.Text.Trim());
                        int count = Convert.ToInt32(cid.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show($"Movie ID {addmovie_id.Text.Trim()} đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string path = Path.Combine(@"D:\baitap\c#\movie\movie_pic", addmovie_id.Text.Trim() + ".jpg");
                    if (!string.IsNullOrEmpty(addmovie_pic.ImageLocation))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                        File.Copy(addmovie_pic.ImageLocation, path, true);
                    }

                    string insertdata = "INSERT INTO MOVIES (MOVIE_ID, MOVIE_NAME, GENER, PRICE, CAPACITY, MOVIE_IMAGE, STATUS, CREATE_AT) " +
                                       "VALUES (@MOVIEID, @MOVIEN, @GENER, @PRICE, @CAPACITY, @MOVIEPIC, @STATUS, @DATE)";

                    using (SqlCommand cmd = new SqlCommand(insertdata, connection))
                    {
                        cmd.Parameters.AddWithValue("@MOVIEID", addmovie_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@MOVIEN", addmovie_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@GENER", addmovie_gener.Text.Trim());
                        cmd.Parameters.AddWithValue("@PRICE", addmovie_price.Text.Trim());
                        cmd.Parameters.AddWithValue("@CAPACITY", addmovie_capacity.Text.Trim());
                        cmd.Parameters.AddWithValue("@MOVIEPIC", path);
                        cmd.Parameters.AddWithValue("@STATUS", addmovie_status1.Text.Trim());
                        cmd.Parameters.AddWithValue("@DATE", DateTime.Now);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        displaydata();
                        clearfiel();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addmovie_btnup_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn cập nhật phim với ID: {addmovie_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();

                        string checkid = "SELECT COUNT(*) FROM MOVIES WHERE MOVIE_ID = @MOVIEID AND ID <> @ID";
                        using (SqlCommand cid = new SqlCommand(checkid, connection))
                        {
                            cid.Parameters.AddWithValue("@MOVIEID", addmovie_id.Text.Trim());
                            cid.Parameters.AddWithValue("@ID", id);
                            int count = Convert.ToInt32(cid.ExecuteScalar());
                            if (count > 0)
                            {
                                MessageBox.Show($"Movie ID {addmovie_id.Text.Trim()} đã tồn tại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        string updatedata = "UPDATE MOVIES SET MOVIE_ID = @MOVIEID, MOVIE_NAME = @MOVIEN, GENER = @GENER, PRICE = @PRICE, " +
                                           "CAPACITY = @CAPACITY, STATUS = @STATUS, UPDATE_DATE = @UPDATEDATE WHERE ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(updatedata, connection))
                        {
                            cmd.Parameters.AddWithValue("@MOVIEID", addmovie_id.Text.Trim());
                            cmd.Parameters.AddWithValue("@MOVIEN", addmovie_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@GENER", addmovie_gener.Text.Trim());
                            cmd.Parameters.AddWithValue("@PRICE", addmovie_price.Text.Trim());
                            cmd.Parameters.AddWithValue("@CAPACITY", addmovie_capacity.Text.Trim());
                            cmd.Parameters.AddWithValue("@STATUS", addmovie_status1.Text.Trim());
                            cmd.Parameters.AddWithValue("@UPDATEDATE", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ID", id);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displaydata();
                            clearfiel();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearfiel()
        {
            addmovie_id.Text = string.Empty;
            addmovie_name.Text = string.Empty;
            addmovie_gener.SelectedIndex = -1;
            addmovie_price.Text = string.Empty;
            addmovie_capacity.Text = string.Empty;
            addmovie_status1.SelectedIndex = -1;
            addmovie_pic.Image = null;
        }

        private void addmovie_btnclear_Click(object sender, EventArgs e)
        {
            clearfiel();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                id = Convert.ToInt32(row.Cells[0].Value);
                addmovie_id.Text = row.Cells[1].Value.ToString();
                addmovie_name.Text = row.Cells[2].Value.ToString();
                addmovie_gener.Text = row.Cells[3].Value.ToString();
                addmovie_price.Text = row.Cells[4].Value.ToString();
                addmovie_capacity.Text = row.Cells[5].Value.ToString();
                addmovie_status1.Text = row.Cells[6].Value.ToString();
                addmovie_pic.ImageLocation = row.Cells[7].Value.ToString();
            }
        }

        private void addmovie_btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn xóa phim với ID: {addmovie_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();
                        string updatedata = "UPDATE MOVIES SET delete_date = @DELETE ,STATUS = @STATUS WHERE ID = @ID";

                        using (SqlCommand cmd = new SqlCommand(updatedata, connection))
                        {

                            cmd.Parameters.AddWithValue("@STATUS", "delete");
                            cmd.Parameters.AddWithValue("@DELETE", DateTime.Now);
                            cmd.Parameters.AddWithValue("@ID", id);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displaydata();
                            clearfiel();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addmovie_btnclear_Click_1(object sender, EventArgs e)
        {
            clearfiel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchValue = textBox1.Text.Trim();
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
                            displaydata();
                        }
                    }
                }
            }
        }

        
    }
}
