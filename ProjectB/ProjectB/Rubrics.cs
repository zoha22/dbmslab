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
    public partial class Rubrics : Form
    {
        public Rubrics()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form1_Load(object sender, EventArgs e)
        {
            //This will display the CloId in ComboBox//
            SqlConnection con = new SqlConnection(connection);
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from Clo";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                comboBox1.Items.Add(row["Id"].ToString());
            }

            con.Close();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainPage form = new MainPage();
            this.Hide();
            form.Show(); //this will redirect the page to main page

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                
                string aquery = "INSERT INTO Rubric (Details, CloId) VALUES('" + desc.Text + "', '"+ Convert.ToInt32(comboBox1.SelectedItem)+"')";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Rubric has entered successfully");
            }

            else
            {
                MessageBox.Show("Error!");
            } 

        } //Data is inserted in Rubric

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this will redirect the page for reading the Rubrics//
            RubRead frm = new RubRead();
            this.Hide();
            frm.Show();
        }
    }
}
