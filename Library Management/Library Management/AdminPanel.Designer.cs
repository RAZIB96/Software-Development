namespace Library_Management {
    partial class AdminPanel {
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
            this.buttonAddLibrarian = new System.Windows.Forms.Button();
            this.buttonAddMember = new System.Windows.Forms.Button();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.buttonLog = new System.Windows.Forms.Button();
            this.buttonLibrarianList = new System.Windows.Forms.Button();
            this.buttonIssueReturnBook = new System.Windows.Forms.Button();
            this.buttonViewBooks = new System.Windows.Forms.Button();
            this.buttonMemberList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddLibrarian
            // 
            this.buttonAddLibrarian.Location = new System.Drawing.Point(340, 499);
            this.buttonAddLibrarian.Name = "buttonAddLibrarian";
            this.buttonAddLibrarian.Size = new System.Drawing.Size(100, 50);
            this.buttonAddLibrarian.TabIndex = 0;
            this.buttonAddLibrarian.Text = "Add Librarian";
            this.buttonAddLibrarian.UseVisualStyleBackColor = true;
            this.buttonAddLibrarian.Click += new System.EventHandler(this.buttonAddLibrarian_Click);
            // 
            // buttonAddMember
            // 
            this.buttonAddMember.Location = new System.Drawing.Point(340, 24);
            this.buttonAddMember.Name = "buttonAddMember";
            this.buttonAddMember.Size = new System.Drawing.Size(100, 50);
            this.buttonAddMember.TabIndex = 1;
            this.buttonAddMember.Text = "Add Member";
            this.buttonAddMember.UseVisualStyleBackColor = true;
            this.buttonAddMember.Click += new System.EventHandler(this.buttonAddMember_Click);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(644, 151);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(100, 50);
            this.buttonAddBook.TabIndex = 2;
            this.buttonAddBook.Text = "Add Book";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // buttonLog
            // 
            this.buttonLog.Location = new System.Drawing.Point(72, 151);
            this.buttonLog.Name = "buttonLog";
            this.buttonLog.Size = new System.Drawing.Size(100, 50);
            this.buttonLog.TabIndex = 3;
            this.buttonLog.Text = "Check Log";
            this.buttonLog.UseVisualStyleBackColor = true;
            // 
            // buttonLibrarianList
            // 
            this.buttonLibrarianList.Location = new System.Drawing.Point(72, 402);
            this.buttonLibrarianList.Name = "buttonLibrarianList";
            this.buttonLibrarianList.Size = new System.Drawing.Size(100, 50);
            this.buttonLibrarianList.TabIndex = 4;
            this.buttonLibrarianList.Text = "Librarian List";
            this.buttonLibrarianList.UseVisualStyleBackColor = true;
            this.buttonLibrarianList.Click += new System.EventHandler(this.buttonLibrarianList_Click);
            // 
            // buttonIssueReturnBook
            // 
            this.buttonIssueReturnBook.Location = new System.Drawing.Point(644, 274);
            this.buttonIssueReturnBook.Name = "buttonIssueReturnBook";
            this.buttonIssueReturnBook.Size = new System.Drawing.Size(100, 50);
            this.buttonIssueReturnBook.TabIndex = 5;
            this.buttonIssueReturnBook.Text = "Issue/Return Book";
            this.buttonIssueReturnBook.UseVisualStyleBackColor = true;
            // 
            // buttonViewBooks
            // 
            this.buttonViewBooks.Location = new System.Drawing.Point(644, 402);
            this.buttonViewBooks.Name = "buttonViewBooks";
            this.buttonViewBooks.Size = new System.Drawing.Size(100, 50);
            this.buttonViewBooks.TabIndex = 6;
            this.buttonViewBooks.Text = "View Books";
            this.buttonViewBooks.UseVisualStyleBackColor = true;
            this.buttonViewBooks.Click += new System.EventHandler(this.buttonViewBooks_Click);
            // 
            // buttonMemberList
            // 
            this.buttonMemberList.Location = new System.Drawing.Point(72, 274);
            this.buttonMemberList.Name = "buttonMemberList";
            this.buttonMemberList.Size = new System.Drawing.Size(100, 50);
            this.buttonMemberList.TabIndex = 7;
            this.buttonMemberList.Text = "Member List";
            this.buttonMemberList.UseVisualStyleBackColor = true;
            this.buttonMemberList.Click += new System.EventHandler(this.buttonMemberList_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Library_Management.Properties.Resources.adminpanelbg;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.buttonMemberList);
            this.Controls.Add(this.buttonViewBooks);
            this.Controls.Add(this.buttonIssueReturnBook);
            this.Controls.Add(this.buttonLibrarianList);
            this.Controls.Add(this.buttonLog);
            this.Controls.Add(this.buttonAddBook);
            this.Controls.Add(this.buttonAddMember);
            this.Controls.Add(this.buttonAddLibrarian);
            this.Name = "AdminPanel";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddLibrarian;
        private System.Windows.Forms.Button buttonAddMember;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Button buttonLog;
        private System.Windows.Forms.Button buttonLibrarianList;
        private System.Windows.Forms.Button buttonIssueReturnBook;
        private System.Windows.Forms.Button buttonViewBooks;
        private System.Windows.Forms.Button buttonMemberList;
    }
}