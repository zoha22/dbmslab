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
    public partial class UpdateStu : Form
    {
        public UpdateStu()
        {
            InitializeComponent();
        }
        public int IdToUpdate;
        public UpdateStu(int id)
        {
            IdToUpdate = id;
            InitializeComponent();
        } //parameters for passing


        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        private void upload_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                //string aquery = "UPDATE dbo.Assessment SET Title='" + txtTitle.Text + "',TotalMarks = '" + txtTmarks.Text + "',TotalWeightage = '" + txtTweight.Text + "' WHERE Id = '" + Id + "'";
                string aquery = "UPDATE dbo.Student SET FirstName='" + Firstna.Text + "', LastName = '" + Lastna.Text + "',Contact = '" + num.Text + "', Email = '" + Mail.Text +  "' , RegistrationNumber = '" + Reg.Text + "' WHERE Id = '" + IdToUpdate + "'";
                SqlCommand cmd = new SqlCommand(aquery, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data has updated successfully");
            }

            else
            {
                MessageBox.Show("Error!"); //updated students i n Student list
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StuRead form = new StuRead();
            this.Hide();
            form.Show(); //for redirecting it for reading the total student
        }
    }
       


       

        
    }

