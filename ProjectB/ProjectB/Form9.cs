using System;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public int IdToUpdate;
        public Form9(int id)
        {
            IdToUpdate = id;
            InitializeComponent();
        }


        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form9_Load(object sender, EventArgs e)
        {

        }//RUN KRNa ?????

        private void Submit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //string aquery = "UPDATE dbo.Assessment SET Title='" + txtTitle.Text + "',TotalMarks = '" + txtTmarks.Text + "',TotalWeightage = '" + txtTweight.Text + "' WHERE Id = '" + Id + "'";
                string aquery = "UPDATE dbo.Clo SET Name='" + name.Text + "' WHERE Id = '" + IdToUpdate + "'";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has updated successfully");
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form8 form = new Form8();
            this.Hide();
            form.Show();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
