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
    public partial class OptionsForm : Form
    {
        DataHandler handler = new DataHandler();
        public OptionsForm()
        {
            
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
           RegForm frm = new RegForm();
            frm.ShowDialog();
            this.Close();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadForm frm = new ReadForm();
            frm.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateForm frm = new UpdateForm();
            frm.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DelForm frm = new DelForm();    
            frm.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm();
            frm.Show();
            this.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
