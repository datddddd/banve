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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace movie
{
    public partial class maintenancestaffform : Form
    {
        string conn = DatabaseConfig.ConnectionString;

        public maintenancestaffform()
        {
            InitializeComponent();
        }
        public int ID { get; set; }
        public void SetMaintenName(string name)
        {
            mainten_name.Text = name;
        }

        public void SetMaintenDate(DateTime date)
        {
            mainten_date.Value = date;
        }

        public void SetMaintenDescribe(string describe)
        {
            mainten_describe.Text = describe;
        }

        public void SetMaintenanImage(string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image) && File.Exists(image))
                {
                    maintenan_p.Image = Image.FromFile(image);
                }
                else
                {
                    maintenan_p.Image = null; // Đặt lại nếu không có ảnh
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainten_update_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string name = mainten_name.Text;
            DateTime date = mainten_date.Value;
            string describe = mainten_describe.Text;
            string image = maintenan_p.ImageLocation;

            // Cập nhật dữ liệu vào cơ sở dữ liệu
            UpdateMaintenance(name, date, describe, image);

            // Đóng form
            this.Close();
        }
        private void UpdateMaintenance(string name, DateTime date, string describe, string image)
        {
            try
            {
                if (MessageBox.Show($"Bạn có muốn cập nhật với ID: {ID}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (SqlConnection connection = new SqlConnection(conn))
                    {
                        connection.Open();

                        // Lấy ảnh cũ từ cơ sở dữ liệu nếu người dùng không chọn ảnh mới
                        string oldImagePath = string.Empty;
                        if (string.IsNullOrEmpty(image))
                        {
                            string queryGetOldImage = "SELECT MOVIE_IMAGE FROM MAINTENANCE WHERE ID = @ID";
                            using (SqlCommand cmdGetOldImage = new SqlCommand(queryGetOldImage, connection))
                            {
                                cmdGetOldImage.Parameters.AddWithValue("@ID", ID);
                                oldImagePath = cmdGetOldImage.ExecuteScalar()?.ToString();
                            }
                        }

                        // Cập nhật dữ liệu
                        string updatedata = "UPDATE MAINTENANCE SET ENAME = @ENAME, DATE = @DATE, DESCRIBE = @DES, MOVIE_IMAGE = @IMAGE WHERE ID = @ID";
                        using (SqlCommand cmd = new SqlCommand(updatedata, connection))
                        {
                            cmd.Parameters.AddWithValue("@ID", ID);
                            cmd.Parameters.AddWithValue("@ENAME", name.Trim());
                            cmd.Parameters.AddWithValue("@DATE", date);
                            cmd.Parameters.AddWithValue("@DES", describe.Trim());

                            // Nếu có ảnh mới, lưu đường dẫn mới; ngược lại, dùng ảnh cũ
                            string savedImagePath = oldImagePath;
                            if (!string.IsNullOrEmpty(image))
                            {
                                string directory = @"D:\ANH\";
                                Directory.CreateDirectory(directory); // Tạo thư mục nếu chưa có
                                savedImagePath = Path.Combine(directory, Path.GetFileName(image));
                                File.Copy(image, savedImagePath, true); // Lưu ảnh vào thư mục
                            }
                            cmd.Parameters.AddWithValue("@IMAGE", savedImagePath);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Cập nhật thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainten_importbtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    maintenan_p.ImageLocation = ofd.FileName; // Hiển thị đường dẫn ảnh được chọn
                    maintenan_p.Image = Image.FromFile(ofd.FileName); // Hiển thị ảnh trên PictureBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mainten_report_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    connection.Open();

                    // Thay đổi đường dẫn đến file ảnh thành một đường dẫn ngắn hơn
                    string path = Path.Combine(@"D:\ANH\"+ ID + ".jpg");

                    if (!string.IsNullOrEmpty(maintenan_p.ImageLocation))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                        File.Copy(maintenan_p.ImageLocation, path, true);
                    }

                    string insertdata = "INSERT INTO maintenance (ename, date, describe, movie_image) " +
                                       "VALUES (@ename,@date,@des,@image)";

                    using (SqlCommand cmd = new SqlCommand(insertdata, connection))
                    {
                        cmd.Parameters.AddWithValue("@ename", mainten_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@date", mainten_date.Value);
                        cmd.Parameters.AddWithValue("@des", mainten_describe.Text.Trim());
                        cmd.Parameters.AddWithValue("@image", path);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Thêm thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 
    

