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
    public partial class staffmainform : Form
    {
        public staffmainform()
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
            buyticket1.Show();
            dashboardform1.Hide();
            receip1.Hide();
            maintenancestaff1.Hide();
            buyticket bt = buyticket1 as buyticket;
            if (bt != null)
            {
                bt.refreshdata();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboardform1.Show();
            buyticket1.Hide();
            receip1.Hide();
            maintenancestaff1.Hide();
            dashboardform da = dashboardform1 as dashboardform;
            if (da != null)
            {
                da.refreshdata();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buyticket1.Hide();
            dashboardform1.Hide();
            receip1.Show();
            maintenancestaff1.Hide();
            receip bt = receip1 as receip;
            if (bt != null)
            {
                bt.refreshdata();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            maintenancestaff1.Show();
            buyticket1.Hide();
            dashboardform1.Hide();
            receip1.Hide();
            maintenancestaff bt = maintenancestaff1 as maintenancestaff;
            if (bt != null)
            {
                bt.refreshdata();
            }
        }
    }
}
