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
            ("SELECT * FROM course WHERE courseId NOT IN (SELECT courseId FROM enrollment e JOIN student s ON e.studentId = s.studentId AND s.studentId = @studentId)", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                // Checks to make sure there is data associated with student ID.
                if (courseTable.Rows.Count < 1)
                {
                    btnEnroll.Enabled = false;
                    courseComboBox.Enabled = false;
                    courseComboBox.DataSource = null;
                    MessageBox.Show("*** No student found.***\nPlease check student ID and try again.", "Error");
                }

                // If there is data, then display.
                else
                {
                    btnEnroll.Enabled = true;
                    courseComboBox.Enabled = true;
                    courseComboBox.DisplayMember = "courseName";
                    courseComboBox.ValueMember = "courseId";
                    courseComboBox.DataSource = courseTable;
                }
            }
        }

        // Button that will enroll the student in a course.
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("INSERT INTO enrollment (courseId, studentId) " +
            "VALUES (@courseId,  @studentId)", conn))
            {
                try
                {
                    conn.Open();
                    comd.Parameters.AddWithValue("@courseId", courseComboBox.SelectedValue);
                    comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                    comd.ExecuteScalar();
                    MessageBox.Show("Course Added.", "Success!");
                    studentIdTextBox.Clear();
                    studentIdTextBox.Focus();
                    courseComboBox.SelectedIndex = -1;
                }

                // Displays error if the student ID is not in the database. 
                catch(Exception)
                {
                    MessageBox.Show("*** A student is not associated with that ID.***\nPlease check student ID and try again.", "Error");
                    studentIdTextBox.Clear();
                    courseComboBox.SelectedIndex = -1;
                }
            }
        }

        // Button that will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
