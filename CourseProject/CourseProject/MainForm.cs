// Created by:  Jared Alwyn
// Date:        Late Summer
// Project:     Course Project
// Class:       Advanced Agile Software Development
// Instructor:  Chiemerie Buzhyason

//*******************************************
// This is the main, or "home page" form.   *
// This form displays all the options that  *
// A user can select from. This will open   *
// other forms or close the program.        *
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Administration Button. Opens the Administration form.
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        // Instructor Button. Opens the Instructor form.
        private void btnInstructor_Click(object sender, EventArgs e)
        {
            InstructorForm instructorForm = new InstructorForm();
            instructorForm.ShowDialog();
        }

        // Students Button. Opens the Students form.
        private void btnStu_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        // Exit Button. Exits the program.
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Handles the event in the file menu when exit is clicked.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        // File Menu to open the Administration main form
        private void aministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
        }

        // File menu to open the Instructor main form. 
        private void instructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructorForm instructorForm = new InstructorForm();
            instructorForm.ShowDialog();
        }

        // File menu to open the Student main form. 
        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            studentForm.ShowDialog();
        }

        // Main form load event.
        private void MainForm_Load(object sender, EventArgs e)
        {
            btnAdmin.Focus();
        }
    }
}

// Notes: Administator assigns course availability. **
// Classes each have a limted number of seats
// Classes have credits that are applied to students.  
