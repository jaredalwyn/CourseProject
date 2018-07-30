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
        public StudentViewCourseForm()
        {
            InitializeComponent();
        }

        // Load event for the form. 
        private void StudentViewCourseForm_Load(object sender, EventArgs e)
        {

        }

        // Find button searches for student ID.
        private void btnFind_Click(object sender, EventArgs e)
        {

        }

        // Button will close the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
