//*******************************************
// This is the student form page.           *
// The student will have multiple selection *
// options from this page including         *
// the option to return to the main form.   * 
//*******************************************
using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        // Student form load event.
        private void StudentForm_Load(object sender, EventArgs e)
        {
        }

        // This button will return to main form.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // This button will exit program.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Button to register for course.
        private void btnRegister_Click(object sender, EventArgs e)
        {
            StudentEnrollForm studentEnrollForm = new StudentEnrollForm();
            studentEnrollForm.ShowDialog();
        }

        // Button for student to view current courses registered for. 
        private void btnViewCourse_Click(object sender, EventArgs e)
        {
            StudentViewCourseForm studentViewCourseForm = new StudentViewCourseForm();
            studentViewCourseForm.ShowDialog();
        }

        // Opens the about page. 
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        // Opens the works cited page. 
        private void worksCitedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorksCitedForm worksCitedForm = new WorksCitedForm();
            worksCitedForm.ShowDialog();
        }

        // Closes the program
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Opens the Tiny College home page.
        private void tinyCollegeHomePageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Opens the administrator page.
        private void administratorPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        // Opens the instructor page. 
        private void instructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructorForm instructorForm = new InstructorForm();
            instructorForm.ShowDialog();
        }
    }
}
