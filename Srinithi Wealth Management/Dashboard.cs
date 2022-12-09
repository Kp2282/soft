using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Srinithi_Wealth_Management
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            UserForm form2 = new UserForm();
            form2.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            StaffForm form2 = new StaffForm();
            form2.Show();
            this.Hide();
        }
    }
}
