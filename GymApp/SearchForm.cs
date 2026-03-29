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
    public partial class SearchForm : Form
    {
        DataHandler handler = new DataHandler();
        public SearchForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            handler.Search(txtSeach.Text);
            dataGridView2.DataSource = handler.Search(txtSeach.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsForm OptionsForm = new OptionsForm();
            OptionsForm.Show();
            this.Close();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
