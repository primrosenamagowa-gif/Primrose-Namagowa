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

namespace GymApp
{
    public partial class UpdatePrg : Form
    {
        DataHandler handler = new DataHandler();
        public UpdatePrg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            handler.UpdatePrograms(txtID.Text, txtName.Text, txtDescription.Text, txtInstructor.Text, txtSchedule.Text, txtCapacity.Text, txtDuration.Text);
        }

        private void UpdatePrg_Load(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            OptionsIIForm optionsForm = new OptionsIIForm();
            optionsForm.Show();
            this.Close();
        }
    }
}
