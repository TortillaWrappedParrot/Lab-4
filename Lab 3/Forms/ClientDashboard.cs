using Lab_4.Forms;
using Lab_4.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab_4
{
    public partial class ClientDashboard : Form
    {
        public ClientDashboard()
        {
            InitializeComponent();

            User? check = Client.getCurrentUser();

            if (check != null)
            {
                if (check.getStatus() == true)
                {
                    adminDashboard.Visible = true;
                    adminDashboard.Enabled = true;
                }
                else
                {
                    adminDashboard.Visible = false;
                    adminDashboard.Enabled = false;
                }

                movieDisplay.DataSource = Client.displayMovies();
                movieDisplay.DisplayMember = "DisplayText";
                movieDisplay.ValueMember = "DescriptionText";

                movieDescription.Visible = false;
            }
            else
            {
                this.Close();
                new Login().Show();
            }
        }

        private void updateMovieDisplay(Filter filter)
        {
            movieDisplay.DataSource = Client.displayMovies(filter);
            movieDisplay.DisplayMember = "DisplayText";
            movieDisplay.ValueMember = "DescriptionText";
        }

        private void updateMovieDisplay(List<Movie> movies)
        {
            movieDisplay.DataSource = movies;
            movieDisplay.DisplayMember = "DisplayText";
            movieDisplay.ValueMember = "DescriptionText";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            Filter newFilter = new Filter(keywordFilter.Text.Trim(), titleFilter.Text.Trim(), directorFilter.Text.Trim(), releaseYearFilter.Text.Trim(), genreFilter.Text.Trim());

            updateMovieDisplay(newFilter);
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            Client.logout();
        }

        private void movieDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (movieDisplay.SelectedValue != null)
            {
                movieDescription.Visible = true;
                movieDescription.Text = movieDisplay.SelectedValue.ToString();
            }
            else
            {
                movieDescription.Visible = false;
            }
        }

        private void adminDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            new AdminDashboard().Show();
        }

        private void getRecomendedFilter_Click(object sender, EventArgs e)
        {
            List<Movie> movies = Client.getRecomendations();

            updateMovieDisplay(movies);
        }
    }
}
