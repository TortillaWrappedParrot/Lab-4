namespace Lab_4
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginButton = new Button();
            usernameText = new TextBox();
            UsernameLabel = new Label();
            passwordText = new TextBox();
            label2 = new Label();
            loginError = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(281, 231);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(249, 23);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // usernameText
            // 
            usernameText.Location = new Point(281, 124);
            usernameText.MaxLength = 50;
            usernameText.Name = "usernameText";
            usernameText.PlaceholderText = "Enter Username";
            usernameText.Size = new Size(249, 23);
            usernameText.TabIndex = 2;
            usernameText.TextChanged += textBox1_TextChanged;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(281, 106);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(60, 15);
            UsernameLabel.TabIndex = 1;
            UsernameLabel.Text = "Username";
            UsernameLabel.Click += label1_Click;
            // 
            // passwordText
            // 
            passwordText.Location = new Point(281, 173);
            passwordText.MaxLength = 50;
            passwordText.Name = "passwordText";
            passwordText.PasswordChar = '*';
            passwordText.PlaceholderText = "Enter Password";
            passwordText.Size = new Size(249, 23);
            passwordText.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 155);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // loginError
            // 
            loginError.AutoSize = true;
            loginError.ForeColor = Color.Crimson;
            loginError.Location = new Point(284, 213);
            loginError.Name = "loginError";
            loginError.Size = new Size(73, 15);
            loginError.TabIndex = 5;
            loginError.Text = "Error Display";
            loginError.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 328);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 7;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 450);
            Controls.Add(label1);
            Controls.Add(loginError);
            Controls.Add(passwordText);
            Controls.Add(label2);
            Controls.Add(usernameText);
            Controls.Add(UsernameLabel);
            Controls.Add(LoginButton);
            Name = "Login";
            Text = "CineTrend";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoginButton;
        private TextBox usernameText;
        private Label UsernameLabel;
        private TextBox passwordText;
        private Label label2;
        private Label loginError;
        private Label label1;
    }
}
