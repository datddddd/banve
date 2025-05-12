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
    public partial class addstaff : UserControl
    {
        string conn = DatabaseConfig.ConnectionString;

        public addstaff()
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
            staffdata sda = new staffdata();
            List<staffdata> list = sda.staffdatalist();
            dataGridView1.DataSource = list;
        }


        private void addstaff_addbtn_Click(object sender, EventArgs e)
        {
            if (isempty())
            {
                MessageBox.Show("vui long dien du", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    string selectUsername = "SELECT * FROM TAIKHOAN WHERE TENDANGNHAP = @USERN and trangthai != 'DELETED'";
                    using (SqlCommand checkUsern = new SqlCommand(selectUsername, con))
                    {
                        checkUsern.Parameters.AddWithValue("@USERN", addstaff_username.Text.Trim());
                        SqlDataAdapter ad = new SqlDataAdapter(checkUsern);
                        DataTable dt = new DataTable();
                        ad.Fill(dt);
                        if (dt.Rows.Count >= 2)
                        {
                            MessageBox.Show(addstaff_username.Text.Substring(0, 1).ToUpper()
                                + addstaff_username.Text.Substring(1) + " da ton tai", "Message error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertdata = "INSERT INTO TAIKHOAN (TENDANGNHAP,MATKHAU,LOAITAIKHOAN,NGAYTAO,TRANGTHAI)" +
                                "VALUES (@USERN,@PASS,@ROLE,@DATE,@STATUS)";
                            using (SqlCommand cmd = new SqlCommand(insertdata, con))
                            {
                                cmd.Parameters.AddWithValue("@USERN", addstaff_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@PASS", addstaff_pass.Text.Trim());
                                cmd.Parameters.AddWithValue("@ROLE", "staff");
                                DateTime toda = DateTime.Today;
                                cmd.Parameters.AddWithValue("@DATE", toda);
                                cmd.Parameters.AddWithValue("@STATUS", addstaff_status.SelectedItem.ToString());
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("them thanh cong", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clearfiel();
                                displaydata();
                            }
                        }

                    }
                }
            }
        }

        public bool isempty()
        {
            if (addstaff_username.Text == "" || addstaff_pass.Text == "" || addstaff_status.SelectedIndex == -1)
            { return true; }
            return false;
        }
        private int getid = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                getid = (int)row.Cells[0].Value;
                addstaff_username.Text= row.Cells[1].Value.ToString();
                addstaff_pass.Text = row.Cells[2].Value.ToString();
                addstaff_status.SelectedItem = row.Cells[4].Value.ToString();
            }
        }

        private void addstaff_updatebtn_Click(object sender, EventArgs e)
        {
            if (isempty())
            {
                MessageBox.Show("vui long dien", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("ban co chac muon sua tai khoan co id " + getid + " ?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) ;
                {
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        try
                        {
                            con.Open();
                            string selectusern = @"SELECT * FROM TAIKHOAN 
                               WHERE TENDANGNHAP = @USERN 
                               AND TRANGTHAI != 'DELETED' 
                               AND MATAIKHOAN != @ID";
                            using (SqlCommand cmd = new SqlCommand(selectusern, con))
                            {
                                cmd.Parameters.AddWithValue("@USERN", addstaff_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@ID", getid);

                                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                if (dt.Rows.Count > 0) // Nếu có tài khoản khác cùng tên đăng nhập
                                {
                                    MessageBox.Show(addstaff_username.Text.Substring(0, 1).ToUpper()
                                       + addstaff_username.Text.Substring(1) + " đã tồn tại", "Message error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    string updatedata = @"UPDATE TAIKHOAN 
                                      SET TENDANGNHAP = @USERN, 
                                          MATKHAU = @PASS, 
                                          TRANGTHAI = @STATUS 
                                      WHERE MATAIKHOAN = @ID";
                                    using (SqlCommand command = new SqlCommand(updatedata, con))
                                    {
                                        command.Parameters.AddWithValue("@USERN", addstaff_username.Text.Trim());
                                        command.Parameters.AddWithValue("@PASS", addstaff_pass.Text.Trim());
                                        command.Parameters.AddWithValue("@STATUS", addstaff_status.SelectedItem.ToString());
                                        command.Parameters.AddWithValue("@ID", getid);

                                        command.ExecuteNonQuery();
                                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        clearfiel();
                                        displaydata();
                                    }
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Lỗi SQL: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }

        public void clearfiel()
        {
            addstaff_username.Text = "";
            addstaff_pass.Text = "";
            addstaff_status.SelectedIndex = -1;
        }

        private void addstaff_deletebtn_Click(object sender, EventArgs e)
        {
            if (isempty())
            {
                MessageBox.Show("vui long dien", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("ban co chac muon xoa tai khoan co id " + getid + " ?", "Confirmation message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) ;
                {
                    using (SqlConnection con = new SqlConnection(conn))
                    {
                        con.Open();
                        
                                string updatedata = "UPDATE TAIKHOAN SET TRANGTHAI = @STATUS WHERE MATAIKHOAN = @ID";
                                using (SqlCommand command = new SqlCommand(updatedata, con))
                                {
                                    
                                    command.Parameters.AddWithValue("@STATUS", "deleted");
                                    command.Parameters.AddWithValue("@ID", getid);
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("xoa thanh cong", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    clearfiel();
                                    displaydata();
                                }
                            }

                        }

                    }
                }

        private void addstaff_clearbtn_Click(object sender, EventArgs e)
        {
            clearfiel();
        }

        private void addstaff_searchbtn_Click(object sender, EventArgs e)
        {
            string searchValue = addstaff_searchtxt.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                string searchQuery = "SELECT * FROM TAIKHOAN WHERE (TENDANGNHAP LIKE @SearchValue OR MATAIKHOAN LIKE @SearchValue )" 
                    ;
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
                        dataGridView1.DataSource = null;
                    }
                }
            }
        }

        private void addstaff_searchtxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Nếu nhấn Enter để xác nhận
            {
                addstaff_searchbtn_Click(null,null);
            }
        }


    }
}
    

