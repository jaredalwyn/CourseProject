﻿// Created by Jared Alwyn and Eldon Edwards
// Late Summer 2018
// Course Project
// Advanced Agile Software Development
// Professor Buzhyason

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
            Close();
        }
    }
}
