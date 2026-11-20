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
            List<Movie> movieList = DatabaseManager.requestMovies();
            listBox1.DisplayMember = "movieID";
            listBox1.DataSource = movieList;
        }
    }
}
