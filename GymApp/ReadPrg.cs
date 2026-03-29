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
    public partial class ReadPrg : Form
    {
        DataHandler handler = new DataHandler();
        public ReadPrg()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.ReadPrograms();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsIIForm optionsForm = new OptionsIIForm();
            optionsForm.Show();
            this.Close();
        }

        private void ReadPrg_Load(object sender, EventArgs e)
        {

        }
    }
}
