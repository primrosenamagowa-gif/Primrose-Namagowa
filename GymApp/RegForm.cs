using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymApp
{
    public partial class RegForm : Form
    {
        DataHandler handler = new DataHandler();
        public RegForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Member newmembers = new Member(txtID.Text, txtName.Text, txtLastName.Text, txtGender.Text, txtNumber.Text, txtAddress.Text, txtProgram.Text,DateTime.Parse(dtp1.Text), DateTime.Parse(dtp2.Text),  DateTime.Parse(dtp3.Text));
            handler.registerMember(newmembers.MemberID, newmembers.FirstName, newmembers.LastName, newmembers.Gender, newmembers.PhoneNumber, newmembers.Address, newmembers.TrainingProgram, newmembers.Dob, newmembers.Start, newmembers.End);


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            OptionsForm OptionsForm = new OptionsForm();
            OptionsForm.Show();
            this.Close();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }
    }
}
