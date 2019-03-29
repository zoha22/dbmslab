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
            SqlDataAdapter VD= new SqlDataAdapter(cmd);
            DataTable table = new DataTable(cmd.ToString());

            VD.Fill(table);
            dataGridView1.DataSource = table; //showing required data in dataGrid


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainPage form = new MainPage();
            this.Hide();
            form.Show(); //this will redirect the page to main page


        }
    }
}
