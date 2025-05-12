namespace movie.view
{
    partial class maintenanceadmin
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.receipt_searchbtn = new System.Windows.Forms.Button();
            this.mainten_search = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maintenan_p = new System.Windows.Forms.PictureBox();
            this.mainten_des = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mainten_name = new System.Windows.Forms.Label();
            this.mainten_Date = new System.Windows.Forms.Label();
            this.mainten_reject = new System.Windows.Forms.Button();
            this.mainten_accept = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maintenan_p)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
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
            this.dataGridView1.Location = new System.Drawing.Point(26, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(451, 614);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.receipt_searchbtn);
            this.panel2.Controls.Add(this.mainten_search);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(590, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 702);
            this.panel2.TabIndex = 3;
            // 
            // receipt_searchbtn
            // 
            this.receipt_searchbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.receipt_searchbtn.FlatAppearance.BorderSize = 0;
            this.receipt_searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.receipt_searchbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receipt_searchbtn.Location = new System.Drawing.Point(26, 51);
            this.receipt_searchbtn.Name = "receipt_searchbtn";
            this.receipt_searchbtn.Size = new System.Drawing.Size(78, 25);
            this.receipt_searchbtn.TabIndex = 16;
            this.receipt_searchbtn.Text = "SEARCH";
            this.receipt_searchbtn.UseVisualStyleBackColor = false;
            this.receipt_searchbtn.Click += new System.EventHandler(this.receipt_searchbtn_Click);
            // 
            // mainten_search
            // 
            this.mainten_search.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_search.Location = new System.Drawing.Point(110, 51);
            this.mainten_search.Name = "mainten_search";
            this.mainten_search.Size = new System.Drawing.Size(244, 22);
            this.mainten_search.TabIndex = 10;
            this.mainten_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainten_search_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "All problem";
            // 
            // maintenan_p
            // 
            this.maintenan_p.BackColor = System.Drawing.Color.White;
            this.maintenan_p.Location = new System.Drawing.Point(0, 0);
            this.maintenan_p.Name = "maintenan_p";
            this.maintenan_p.Size = new System.Drawing.Size(193, 307);
            this.maintenan_p.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maintenan_p.TabIndex = 41;
            this.maintenan_p.TabStop = false;
            // 
            // mainten_des
            // 
            this.mainten_des.BackColor = System.Drawing.Color.White;
            this.mainten_des.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_des.Location = new System.Drawing.Point(67, 87);
            this.mainten_des.Name = "mainten_des";
            this.mainten_des.Size = new System.Drawing.Size(275, 427);
            this.mainten_des.TabIndex = 0;
            this.mainten_des.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "Describe";
            // 
            // mainten_name
            // 
            this.mainten_name.AutoSize = true;
            this.mainten_name.Location = new System.Drawing.Point(67, 25);
            this.mainten_name.Name = "mainten_name";
            this.mainten_name.Size = new System.Drawing.Size(25, 13);
            this.mainten_name.TabIndex = 39;
            this.mainten_name.Text = "......";
            // 
            // mainten_Date
            // 
            this.mainten_Date.AutoSize = true;
            this.mainten_Date.Location = new System.Drawing.Point(67, 54);
            this.mainten_Date.Name = "mainten_Date";
            this.mainten_Date.Size = new System.Drawing.Size(25, 13);
            this.mainten_Date.TabIndex = 40;
            this.mainten_Date.Text = "......";
            // 
            // mainten_reject
            // 
            this.mainten_reject.BackColor = System.Drawing.Color.Aqua;
            this.mainten_reject.FlatAppearance.BorderSize = 0;
            this.mainten_reject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_reject.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_reject.Location = new System.Drawing.Point(227, 571);
            this.mainten_reject.Name = "mainten_reject";
            this.mainten_reject.Size = new System.Drawing.Size(75, 28);
            this.mainten_reject.TabIndex = 42;
            this.mainten_reject.Text = "REJECT";
            this.mainten_reject.UseVisualStyleBackColor = false;
            this.mainten_reject.Click += new System.EventHandler(this.mainten_reject_Click);
            // 
            // mainten_accept
            // 
            this.mainten_accept.BackColor = System.Drawing.Color.Aqua;
            this.mainten_accept.FlatAppearance.BorderSize = 0;
            this.mainten_accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mainten_accept.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainten_accept.Location = new System.Drawing.Point(88, 571);
            this.mainten_accept.Name = "mainten_accept";
            this.mainten_accept.Size = new System.Drawing.Size(75, 28);
            this.mainten_accept.TabIndex = 43;
            this.mainten_accept.Text = "ACCEPT";
            this.mainten_accept.UseVisualStyleBackColor = false;
            this.mainten_accept.Click += new System.EventHandler(this.mainten_accept_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.mainten_accept);
            this.panel1.Controls.Add(this.mainten_reject);
            this.panel1.Controls.Add(this.mainten_Date);
            this.panel1.Controls.Add(this.mainten_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.mainten_des);
            this.panel1.Location = new System.Drawing.Point(15, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 702);
            this.panel1.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(376, 574);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 25);
            this.button3.TabIndex = 46;
            this.button3.Text = "REFRESH";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.maintenan_p);
            this.panel3.Location = new System.Drawing.Point(348, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 307);
            this.panel3.TabIndex = 45;
            // 
            // maintenanceadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "maintenanceadmin";
            this.Size = new System.Drawing.Size(1083, 737);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maintenan_p)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button receipt_searchbtn;
        private System.Windows.Forms.TextBox mainten_search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox maintenan_p;
        private System.Windows.Forms.RichTextBox mainten_des;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label mainten_name;
        private System.Windows.Forms.Label mainten_Date;
        private System.Windows.Forms.Button mainten_reject;
        private System.Windows.Forms.Button mainten_accept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button3;
    }
}
