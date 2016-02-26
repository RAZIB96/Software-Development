using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management {
    public partial class AddBook : Form {
        Regex regexalpha = new Regex(@"[A-Za-z ]");
        Regex regexnumeric = new Regex(@"[0-9]");
        DatabaseAdapter databaseadapter = new DatabaseAdapter();
        public AddBook() {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            string bookname = textBoxBookName.Text;
            string author = textBoxAuthor.Text;
            string publisher = textBoxPublisher.Text;
            int price = Convert.ToInt32(textBoxPrice.Text);
            int quantity = Convert.ToInt32(textBoxQuantity.Text);
            string bookclass = textBoxClass.Text;
            string message = "";

            if (message.Length > 0) {
                MessageBox.Show(message);
            }
            else {
                databaseadapter.setBooks(bookname, author, publisher, quantity, price, bookclass);
                this.Close();
            }
        }

        private void textBoxBookName_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexalpha.Matches(textBoxBookName.Text);

            if (matches.Count != textBoxBookName.Text.Length) {
                textBoxBookName.Text = textBoxBookName.Text.Substring(0, textBoxBookName.Text.Length - 1);
                textBoxBookName.Focus();
                textBoxBookName.SelectionStart = textBoxBookName.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only alphabets are allowed", textBoxBookName, 50, 0, 1000);
            }
        }

        private void textBoxAuthor_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexalpha.Matches(textBoxAuthor.Text);

            if (matches.Count != textBoxAuthor.Text.Length) {
                textBoxAuthor.Text = textBoxAuthor.Text.Substring(0, textBoxAuthor.Text.Length - 1);
                textBoxAuthor.Focus();
                textBoxAuthor.SelectionStart = textBoxAuthor.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only alphabets are allowed", textBoxAuthor, 50, 0, 1000);
            }
        }

        private void textBoxPublisher_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexalpha.Matches(textBoxPublisher.Text);

            if (matches.Count != textBoxPublisher.Text.Length) {
                textBoxPublisher.Text = textBoxPublisher.Text.Substring(0, textBoxPublisher.Text.Length - 1);
                textBoxPublisher.Focus();
                textBoxPublisher.SelectionStart = textBoxPublisher.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only alphabets are allowed", textBoxPublisher, 50, 0, 1000);
            }
        }

        private void textBoxPrice_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexnumeric.Matches(textBoxPrice.Text);

            if (matches.Count != textBoxPrice.Text.Length) {
                textBoxPrice.Text = textBoxPrice.Text.Substring(0, textBoxPrice.Text.Length - 1);
                textBoxPrice.Focus();
                textBoxPrice.SelectionStart = textBoxPrice.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only numerics are allowed", textBoxPrice, 50, 0, 1000);
            }
        }

        private void textBoxQuantity_TextChanged(object sender, EventArgs e) {
            MatchCollection matches = regexnumeric.Matches(textBoxQuantity.Text);

            if (matches.Count != textBoxQuantity.Text.Length) {
                textBoxQuantity.Text = textBoxQuantity.Text.Substring(0, textBoxQuantity.Text.Length - 1);
                textBoxQuantity.Focus();
                textBoxQuantity.SelectionStart = textBoxQuantity.Text.Length;

                ToolTip tooltip = new ToolTip();
                tooltip.Show("Only numerics are allowed", textBoxQuantity, 50, 0, 1000);
            }
        }
    }
}
