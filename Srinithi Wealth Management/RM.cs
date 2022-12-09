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
    public partial class RM : Form
    {
        public RM()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "select * from Employee";
            SqlCommand cmd = new SqlCommand(Query,con);
            var reader= cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"], reader["SecondName"], reader["Email"], reader["PhoneNumber"], reader["AdviceOn"], reader["Country"], reader["City"], "Edit");
            }

           
            con.Close();


        }

        private void Search_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string SearchData = tbSearch.Text;

            string Query = "select * from Employee where FirstName like '%"+SearchData+"%' or SecondName like '%"+SearchData+"%'";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"], reader["SecondName"], reader["Email"], reader["PhoneNumber"], reader["AdviceOn"], reader["Country"], reader["City"], "Edit");
            }


            con.Close();




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string NameId = tbID.Text;
            string FirstName = tbFirstName.Text;
            string SecondName = tbAdviceOn.Text;

            string Query = "update Employee set FirstName = '"+FirstName+"', SecondName='"+SecondName+"' where id ="+NameId;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Has been Updated");

            tbFirstName.Text = "";
            tbAdviceOn.Text = "";
            tbID.Text = "";
        }

        private void tbFetch_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string NameId = tbID.Text;
            
            string Query = "select * from Employee where id ="+NameId;
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                tbFirstName.Text = reader["FirstName"].ToString();
                tbAdviceOn.Text = reader["AdviceOn"].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found");
            }

            con.Close();
            
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string NameId = tbID.Text;
            
            string Query = "delete from Employee where id=" + NameId;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Has been Deleted");

            tbFirstName.Text = "";
            tbAdviceOn.Text = "";
            tbID.Text = "";

            button1_Click(null,null);
        }

        private void RM_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==3 && e.RowIndex > -1)
            {
                tbID.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string SearchData = tbSearch.Text;

            string Query = "select * from Employee where FirstName like '%" + SearchData + "%' or SecondName like '%" + SearchData + "%'";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["ID"], reader["FirstName"], reader["SecondName"], reader["Email"], reader["PhoneNumber"], reader["AdviceOn"], reader["Country"], reader["City"], "Edit");
            }


            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-APTC7FL\\SQLEXPRESS;Initial Catalog=WealthManagement;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "select * from Ideas";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();

            dataGridView2.Rows.Clear();

            while (reader.Read())
            {
                dataGridView2.Rows.Add( reader["ProductType"], reader["region"]);
            }


            con.Close();
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
