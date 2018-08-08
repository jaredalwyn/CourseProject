//***********************************************************
// This is the instructor view course form.                 *
// This form will allow an instructor to enter in their ID  *
// and display all the courses they are currently teaching  *
// in a dropdown box. Once course is selected from the      *
// dropdown box, instructor will see all students           *
// currently enrolled in the course. Instructor can         *
// update grade from this point.                            *
//***********************************************************
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
    public partial class InstructorViewCourseForm : Form
    {
        string connectionString;    // Declared string variable at the class level.
        SqlConnection conn;         // SQLconnection variable.
        BindingSource studentBindingSource = new BindingSource();
        public InstructorViewCourseForm()
        {
            InitializeComponent();

            // Assign value to the string vaiable.
            connectionString =
                ConfigurationManager.ConnectionStrings
                ["CourseProject.Properties.Settings.TinyCollegeDBConnectionString"]
                .ConnectionString;
        }

        // This button will search for Instructor ID and display courses in combobox.
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
                ("SELECT * FROM instructor i JOIN tEnrollment t ON i.instructorId = t.instructorId JOIN course c ON c.courseId = t.courseId" +
                " AND i.instructorId = @instructorId", conn))
            // ("SELECT course.courseId, course.courseName FROM course" +
            //" WHERE  course.instructorId = @instructorId", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@instructorId", instructorIdTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);

                // Checks to make sure there is data associated with instructor ID.
                if (courseTable.Rows.Count < 1)
                {
                    instructorIdTextBox.Clear();
                    instructorIdTextBox.Focus();
                    instructorNameTextBox.Clear();
                    coursesComboBox.Enabled = false;
                    coursesComboBox.DataSource = null;
                    MessageBox.Show("*** No Instructor found. Please check Instructor ID ***");
                }
                // If there is data, then display.
                else
                {
                    DataRow dr = courseTable.Rows[0];
                    instructorNameTextBox.Text = dr["instructorName"].ToString();
                    coursesComboBox.Enabled = true;
                    coursesComboBox.DisplayMember = "courseName";
                    coursesComboBox.ValueMember = "courseId";
                    coursesComboBox.DataSource = courseTable;
                }
            }
        }

        // Button that will close current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Form load event.
        private void InstructorViewCourseForm_Load(object sender, EventArgs e)
        {
        }

        // Combobox to show courses. This will update the data grid view on change.
        private void coursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentDataGridView.DataSource = studentBindingSource;
            using (conn = new SqlConnection(connectionString))
            using (SqlCommand comd = new SqlCommand
                ("SELECT student.studentId, studentName, studentGrade FROM student, enrollment" +
                " WHERE student.studentId = enrollment.studentId AND enrollment.courseId = @courseId", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                try
                {
                    comd.Parameters.AddWithValue("@courseId", coursesComboBox.SelectedValue);
                    DataTable studentTable = new DataTable();
                    adapter.Fill(studentTable);
                    this.studentDataGridView.DataSource = studentTable;
                }
                catch (Exception)
                {
                    instructorIdTextBox.Clear();
                }
            }
        }

        // Button that will update current grades for student.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        // Data grid view for students in the currently selected course.
        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
