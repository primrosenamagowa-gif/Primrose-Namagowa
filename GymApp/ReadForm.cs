using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    public partial class ReadForm : Form
    {
        DataHandler handler = new DataHandler();
        public ReadForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = handler.ReadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsForm OptionsForm = new OptionsForm();
            OptionsForm.Show();
            this.Close();

        }

        private void ReadForm_Load(object sender, EventArgs e)
        {

        }
    }
}
