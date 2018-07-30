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
    }
}
