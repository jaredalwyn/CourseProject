//*******************************************
// This is the about form.                  *
// This displays project information.       *
//*******************************************
using System;
using System.Windows.Forms;

namespace CourseProject
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        // Paint.
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        // Button to close about form. 
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
