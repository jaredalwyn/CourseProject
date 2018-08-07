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
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
               ("SELECT student.studentName, student.studentId, course.courseName, student.studentGrade FROM student, course" +
              " WHERE  student.studentId = @studentId AND student.studentId = course.studentId", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@studentId", studentIdTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                if (courseTable.Rows.Count < 1)
                {
                    lblStudentName.Clear();
                    lblStudentName.Text = "No Student Found";
                }
                else
                {
                    DataRow dr = courseTable.Rows[0];
                    lblStudentName.Text = dr["studentName"].ToString();

                    // Upadate Data grid view
                    studentDataGridView.DataSource = studentBindingSource;
                    this.studentDataGridView.DataSource = courseTable;
                }
            }
        }

        // Button will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
