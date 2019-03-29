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
    public partial class CloRead : Form
    {
        public CloRead()
        {
            InitializeComponent();
        }

        //SqlConnection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";




        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();


            if (e.ColumnIndex == dataGridView1.Columns["btnDelete"].Index)
            {
                var askbox = MessageBox.Show("Are you sure to Delete this CLO ??",
                                     "Delete!",
                                     MessageBoxButtons.YesNo);

                if (askbox == DialogResult.Yes)
                {
                    int r = e.RowIndex;
                    int ID = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);

                    string s = "SELECT * FROM Rubric WHERE CloId = '" + ID + "'";
                    SqlCommand QueryForRUBRICID = new SqlCommand(s, Connection);
                    var reader = QueryForRUBRICID.ExecuteReader();
                    reader.Read();
                    int RUBRICid = reader.GetInt32(0);
                    reader.Close();
                    try
                    {
                        if (RUBRICid > 0)
                        {
                            //this will delete the Rubric Level which is against to Selected Rubric Id
                            string s2 = "DELETE from RubricLevel WHERE RubricId = '" + RUBRICid + "'";
                            SqlCommand QueryforRUBRICLEVEL = new SqlCommand(s2, Connection);
                            QueryforRUBRICLEVEL.ExecuteNonQuery();
                            //this will delete the Rubric which is against the deleted CloId

                            string s3 = "DELETE from Rubric WHERE CloId = '" + ID + "'";
                            SqlCommand QueryForRUBRIC = new SqlCommand(s3, Connection);
                            QueryForRUBRIC.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        reader.Close();
                    }


                    this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                    SqlCommand queryDEL = new SqlCommand("DELETE FROM dbo.Clo WHERE Id = '" + ID + "'", Connection);
                    queryDEL.ExecuteNonQuery();
                    MessageBox.Show("Deleted!"); //Deletion of Clo is made possible with the deletion of against Rubric and Rubric Level
                    




                }

            }
            if (e.ColumnIndex == dataGridView1.Columns["btnUpdate"].Index)
            {
                int r = e.RowIndex;
                int Id = Convert.ToInt32(dataGridView1.Rows[r].Cells["Id"].Value);
                this.Hide();
                UpdateClo frm = new UpdateClo(Id);
                frm.Show(); //Clo is updated successfully.
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from Clo";
                SqlCommand cmnd = new SqlCommand(aquery, con);
                SqlDataAdapter VD = new SqlDataAdapter(cmnd);
                DataTable table = new DataTable(cmnd.ToString());

                VD.Fill(table);
                dataGridView1.DataSource = table; //CloId is shown in DataGrid
            }

            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloPortal form = new CloPortal(); 
           this.Hide();
            form.Show(); //This will redirect the page to CloPortal

        }
    }
}
