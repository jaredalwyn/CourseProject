//*******************************************
// This is the add course form.             *
// Admins can add enter new course info     *
// and click add course.                    *
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

    public partial class AddCourseForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        public AddCourseForm()
        {
            InitializeComponent();
            connectionString =
    ConfigurationManager.ConnectionStrings
    ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
    .ConnectionString;
        }

        // Holds information for the course title. 
        private void courseTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        // Holds information for the Semester Offered.
        private void SemesterTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        // Button that will add course from text in courseText and SemesterText. 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand

            ("INSTERT INTO course (courseName, courseSemester) " +
            "VALUES (@courseName, @courseSemester)", conn))
            {
                conn.Open();
                comd.Parameters.AddWithValue("@courseName", courseTextbox.Text);
                comd.Parameters.AddWithValue("@courseSemester", SemesterTextbox.Text);
                comd.ExecuteScalar();
                MessageBox.Show("Course Added.");
                courseTextbox.Clear();
                SemesterTextbox.Clear();
                courseTextbox.Focus();
            }
        }

        // Button that will close the form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
