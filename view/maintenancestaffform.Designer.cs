namespace movie
{
    partial class maintenancestaffform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainten_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maintenan_p = new System.Windows.Forms.PictureBox();
            this.mainten_date = new System.Windows.Forms.DateTimePicker();
            this.mainten_describe = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.mainten_report = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mainten_importbtn = new System.Windows.Forms.Button();
            this.mainten_update = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.maintenan_p)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainten_name
            // 
            this.mainten_name.Location = new System.Drawing.Point(115, 82);
            this.mainten_name.Name = "mainten_name";
            this.mainten_name.Size = new System.Drawing.Size(200, 20);
            this.mainten_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // maintenan_p
            // 
            this.maintenan_p.BackColor = System.Drawing.Color.White;
            this.maintenan_p.Location = new System.Drawing.Point(615, 154);
            this.maintenan_p.Name = "maintenan_p";
            this.maintenan_p.Size = new System.Drawing.Size(193, 307);
            this.maintenan_p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maintenan_p.TabIndex = 28;
            this.maintenan_p.TabStop = false;
            // 
            // mainten_date
            // 
            this.mainten_date.Location = new System.Drawing.Point(115, 122);
            this.mainten_date.Name = "mainten_date";
            this.mainten_date.Size = new System.Drawing.Size(200, 20);
            this.mainten_date.TabIndex = 29;
            // 
            // mainten_describe
            // 
            this.mainten_describe.Location = new System.Drawing.Point(115, 154);
            this.mainten_describe.Name = "mainten_describe";
            this.mainten_describe.Size = new System.Drawing.Size(427, 307);
            this.mainten_describe.TabIndex = 31;
            this.mainten_describe.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.close);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 59);
            this.panel1.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "INCIDENT REPORT";
            // 
            // mainten_report
            // 
            this.mainten_report.BackColor = System.Drawing.Color.Aqua;
            this.mainten_report.FlatAppearance.BorderSize = 0;
            this.mainten_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_report.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_report.Location = new System.Drawing.Point(842, 476);
            this.mainten_report.Name = "mainten_report";
            this.mainten_report.Size = new System.Drawing.Size(75, 28);
            this.mainten_report.TabIndex = 33;
            this.mainten_report.Text = "REPORT";
            this.mainten_report.UseVisualStyleBackColor = false;
            this.mainten_report.Click += new System.EventHandler(this.mainten_report_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 34;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Describe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(690, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 36;
            this.label5.Text = "Picture";
            // 
            // mainten_importbtn
            // 
            this.mainten_importbtn.BackColor = System.Drawing.Color.Aqua;
            this.mainten_importbtn.FlatAppearance.BorderSize = 0;
            this.mainten_importbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_importbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_importbtn.Location = new System.Drawing.Point(653, 476);
            this.mainten_importbtn.Name = "mainten_importbtn";
            this.mainten_importbtn.Size = new System.Drawing.Size(112, 28);
            this.mainten_importbtn.TabIndex = 37;
            this.mainten_importbtn.Text = "Import";
            this.mainten_importbtn.UseVisualStyleBackColor = false;
            this.mainten_importbtn.Click += new System.EventHandler(this.mainten_importbtn_Click);
            // 
            // mainten_update
            // 
            this.mainten_update.BackColor = System.Drawing.Color.Aqua;
            this.mainten_update.FlatAppearance.BorderSize = 0;
            this.mainten_update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_update.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_update.Location = new System.Drawing.Point(518, 476);
            this.mainten_update.Name = "mainten_update";
            this.mainten_update.Size = new System.Drawing.Size(75, 28);
            this.mainten_update.TabIndex = 38;
            this.mainten_update.Text = "UPDATE";
            this.mainten_update.UseVisualStyleBackColor = false;
            this.mainten_update.Click += new System.EventHandler(this.mainten_update_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(961, 0);
            this.close.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(16, 17);
            this.close.TabIndex = 2;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // maintenancestaffform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 516);
            this.Controls.Add(this.mainten_update);
            this.Controls.Add(this.mainten_importbtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainten_report);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainten_describe);
            this.Controls.Add(this.mainten_date);
            this.Controls.Add(this.maintenan_p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mainten_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "maintenancestaffform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "maintenancestaffform";
            ((System.ComponentModel.ISupportInitialize)(this.maintenan_p)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mainten_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox maintenan_p;
        private System.Windows.Forms.DateTimePicker mainten_date;
        private System.Windows.Forms.RichTextBox mainten_describe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button mainten_report;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mainten_importbtn;
        private System.Windows.Forms.Button mainten_update;
        private System.Windows.Forms.Label close;
    }
}