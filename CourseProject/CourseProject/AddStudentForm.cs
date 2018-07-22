//*******************************************
// This is the add student form.            *
// Admins can add enter a new student name  *
// and click add student.                   *
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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        // Form load event.
        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        // Textbox where New Student name is entered into. 
        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        // Button that adds the student information from the nameTextbox.
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        // Button that closes the form. 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
