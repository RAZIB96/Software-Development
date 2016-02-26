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
    public partial class MemberList : Form {
        
        public MemberList() {
            InitializeComponent();
            displayMemberData();
        }

        void displayMemberData() {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            DataTable membertable = new DataTable();
            membertable = databaseadapter.getMember();
            dataGridViewMember.DataSource = membertable;
            databaseadapter = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            DatabaseAdapter databaseadapter = new DatabaseAdapter ();
            int row = dataGridViewMember.CurrentCell.RowIndex;

            if (row == -1) {
                MessageBox.Show("Select an entry to delete.");
            } else {
                int id = Convert.ToInt32(dataGridViewMember.Rows[row].Cells[0].Value.ToString());
                databaseadapter.deleteMember(id);
                displayMemberData();
                MessageBox.Show("Deleted Successfully!");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            DatabaseAdapter databaseadapter = new DatabaseAdapter();
            int row = dataGridViewMember.CurrentCell.RowIndex;

            if (row == -1) {
                MessageBox.Show("Select an entry to delete.");
            } else {
                int id = Convert.ToInt32(dataGridViewMember.Rows[row].Cells[0].Value.ToString());
                string name = dataGridViewMember.Rows[row].Cells[1].Value.ToString();
                int age = Convert.ToInt32(dataGridViewMember.Rows[row].Cells[2].Value.ToString());
                string contact = dataGridViewMember.Rows[row].Cells[3].Value.ToString();
                string email = dataGridViewMember.Rows[row].Cells[4].Value.ToString();

                databaseadapter.updateMember(id, name, age, contact, email);
                displayMemberData();
                MessageBox.Show("Updated Successfully!");
            }
        }
    }
}
