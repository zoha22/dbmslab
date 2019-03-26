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
    public partial class ComRead : Form
    {
        public ComRead()
        {
            InitializeComponent();
        }

        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();
            if (e.ColumnIndex == dataGridView1.Columns["btndelete"].Index)
            {
                var confirmResult = MessageBox.Show(" you sure about deleting this Assessment ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    int row = e.RowIndex;
                    int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                    string Delete_Query = "DELETE FROM AssessmentComponent WHERE Id = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(Delete_Query, Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Asssessment is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }





            }
            if (e.ColumnIndex == dataGridView1.Columns["btnupdate"].Index)
            {
                int row = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);
                this.Hide();
                UpdateComp frm = new UpdateComp(id);
                frm.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AssessCom form = new AssessCom();
            this.Hide();
            form.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from AssessmentComponent";
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
    }
}

