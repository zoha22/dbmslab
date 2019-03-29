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
    public partial class Attendence : Form
    {
        public Attendence()
        {
            InitializeComponent();
        }
        //Sql connection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void Attendence_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connection);
            
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into ClassAttendance(AttendanceDate) values('" + Convert.ToDateTime(dateTimePicker1.Text) + "')",conn);
            cmd.ExecuteNonQuery(); //ClassAttendance is added

            SqlCommand cmd2 = new SqlCommand("select * from ClassAttendance where AttendanceDate = '" + Convert.ToDateTime(dateTimePicker1.Text) + "'", conn);

            var reader = cmd2.ExecuteReader();
            reader.Read();
            int Id = reader.GetInt32(0);
            Form1 frm = new Form1(Id); //This will redirect page to mark attendance of students.
            this.Hide();
            frm.Show(); 

        }
    }
}
