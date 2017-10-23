using System;
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
            try
            {
                var commandText = $"SELECT * FROM informationstabilitylabdatabase.allowedtable WHERE number > {TextBoxSqlParameter.Text}";
                var command = new MySqlCommand(commandText, Connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    ListViewRecords.Items.Clear();
                    while (reader.Read())
                    {
                        var id = reader.GetInt32("id");
                        var number = reader.GetInt32("number");
                        var name = reader.GetString("name");

                        ListViewRecords.Items.Add(new { id, number, name });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Confirmation", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
