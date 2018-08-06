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

             ("SELECT courseId, courseName FROM course" +
            " WHERE  course.instructorId = @instructorId", conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(comd))
            {
                comd.Parameters.AddWithValue("@instructorId", instructorIdTextBox.Text);
                DataTable courseTable = new DataTable();
                adapter.Fill(courseTable);
                if (courseTable.Rows.Count < 1)
                {
                    coursesComboBox.Enabled = false;
                    coursesComboBox.DataSource = null;
                    MessageBox.Show("*** No Instructor found. Please check Instructor ID ***");
                }
                else
                {
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

        // Combobox to show courses.
        private void coursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
