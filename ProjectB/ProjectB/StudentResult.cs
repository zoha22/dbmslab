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
    public partial class StudentResult : Form
    {
        public StudentResult()
        {
            InitializeComponent();
        }

        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from Student";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                comboBox1.Items.Add(row["Id"].ToString());
            }

            SqlCommand cmnd2;
            cmnd2 = con.CreateCommand();
            cmnd2.CommandType = CommandType.Text;
            cmnd2.CommandText = "Select AssessmentId from AssessmentComponent";
            cmnd2.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmnd2);
            adap.Fill(tb);

            foreach (DataRow row in tb.Rows)
            {
                comboBox1.Items.Add(row["AssessmentId"].ToString());   //for showing AssessmentComponentId in comboBox 
            }

           
            comboBox3.Items.Clear();
            SqlCommand cmd3;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select MeasurementLevel from RubricLevel";
            cmd.ExecuteNonQuery();
            DataTable tble = new DataTable();
            SqlDataAdapter adpter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            foreach (DataRow row in tble.Rows)
            {
                comboBox3.Items.Add(row["MeasurementLevel"].ToString());
            }


            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}