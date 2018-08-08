//*******************************************
// This is the enroll form for students.    *
// Students will enter their student ID and *
// select the course they would like to     *
// enroll in. An error will occur if course.*
// is full.                                 *
//*******************************************
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class StudentEnrollForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        public StudentEnrollForm()
        {
            InitializeComponent();

            // Assign value to the string vaiable.
            connectionString =
                ConfigurationManager.ConnectionStrings
                ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
                .ConnectionString;
        }

        // Form load event.
        private void StudentEnrollForm_Load(object sender, EventArgs e)
        {
        }

        // Button that will search and find Student Id.
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("SELECT courseName FROM course WHERE courseId IN (SELECT courseId FROM enrollment WHERE enrollment.studentId != @studentId)", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                // Checks to make sure there is data associated with instructor ID.
                if (courseTable.Rows.Count < 1)
                {
                    courseComboBox.Enabled = false;
                    courseComboBox.DataSource = null;
                    MessageBox.Show("*** No student found. Please check student ID ***");
                }
                // If there is data, then display.
                else
                {
                    courseComboBox.Enabled = true;
                    courseComboBox.DisplayMember = "courseName";
                    courseComboBox.ValueMember = "course.courseId";
                    courseComboBox.DataSource = courseTable;
                }
            }
        }

        // Button that will enroll the student in a course.
        private void btnEnroll_Click(object sender, EventArgs e)
        {
        }

        // Button that will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
