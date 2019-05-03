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
using DGVPrinterHelper;


namespace ProjectB
{
    public partial class Result : Form
    {
        public Result()
        {
            InitializeComponent();
        }
        public int AssessmentId;
        public int StudentId;
        public int MeasurementLevel;
        public Result(int id, int id2, int id3)
        {
            AssessmentId = id;
            StudentId = id2;
            MeasurementLevel = id3;
            InitializeComponent(); //parameters for passing
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
            string SelectQuery = "SELECT AssessmentComponent.Name AS Component,Rubric.Details AS Rubric,AssessmentComponent.TotalMarks AS Component_Marks,RubricLevel.MeasurementLevel AS Student_Rubric_Level,CAST(RubricLevel.MeasurementLevel  AS float)/ '" + 4 + "' * AssessmentComponent.TotalMarks AS ObtainedMarks FROM [AssessmentComponent]  ";
            string Join1 = "JOIN Rubric ON [AssessmentComponent].RubricId = Rubric.Id ";
            string Join2 = "JOIN RubricLevel ON Rubric.Id = RubricLevel.RubricId"; //For obataining marks query//
            string WhereClause = "WHERE  RubricLevel.Id = '" + MeasurementLevel + "' AND [AssessmentComponent].Id = '" + AssessmentId + "'";
            string MainQuery = SelectQuery + Join1 + Join2 ; 
            SqlCommand cmd = new SqlCommand(MainQuery, con);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentResult Form = new StudentResult();
            this.Hide();
            Form.Show(); //Student result redirection
        }
       
        
        







        private void button1_Click( object sender,  EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Student Result Report"; //HEADER

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dataGridView1);

        }
    }
}
