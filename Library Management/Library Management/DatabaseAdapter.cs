using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management
{
    class DatabaseAdapter
    {
        string connectionString;
        SqlConnection connection;

        public DatabaseAdapter () {
            connectionString = @"Data Source=techboy\SQLExpress;Initial Catalog=Library;Integrated Security=True;Pooling=False";
            connection = new SqlConnection (connectionString);
        }

        public string isLibrarian (string email, string password) {
            string query = "SELECT email, password FROM Librarian WHERE email = @email";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.Parameters.AddWithValue("@email", email);
            string message="";

            try {
                connection.Open ();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                if (sqldatareader.HasRows) {
                    if (sqldatareader ["password"].ToString() != password) message += "Incorrect Password";
                    else message += "Success";
                } else {
                    message += "Account not found";
                }
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close ();
            }

            return message;
        }

        public bool isAdmin(string email) {
            string query = @"SELECT admin FROM LIBRARIAN WHERE email = @email";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            bool isadmin = false;

            sqlcommand.Parameters.AddWithValue("@email", email);

            try {
                connection.Open();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                if (sqldatareader.HasRows) {
                    isadmin = (bool) sqldatareader["admin"];
                }
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close();
            }

            return isadmin;
        }

        public bool duplicateEmail(string email) {
            string querylibrarian = @"SELECT * FROM Librarian WHERE email = @email";
            string querymember = @"SELECT * FROM Member WHERE email = @email";
            SqlCommand sqlcommandlibrarian = new SqlCommand(querylibrarian, connection);
            SqlCommand sqlcommandmember = new SqlCommand(querymember, connection);

            bool duplicate = false;

            sqlcommandlibrarian.Parameters.AddWithValue("@email", email);
            sqlcommandmember.Parameters.AddWithValue("@email", email);

            try {
                connection.Open();
                SqlDataReader sqldatareaderlibrarian = sqlcommandlibrarian.ExecuteReader();
                SqlDataReader sqldatareadermember = sqlcommandmember.ExecuteReader();
                duplicate = (sqldatareaderlibrarian.HasRows || sqldatareadermember.HasRows);
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close();
            }

            return duplicate;
        }

        public bool duplicateContact(string contact) {
            string querylibrarian = @"SELECT * FROM Librarian WHERE contact = @contact";
            string querymember = @"SELECT * FROM Member WHERE contact = @contact";
            SqlCommand sqlcommandlibrarian = new SqlCommand(querylibrarian, connection);
            SqlCommand sqlcommandmember = new SqlCommand(querymember, connection);

            bool duplicate = false;

            sqlcommandlibrarian.Parameters.AddWithValue("@contact", contact);
            sqlcommandmember.Parameters.AddWithValue("@contact", contact);

            try {
                connection.Open();
                SqlDataReader sqldatareaderlibrarian = sqlcommandlibrarian.ExecuteReader();
                SqlDataReader sqldatareadermember = sqlcommandmember.ExecuteReader();
                duplicate = (sqldatareaderlibrarian.HasRows || sqldatareadermember.HasRows);
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close();
            }

            return duplicate;
        }

        public void addLibrarian(string name, int age, string email, string contact, string password, bool adminprivilege) {
            string query = @"INSERT INTO Librarian (full_name, age, contact, email, password, admin)";
            query += "VALUES (@name, @age, @contact, @email, @password, @adminprivilege)";
            SqlCommand sqlcommand = new SqlCommand(query, connection);

            sqlcommand.Parameters.AddWithValue("@name", name);
            sqlcommand.Parameters.AddWithValue("@age", age);
            sqlcommand.Parameters.AddWithValue("@email", email);
            sqlcommand.Parameters.AddWithValue("@contact", contact);
            sqlcommand.Parameters.AddWithValue("@password", password);
            sqlcommand.Parameters.AddWithValue("@adminprivilege", adminprivilege);

            try {
                connection.Open();
                int rowseffected = sqlcommand.ExecuteNonQuery();
                if (rowseffected > 0) MessageBox.Show("Success");
                else MessageBox.Show("Failed");
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close();
            }
        }

        public void addMember(string name, int age, string email, string contact, string readercatagory) {
            string query = @"INSERT INTO Member (full_name, age, contact, email, reader_catagory)";
            query += "VALUES (@name, @age, @contact, @email, @password, @readercatagory)";
            SqlCommand sqlcommand = new SqlCommand(query, connection);

            sqlcommand.Parameters.AddWithValue("@name", name);
            sqlcommand.Parameters.AddWithValue("@age", age);
            sqlcommand.Parameters.AddWithValue("@email", email);
            sqlcommand.Parameters.AddWithValue("@contact", contact);
            sqlcommand.Parameters.AddWithValue("@readercatagory", readercatagory);

            try {
                connection.Open();
                int rowseffected = sqlcommand.ExecuteNonQuery();
                if (rowseffected > 0) MessageBox.Show("Success");
                else MessageBox.Show("Failed");
            } catch (SqlException se) {
                MessageBox.Show(se.ToString());
            } finally {
                connection.Close();
            }
        }
    }
}
