using Lab_4.Objects;

namespace Lab_4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Client.clientLogin(usernameText.Text, passwordText.Text) == false)
            {
                loginError.Visible = true;
                loginError.Text = "Failed to login";
            }
        }
    }
}
