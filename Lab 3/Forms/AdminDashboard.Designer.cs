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
            trendShowcase = new ListBox();
            generateTrendsButton = new Button();
            trendLabel = new Label();
            generateUsersButton = new Button();
            userAmount = new TextBox();
            movieAmount = new TextBox();
            amountLabel = new Label();
            label1 = new Label();
            monthLabel = new Label();
            monthAmount = new TextBox();
            adminError = new Label();
            label2 = new Label();
            trendMonthAmount = new TextBox();
            SuspendLayout();
            // 
            // clientDashboard
            // 
            clientDashboard.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            clientDashboard.Location = new Point(707, 421);
            clientDashboard.Name = "clientDashboard";
            clientDashboard.Size = new Size(121, 23);
            clientDashboard.TabIndex = 0;
            clientDashboard.Text = "Client Dashboard";
            clientDashboard.UseVisualStyleBackColor = true;
            clientDashboard.Click += clientDashboard_Click;
            // 
            // trendShowcase
            // 
            trendShowcase.FormattingEnabled = true;
            trendShowcase.Location = new Point(207, 38);
            trendShowcase.Name = "trendShowcase";
            trendShowcase.Size = new Size(484, 364);
            trendShowcase.TabIndex = 1;
            // 
            // generateTrendsButton
            // 
            generateTrendsButton.Location = new Point(269, 9);
            generateTrendsButton.Name = "generateTrendsButton";
            generateTrendsButton.Size = new Size(422, 23);
            generateTrendsButton.TabIndex = 2;
            generateTrendsButton.Text = "Generate Trends";
            generateTrendsButton.UseVisualStyleBackColor = true;
            generateTrendsButton.Click += generateTrendsButton_Click;
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
            generateUsersButton.Click += generateUsersButton_Click;
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
            // monthLabel
            // 
            monthLabel.AutoSize = true;
            monthLabel.Location = new Point(12, 101);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(74, 15);
            monthLabel.TabIndex = 10;
            monthLabel.Text = "Max Months";
            // 
            // monthAmount
            // 
            monthAmount.Location = new Point(12, 119);
            monthAmount.Name = "monthAmount";
            monthAmount.Size = new Size(128, 23);
            monthAmount.TabIndex = 9;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(707, 13);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 12;
            label2.Text = "Max Month Amount";
            // 
            // trendMonthAmount
            // 
            trendMonthAmount.Location = new Point(707, 31);
            trendMonthAmount.Name = "trendMonthAmount";
            trendMonthAmount.Size = new Size(116, 23);
            trendMonthAmount.TabIndex = 13;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(854, 458);
            Controls.Add(trendMonthAmount);
            Controls.Add(label2);
            Controls.Add(adminError);
            Controls.Add(monthLabel);
            Controls.Add(monthAmount);
            Controls.Add(label1);
            Controls.Add(amountLabel);
            Controls.Add(movieAmount);
            Controls.Add(userAmount);
            Controls.Add(generateUsersButton);
            Controls.Add(trendLabel);
            Controls.Add(generateTrendsButton);
            Controls.Add(trendShowcase);
            Controls.Add(clientDashboard);
            Name = "AdminDashboard";
            Text = "CineTrend Admin Dashboard";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientDashboard;
        private ListBox trendShowcase;
        private Button generateTrendsButton;
        private Label trendLabel;
        private Button generateUsersButton;
        private TextBox userAmount;
        private TextBox movieAmount;
        private Label amountLabel;
        private Label label1;
        private Label monthLabel;
        private TextBox monthAmount;
        private Label adminError;
        private Label label2;
        private TextBox trendMonthAmount;
    }
}