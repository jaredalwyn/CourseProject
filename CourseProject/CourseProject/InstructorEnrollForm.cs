//*******************************************
// This is the enroll form for instructors. *
// Instructors will enter their ID          *
// and select the course they would like to *
// enroll in. An error will occur if course *
// has an instructor.                       *
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
    public partial class InstructorEnrollForm : Form
    {
        public InstructorEnrollForm()
        {
            InitializeComponent();
        }

        // Load event for the instructor enroll form. 
        private void InstructorEnrollForm_Load(object sender, EventArgs e)
        {
        }

        // Holds the value for the instructor ID.
        private void instructorTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        // ComboBox that will display courses available to register for. 
        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Button that will enroll the instructor into the selected course. 
        private void btnEnroll_Click(object sender, EventArgs e)
        {

        }

        // Button that will close this form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
