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
    public partial class DelForm : Form
    {
        DataHandler handler = new DataHandler();
        public DelForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            handler.DeleteData(txtID.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsForm OptionsForm = new OptionsForm();
            OptionsForm.Show();
            this.Close();

        }

        private void DelForm_Load(object sender, EventArgs e)
        {

        }
    }
}
