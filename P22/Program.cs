// See https://aka.ms/new-console-template for more information
using System.Data;

Console.WriteLine("Hello, World!");

// NET 2.0,3.0,4.0,4.8- несумісні (5.0,6.0,7.0,8.0)
// Net Core 1.0,2.0,3.0,3.1,3.2 (5.0,6.0,7.0,8.0)

using (IDbConnection dbConnection = new System.Data.SQLite.SQLiteConnection("DataSource=C:/Users/serhi/.databases/cafe.db"))
{
    dbConnection.Open();
    dbConnection.Close();

}
