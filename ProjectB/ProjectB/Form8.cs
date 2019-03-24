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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    int row = e.RowIndex;
                    int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                    string Delete_Query = "DELETE FROM clo WHERE Id = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(Delete_Query, Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }





            }
            if (e.ColumnIndex == dataGridView1.Columns["btnUpdate"].Index)
            {
                int row = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                this.Hide();
                Form9 frm = new Form9(id);
                frm.Show();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from Clo";
                SqlCommand cmd = new SqlCommand(aquery, con);
                SqlDataAdapter View_Data = new SqlDataAdapter(cmd);
                DataTable Table = new DataTable(cmd.ToString());

                View_Data.Fill(Table);
                dataGridView1.DataSource = Table;
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
