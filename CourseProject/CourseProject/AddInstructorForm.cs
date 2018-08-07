//**********************************************
// This is the add instructor form.            *
// Admins can add enter a new instructor name  *
// and click add instructor.                   *
//**********************************************
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
    public partial class AddInstructorForm : Form
    {
        public AddInstructorForm()
        {
            InitializeComponent();
        }

        // Holds the name of the instructor. 
        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        // Button to add instructor information from name text box. 
        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        // Closes the current form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
