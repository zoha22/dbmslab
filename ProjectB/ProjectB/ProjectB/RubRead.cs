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
                //It will delete Rubric Level against this rubric that has been deleted//
                var Result = MessageBox.Show(" Are you sure to delete this Rubric ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);

                if (Result == DialogResult.Yes)
                {

                    int r = e.RowIndex;
                    int ID = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                    
                    SqlCommand RubricLevelCommand = new SqlCommand("DELETE FROM RubricLevel WHERE RubricId = '" + ID + "'", Connection);
                    RubricLevelCommand.ExecuteNonQuery();

                    string QueryDel = "DELETE FROM Rubric WHERE Id = '" + ID + "'";
                    SqlCommand command = new SqlCommand(QueryDel, Connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rubric has been deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }







            }
            if (e.ColumnIndex == dataGridView1.Columns["btnupdate"].Index)
            {   
                //it will update the rubric//
                int row = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                this.Hide();
                RubUpdate frm = new RubUpdate(id);
                frm.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //it will display Rubric table in DatGrid
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
            //this will redirect page to Rubrics
            Rubrics form = new Rubrics (); 
            this.Hide();
            form.Show(); 

        }
    }
}
