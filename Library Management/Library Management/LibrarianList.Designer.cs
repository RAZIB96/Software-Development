namespace Library_Management {
    partial class LibrarianList {
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
            this.dataGridViewLibrarian = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrarian)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLibrarian
            // 
            this.dataGridViewLibrarian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLibrarian.Location = new System.Drawing.Point(12, 23);
            this.dataGridViewLibrarian.Name = "dataGridViewLibrarian";
            this.dataGridViewLibrarian.Size = new System.Drawing.Size(760, 421);
            this.dataGridViewLibrarian.TabIndex = 0;
            // 
            // LibrarianList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.dataGridViewLibrarian);
            this.Name = "LibrarianList";
            this.Text = "Librarian List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLibrarian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLibrarian;
    }
}