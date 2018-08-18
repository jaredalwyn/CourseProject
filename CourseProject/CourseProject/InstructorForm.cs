//***********************************************
// This is the Main page for Instructors.       *
// Instructors can further select other options *
// from this page, or return to the main form.  *
//***********************************************
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
    public partial class InstructorForm : Form
    {
        public InstructorForm()
        {
            InitializeComponent();
        }

        // Load event for the instructor form.
        private void InstructorForm_Load(object sender, EventArgs e)
        {
        }

        // Button to return to main form.
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Button that will exit program.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Button that will open new form to view courses and update grades. 
        private void btnViewCourses_Click(object sender, EventArgs e)
        {
            InstructorViewCourseForm instructorViewCourseForm = new InstructorViewCourseForm();
            instructorViewCourseForm.ShowDialog();
        }

        // Button that will allow Instructor to enroll in course. 
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            InstructorEnrollForm instructorEnrollForm = new InstructorEnrollForm();
            instructorEnrollForm.ShowDialog();
        }

        private void formsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
