using Lab_4.Objects;

namespace Lab_4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            User? test = DatabaseManager.serverLogin(usernameText.Text, passwordText.Text);
            if (test != null)
            {
                loginError.Visible = true;
                loginError.Text = test.ToString();
            }
        }
    }
}
