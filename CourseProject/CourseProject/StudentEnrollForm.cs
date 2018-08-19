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
using System.Data;
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

            // Try catch to handle exeptions. 
            try
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
                        resetForm();
                        MessageBox.Show("*** No student found OR no course available.***\nPlease check student ID and try again.", "Error");
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
            catch (Exception ex)
            {
                resetForm();
                MessageBox.Show(ex.Message);
            }
        }

        // Button that will enroll the student in a course.
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                bool max;                   // Bool that will method value determining if a course is full.
                max = checkEnrollment();    // Bool max will get the value from checkEnrollment method. 

                // If statement will only run if course is not full.
                if (max == false)
                {
                    using (conn = new SqlConnection(connectionString))
                    using (SqlCommand comd = new SqlCommand
                    ("INSERT INTO enrollment (courseId, studentId) " +
                    "VALUES (@courseId,  @studentId)", conn))
                    {
                        conn.Open();
                        comd.Parameters.AddWithValue("@courseId", courseComboBox.SelectedValue);
                        comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                        comd.ExecuteScalar();
                        MessageBox.Show("Course Added.", "Success!");
                        resetForm();
                    }
                }

                // If course is full.
                else
                {
                    resetForm();
                    MessageBox.Show("*** Sorry, the course is currently full. ***", "Error");
                }
            }

            // Displays error if the student ID is not in the database. 
            catch (Exception)
            {
                resetForm();
                MessageBox.Show("*** A student is not associated with that ID.***\nPlease check student ID and try again.", "Error");
            }
        }

        // Button that will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //*******************************************
        // Method that will clear form.             *
        //*******************************************
        public void resetForm()
        {
            btnEnroll.Enabled = false;
            courseComboBox.SelectedIndex = -1;
            courseComboBox.Enabled = false;
            studentIdTextBox.Clear();
            studentIdTextBox.Focus();
        }

        //*******************************************
        // Method that will check if a course has   *
        // reached the enrollment limit. Returns a  *
        // bool value.                              *
        //*******************************************
        public bool checkEnrollment()
        {
            bool maxReached;    // Bool that's used in determining if a course is full. 
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
            ("SELECT COUNT(DISTINCT studentId) FROM enrollment" +
            " WHERE courseId = @courseId" +
            " GROUP BY courseMax" +
            " HAVING COUNT(DISTINCT studentId) <= courseMax ", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@courseId", courseComboBox.SelectedValue);
                DataTable countTable = new DataTable();
                adapter.Fill(countTable);

                // If course is full, return true. 
                if (countTable.Rows.Count < 1)
                {
                    maxReached = true;
                    return maxReached;
                }

                // Else course is not full. 
                else
                {
                    maxReached = false;
                    return maxReached;
                }
            }
        }
    }
}
