//***********************************************************
// This is the student view course form. This form will     *
// allow students to type in their student ID and generate  *
// a list of the classes they are currently taking and      *
// current grade recieved. Displays promp if student has    *
// enough credits to graduate                               *
//***********************************************************
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
    public partial class StudentViewCourseForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        BindingSource studentBindingSource = new BindingSource();
        public StudentViewCourseForm()
        {
            InitializeComponent();

            // Assign value to the string vaiable.
            connectionString =
                ConfigurationManager.ConnectionStrings
                ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
                .ConnectionString;
        }

        // Load event for the form. 
        private void StudentViewCourseForm_Load(object sender, EventArgs e)
        {
        }

        // Find button searches for student ID.
        private void btnFind_Click(object sender, EventArgs e)
        {

            // Try catch to handle any exceptions.
            try
            {
                checkCredits();
                using (conn = new SqlConnection(connectionString))
                using (SqlCommand comd = new SqlCommand
                    ("SELECT studentName, courseName AS 'Course Name', studentGrade AS 'Student Grade'" +
                    " FROM student JOIN enrollment ON student.studentId = enrollment.studentId " +
                    " JOIN course ON course.courseId = enrollment.courseId WHERE student.studentId = @studentId", conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
                {
                    comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                    DataTable courseTable = new DataTable();
                    adapter.Fill(courseTable);

                    // Displays error message if student either isn't enrolled in a course, or doesn't exist in the database. 
                    if (courseTable.Rows.Count < 1)
                    {
                        resetForm();
                        courseTable.Clear();
                        studentDataGridView.DataSource = courseTable;
                        MessageBox.Show("*** Student is currently not enrolled in any course.***\nPlease check the student ID and try again.", "Error");
                    }

                    // Displays data if student information is found. 
                    else
                    {
                        DataRow dr = courseTable.Rows[0];
                        lblStudentName.Text = dr["studentName"].ToString();

                        // Upadate Data grid view
                        studentDataGridView.DataSource = studentBindingSource;
                        studentDataGridView.DataSource = courseTable;
                        studentDataGridView.Columns[0].Visible = false;

                        // checkCredits();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Button will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //*******************************************
        // Method that will clear form.             *
        //*******************************************
        public void resetForm()
        {
            lblStudentName.Clear();
            studentIdTextBox.Clear();
            studentIdTextBox.Focus();
        }

        //*******************************************
        // Method that will check student credits   *
        // and display message if student has met   *
        // graduation requirements.                 *
        //*******************************************
        public void checkCredits()
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
                ("SELECT studentId, studentCredit FROM student" +
                " WHERE studentCredit >= 120 AND studentId = @studentId", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                DataTable creditTable = new DataTable();
                adapter.Fill(creditTable);

                if (creditTable.Rows.Count < 1)
                {
                }
                else
                {
                    MessageBox.Show("Congratulations, you have graduated from Tiny College!", "Congrats!");
                }
            }
        }
    }
}
