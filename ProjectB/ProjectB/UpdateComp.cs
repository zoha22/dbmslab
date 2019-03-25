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
    public partial class UpdateComp : Form
    {
        public UpdateComp()
        {
            InitializeComponent();
        }
        public int IdToUpdate;
        public UpdateComp(int id)
        {
            IdToUpdate = id;
            InitializeComponent();
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            
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
            SqlCommand cmd2;
            cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select Id from Assessment";
            cmd2.ExecuteNonQuery();
            DataTable tb = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter(cmd2);
            adap.Fill(tb);

            foreach (DataRow row in tb.Rows)
            {
                comboBox1.Items.Add(row["Id"].ToString());
            }


            con.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcessPortal form = new AcessPortal();
            this.Hide();
            form.Show();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ComRead form = new ComRead();
            this.Hide();
            form.Show();
        }

        private void Update_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //string aquery = "UPDATE dbo.Assessment SET Title='" + txtTitle.Text + "',TotalMarks = '" + txtTmarks.Text + "',TotalWeightage = '" + txtTweight.Text + "' WHERE Id = '" + Id + "'";
                string aquery = "UPDATE dbo.AssessmentComponent SET Name='" + Nam.Text + "', AssessmentId = '" + Convert.ToInt32(comboBox1.SelectedItem) + "', RubricId = '" + Convert.ToInt32(comboBox2.SelectedItem) + "', TotalMarks = '" + Convert.ToInt32(ToMarks.Text) + "' WHERE Id = '" + IdToUpdate + "'";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has entered successfully");
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
