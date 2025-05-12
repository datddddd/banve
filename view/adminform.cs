using movie.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movie
{
    public partial class adminform : Form
    {
        public adminform()
        {
            InitializeComponent();
            dashboard_btn_Click(null, null);
        }

        private void close_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("ban muon dong chu?", "Confimr message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }    
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("ban muon dang xuat chu?", "Confimr message", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                regform regform = new regform();
                regform.Show();
                this.Hide();
            }
        }

        private void addstuff_btn_Click(object sender, EventArgs e)
        {
            addstaff1.Show();
            dashboardform1.Hide();
            movieadd1.Hide();
            maintenanceadmin1.Hide();
            receip1.Hide();
            addstaff af= addstaff1 as addstaff;
            if (af != null)
            {
                af.refreshdata();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboardform1.Show();
            addstaff1.Hide();
            movieadd1.Hide();
            maintenanceadmin1.Hide();
            receip1.Hide();
            dashboardform db = dashboardform1 as dashboardform;
            if (db != null)
            {
                db.refreshdata();
            }

        }

        private void addmovie_btn_Click(object sender, EventArgs e)
        {
            movieadd1.Show();
            dashboardform1.Hide();
            addstaff1.Hide();
            maintenanceadmin1.Hide();
            receip1.Hide();
            movieadd ma = movieadd1 as movieadd;
            if(ma != null)
            {
                ma.refreshdata();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            movieadd1.Hide();
            dashboardform1.Hide();
            addstaff1.Hide();
            receip1.Show();
            maintenanceadmin1.Hide();
            receip ma = receip1 as receip;
            if (ma != null)
            {
                ma.refreshdata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            movieadd1.Hide();
            dashboardform1.Hide();
            addstaff1.Hide();
            receip1.Hide();
            maintenanceadmin1.Show();
            maintenanceadmin ma = maintenanceadmin1 as maintenanceadmin;
            if (ma != null)
            {
                ma.refreshdata();
            }
        }
    }
}
