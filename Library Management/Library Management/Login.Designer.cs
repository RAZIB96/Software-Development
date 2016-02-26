namespace Library_Management
{
    partial class Login
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
            this.labelLibrarianEmail = new System.Windows.Forms.Label();
            this.textLibrarianEmail = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLoginSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelLibrarianEmail
            // 
            this.labelLibrarianEmail.AutoSize = true;
            this.labelLibrarianEmail.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLibrarianEmail.Location = new System.Drawing.Point(69, 213);
            this.labelLibrarianEmail.Name = "labelLibrarianEmail";
            this.labelLibrarianEmail.Size = new System.Drawing.Size(54, 21);
            this.labelLibrarianEmail.TabIndex = 0;
            this.labelLibrarianEmail.Text = "Email";
            this.labelLibrarianEmail.Click += new System.EventHandler(this.label1_Click);
            // 
            // textLibrarianEmail
            // 
            this.textLibrarianEmail.Location = new System.Drawing.Point(211, 213);
            this.textLibrarianEmail.Name = "textLibrarianEmail";
            this.textLibrarianEmail.Size = new System.Drawing.Size(277, 20);
            this.textLibrarianEmail.TabIndex = 1;
            this.textLibrarianEmail.TextChanged += new System.EventHandler(this.textLibrarianEmail_TextChanged);
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(211, 258);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(277, 20);
            this.textPassword.TabIndex = 2;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.Location = new System.Drawing.Point(69, 257);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(89, 21);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // buttonLoginSubmit
            // 
            this.buttonLoginSubmit.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoginSubmit.Location = new System.Drawing.Point(286, 334);
            this.buttonLoginSubmit.Name = "buttonLoginSubmit";
            this.buttonLoginSubmit.Size = new System.Drawing.Size(100, 50);
            this.buttonLoginSubmit.TabIndex = 4;
            this.buttonLoginSubmit.Text = "Submit";
            this.buttonLoginSubmit.UseVisualStyleBackColor = true;
            this.buttonLoginSubmit.Click += new System.EventHandler(this.buttonLoginSubmit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management.Properties.Resources.loginbg;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonLoginSubmit);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textLibrarianEmail);
            this.Controls.Add(this.labelLibrarianEmail);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLibrarianEmail;
        private System.Windows.Forms.TextBox textLibrarianEmail;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLoginSubmit;
    }
}

