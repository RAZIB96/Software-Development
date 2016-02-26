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
            connectionString = @"Data Source=techboy\SQLExpress;Initial Catalog=Library;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;";
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
                if (sqldatareader.Read()) {
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
                if (sqldatareader.Read()) {
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

        public void setLibrarian(string name, int age, string email, string contact, string password, bool adminprivilege) {
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

        public DataTable getLibrarian() {
            string query = @"SELECT * FROM Librarian";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            try {
                connection.Open();
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(datatable);
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }

            return datatable;
        }

        
        public void setBooks(string bookname, string author, string publisher, int quantity, int price, string bookclass) {
            string query = @"INSERT INTO Books (book_name, author, publisher, price, quantity, class)";
            query += "VALUES (@bookname, @author, @publisher, @price, @quantity, @bookclass)";
            SqlCommand sqlcommand = new SqlCommand(query, connection);

            sqlcommand.Parameters.AddWithValue("@bookname", bookname);
            sqlcommand.Parameters.AddWithValue("@author", author);
            sqlcommand.Parameters.AddWithValue("@publisher", publisher);
            sqlcommand.Parameters.AddWithValue("@price", price);
            sqlcommand.Parameters.AddWithValue("@quantity", quantity);
            sqlcommand.Parameters.AddWithValue("@bookclass", bookclass);

            try {
                connection.Open();
                int rowseffected = sqlcommand.ExecuteNonQuery();
                if (rowseffected > 0) MessageBox.Show("Success");
                else MessageBox.Show("Failed");
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }

        public DataTable getBooks() {
            string query = @"SELECT * FROM Books";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            try {
                connection.Open();
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(datatable);
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }

            return datatable;
        }

        public void updateBook(int id, string name, string author, string publisher, int price, int quantity, string readerclass) {
            string query = @"UPDATE Books SET book_name = @name, author = @author, publisher = @publisher, price = @price, quantity = @quantity, class = @readerclass WHERE book_id = @id";
            SqlCommand sqlcommand = new SqlCommand(query, connection);

            sqlcommand.Parameters.AddWithValue("@id", id);
            sqlcommand.Parameters.AddWithValue("@name", name);
            sqlcommand.Parameters.AddWithValue("@author", author);
            sqlcommand.Parameters.AddWithValue("@publisher", publisher);
            sqlcommand.Parameters.AddWithValue("@price", price);
            sqlcommand.Parameters.AddWithValue("@quantity", quantity);
            sqlcommand.Parameters.AddWithValue("@readerclass", readerclass);

            try {
                connection.Open();
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }

        public void deleteBook(int id) {
            string query = @"DELETE FROM Books WHERE book_id = @id";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.Parameters.AddWithValue("@id", id);

            try {
                connection.Open();
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }


        public void setMember(string name, int age, string email, string contact, string readercatagory) {
            string query = @"INSERT INTO Member (full_name, age, contact, email, reader_catagory)";
            query += "VALUES (@name, @age, @contact, @email, @readercatagory)";
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
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }

        public DataTable getMember() {
            string query = @"SELECT * FROM Member";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            DataTable datatable = new DataTable();
            try {
                connection.Open();
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlcommand);
                sqldataadapter.Fill(datatable);
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }

            return datatable;
        }

        public void updateMember(int id, string name, int age, string contact, string email) {
            string readercatagory = "adult";
            if (age < 18) readercatagory = "minor";

            string query = @"UPDATE Member SET full_name = @name, age = @age, contact = @contact, email = @email, reader_catagory = @catagory WHERE Member_Id = @id";
            SqlCommand sqlcommand = new SqlCommand(query, connection);

            sqlcommand.Parameters.AddWithValue("@id", id);
            sqlcommand.Parameters.AddWithValue("@name", name);
            sqlcommand.Parameters.AddWithValue("@age", age);
            sqlcommand.Parameters.AddWithValue("@contact", contact);
            sqlcommand.Parameters.AddWithValue("@email", email);
            sqlcommand.Parameters.AddWithValue("@catagory", readercatagory);

            try {
                connection.Open();
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }

        public void deleteMember(int id) {
            string query = @"DELETE FROM Member WHERE Member_Id = @id";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.Parameters.AddWithValue("@id", id);

            try {
                connection.Open();
                sqlcommand.ExecuteNonQuery();
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }
        }
    }
}
