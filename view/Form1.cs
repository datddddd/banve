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
using System.Data;
using movie.data;

namespace movie
{
    public partial class Form1 : Form
    {
        string conn = DatabaseConfig.ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reg_showpass_CheckedChanged(object sender, EventArgs e)
        {
            reg_password.PasswordChar = reg_showpass.Checked ? '\0' : '*';
            reg_cpassword.PasswordChar = reg_showpass.Checked ? '\0' : '*';
        }

        private void reg_btn_Click(object sender, EventArgs e)
        {
            if(reg_username.Text == ""||reg_password.Text == ""||  reg_cpassword.Text =="")
            {
                MessageBox.Show("vui long dien thong tin", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(reg_password.Text != reg_cpassword.Text)
            {
                MessageBox.Show("mat khau khong khop", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn)) 
                {
                    connect.Open();
                    string checkusername = "SELECT COUNT(MATAIKHOAN) FROM TAIKHOAN WHERE TENDANGNHAP = @USERN";
                    using (SqlCommand checkusern = new SqlCommand(checkusername, connect))
                    {
                        checkusern.Parameters.AddWithValue("@USERN", reg_username.Text.Trim());
                        int count = (int)checkusern.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show(reg_username.Text.Substring(0, 1).ToUpper()
                                + reg_username.Text.Substring(1) + " đã tồn tại", "Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                    {
                            string insertData = "INSERT INTO TAIKHOAN (TENDANGNHAP,MATKHAU,LOAITAIKHOAN,NGAYTAO,TRANGTHAI) " +
                                "VALUES(@USERN,@PASS,@ROLE,@DATE,@STATUS)";

                            DateTime today = DateTime.Today;
                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@USERN",reg_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@PASS",reg_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@ROLE","staff");
                                cmd.Parameters.AddWithValue("@DATE",today);
                                cmd.Parameters.AddWithValue("@STATUS","Active");
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("dang ki thanh cong","infomation message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                regform login = new regform();
                                login.Show();
                                this.Hide();
                            }
                        }
                    }

                }
            }

        }

        private void reg_signinbtn_Click(object sender, EventArgs e)
        {
            regform regform = new regform();
            regform.Show();
            this.Close();
        }
    }
}
