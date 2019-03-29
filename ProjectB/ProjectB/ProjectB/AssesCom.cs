﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectB
{
    public partial class AssessCom : Form
    {
        public AssessCom()
        {
            InitializeComponent();
        }

        //Sql Connection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AssessCom_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);
            comboBox2.Items.Clear();
            conn.Open(); //connection is open
            SqlCommand command;
            command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "Select Id from Rubric";
            command.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                comboBox2.Items.Add(row["Id"].ToString());     //for showing RubricId in comboBox 
            }
            
            SqlCommand cmnd2;
            cmnd2 = conn.CreateCommand();
            cmnd2.CommandType = CommandType.Text;
            cmnd2.CommandText = "Select Id from Assessment";
            cmnd2.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmnd2);
            adap.Fill(tb);

            foreach (DataRow row in tb.Rows)
            {
                comboBox1.Items.Add(row["Id"].ToString());   //for showing AssessmentId in comboBox 
            }

            conn.Close(); //connection is closed



        }

        private void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "INSERT INTO AssessmentComponent (Name, DateCreated, DateUpdated, TotalMarks, AssessmentId, RubricId) VALUES('" + Nam.Text + "','" + DateTime.Now + "','" + DateTime.Now + "', '" + Convert.ToInt32(ToMarks.Text) + "' , '"+ Convert.ToInt32(comboBox1.SelectedItem) + "', '"+ Convert.ToInt32(comboBox2.SelectedItem) + "')";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("AssessComponent is entered successfully"); //Values in AssessmentComponent are added
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcessPortal frm = new AcessPortal(); //this will redirect the page to Assessement portal
            this.Hide();
            frm.Show();  
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ComRead form = new ComRead(); 
            this.Hide();
            form.Show();   //this will redirect the page for reading the total AssessmentComponent which were added 
        }

        private void Nam_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lanam_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ToMarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ComRead form = new ComRead();
            this.Hide();
            form.Show();
        }
    }
}
