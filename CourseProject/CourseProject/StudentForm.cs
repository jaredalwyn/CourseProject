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
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

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
    }
}
