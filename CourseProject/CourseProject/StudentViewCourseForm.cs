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
        int studentId;

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

             ("SELECT studentId, studentName, studentGrade FROM student" +
            " WHERE  student.studentId = @studentId", conn))
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
                    studentId = int.Parse(dr["studentId"].ToString());
                    lblStudentName.Text = dr["studentName"].ToString();
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
