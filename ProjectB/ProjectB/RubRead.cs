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
    public partial class RubRead : Form
    {
        public RubRead()
        {
            InitializeComponent();
        }
       
        
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();
            if (e.ColumnIndex == dataGridView1.Columns["btndelete"].Index)
            {
                var confirmResult = MessageBox.Show(" you sure about deleting this RubricLevel ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = e.RowIndex;
                    int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                    string Delete_Query = "DELETE FROM Rubric WHERE Id = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(Delete_Query, Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }





            }
            if (e.ColumnIndex == dataGridView1.Columns["btnupdate"].Index)
            {
                int row = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                this.Hide();
                RubUpdate frm = new RubUpdate(id);
                frm.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from Rubric";
                SqlCommand cmd = new SqlCommand(aquery, con);
                SqlDataAdapter VD = new SqlDataAdapter(cmd);
                DataTable Table = new DataTable(cmd.ToString());

                VD.Fill(Table);
                dataGridView1.DataSource = Table;
            }

            else
            {
                MessageBox.Show("Error!");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rubrics form = new Rubrics ();
            this.Hide();
            form.Show();

        }
    }
}
