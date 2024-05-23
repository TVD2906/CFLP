//Ai primit sarcina de a dezvolta o aplicație simplă pentru gestionarea bazei de date a unei biblioteci. Baza de date trebuie să conțină două tabele: una pentru cărți și una pentru împrumuturi.

//Tabelul "Books" trebuie să aibă următoarele coloane:

//Id (cheie primară)
//Title (titlul cărții)
//Author (autorul cărții)
//Quantity (cantitatea disponibilă în stoc)

//Tabelul "Loans" trebuie să aibă următoarele coloane:

//Id (cheie primară)
//BookId (cheie externă către tabela "Books", indicând cărțile împrumutate)
//BorrowerName (numele împrumutătorului)
//StartDate (data începutului împrumutului)
//ReturnDate (data la care trebuie returnată cartea)

//Sarcini:

//Implementează o metodă pentru a adăuga o carte în baza de date.
//Implementează o metodă pentru a înregistra un împrumut în baza de date.
//Implementează o metodă pentru a afișa toate cărțile disponibile în baza de date.
//Implementează o metodă pentru a afișa toate împrumuturile active din baza de date.

using System;
using System.Data.SqlClient;

class LibraryDatabaseManager
{
    private string connectionString;

    public LibraryDatabaseManager(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void AddBook(string title, string author, int quantity)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Books (Title, Author, Quantity) VALUES (@Title, @Author, @Quantity)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);
            command.Parameters.AddWithValue("@Author", author);
            command.Parameters.AddWithValue("@Quantity", quantity);
            command.ExecuteNonQuery();
            Console.WriteLine("Book added successfully.");
        }
    }

    public void RegisterLoan(int bookId, string borrowerName, DateTime startDate, DateTime returnDate)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Loans (BookId, BorrowerName, StartDate, ReturnDate) VALUES (@BookId, @BorrowerName, @StartDate, @ReturnDate)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BookId", bookId);
            command.Parameters.AddWithValue("@BorrowerName", borrowerName);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@ReturnDate", returnDate);
            command.ExecuteNonQuery();
            Console.WriteLine("Loan registered successfully.");
        }
    }

    public void DisplayAvailableBooks()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Books WHERE Quantity > 0";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Available Books:");
            Console.WriteLine("Id\tTitle\tAuthor\tQuantity");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}\t{reader["Title"]}\t{reader["Author"]}\t{reader["Quantity"]}");
            }
            reader.Close();
        }
    }

    public void DisplayActiveLoans()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT Loans.Id, Books.Title, Loans.BorrowerName, Loans.StartDate, Loans.ReturnDate FROM Loans INNER JOIN Books ON Loans.BookId = Books.Id";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Active Loans:");
            Console.WriteLine("Id\tTitle\tBorrower\tStartDate\tReturnDate");
            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]}\t{reader["Title"]}\t{reader["BorrowerName"]}\t{reader["StartDate"]}\t{reader["ReturnDate"]}");
            }
            reader.Close();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Your_Connection_String";
        LibraryDatabaseManager manager = new LibraryDatabaseManager(connectionString);

        manager.AddBook("Dune", "Frank Herbert", 5);
        manager.RegisterLoan(1, "John Doe", DateTime.Now, DateTime.Now.AddDays(14));
        manager.DisplayAvailableBooks();
        manager.DisplayActiveLoans();
    }
}
