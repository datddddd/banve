namespace movie
{
    partial class maintenancestaff
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(maintenancestaff));
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainten_delete = new System.Windows.Forms.Button();
            this.mainten_refresh = new System.Windows.Forms.Button();
            this.mainten_report = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_search = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.mainten_delete);
            this.panel1.Controls.Add(this.mainten_refresh);
            this.panel1.Controls.Add(this.mainten_report);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bt_search);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1056, 708);
            this.panel1.TabIndex = 1;
            // 
            // mainten_delete
            // 
            this.mainten_delete.BackColor = System.Drawing.Color.Aqua;
            this.mainten_delete.FlatAppearance.BorderSize = 0;
            this.mainten_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_delete.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_delete.Location = new System.Drawing.Point(454, 680);
            this.mainten_delete.Name = "mainten_delete";
            this.mainten_delete.Size = new System.Drawing.Size(93, 28);
            this.mainten_delete.TabIndex = 36;
            this.mainten_delete.Text = "DELETE";
            this.mainten_delete.UseVisualStyleBackColor = false;
            this.mainten_delete.Click += new System.EventHandler(this.mainten_delete_Click);
            // 
            // mainten_refresh
            // 
            this.mainten_refresh.BackColor = System.Drawing.Color.Aqua;
            this.mainten_refresh.FlatAppearance.BorderSize = 0;
            this.mainten_refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_refresh.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_refresh.Location = new System.Drawing.Point(337, 680);
            this.mainten_refresh.Name = "mainten_refresh";
            this.mainten_refresh.Size = new System.Drawing.Size(93, 28);
            this.mainten_refresh.TabIndex = 35;
            this.mainten_refresh.Text = "REFRESH";
            this.mainten_refresh.UseVisualStyleBackColor = false;
            this.mainten_refresh.Click += new System.EventHandler(this.mainten_refresh_Click);
            // 
            // mainten_report
            // 
            this.mainten_report.BackColor = System.Drawing.Color.Aqua;
            this.mainten_report.FlatAppearance.BorderSize = 0;
            this.mainten_report.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_report.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_report.Location = new System.Drawing.Point(220, 680);
            this.mainten_report.Name = "mainten_report";
            this.mainten_report.Size = new System.Drawing.Size(93, 28);
            this.mainten_report.TabIndex = 34;
            this.mainten_report.Text = "REPORT";
            this.mainten_report.UseVisualStyleBackColor = false;
            this.mainten_report.Click += new System.EventHandler(this.mainten_report_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(15, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(1026, 605);
            this.dataGridView1.TabIndex = 25;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(179, 685);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 23;
            // 
            // bt_search
            // 
            this.bt_search.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_search.Location = new System.Drawing.Point(12, 683);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(161, 22);
            this.bt_search.TabIndex = 22;
            this.bt_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bt_search_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "All problem";
            // 
            // maintenancestaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "maintenancestaff";
            this.Size = new System.Drawing.Size(1083, 737);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bt_search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button mainten_report;
        private System.Windows.Forms.Button mainten_refresh;
        private System.Windows.Forms.Button mainten_delete;
    }
}
