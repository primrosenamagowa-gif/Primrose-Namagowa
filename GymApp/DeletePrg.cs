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
    public partial class DeletePrg : Form
    {
        DataHandler handler = new DataHandler();
        public DeletePrg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            handler.DeleteProgram(txtID.Text);
        }

        private void DeletePrg_Load(object sender, EventArgs e)
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
