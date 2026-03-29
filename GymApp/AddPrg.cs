using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymApp
{
    public partial class AddPrg : Form
    {
        DataHandler handler = new DataHandler();
        public AddPrg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrainingProgram program = new TrainingProgram(txtId.Text, txtCapacity.Text,txtName.Text, txtDescriptor.Text, txtInstructor.Text,txtSchedule.Text, txtDuration.Text);
            handler.AddPrograms(program.ClassId, program.ClassName, program.Description, program.Instructor ,program.Schedule, program.Capacity, program.Duration);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OptionsIIForm optionsForm = new OptionsIIForm();
            optionsForm.Show();
            this.Close();
        }

        private void AddPrg_Load(object sender, EventArgs e)
        {

        }
    }
}
