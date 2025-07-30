using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ConsoleDapper.Database
{
    public static class DBUtilities
    {
        public static void Init()
        {
            var connectionString = "Server=a205822-ogt-rds-sql-pre.cvf1wemrnbe3.us-east-1.rds.amazonaws.com;Initial Catalog=IP_2032_QA;Password=SGzUtVvu8wfwJINfnG3ufMYSg;User Id=IP_App_GTM;TrustServerCertificate=True";
            // Connect to the database 
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    // Create a query that retrieves all books with an author name of "John Smith"    
                    var sql = "SELECT * FROM tmgRVCMethodInfoHist";

                    // Use the Query method to execute the query and return a list of objects    
                    var books = connection.Query<RVCMethodInfo>(sql, new { authorName = "John Smith" }).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static async Task<bool> InitializeDBAsync()
        {
            var connectionString = "";// app.Configuration.GetConnectionString("DefaultConnection");

            var createSQL = @"CREATE TABLE IF NOT EXISTS Customer (
            ID INTEGER PRIMARY KEY AUTOINCREMENT,
            FirstName TEXT,
            LastName TEXT,
            DOB DATE,
            Email TEXT
        );";

            var insertSQL = @"
           INSERT INTO Customer (FirstName, LastName, DOB, Email)
           VALUES 
                ('Tony', 'Stark', '1970-05-29', 'tony.stark@example.com'),
                ('Bruce', 'Wayne', '1972-11-11', 'bruce.wayne@example.com'),
                ('Peter', 'Parker', '1995-08-10', 'peter.parker@example.com'),
                ('Diana', 'Prince', '1985-04-02', 'diana.prince@example.com'),
                ('Clark', 'Kent', '1980-07-18', 'clark.kent@example.com'),
                ('Natasha', 'Romanoff', '1983-06-25', 'natasha.romanoff@example.com'),
                ('Wade', 'Wilson', '1977-02-19', 'wade.wilson@example.com'),
                ('Hal', 'Jordan', '1988-09-05', 'hal.jordan@example.com'),
                ('Steve', 'Rogers', '1920-07-04', 'steve.rogers@example.com'),
                ('Selina', 'Kyle', '1982-12-08', 'selina.kyle@example.com');";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                await connection.ExecuteAsync(createSQL, transaction: transaction);

                // Check if the Customer table exists
                var tableExists = await connection.QueryFirstOrDefaultAsync<int>(
                    "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Customer';", transaction: transaction);

                if (tableExists > 0)
                {
                    // Table exists and populated, no need to seed database again
                    return true;
                }

                await connection.ExecuteAsync(insertSQL, transaction: transaction);

                // Commit the transaction if everything is successful
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // An error occurred, rollback the transaction
                transaction.Rollback();
                connection.Close();
                return false;
            }
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }

    public class RVCMethodInfo
    {
        public int PartnerID { get; set; }
        public DateTime EffDate { get; set; }
        public string Username { get; set; }
        public string Agreement { get; set; }
        public string RVCMethod { get; set; }
    }
}
