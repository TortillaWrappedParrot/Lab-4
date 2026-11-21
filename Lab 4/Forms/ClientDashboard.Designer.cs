namespace Lab_4
{
    partial class ClientDashboard
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

        private void InitializeComponents()
        {

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            keywordFilter = new TextBox();
            label1 = new Label();
            searchButton = new Button();
            label2 = new Label();
            titleLabel = new Label();
            titleFilter = new TextBox();
            directorFilter = new TextBox();
            authorLabel = new Label();
            releaseYearFilter = new TextBox();
            releaseYearLabel = new Label();
            genreFilter = new TextBox();
            genreLabel = new Label();
            signOutButton = new Button();
            adminDashboard = new Button();
            getRecomendedFilter = new Button();
            clientError = new Label();
            movieDisplay = new ListBox();
            movieDescription = new Label();
            SuspendLayout();
            // 
            // keywordFilter
            // 
            keywordFilter.Location = new Point(161, 99);
            keywordFilter.Name = "keywordFilter";
            keywordFilter.Size = new Size(359, 23);
            keywordFilter.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 75);
            label1.Name = "label1";
            label1.Size = new Size(162, 15);
            label1.TabIndex = 2;
            label1.Text = "Keyword Search (Description)";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(526, 98);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(64, 23);
            searchButton.TabIndex = 3;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 128);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 4;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(60, 164);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(29, 15);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title";
            // 
            // titleFilter
            // 
            titleFilter.Location = new Point(27, 182);
            titleFilter.Name = "titleFilter";
            titleFilter.Size = new Size(100, 23);
            titleFilter.TabIndex = 7;
            // 
            // directorFilter
            // 
            directorFilter.Location = new Point(27, 228);
            directorFilter.Name = "directorFilter";
            directorFilter.Size = new Size(100, 23);
            directorFilter.TabIndex = 9;
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(54, 210);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(49, 15);
            authorLabel.TabIndex = 8;
            authorLabel.Text = "Director";
            // 
            // releaseYearFilter
            // 
            releaseYearFilter.Location = new Point(27, 276);
            releaseYearFilter.Name = "releaseYearFilter";
            releaseYearFilter.Size = new Size(100, 23);
            releaseYearFilter.TabIndex = 11;
            // 
            // releaseYearLabel
            // 
            releaseYearLabel.AutoSize = true;
            releaseYearLabel.Location = new Point(41, 258);
            releaseYearLabel.Name = "releaseYearLabel";
            releaseYearLabel.Size = new Size(71, 15);
            releaseYearLabel.TabIndex = 10;
            releaseYearLabel.Text = "Release Year";
            // 
            // genreFilter
            // 
            genreFilter.Location = new Point(27, 324);
            genreFilter.Name = "genreFilter";
            genreFilter.Size = new Size(100, 23);
            genreFilter.TabIndex = 13;
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Location = new Point(54, 306);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(38, 15);
            genreLabel.TabIndex = 12;
            genreLabel.Text = "Genre";
            // 
            // signOutButton
            // 
            signOutButton.Location = new Point(12, 12);
            signOutButton.Name = "signOutButton";
            signOutButton.Size = new Size(75, 23);
            signOutButton.TabIndex = 15;
            signOutButton.Text = "Sign Out";
            signOutButton.UseVisualStyleBackColor = true;
            signOutButton.Click += signOutButton_Click;
            // 
            // adminDashboard
            // 
            adminDashboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            adminDashboard.Enabled = false;
            adminDashboard.Location = new Point(969, 420);
            adminDashboard.Name = "adminDashboard";
            adminDashboard.Size = new Size(135, 23);
            adminDashboard.TabIndex = 16;
            adminDashboard.Text = "Admin Dashboard";
            adminDashboard.UseVisualStyleBackColor = true;
            adminDashboard.Visible = false;
            adminDashboard.Click += adminDashboard_Click;
            // 
            // getRecomendedFilter
            // 
            getRecomendedFilter.Location = new Point(596, 99);
            getRecomendedFilter.Name = "getRecomendedFilter";
            getRecomendedFilter.Size = new Size(153, 23);
            getRecomendedFilter.TabIndex = 17;
            getRecomendedFilter.Text = "Get Recomended Movies";
            getRecomendedFilter.UseVisualStyleBackColor = true;
            getRecomendedFilter.Click += getRecomendedFilter_Click;
            // 
            // clientError
            // 
            clientError.AutoSize = true;
            clientError.ForeColor = Color.Crimson;
            clientError.Location = new Point(161, 415);
            clientError.Name = "clientError";
            clientError.Size = new Size(73, 15);
            clientError.TabIndex = 18;
            clientError.Text = "Error Display";
            clientError.Visible = false;
            // 
            // movieDisplay
            // 
            movieDisplay.FormattingEnabled = true;
            movieDisplay.Location = new Point(161, 131);
            movieDisplay.Name = "movieDisplay";
            movieDisplay.Size = new Size(588, 274);
            movieDisplay.TabIndex = 19;
            movieDisplay.SelectedIndexChanged += movieDisplay_SelectedIndexChanged;
            // 
            // movieDescription
            // 
            movieDescription.Location = new Point(778, 131);
            movieDescription.Name = "movieDescription";
            movieDescription.Size = new Size(326, 274);
            movieDescription.TabIndex = 20;
            movieDescription.Text = "The qucik brown fox jumped over the lazy dog. Quartz of black sphinx, judge my vow.";
            // 
            // ClientDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 455);
            Controls.Add(movieDescription);
            Controls.Add(movieDisplay);
            Controls.Add(clientError);
            Controls.Add(getRecomendedFilter);
            Controls.Add(adminDashboard);
            Controls.Add(signOutButton);
            Controls.Add(genreFilter);
            Controls.Add(genreLabel);
            Controls.Add(releaseYearFilter);
            Controls.Add(releaseYearLabel);
            Controls.Add(directorFilter);
            Controls.Add(authorLabel);
            Controls.Add(titleFilter);
            Controls.Add(titleLabel);
            Controls.Add(label2);
            Controls.Add(searchButton);
            Controls.Add(label1);
            Controls.Add(keywordFilter);
            Name = "ClientDashboard";
            Text = "CineTrend Client Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox keywordFilter;
        private Label label1;
        private Button searchButton;
        private Label label2;
        private Label titleLabel;
        private TextBox titleFilter;
        private TextBox directorFilter;
        private Label authorLabel;
        private TextBox releaseYearFilter;
        private Label releaseYearLabel;
        private TextBox genreFilter;
        private Label genreLabel;
        private Button signOutButton;
        private Button adminDashboard;
        private Button getRecomendedFilter;
        private Label clientError;
        private ListBox movieDisplay;
        private Label movieDescription;
    }
}