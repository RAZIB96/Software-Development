using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management {
    public partial class AddMember : Form {
        Regex regexalpha = new Regex(@"[A-Za-z ]");
        Regex regexnumeric = new Regex(@"[0-9]");
        DatabaseAdapter databaseadapter = new DatabaseAdapter();
        public AddMember() {
            InitializeComponent();
        }

        bool isValidEmail(string email) {
            try {
                var test = new MailAddress(email);
                return true;
            }
            catch (FormatException ex) {
                return false;
            }
        }

        string checkValidEmail(string email, string message) {
            if (!isValidEmail(email)) {
                message += "Invalid Email.\n";
            } else if (databaseadapter.duplicateEmail(email)) {
                message += "Email allready exists. Try another.\n";
            }
            return message;
        }

        string checkValidContact(string contact, string message) {
            if (contact.Length == 0) {
                message += "Contact Field Empty\n";
            } else if (contact.Length != 11) {
                message += "Invalid Mobile Number.\n";
            } else if (databaseadapter.duplicateContact(contact)) {
                message += "Contact allready exists. Try another.\n";
            }
            return message;
        }

        string readerClassDetect(int age) {
            if (age < 18) return "minor";
            return "adult";
        }

        private void buttonRegister_Click(object sender, EventArgs e) {
            string name = textBoxName.Text;
            int age = Convert.ToInt32(textBoxAge.Text);
            string email = textBoxEmail.Text;
            string contact = textBoxContact.Text;            
            string message = "";

            message = checkValidEmail(email, message);
            message = checkValidContact(contact, message);

            if (message.Length > 0) {
                MessageBox.Show(message);
            } else {
                string readercatagory = readerClassDetect(age);
                databaseadapter.addMember(name, age, email, contact, readercatagory);
                this.Close();
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexalpha.Matches(textBoxName.Text);

            if (matches.Count != textBoxName.Text.Length) {
                textBoxName.Text = textBoxName.Text.Substring(0, textBoxName.Text.Length - 1);
                textBoxName.Focus();
                textBoxName.SelectionStart = textBoxName.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only alphabets are allowed", textBoxName, 50, 0, 1000);
            }
        }

        private void textBoxAge_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexnumeric.Matches(textBoxAge.Text);

            if (matches.Count != textBoxAge.Text.Length) {
                textBoxAge.Text = textBoxAge.Text.Substring(0, textBoxAge.Text.Length - 1);
                textBoxAge.Focus();
                textBoxAge.SelectionStart = textBoxAge.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only numerics are allowed", textBoxAge, 50, 0, 1000);
            }
        }

        private void textBoxContact_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexnumeric.Matches(textBoxContact.Text);

            if (matches.Count != textBoxContact.Text.Length) {
                textBoxContact.Text = textBoxContact.Text.Substring(0, textBoxContact.Text.Length - 1);
                textBoxContact.Focus();
                textBoxContact.SelectionStart = textBoxContact.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only numerics are allowed", textBoxContact, 50, 0, 1000);
            }
        }
    }
}
