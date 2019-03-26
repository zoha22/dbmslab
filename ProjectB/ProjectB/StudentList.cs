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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int AttendenceId;
        public Form1(int id)
        {
            AttendenceId = id;
            InitializeComponent();
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string aquery = "select * from Student";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection Connection = new SqlConnection(connection);

            Connection.Open();
            int row = e.RowIndex;
                int id = Convert.ToInt32(dataGridView1.Rows[row].Cells["Id"].Value);

            MarkAttendance frm = new MarkAttendance(AttendenceId, id);
            this.Hide();
            frm.Show();



        }

        private void label1_Click(object sender, EventArgs e)

        {
            Attendence frm = new Attendence();
            this.Hide();
            frm.Show();

        }
    }
}
