namespace Library_Management {
    partial class AddLibrarian {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.labelName = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelAge = new System.Windows.Forms.Label();
            this.labelContact = new System.Windows.Forms.Label();
            this.labelConfirmPass = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxContact = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(61, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(61, 123);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 1;
            this.labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(61, 205);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(61, 80);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(26, 13);
            this.labelAge.TabIndex = 3;
            this.labelAge.Text = "Age";
            this.labelAge.Click += new System.EventHandler(this.label4_Click);
            // 
            // labelContact
            // 
            this.labelContact.AutoSize = true;
            this.labelContact.Location = new System.Drawing.Point(61, 166);
            this.labelContact.Name = "labelContact";
            this.labelContact.Size = new System.Drawing.Size(44, 13);
            this.labelContact.TabIndex = 4;
            this.labelContact.Text = "Contact";
            // 
            // labelConfirmPass
            // 
            this.labelConfirmPass.AutoSize = true;
            this.labelConfirmPass.Location = new System.Drawing.Point(61, 249);
            this.labelConfirmPass.Name = "labelConfirmPass";
            this.labelConfirmPass.Size = new System.Drawing.Size(91, 13);
            this.labelConfirmPass.TabIndex = 5;
            this.labelConfirmPass.Text = "Confirm Password";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(169, 42);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(204, 20);
            this.textBoxName.TabIndex = 6;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // textBoxContact
            // 
            this.textBoxContact.Location = new System.Drawing.Point(169, 166);
            this.textBoxContact.Name = "textBoxContact";
            this.textBoxContact.Size = new System.Drawing.Size(204, 20);
            this.textBoxContact.TabIndex = 7;
            this.textBoxContact.TextChanged += new System.EventHandler(this.textBoxContact_TextChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(169, 123);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(204, 20);
            this.textBoxEmail.TabIndex = 8;
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(169, 80);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.Size = new System.Drawing.Size(204, 20);
            this.textBoxAge.TabIndex = 9;
            this.textBoxAge.TextChanged += new System.EventHandler(this.textBoxAge_TextChanged);
            // 
            // textBoxConfirmPass
            // 
            this.textBoxConfirmPass.Location = new System.Drawing.Point(169, 242);
            this.textBoxConfirmPass.Name = "textBoxConfirmPass";
            this.textBoxConfirmPass.Size = new System.Drawing.Size(204, 20);
            this.textBoxConfirmPass.TabIndex = 10;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(169, 205);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(204, 20);
            this.textBoxPassword.TabIndex = 11;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(169, 288);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(54, 17);
            this.radioButtonAdmin.TabIndex = 12;
            this.radioButtonAdmin.TabStop = true;
            this.radioButtonAdmin.Text = "Admin";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(169, 371);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(100, 30);
            this.buttonRegister.TabIndex = 13;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // AddLibrarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 519);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.radioButtonAdmin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxConfirmPass);
            this.Controls.Add(this.textBoxAge);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxContact);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelConfirmPass);
            this.Controls.Add(this.labelContact);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelName);
            this.Name = "AddLibrarian";
            this.Text = "AddLibrarian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.Label labelContact;
        private System.Windows.Forms.Label labelConfirmPass;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxContact;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.TextBox textBoxConfirmPass;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.Button buttonRegister;
    }
}