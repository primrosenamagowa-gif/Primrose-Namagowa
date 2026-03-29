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
    public partial class UpdateForm : Form
    {
        DataHandler handler = new DataHandler();
        public UpdateForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            handler.UpdateData(txtID.Text, txtName.Text, txtLastName.Text, txtGender.Text, txtNumber.Text, txtAddress.Text, txtProgram.Text, DateTime.Parse(dtp3.Text), DateTime.Parse(dtp1.Text), DateTime.Parse(dtp2.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OptionsForm OptionsForm = new OptionsForm();
            OptionsForm.Show();
            this.Close();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {

        }
    }
}
