using System.Configuration;
using System.Windows;
using MySql.Data.MySqlClient;

namespace InformationStabilityLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once InheritdocConsiderUsage
    public partial class MainWindow
    {
        private MySqlConnection Connection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Connect();
        }

        private void Connect()
        {
            try
            {
                Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["localhost"].ConnectionString);
                Connection.Open();
                LabelStatus.Content = "Connected successfully";
            }
            catch
            {
                Connection.Close();
                LabelStatus.Content = "Cannot connect";
            }
        }

        private void ButtonExecute_Click(object sender, RoutedEventArgs e)
        {
            var command = new MySqlCommand("SELECT * FROM informationstabilitylabdatabase.allowedtable;", Connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32("id");
                    var number = reader.GetInt32("number");
                    var name = reader.GetString("name");

                    ListViewRecords.Items.Add(new {id, number, name });
                }
            }
        }
    }
}
