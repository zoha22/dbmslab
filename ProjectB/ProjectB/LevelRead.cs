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
    public partial class LevelRead : Form
    {
        public LevelRead()
        {
            InitializeComponent();
        }
        //Sql connection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";
        
        private void LevelRead_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from RubricLevel";
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
        }   //showing the Table of RubricLevel in comboBox

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    int r = e.RowIndex;
                    int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                    string Delete_Query = "DELETE FROM RubricLevel WHERE Id = '" + Id + "'";
                    SqlCommand cmd = new SqlCommand(Delete_Query, Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("RubricLevel is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                //Deletion is made possible




            }
            if (e.ColumnIndex == dataGridView1.Columns["btnupdate"].Index)
            {
                int r = e.RowIndex;
                int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                this.Hide();
                UpdateLevel frm = new UpdateLevel(Id);
                frm.Show();
            }
            //Update is made possible


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RubLevel form = new RubLevel();
            this.Hide();
            form.Show(); //this will redirect the page to rubric level
        }
    }
}
