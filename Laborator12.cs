//În cadrul unei aplicații ASP.NET, se dorește implementarea unei pagini de înregistrare a utilizatorilor. Utilizatorii trebuie să completeze un formular cu următoarele câmpuri: nume de utilizator, adresă de email și parolă. Problema constă în validarea datelor introduse de utilizatori și în stocarea acestora într-o bază de date.

//Definește o clasă User care să reprezinte un utilizator al aplicației. Această clasă ar trebui să conțină proprietățile pentru numele de utilizator, adresa de email și parolă.

//Implementează o pagină de înregistrare Register.aspx care să conțină un formular cu câmpurile pentru numele de utilizator, adresa de email și parolă.

//Folosește ASP.NET pentru a valida datele introduse de utilizator în formular:

//Asigură-te că toate câmpurile sunt completate.
//Verifică dacă adresa de email este validă.
//Aplică o regulă pentru parolă (de exemplu, parola trebuie să aibă cel puțin 8 caractere și să conțină cel puțin o literă majusculă, o literă minusculă și un număr).
//Implementează o conexiune cu o bază de date SQL Server folosind Entity Framework sau ADO.NET pentru a stoca datele utilizatorilor într-o tabelă Users.

//După validarea cu succes a datelor, salvează noul utilizator în baza de date.

//Dacă înregistrarea este reușită, afișează un mesaj de succes pe pagina Register.aspx. Dacă apare o eroare în timpul procesului de înregistrare, afișează un mesaj corespunzător de eroare.


using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace UserRegistration
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            if (!IsValidEmail(email))
            {
                lblMessage.Text = "Invalid email address.";
                return;
            }

            if (!IsValidPassword(password))
            {
                lblMessage.Text = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, and one digit.";
                return;
            }

            string connectionString = "your_connection_string_here";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Registration successful!";
                    }
                    else
                    {
                        lblMessage.Text = "Registration failed. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "An error occurred: " + ex.Message;
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }
    }
}
