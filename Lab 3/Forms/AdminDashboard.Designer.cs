namespace Lab_4.Forms
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientDashboard = new Button();
            listBox1 = new ListBox();
            generateTrendsButton = new Button();
            trendLabel = new Label();
            generateUsersButton = new Button();
            userAmount = new TextBox();
            movieAmount = new TextBox();
            amountLabel = new Label();
            label1 = new Label();
            yearLabel = new Label();
            yearAmount = new TextBox();
            adminError = new Label();
            SuspendLayout();
            // 
            // clientDashboard
            // 
            clientDashboard.Location = new Point(667, 415);
            clientDashboard.Name = "clientDashboard";
            clientDashboard.Size = new Size(121, 23);
            clientDashboard.TabIndex = 0;
            clientDashboard.Text = "Client Dashboard";
            clientDashboard.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(207, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(484, 364);
            listBox1.TabIndex = 1;
            // 
            // generateTrendsButton
            // 
            generateTrendsButton.Location = new Point(269, 9);
            generateTrendsButton.Name = "generateTrendsButton";
            generateTrendsButton.Size = new Size(422, 23);
            generateTrendsButton.TabIndex = 2;
            generateTrendsButton.Text = "Generate Trends";
            generateTrendsButton.UseVisualStyleBackColor = true;
            // 
            // trendLabel
            // 
            trendLabel.AutoSize = true;
            trendLabel.Location = new Point(207, 13);
            trendLabel.Name = "trendLabel";
            trendLabel.Size = new Size(41, 15);
            trendLabel.TabIndex = 3;
            trendLabel.Text = "Trends";
            // 
            // generateUsersButton
            // 
            generateUsersButton.Location = new Point(12, 148);
            generateUsersButton.Name = "generateUsersButton";
            generateUsersButton.Size = new Size(128, 23);
            generateUsersButton.TabIndex = 4;
            generateUsersButton.Text = "Generate Users";
            generateUsersButton.UseVisualStyleBackColor = true;
            // 
            // userAmount
            // 
            userAmount.Location = new Point(12, 27);
            userAmount.Name = "userAmount";
            userAmount.Size = new Size(128, 23);
            userAmount.TabIndex = 5;
            // 
            // movieAmount
            // 
            movieAmount.Location = new Point(12, 75);
            movieAmount.Name = "movieAmount";
            movieAmount.Size = new Size(128, 23);
            movieAmount.TabIndex = 6;
            // 
            // amountLabel
            // 
            amountLabel.AutoSize = true;
            amountLabel.Location = new Point(12, 9);
            amountLabel.Name = "amountLabel";
            amountLabel.Size = new Size(96, 15);
            amountLabel.TabIndex = 7;
            amountLabel.Text = "Amount of Users";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 57);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 8;
            label1.Text = "Amount of Movies";
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(12, 101);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(69, 15);
            yearLabel.TabIndex = 10;
            yearLabel.Text = "Lowest Year";
            // 
            // yearAmount
            // 
            yearAmount.Location = new Point(12, 119);
            yearAmount.Name = "yearAmount";
            yearAmount.Size = new Size(128, 23);
            yearAmount.TabIndex = 9;
            // 
            // adminError
            // 
            adminError.AutoSize = true;
            adminError.ForeColor = Color.Crimson;
            adminError.Location = new Point(207, 415);
            adminError.Name = "adminError";
            adminError.Size = new Size(73, 15);
            adminError.TabIndex = 11;
            adminError.Text = "Error Display";
            adminError.Visible = false;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(adminError);
            Controls.Add(yearLabel);
            Controls.Add(yearAmount);
            Controls.Add(label1);
            Controls.Add(amountLabel);
            Controls.Add(movieAmount);
            Controls.Add(userAmount);
            Controls.Add(generateUsersButton);
            Controls.Add(trendLabel);
            Controls.Add(generateTrendsButton);
            Controls.Add(listBox1);
            Controls.Add(clientDashboard);
            Name = "AdminDashboard";
            Text = "CineTrend Admin Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientDashboard;
        private ListBox listBox1;
        private Button generateTrendsButton;
        private Label trendLabel;
        private Button generateUsersButton;
        private TextBox userAmount;
        private TextBox movieAmount;
        private Label amountLabel;
        private Label label1;
        private Label yearLabel;
        private TextBox yearAmount;
        private Label adminError;
    }
}