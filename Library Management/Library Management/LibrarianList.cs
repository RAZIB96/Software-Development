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
    public partial class LibrarianList : Form {
        public LibrarianList() {
            InitializeComponent();
            displayLibrarianData();
            dataGridViewLibrarian.ReadOnly = true;
        }

        void displayLibrarianData() {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            DataTable librariantable = new DataTable();
            librariantable = databaseadapter.getLibrarian();
            dataGridViewLibrarian.DataSource = librariantable;
        }
    }
}
