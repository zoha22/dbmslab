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
    public partial class ShowAttendance : Form
    {
        public ShowAttendance()
        {
            InitializeComponent();
        }

        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();

            String query = "SELECT FirstName,LastName,RegistrationNumber,AttendanceStatus FROM [Student] JOIN StudentAttendance ON StudentAttendance.StudentId = [Student].Id ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter View_Data = new SqlDataAdapter(cmd);
            DataTable Table = new DataTable(cmd.ToString());

            View_Data.Fill(Table);
            dataGridView1.DataSource = Table;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainPage form = new MainPage();
            this.Hide();
            form.Show();


        }
    }
}
