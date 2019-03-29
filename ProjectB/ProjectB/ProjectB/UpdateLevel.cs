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
    public partial class UpdateLevel : Form
    {
        public UpdateLevel()
        {
            InitializeComponent();
        }
        public int IdToUpdate;
        public UpdateLevel(int id)
        {
            IdToUpdate = id;
            InitializeComponent();
        }//parameters for passing 
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True"; 
        //sql connection


        private void RubericLevel_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Id from Rubric";
            cmd.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(table);

            foreach (DataRow row in table.Rows)
            {
                comboBox2.Items.Add(row["Id"].ToString());
            }

            con.Close(); //showing Rubricid in comboBox

        }

        private void updt_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //string aquery = "UPDATE dbo.Assessment SET Title='" + txtTitle.Text + "',TotalMarks = '" + txtTmarks.Text + "',TotalWeightage = '" + txtTweight.Text + "' WHERE Id = '" + Id + "'";
                string aquery = "UPDATE dbo.RubricLevel SET Details='" + Deta.Text + "', RubricId = '" + Convert.ToInt32(comboBox2.SelectedItem) + "', MeasurementLevel= '" + Convert.ToInt32(comboBox1.SelectedItem) + "' WHERE Id = '" + IdToUpdate + "'";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("RubricLevel has updated successfully"); //updated Rubriclevel by applying query
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RubLevel form = new RubLevel();
            this.Hide();
            form.Show(); //for redirecting it Rubric level
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainPage form = new MainPage();
            this.Hide();
            form.Show(); //for redirecting it to main page

        }
    }
}
