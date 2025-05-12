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
    public partial class regform : Form
    {
        string conn = DatabaseConfig.ConnectionString;

        public regform()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_pass.Text == "")
            {
                MessageBox.Show("vui long dien thong tin", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string selectData = "SELECT * FROM TAIKHOAN WHERE TENDANGNHAP = @USERN AND MATKHAU = @PASS AND TRANGTHAI = 'ACTIVE'";
                    using (SqlCommand command = new SqlCommand(selectData, connection))
                    {
                        command.Parameters.AddWithValue("@USERN", login_username.Text.Trim());
                        command.Parameters.AddWithValue("@PASS", login_pass.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        
                        adapter.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string role = dt.Rows[0]["loaitaikhoan"].ToString();
                            if(role == "admin")
                            {
                                MessageBox.Show("Đăng nhập thành công vớii vai trò " + role.ToString()+"!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                adminform ad = new adminform();
                                ad.Show();
                                this.Hide();

                            }
                            else if(role == "staff")
                            {
                                MessageBox.Show("Đăng nhập thành công vớii vai trò " + role.ToString() + "!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                staffmainform st = new staffmainform();
                                st.Show();
                                this.Hide();


                            }
                            else
                            {
                                MessageBox.Show("Đăng nhập lỗi", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            

                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập lỗi", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }    
                    }
                }
            }

        }

        private void login_signup_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            login_pass.PasswordChar = login_showpass.Checked ? '\0' : '*';
           
        }
        
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Nếu nhấn Enter để xác nhận
            {
                login_btn_Click(null,null);
            }
        }
    }
}
