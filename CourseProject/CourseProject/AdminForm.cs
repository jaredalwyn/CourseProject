//*******************************************
// This is the main Administration form.    *
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

        // Opens the main home page form. 
        private void tinyCollegeHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Opens the Instructor main page.
        private void instructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructorForm instructorForm = new InstructorForm();
            instructorForm.ShowDialog();
            this.Close();
        }

        // Opens the Student main page. 
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
            this.Close();
        }

        // Opens the About Form.
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        // Opens the works cited form. 
        private void worksCitedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorksCitedForm worksCitedForm = new WorksCitedForm();
            worksCitedForm.ShowDialog();
        }

        // Handles the event in the file menu when exit is clicked.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Label Click
        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
