//*******************************************
// This is the add course form.             *
// Admins can add enter new course info     *
// and click add course.                    *
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
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        // Holds information for the course title. 
        private void courseTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // Holds information for the Semester Offered.
        private void SemesterTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // Button that will add course from text in courseText and SemesterText. 
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        // Button that will close the form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
