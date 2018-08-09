//*******************************************
// This is the add student form.            *
// Admins can add enter a new student name  *
// and click add student.                   *
//*******************************************
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class AddStudentForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        public AddStudentForm()
        {
            InitializeComponent();
            InitializeComponent();
            connectionString =
    ConfigurationManager.ConnectionStrings
    ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
    .ConnectionString;
        }

        // Form load event.
        private void AddStudentForm_Load(object sender, EventArgs e)
        {
        }

        // Textbox where New Student name is entered into. 
        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        // Button that adds the student information from the nameTextbox.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("INSERT INTO student (studentName) " +
            "VALUES (@studentName)", conn))
            {
                conn.Open();
                comd.Parameters.AddWithValue("@studentName", nameTextbox.Text);
                comd.ExecuteScalar();
                MessageBox.Show("Student Added.");
                //nameTextbox.Clear();
                //nameTextbox.Focus();
            }
        }

        // Button that closes the form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
