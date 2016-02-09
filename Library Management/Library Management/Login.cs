using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    public partial class Login : Form
    {
        public Login ()
        {
            InitializeComponent();
            textPassword.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLoginSubmit_Click(object sender, EventArgs e)
        {
            string email = textLibrarianEmail.Text;
            string password = textPassword.Text;
            DatabaseAdapter databaseadapter = new DatabaseAdapter();

            string message = databaseadapter.isLibrarian(email, password);

            if (message == "Success") {
                MessageBox.Show("Login Successful! Welcome!");
                AdminPanel adminpanel = new AdminPanel(this, email);
                adminpanel.Show();
            } else if (message == "Incorrect Password") {
                MessageBox.Show("Incorrect Password. Try Again!");
            } else {
                MessageBox.Show("No such account");
            }
        }

        private void Login_Load(object sender, EventArgs e) {

        }
    }
}
