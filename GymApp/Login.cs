using GymApp;
using System;
using System.Windows.Forms;
using System.IO;

namespace GymApp
{
    public partial class Login : Form
    {
        private UserManager _userManager;

        public Login()
        {
            InitializeComponent();
            _userManager = new UserManager(@"C:\Games\Users");
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userManager.VerifyUser(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenMainForm(); // Call method to open Main form
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenMainForm()
        {
            Main mainForm = new Main();
            mainForm.Show();
            this.Hide(); // Hide the login form
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
