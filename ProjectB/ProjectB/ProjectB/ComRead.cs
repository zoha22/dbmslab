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

        //Sql Connection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();
            if (e.ColumnIndex == dataGridView1.Columns["btndelete"].Index)
            {
                var Result = MessageBox.Show(" you sure about deleting this Assessment ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);

                if (Result == DialogResult.Yes)
                {
                    int r = e.RowIndex;
                    int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                    string QueryDel = "DELETE FROM AssessmentComponent WHERE Id = '" + Id + "'";
                    SqlCommand cmd = new SqlCommand(QueryDel, Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Asssessment is deleted!");
                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                }

                //Deletion is made possible



            }
            if (e.ColumnIndex == dataGridView1.Columns["btnupdate"].Index)
            {
                int r = e.RowIndex;
                int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                this.Hide();
                UpdateComp frm = new UpdateComp(Id);
                frm.Show();
            }  //Updation is made possible
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AssessCom form = new AssessCom();
            this.Hide();
            form.Show(); //this will redirect the page to AssessmentComponenet
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from AssessmentComponent";
                SqlCommand cmnd = new SqlCommand(aquery, con);
                SqlDataAdapter VD = new SqlDataAdapter(cmnd);
                DataTable Table = new DataTable(cmnd.ToString());   //for showing all attributes of AssessmentComponent in DataGrid

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

