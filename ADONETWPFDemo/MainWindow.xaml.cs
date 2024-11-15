using Cafe.Models;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADONETWPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> waiters;
        public MainWindow()
        {
            InitializeComponent();
            waiters = new List<User>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (IDbConnection dbConnection = new System.Data.SQLite.SQLiteConnection("DataSource=C:/Users/serhi/.databases/itstep/cafe.db"))
            {
                dbConnection.Open();
                waiters.Clear();

                waiters.Add(new User { Id = 1, Name = "Tester", Password = "******", Birthday = new DateTime(2000, 5, 1) });
                dg.ItemsSource = waiters;

                var dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = "select * from Waiters";
                var dbReader = dbCommand.ExecuteReader();
                while (dbReader.Read())
                {
                    Console.WriteLine($"{dbReader.GetInt32(0)} {dbReader.GetString(1)} {dbReader.GetString(2)} {dbReader.GetString(3)}");
                }

                dbConnection.Close();

            }

        }
    }
}