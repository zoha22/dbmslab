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
    public partial class MarkAttendance : Form
    {
        public MarkAttendance()
        {
            InitializeComponent();
        }
        public int AttendenceId;
        public int StudentId;

        public MarkAttendance(int id,int id2)
        {
            AttendenceId= id;
            StudentId = id2;
            InitializeComponent(); //Global Variables created
        }
        
       //Sql Connection
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Status = 0;
            if (comboBox1.Text == "Present") 
            {
                Status = 1;
            }
            if (comboBox1.Text == "Absent")
            {
                Status = 2;
            }
            if (comboBox1.Text == "Leave")
            {
                Status = 3;
            }
            else 
            {
                Status = 4;
            } //Status is marked

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            string aquery = "INSERT INTO StudentAttendance (AttendanceId, StudentId, AttendanceStatus) VALUES('" + AttendenceId + "','" + StudentId + "', '" + Status + "')";
            SqlCommand cmd = new SqlCommand(aquery, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Attendence is marked successfully"); //Attendance is marked
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowAttendance frm = new ShowAttendance();
            this.Hide();
            frm.Show(); //This will redirect the page to Show Attendance

        }
    }
    }

