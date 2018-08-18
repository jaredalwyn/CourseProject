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
        SqlDataAdapter adapter;
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

            // Try catch to display any errors when searching for instructor ID.
            try
            {
                using (conn = new SqlConnection(connectionString))
                using (SqlCommand comd = new SqlCommand
                ("SELECT courseName, courseId, instructorName from course c" +
                " JOIN instructor i ON c.instructorId = i.instructorId" +
                " AND i.instructorId = @instructorId", conn))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
                {
                    comd.Parameters.AddWithValue("@instructorId", instructorIdTextBox.Text);
                    DataTable courseTable = new DataTable();
                    adapter.Fill(courseTable);

                    DataRow dr = courseTable.Rows[0];
                    instructorNameTextBox.Text = dr["instructorName"].ToString();
                    coursesComboBox.Enabled = true;
                    coursesComboBox.DisplayMember = "courseName";
                    coursesComboBox.ValueMember = "courseId";
                    coursesComboBox.DataSource = courseTable;
                }
            }
            catch (Exception)
            {
                resetForm();
                MessageBox.Show("***Instructor is not enrolled in a course.***\nPlease check Instructor ID.", "Error");
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
            // Uses an If statement to make sure there wasn't an error in the Instuctor ID textbox. (Takes away double error).
            if (coursesComboBox.SelectedIndex != -1)
            {

                // Try catch to display any possible errors. 
                try
                {
                    studentDataGridView.DataSource = studentBindingSource;
                    adapter = new SqlDataAdapter
                        ("SELECT enrollmentId, enrollment.studentId AS 'Student ID', studentGrade AS 'Student Grade' FROM enrollment" +
                         " WHERE enrollment.courseId = @courseId", connectionString);
                    SqlCommandBuilder comdBuilder = new SqlCommandBuilder(adapter);
                    adapter.SelectCommand.Parameters.AddWithValue("@courseId", coursesComboBox.SelectedValue);
                    DataTable studentTable = new DataTable();
                    adapter.Fill(studentTable);
                    studentBindingSource.DataSource = studentTable;
                    studentDataGridView.DataSource = studentTable;
                    btnUpdate.Enabled = true;
                    studentDataGridView.Columns[0].Visible = false;
                }
                catch (Exception ex)
                {
                    resetForm();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Button that will update current grades for student.
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            // Try catch to display update error.
            try
            {
                // Update the datasource.
                adapter.Update((DataTable)studentBindingSource.DataSource);
                MessageBox.Show("Update successful.", "Success!");
            }

            // Will display an error if data could not be updated. Could be from invalid value.
            catch (Exception)
            {
                MessageBox.Show("***Data could not be updated.***\n Please look at value and try again.", "Error");
            }
        }

        // Data grid view for students in the currently selected course.
        private void studentDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //*******************************************
        // Method that will clear form.             *
        //*******************************************
        public void resetForm()
        {
            instructorIdTextBox.Clear();
            instructorIdTextBox.Focus();
            instructorNameTextBox.Clear();
            coursesComboBox.Enabled = false;
            coursesComboBox.SelectedIndex = -1;
            btnUpdate.Enabled = false;
        }
    }
}
