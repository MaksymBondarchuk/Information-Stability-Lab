using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows;

namespace InformationStabilityLab
{
    /// <inheritdoc cref="xoxo" />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
    }
}
