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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
        SqlConnection con = new SqlConnection();
        


        private void button2_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text=="")
            {
                MessageBox.Show("Enter the Username");
            }
            else if(txtPassword.Text=="")
            {
                MessageBox.Show("Enter the password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("select * from Names where Username =@Username and Password = @Password",con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("login successfull");
                        Dashboard form2 = new Dashboard();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid details");
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
           Form1 form2 = new Form1();
            form2.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxshowpas.Checked)
            {
                txtPassword.PasswordChar = '\0';


            }
            else
            {
                txtPassword.PasswordChar = '*';

            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
