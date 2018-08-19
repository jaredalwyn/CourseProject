//**********************************************
// This is the add instructor form.            *
// Admins can add enter a new instructor name  *
// and click add instructor.                   *
//**********************************************
using System;
using System.Configuration;
using System.Data.SqlClient;
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

            // Assign value to the string variable.
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

            // Try catch to handle exceptions. 
            try
            {
                using (conn = new SqlConnection(connectionString))
                using (SqlCommand comd = new SqlCommand
                ("INSERT INTO instructor (instructorName) " +
                "VALUES (@instructorName)", conn))
                {
                    conn.Open();
                    comd.Parameters.AddWithValue("@instructorName", nameTextbox.Text);
                    comd.ExecuteScalar();
                    MessageBox.Show("Instructor Added.", "Success!");

                    // Clears the current text boxes.
                    nameTextbox.Clear();
                    nameTextbox.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Closes the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
