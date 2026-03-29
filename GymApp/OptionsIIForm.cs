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
    public partial class OptionsIIForm : Form
    {
        public OptionsIIForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadPrg readPrg = new ReadPrg();
            readPrg.Show();
                

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPrg addPrg = new AddPrg();
            addPrg.Show();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePrg updatePrg = new UpdatePrg();
            updatePrg.Show();
            this.Close();
        }

        private void btnSearchII_Click(object sender, EventArgs e)
        {
            SearchPrg searchPrg = new SearchPrg();
                searchPrg.Show();
            this.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeletePrg deletePrg = new DeletePrg();
            deletePrg.Show();
            this.Close();
        }

        private void OptionsIIForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }
    }
}
