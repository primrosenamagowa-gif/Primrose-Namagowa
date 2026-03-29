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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            OptionsForm frm = new OptionsForm();
            frm.Show();
            this.Close();
        }

        private void btnPrograms_Click(object sender, EventArgs e)
        {
            OptionsIIForm frm = new OptionsIIForm();
            frm.Show();
            this.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
