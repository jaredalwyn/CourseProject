//*******************************************
// This is the enroll form for instructors. *
// Instructors will enter their ID          *
// and select the course they would like to *
// enroll in. An error will occur if course *
// has an instructor.                       *
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
    public partial class InstructorEnrollForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        public InstructorEnrollForm()
        {
            InitializeComponent();

            // Assign value to the string vaiable.
            connectionString =
                ConfigurationManager.ConnectionStrings
                ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
                .ConnectionString;
        }

        // Load event for the instructor enroll form. 
        private void InstructorEnrollForm_Load(object sender, EventArgs e)
        {
        }

        // Holds the value for the instructor ID.
        private void instructorTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        // ComboBox that will display courses available to register for. 
        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Button that will enroll the instructor into the selected course. 
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("INSERT INTO tEnrollment (courseId, instructorId) " +
            "VALUES (@courseId,  @instructorId)", conn))
            {
                try
                {
                    conn.Open();
                    comd.Parameters.AddWithValue("@courseId", courseComboBox.SelectedValue);
                    comd.Parameters.AddWithValue("@instructorId", instructorTextBox.Text);
                    comd.ExecuteScalar();
                    MessageBox.Show("Course Added.", "Success!");

                    // Clears text box, and resets combo box.
                    instructorTextBox.Clear();
                    courseComboBox.SelectedIndex = -1;
                }

                // Catches error if the instructor ID does not exist. 
                catch (Exception)
                {
                    MessageBox.Show("*** No instructor associated with ID.*** \nPlease check instructor ID.", "Error");

                    // clears text box, and resets combo box.
                    instructorTextBox.Clear();
                    courseComboBox.SelectedIndex = -1;
                }
            }
        }

        // Button that will close this form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button that will search for the instructor ID and return courses available to combobox. 
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("SELECT * FROM course WHERE courseId NOT IN (SELECT courseId FROM tEnrollment e JOIN instructor i ON e.instructorId = i.instructorId)", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@instructorId", instructorTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                // Checks to make sure there is data associated with student ID.
                if (courseTable.Rows.Count < 1)
                {
                    btnEnroll.Enabled = false;
                    courseComboBox.Enabled = false;
                    courseComboBox.SelectedItem = -1;
                    instructorTextBox.Clear();
                    btnClose.Focus();
                    MessageBox.Show("*** No courses available to register. *** \nAsk Administrator to add new course.", "Error");
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
    }
}

// Notes: Add funtion to handle reset of page if error occurs. 