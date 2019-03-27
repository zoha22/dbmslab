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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=DESKTOP-6TJ7I4T;Initial Catalog=ProjectB;Integrated Security=True";

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Student form = new Student();
            this.Hide();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AcessPortal form = new AcessPortal(); // this will redirect the page to AssessPortal 
            this.Hide();
            form.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CloPortal form = new CloPortal(); // this will redirect the page to CloPortal 
            this.Hide();
            form.Show();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Rubrics form = new Rubrics(); //// this will redirect the page to Rubrics
            this.Hide();
            form.Show();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RubLevel form = new RubLevel(); // this will redirect the page to RubricLevel
            this.Hide();
            form.Show();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AssessCom form = new AssessCom();  // this will redirect the page to AssessComponent  
            this.Hide();
            form.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StudentResult form = new StudentResult(); // this will redirect the page to StudentResult 
            this.Hide();
            form.Show();
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
        }

        private void linkLabel8_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }
    }
}
