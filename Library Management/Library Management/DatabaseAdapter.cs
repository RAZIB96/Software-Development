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
            string query = "SELECT email, password FROM Librarian WHERE email='" + email +"'";
            SqlDataAdapter sdalibrarian = new SqlDataAdapter (query, connection);
            DataTable dtlibrarian = new DataTable ();

            try {
                connection.Open ();
                sdalibrarian.Fill (dtlibrarian);
            } catch (SqlException se) {
                Console.WriteLine (se.ToString ());
            } finally {
                connection.Close ();
            }

            int rowcount = dtlibrarian.Rows.Count;
            if (rowcount == 0) return "Account not found";
            else {
                if (dtlibrarian.Rows [0].Field <string> ("password") == password) return "Success";
                return "Incorrect Password";
            }
        }

        public bool isAdmin(string email) {
            string query = @"SELECT admin FROM LIBRARIAN WHERE email = @email";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            bool isadmin = false;

            sqlcommand.Parameters.AddWithValue("@email", email);

            try {
                connection.Open();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                isadmin = sqldatareader.GetBoolean(0);
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }

            return isadmin;
        }

        public bool duplicateEmail(string email) {
            string query = @"SELECT * FROM LIBRARIAN WHERE email = @email";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            bool duplicate = false;

            sqlcommand.Parameters.AddWithValue("@email", email);

            try {
                connection.Open();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                duplicate = sqldatareader.HasRows;
            }
            catch (SqlException se) {
                MessageBox.Show(se.ToString());
            }
            finally {
                connection.Close();
            }

            return duplicate;
        }

        public bool duplicateContact(string contact) {
            string query = @"SELECT * FROM LIBRARIAN WHERE contact = @contact";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            bool duplicate = false;

            sqlcommand.Parameters.AddWithValue("@contact", contact);

            try {
                connection.Open();
                SqlDataReader sqldatareader = sqlcommand.ExecuteReader();
                duplicate = sqldatareader.HasRows;
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
    }
}
