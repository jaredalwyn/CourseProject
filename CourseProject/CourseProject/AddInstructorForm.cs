//**********************************************
// This is the add instructor form.            *
// Admins can add enter a new instructor name  *
// and click add instructor.                   *
//**********************************************
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
    public partial class AddInstructorForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        public AddInstructorForm()
        {
            InitializeComponent();
            InitializeComponent();
            connectionString =
    ConfigurationManager.ConnectionStrings
    ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
    .ConnectionString;
        }

        // Holds the name of the instructor. 
        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        // Button to add instructor information from name text box. 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand

            ("INSERT INTO instructor (instructorName) " +
            "VALUES (@instructorName)", conn))
            {
                conn.Open();
                comd.Parameters.AddWithValue("@instructorName", nameTextbox.Text);
                comd.ExecuteScalar();
                MessageBox.Show("Instructor Added.");
                nameTextbox.Clear();
                nameTextbox.Focus();
            }
        }

        // Closes the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
