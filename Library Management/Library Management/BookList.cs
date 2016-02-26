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
    public partial class BookList : Form {
        public BookList() {
            InitializeComponent();
            displayBookData();
        }

        void displayBookData() {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            DataTable booktable = new DataTable();
            booktable = databaseadapter.getBooks();
            dataGridViewBooks.DataSource = booktable;
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            int row = dataGridViewBooks.CurrentCell.RowIndex;

            if (row == -1) {
                MessageBox.Show("Select an entry to delete.");
            }
            else {
                int id = Convert.ToInt32(dataGridViewBooks.Rows[row].Cells[0].Value.ToString());
                databaseadapter.deleteBook(id);
                displayBookData();
                MessageBox.Show("Deleted Successfully!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            int row = dataGridViewBooks.CurrentCell.RowIndex;

            if (row == -1) {
                MessageBox.Show("Select an entry to update.");
            }
            else {
                int id = Convert.ToInt32(dataGridViewBooks.Rows[row].Cells[0].Value.ToString());
                string name = dataGridViewBooks.Rows[row].Cells[1].Value.ToString();
                string author = dataGridViewBooks.Rows[row].Cells[2].Value.ToString();
                string publisher = dataGridViewBooks.Rows[row].Cells[3].Value.ToString();
                int price = Convert.ToInt32(dataGridViewBooks.Rows[row].Cells[2].Value.ToString());
                int quantity = Convert.ToInt32(dataGridViewBooks.Rows[row].Cells[2].Value.ToString());
                string readerclass = dataGridViewBooks.Rows[row].Cells[4].Value.ToString();

                databaseadapter.updateBook(id, name, author, publisher, price, quantity, readerclass);
                displayBookData();
                MessageBox.Show("Updated Successfully!");
            }
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
