using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management {
    public partial class AdminPanel : Form {
        Login loginpage;
        bool adminprivilege;
        DatabaseAdapter databaseadapter = new DatabaseAdapter();

        public AdminPanel() {
            InitializeComponent();
        }

        public AdminPanel(Login loginpage, string email) {
            InitializeComponent();
            this.Show();
            this.loginpage = loginpage;
            this.loginpage.Visible = false;
            adminprivilege = databaseadapter.isAdmin(email);
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            Application.Exit();
        }

        private void buttonAddLibrarian_Click(object sender, EventArgs e) {
            if (!adminprivilege) {
                MessageBox.Show("Sorry! You cannot add new librarian account!");
            } else {
                AddLibrarian addlibrarian = new AddLibrarian();
                addlibrarian.ShowDialog();
            }
        }

        private void buttonAddMember_Click(object sender, EventArgs e) {
            AddMember addmember = new AddMember();
            addmember.ShowDialog();
        }

        private void buttonMemberList_Click(object sender, EventArgs e) {
            MemberList memberlist = new MemberList();
            memberlist.ShowDialog();
        }

        private void buttonLibrarianList_Click(object sender, EventArgs e) {
            LibrarianList librarianlist = new LibrarianList();
            librarianlist.ShowDialog();
        }

        private void buttonViewBooks_Click(object sender, EventArgs e) {
            BookList booklist = new BookList();
            booklist.ShowDialog();
        }

        private void buttonAddBook_Click(object sender, EventArgs e) {
            AddBook addbook = new AddBook();
            addbook.ShowDialog();
        }
    }
}
