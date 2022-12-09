using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Srinithi_Wealth_Management
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
        }
        string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
        
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Dashboard form2 = new Dashboard();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string FirstName = txtFirstname.Text;
                string SecondName = txtSecondName.Text;
                string Email = txtEmail.Text;
                string PhoneNumber = txtPhoneNumber.Text;
                string AdviceOn = comboBox1.Text;
                string Country = txtCountry.Text;
                string City = txtCity.Text;

                string Query = "insert into Employee(FirstName,SecondName,Email,PhoneNumber,AdviceOn,Country,city) values('" + txtFirstname.Text + "','" + txtSecondName.Text + "','" + txtEmail.Text + "','" + txtPhoneNumber.Text + "','" + comboBox1.Text + "','" + txtCountry.Text + "','" + txtCity.Text + "')";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Has been saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
