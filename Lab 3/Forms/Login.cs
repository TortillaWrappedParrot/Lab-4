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

        private void button1_Click(object sender, EventArgs e)
        {
            loginError.Visible = true;
            loginError.Text = "Started";
            DateOnly date = new(2026, 11, 1);
            //List<Movie> movieList = MockEndpoint.getMovies();
            //listBox1.DisplayMember = "movieID";
            //listBox1.DataSource = movieList;


            MockEndpoint.addUser("newUser1", "coolPassword", "s5_11-3-25|s295_11-3-26");
            listBox1.Items.Add(MockEndpoint.getUser(2).username);
            loginError.Text = MockEndpoint.getUser(2).watchedMovies;
        }
    }
}
