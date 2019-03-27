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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //SQL connection 

        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                string aquery = "Select * from Assessment";
               SqlCommand command = new SqlCommand(aquery, conn);  //this will show all the attributes of assessment table in DataGrid
                SqlDataAdapter VD = new SqlDataAdapter(command);
                DataTable TB = new DataTable(command.ToString());

                VD.Fill(TB);
                dataGridView1.DataSource = TB;
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();
            if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index)
            {
                var confirmResult = MessageBox.Show(" you sure about deleting this RubricLevel ??",
                                     "Confirm Delete!!!!",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    int r = e.RowIndex;
                    int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                    string QueryDel = "DELETE FROM Assessment WHERE Id = '" + Id + "'"; //Deleting the Assessment which were added before.
                    SqlCommand command = new SqlCommand(QueryDel, Connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }





            }
            if (e.ColumnIndex == dataGridView1.Columns["btnUpdate"].Index)
            {
                int r = e.RowIndex;
                int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value); //this will update the assessments which are added before
                this.Hide();
                UpdateAss frm = new UpdateAss(Id);
                frm.Show(); 
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcessPortal form = new AcessPortal(); //this will redirect the page to Assessment portal where Assesments are added.
            this.Hide();
            form.Show();
        }
    }
}
