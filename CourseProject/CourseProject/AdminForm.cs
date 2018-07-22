//*******************************************
// This is the Administration form.         *
// Admins can add new courses, students,    *
// and Instructors into the system.         *
//*******************************************
using System;
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        // Load event.
        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        // Button to add new course into the system.
        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            AddCourseForm addcourseForm = new AddCourseForm();
            addcourseForm.ShowDialog();
        }

        // Button to add new student into the system.
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudentForm addstudentForm = new AddStudentForm();
            addstudentForm.ShowDialog();
        }

        // Button to add new Instructor into the system.
        private void btnAddInstructor_Click(object sender, EventArgs e)
        {
            AddInstructorForm addinstructorForm = new AddInstructorForm();
            addinstructorForm.ShowDialog();
        }

        // Button to return to Main Form. 
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button to Exit the program.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
