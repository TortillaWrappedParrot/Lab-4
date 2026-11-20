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
            //bool check = Client.clientLogin(usernameText.Text, passwordText.Text);
            bool check = Client.clientLogin("basicAdmin", "password2");

            if (check == false)
            {
                loginError.Visible = true;
                loginError.Text = "Failed to login";
            }
        }
    }
}
