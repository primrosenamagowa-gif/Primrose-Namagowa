using GymApp;
using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.IO;

namespace GymApp
{
    public partial class frmRegister : Form
    {
        private UserManager _userManager;

        public frmRegister()
        {
            InitializeComponent();
            _userManager = new UserManager(@"C:\Games\Users");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Register_Load(object sender, EventArgs e)
        {
        }

        

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)

        {
            string username = txtusername.Text;
            string password = txtpassword.Text;
            string confirmPassword = txtCompassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userManager.UserExists(username))
            {
                MessageBox.Show("Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _userManager.SaveUser(username, password);
            MessageBox.Show("User registered successfully!");

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
