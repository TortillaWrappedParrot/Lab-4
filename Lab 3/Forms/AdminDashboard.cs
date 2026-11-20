using Lab_4.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lab_4.Forms
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void clientDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClientDashboard().Show();
        }

        private void generateUsersButton_Click(object sender, EventArgs e)
        {
            int userAmountNum;
            int movieAmountNum;
            int oldestYearNum;

            try
            {
                userAmountNum = int.Parse(userAmount.Text.Trim());
                movieAmountNum = int.Parse(movieAmount.Text.Trim());
                oldestYearNum = int.Parse(monthAmount.Text.Trim());

                if (userAmountNum <= 0 || movieAmountNum <= 0 || oldestYearNum < 0 || oldestYearNum > DateTime.Now.Year * 12)
                {
                    adminError.Visible = true;
                    adminError.Text = "Invalid number to create dummies";
                }
                else
                {
                    bool verfiy = DatabaseManager.createDummies(userAmountNum, movieAmountNum, oldestYearNum);

                    if (verfiy)
                    {
                        adminError.Visible = true;
                        adminError.Text = "Finished";
                    }
                    else
                    {
                        adminError.Visible = true;
                        adminError.Text = "Failed to create one or more dummies";
                    }
                }

            } catch (Exception ex)
            {
                adminError.Visible = true;
                adminError.Text = "Invalid input";
            }
        }
    }
}
